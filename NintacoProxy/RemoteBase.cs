using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Nintaco
{
    public delegate int AccessPointListener(int accessPointType, int address, int value);

    public delegate void ActivateListener();

    public delegate void ControllersListener();

    public delegate void DeactivateListener();

    public delegate void FrameListener();

    public delegate void ScanlineListener(int scanline);

    public delegate void ScanlineCycleListener(int scanline, int scanlineCycle, int address, bool rendering);

    public delegate void SpriteZeroListener(int scanline, int scanlineCycle);

    public delegate void StatusListener(string message);

    public delegate void StopListener();

    public abstract class RemoteBase
    {
        private readonly int[] EVENT_TYPES = {
      EventTypes.Activate,
      EventTypes.Deactivate,
      EventTypes.Stop,
      EventTypes.Access,
      EventTypes.Controllers,
      EventTypes.Frame,
      EventTypes.Scanline,
      EventTypes.ScanlineCycle,
      EventTypes.SpriteZero,
      EventTypes.Status,
    };

        public const int EVENT_REQUEST = 0xFF;
        public const int EVENT_RESPONSE = 0xFE;
        public const int HEARTBEAT = 0xFD;
        public const int READY = 0xFC;
        public const int RETRY_MILLIS = 1000;

        // listener -> listenerID
        protected readonly Dictionary<object, int> listenerIDs
            = new Dictionary<object, int>(new IdentityComparator());

        // eventType -> listenerID -> listenerObject(listener)
        protected readonly Dictionary<int, Dictionary<int, object>> listenerObjects
            = new Dictionary<int, Dictionary<int, object>>();

        protected string _host;
        protected int _port;
        protected DataStream _stream;
        protected int _nextID;
        protected bool _running;

        public RemoteBase(string host, int port)
        {
            this._host = host;
            this._port = port;
            foreach (int eventType in EVENT_TYPES)
            {
                listenerObjects[eventType] = new Dictionary<int, object>();
            }
        }

        public void Run()
        {
            if (_running)
            {
                return;
            }
            else
            {
                _running = true;
            }
            while (true)
            {
                FireStatusChanged("Connecting to {0}:{1}...", _host, _port);
                TcpClient socket;
                try
                {
                    socket = new TcpClient(_host, _port);
                    BufferedStream bs = new BufferedStream(socket.GetStream());
                    _stream = new DataStream(new BinaryWriter(bs), new BinaryReader(bs));
                }
                catch
                {
                    FireStatusChanged("Failed to establish connection.");
                }
                if (_stream != null)
                {
                    try
                    {
                        FireStatusChanged("Connection established.");
                        SendListeners();
                        SendReady();
                        while (true)
                        {
                            ProbeEvents();
                        }
                    }
                    catch
                    {
                        FireDeactivated();
                        FireStatusChanged("Disconnected.");
                    }
                    finally
                    {
                        _stream = null;
                    }
                }
                Thread.Sleep(RETRY_MILLIS);
            }
        }

        protected void FireDeactivated()
        {
            foreach (object obj in new List<object>(listenerObjects[EventTypes
                .Deactivate].Values))
            {
                ((DeactivateListener)obj)();
            }
        }

        protected void FireStatusChanged(string message, params object[] ps)
        {
            string msg = String.Format(message, ps);
            foreach (object obj in new List<object>(listenerObjects[EventTypes.Status]
                .Values))
            {
                ((StatusListener)obj)(msg);
            }
        }

        protected void SendReady()
        {
            if (_stream != null)
            {
                try
                {
                    _stream.writeByte(READY);
                    _stream.flush();
                }
                catch
                {
                }
            }
        }

        protected void SendListeners()
        {
            foreach (KeyValuePair<int, Dictionary<int, object>> e1 in listenerObjects)
            {
                foreach (KeyValuePair<int, object> e2 in e1.Value)
                {
                    SendListener(e2.Key, e1.Key, e2.Value);
                }
            }
        }

        protected void ProbeEvents()
        {
            _stream.writeByte(EVENT_REQUEST);
            _stream.flush();

            int eventType = _stream.readByte();

            if (eventType == HEARTBEAT)
            {
                _stream.writeByte(EVENT_RESPONSE);
                _stream.flush();
                return;
            }

            int listenerID = _stream.readInt();
            object obj = listenerObjects[eventType][listenerID];

            if (obj != null)
            {
                if (eventType == EventTypes.Access)
                {
                    int type = _stream.readInt();
                    int address = _stream.readInt();
                    int value = _stream.readInt();
                    int result = ((AccessPoint)obj).listener(type, address, value);
                    _stream.writeByte(EVENT_RESPONSE);
                    _stream.writeInt(result);
                }
                else
                {
                    switch (eventType)
                    {
                        case EventTypes.Activate:
                            ((ActivateListener)obj)();
                            break;

                        case EventTypes.Deactivate:
                            ((DeactivateListener)obj)();
                            break;

                        case EventTypes.Stop:
                            ((StopListener)obj)();
                            break;

                        case EventTypes.Controllers:
                            ((ControllersListener)obj)();
                            break;

                        case EventTypes.Frame:
                            ((FrameListener)obj)();
                            break;

                        case EventTypes.Scanline:
                            ((ScanlinePoint)obj).listener(_stream.readInt());
                            break;

                        case EventTypes.ScanlineCycle:
                            ((ScanlineCyclePoint)obj).listener(_stream.readInt(),
                                _stream.readInt(), _stream.readInt(), _stream.readBoolean());
                            break;

                        case EventTypes.SpriteZero:
                            ((SpriteZeroListener)obj)(_stream.readInt(),
                                _stream.readInt());
                            break;

                        case EventTypes.Status:
                            ((StatusListener)obj)(_stream.readString());
                            break;

                        default:
                            throw new IOException("Unknown listener type: " + eventType);
                    }
                    _stream.writeByte(EVENT_RESPONSE);
                }
            }

            _stream.flush();
        }

        protected void SendListener(int listenerID, int eventType,
            object listenerObject)
        {
            if (_stream != null)
            {
                try
                {
                    _stream.writeByte(eventType);
                    _stream.writeInt(listenerID);
                    switch (eventType)
                    {
                        case EventTypes.Access:
                            {
                                AccessPoint point = (AccessPoint)listenerObject;
                                _stream.writeInt(point.type);
                                _stream.writeInt(point.minAddress);
                                _stream.writeInt(point.maxAddress);
                                _stream.writeInt(point.bank);
                                break;
                            }
                        case EventTypes.Scanline:
                            {
                                ScanlinePoint point = (ScanlinePoint)listenerObject;
                                _stream.writeInt(point.scanline);
                                break;
                            }
                        case EventTypes.ScanlineCycle:
                            {
                                ScanlineCyclePoint point = (ScanlineCyclePoint)listenerObject;
                                _stream.writeInt(point.scanline);
                                _stream.writeInt(point.scanlineCycle);
                                break;
                            }
                    }
                    _stream.flush();
                }
                catch
                {
                }
            }
        }

        protected void AddListener(object listener, int eventType)
        {
            if (listener != null)
            {
                SendListener(AddListenerObject(listener, eventType), eventType,
                    listener);
            }
        }

        public void RemoveListener(object listener, int eventType,
            int methodValue)
        {
            if (listener != null)
            {
                int listenerID = RemoveListenerObject(listener, eventType);
                if (listenerID >= 0 && _stream != null)
                {
                    try
                    {
                        _stream.writeByte(methodValue);
                        _stream.writeInt(listenerID);
                        _stream.flush();
                    }
                    catch
                    {
                    }
                }
            }
        }

        protected int AddListenerObject(object listener, int eventType)
        {
            return AddListenerObject(listener, eventType, listener);
        }

        protected int AddListenerObject(object listener, int eventType,
            object listenerObject)
        {
            int listenerID = _nextID++;
            listenerIDs[listener] = listenerID;
            listenerObjects[eventType][listenerID] = listenerObject;
            return listenerID;
        }

        protected int RemoveListenerObject(object listener, int eventType)
        {
            if (listenerIDs.TryGetValue(listener, out int listenerID))
            {
                listenerIDs.Remove(listener);
                listenerObjects[eventType].Remove(listenerID);
                return listenerID;
            }
            else
            {
                return -1;
            }
        }

        public void AddActivateListener(ActivateListener listener)
        {
            AddListener(listener, EventTypes.Activate);
        }

        public void RemoveActivateListener(ActivateListener listener)
        {
            RemoveListener(listener, EventTypes.Activate, 2);
        }

        public void AddDeactivateListener(DeactivateListener listener)
        {
            AddListener(listener, EventTypes.Deactivate);
        }

        public void RemoveDeactivateListener(DeactivateListener listener)
        {
            RemoveListener(listener, EventTypes.Deactivate, 4);
        }

        public void AddStopListener(StopListener listener)
        {
            AddListener(listener, EventTypes.Stop);
        }

        public void RemoveStopListener(StopListener listener)
        {
            RemoveListener(listener, EventTypes.Stop, 6);
        }

        public void AddAccessPointListener(AccessPointListener listener,
            int accessPointType, int address)
        {
            AddAccessPointListener(listener, accessPointType, address, -1, -1);
        }

        public void AddAccessPointListener(AccessPointListener listener,
            int accessPointType, int minAddress, int maxAddress)
        {
            AddAccessPointListener(listener, accessPointType, minAddress, maxAddress,
                -1);
        }

        public void AddAccessPointListener(AccessPointListener listener,
            int accessPointType, int minAddress, int maxAddress,
                int bank)
        {
            if (listener != null)
            {
                AccessPoint point = new AccessPoint(listener, accessPointType,
                    minAddress, maxAddress, bank);
                SendListener(AddListenerObject(listener, EventTypes.Access, point),
                    EventTypes.Access, point);
            }
        }

        public void RemoveAccessPointListener(AccessPointListener listener)
        {
            RemoveListener(listener, EventTypes.Access, 10);
        }

        public void AddControllersListener(ControllersListener listener)
        {
            AddListener(listener, EventTypes.Controllers);
        }

        public void RemoveControllersListener(ControllersListener listener)
        {
            RemoveListener(listener, EventTypes.Controllers, 12);
        }

        public void AddFrameListener(FrameListener listener)
        {
            AddListener(listener, EventTypes.Frame);
        }

        public void RemoveFrameListener(FrameListener listener)
        {
            RemoveListener(listener, EventTypes.Frame, 14);
        }

        public void AddScanlineListener(ScanlineListener listener, int scanline)
        {
            if (listener != null)
            {
                ScanlinePoint point = new ScanlinePoint(listener, scanline);
                SendListener(AddListenerObject(listener, EventTypes.Scanline, point),
                    EventTypes.Scanline, point);
            }
        }

        public void RemoveScanlineListener(ScanlineListener listener)
        {
            RemoveListener(listener, EventTypes.Scanline, 16);
        }

        public void AddScanlineCycleListener(ScanlineCycleListener listener,
            int scanline, int scanlineCycle)
        {
            if (listener != null)
            {
                ScanlineCyclePoint point = new ScanlineCyclePoint(listener,
                    scanline, scanlineCycle);
                SendListener(AddListenerObject(listener, EventTypes.ScanlineCycle,
                    point), EventTypes.ScanlineCycle, point);
            }
        }

        public void RemoveScanlineCycleListener(
            ScanlineCycleListener listener)
        {
            RemoveListener(listener, EventTypes.ScanlineCycle, 18);
        }

        public void AddSpriteZeroListener(SpriteZeroListener listener)
        {
            AddListener(listener, EventTypes.SpriteZero);
        }

        public void RemoveSpriteZeroListener(SpriteZeroListener listener)
        {
            RemoveListener(listener, EventTypes.SpriteZero, 20);
        }

        public void AddStatusListener(StatusListener listener)
        {
            AddListener(listener, EventTypes.Status);
        }

        public void RemoveStatusListener(StatusListener listener)
        {
            RemoveListener(listener, EventTypes.Status, 22);
        }

        public void GetPixels(int[] pixels)
        {
            try
            {
                _stream.writeByte(119);
                _stream.flush();
                _stream.readIntArray(pixels);
            }
            catch
            {
            }
        }
    }
}