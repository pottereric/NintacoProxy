namespace Nintaco
{
    public class RemoteAPI : RemoteBase
    {
        public RemoteAPI(string host, int port) : base(host, port)
        {
        }

        public void SetPaused(bool paused)
        {
            try
            {
                _stream.writeByte(23);
                _stream.writeBoolean(paused);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsPaused()
        {
            try
            {
                _stream.writeByte(24);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public int GetFrameCount()
        {
            try
            {
                _stream.writeByte(25);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public int GetA()
        {
            try
            {
                _stream.writeByte(26);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetA(int A)
        {
            try
            {
                _stream.writeByte(27);
                _stream.writeInt(A);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetS()
        {
            try
            {
                _stream.writeByte(28);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetS(int S)
        {
            try
            {
                _stream.writeByte(29);
                _stream.writeInt(S);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetPC()
        {
            try
            {
                _stream.writeByte(30);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetPC(int PC)
        {
            try
            {
                _stream.writeByte(31);
                _stream.writeInt(PC);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetX()
        {
            try
            {
                _stream.writeByte(32);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetX(int X)
        {
            try
            {
                _stream.writeByte(33);
                _stream.writeInt(X);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetY()
        {
            try
            {
                _stream.writeByte(34);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetY(int Y)
        {
            try
            {
                _stream.writeByte(35);
                _stream.writeInt(Y);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetP()
        {
            try
            {
                _stream.writeByte(36);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetP(int P)
        {
            try
            {
                _stream.writeByte(37);
                _stream.writeInt(P);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsN()
        {
            try
            {
                _stream.writeByte(38);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetN(bool N)
        {
            try
            {
                _stream.writeByte(39);
                _stream.writeBoolean(N);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsV()
        {
            try
            {
                _stream.writeByte(40);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetV(bool V)
        {
            try
            {
                _stream.writeByte(41);
                _stream.writeBoolean(V);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsD()
        {
            try
            {
                _stream.writeByte(42);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetD(bool D)
        {
            try
            {
                _stream.writeByte(43);
                _stream.writeBoolean(D);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsI()
        {
            try
            {
                _stream.writeByte(44);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetI(bool I)
        {
            try
            {
                _stream.writeByte(45);
                _stream.writeBoolean(I);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsZ()
        {
            try
            {
                _stream.writeByte(46);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetZ(bool Z)
        {
            try
            {
                _stream.writeByte(47);
                _stream.writeBoolean(Z);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsC()
        {
            try
            {
                _stream.writeByte(48);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetC(bool C)
        {
            try
            {
                _stream.writeByte(49);
                _stream.writeBoolean(C);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetPPUv()
        {
            try
            {
                _stream.writeByte(50);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetPPUv(int v)
        {
            try
            {
                _stream.writeByte(51);
                _stream.writeInt(v);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetPPUt()
        {
            try
            {
                _stream.writeByte(52);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetPPUt(int t)
        {
            try
            {
                _stream.writeByte(53);
                _stream.writeInt(t);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetPPUx()
        {
            try
            {
                _stream.writeByte(54);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetPPUx(int x)
        {
            try
            {
                _stream.writeByte(55);
                _stream.writeInt(x);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsPPUw()
        {
            try
            {
                _stream.writeByte(56);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetPPUw(bool w)
        {
            try
            {
                _stream.writeByte(57);
                _stream.writeBoolean(w);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetCameraX()
        {
            try
            {
                _stream.writeByte(58);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetCameraX(int scrollX)
        {
            try
            {
                _stream.writeByte(59);
                _stream.writeInt(scrollX);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetCameraY()
        {
            try
            {
                _stream.writeByte(60);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetCameraY(int scrollY)
        {
            try
            {
                _stream.writeByte(61);
                _stream.writeInt(scrollY);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetScanline()
        {
            try
            {
                _stream.writeByte(62);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public int GetDot()
        {
            try
            {
                _stream.writeByte(63);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public bool IsSpriteZeroHit()
        {
            try
            {
                _stream.writeByte(64);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetSpriteZeroHit(bool sprite0Hit)
        {
            try
            {
                _stream.writeByte(65);
                _stream.writeBoolean(sprite0Hit);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetScanlineCount()
        {
            try
            {
                _stream.writeByte(66);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void RequestInterrupt()
        {
            try
            {
                _stream.writeByte(67);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void AcknowledgeInterrupt()
        {
            try
            {
                _stream.writeByte(68);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int PeekCPU(int address)
        {
            try
            {
                _stream.writeByte(69);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public int ReadCPU(int address)
        {
            try
            {
                _stream.writeByte(70);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void WriteCPU(int address, int value)
        {
            try
            {
                _stream.writeByte(71);
                _stream.writeInt(address);
                _stream.writeInt(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int PeekCPU16(int address)
        {
            try
            {
                _stream.writeByte(72);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public int ReadCPU16(int address)
        {
            try
            {
                _stream.writeByte(73);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void WriteCPU16(int address, int value)
        {
            try
            {
                _stream.writeByte(74);
                _stream.writeInt(address);
                _stream.writeInt(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int PeekCPU32(int address)
        {
            try
            {
                _stream.writeByte(75);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public int ReadCPU32(int address)
        {
            try
            {
                _stream.writeByte(76);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void WriteCPU32(int address, int value)
        {
            try
            {
                _stream.writeByte(77);
                _stream.writeInt(address);
                _stream.writeInt(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int ReadPPU(int address)
        {
            try
            {
                _stream.writeByte(78);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void WritePPU(int address, int value)
        {
            try
            {
                _stream.writeByte(79);
                _stream.writeInt(address);
                _stream.writeInt(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int ReadPaletteRAM(int address)
        {
            try
            {
                _stream.writeByte(80);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void WritePaletteRAM(int address, int value)
        {
            try
            {
                _stream.writeByte(81);
                _stream.writeInt(address);
                _stream.writeInt(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int ReadOAM(int address)
        {
            try
            {
                _stream.writeByte(82);
                _stream.writeInt(address);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void WriteOAM(int address, int value)
        {
            try
            {
                _stream.writeByte(83);
                _stream.writeInt(address);
                _stream.writeInt(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool ReadGamepad(int gamepad, int button)
        {
            try
            {
                _stream.writeByte(84);
                _stream.writeInt(gamepad);
                _stream.writeInt(button);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void WriteGamepad(int gamepad, int button, bool value)
        {
            try
            {
                _stream.writeByte(85);
                _stream.writeInt(gamepad);
                _stream.writeInt(button);
                _stream.writeBoolean(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public bool IsZapperTrigger()
        {
            try
            {
                _stream.writeByte(86);
                _stream.flush();
                return _stream.readBoolean();
            }
            catch
            {
            }
            return false;
        }

        public void SetZapperTrigger(bool zapperTrigger)
        {
            try
            {
                _stream.writeByte(87);
                _stream.writeBoolean(zapperTrigger);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetZapperX()
        {
            try
            {
                _stream.writeByte(88);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetZapperX(int x)
        {
            try
            {
                _stream.writeByte(89);
                _stream.writeInt(x);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetZapperY()
        {
            try
            {
                _stream.writeByte(90);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetZapperY(int y)
        {
            try
            {
                _stream.writeByte(91);
                _stream.writeInt(y);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void SetColor(int color)
        {
            try
            {
                _stream.writeByte(92);
                _stream.writeInt(color);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetColor()
        {
            try
            {
                _stream.writeByte(93);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void SetClip(int x, int y, int width, int height)
        {
            try
            {
                _stream.writeByte(94);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void ClipRect(int x, int y, int width, int height)
        {
            try
            {
                _stream.writeByte(95);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void ResetClip()
        {
            try
            {
                _stream.writeByte(96);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void CopyArea(int x, int y, int width, int height, int dx, int dy)
        {
            try
            {
                _stream.writeByte(97);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.writeInt(dx);
                _stream.writeInt(dy);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            try
            {
                _stream.writeByte(98);
                _stream.writeInt(x1);
                _stream.writeInt(y1);
                _stream.writeInt(x2);
                _stream.writeInt(y2);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawOval(int x, int y, int width, int height)
        {
            try
            {
                _stream.writeByte(99);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawPolygon(int[] xPoints, int[] yPoints, int nPoints)
        {
            try
            {
                _stream.writeByte(100);
                _stream.writeIntArray(xPoints);
                _stream.writeIntArray(yPoints);
                _stream.writeInt(nPoints);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawPolyline(int[] xPoints, int[] yPoints, int nPoints)
        {
            try
            {
                _stream.writeByte(101);
                _stream.writeIntArray(xPoints);
                _stream.writeIntArray(yPoints);
                _stream.writeInt(nPoints);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawRect(int x, int y, int width, int height)
        {
            try
            {
                _stream.writeByte(102);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawRoundRect(int x, int y, int width, int height, int arcWidth,
            int arcHeight)
        {
            try
            {
                _stream.writeByte(103);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.writeInt(arcWidth);
                _stream.writeInt(arcHeight);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void Draw3DRect(int x, int y, int width, int height, bool raised)
        {
            try
            {
                _stream.writeByte(104);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.writeBoolean(raised);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawArc(int x, int y, int width, int height, int startAngle,
            int arcAngle)
        {
            try
            {
                _stream.writeByte(105);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.writeInt(startAngle);
                _stream.writeInt(arcAngle);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void Fill3DRect(int x, int y, int width, int height, bool raised)
        {
            try
            {
                _stream.writeByte(106);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.writeBoolean(raised);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void FillArc(int x, int y, int width, int height, int startAngle,
            int arcAngle)
        {
            try
            {
                _stream.writeByte(107);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.writeInt(startAngle);
                _stream.writeInt(arcAngle);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void FillOval(int x, int y, int width, int height)
        {
            try
            {
                _stream.writeByte(108);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void FillPolygon(int[] xPoints, int[] yPoints, int nPoints)
        {
            try
            {
                _stream.writeByte(109);
                _stream.writeIntArray(xPoints);
                _stream.writeIntArray(yPoints);
                _stream.writeInt(nPoints);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void FillRect(int x, int y, int width, int height)
        {
            try
            {
                _stream.writeByte(110);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void FillRoundRect(int x, int y, int width, int height, int arcWidth,
            int arcHeight)
        {
            try
            {
                _stream.writeByte(111);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.writeInt(arcWidth);
                _stream.writeInt(arcHeight);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawChar(char c, int x, int y)
        {
            try
            {
                _stream.writeByte(112);
                _stream.writeChar(c);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawChars(char[] data, int offset, int length, int x, int y,
            bool monospaced)
        {
            try
            {
                _stream.writeByte(113);
                _stream.writeCharArray(data);
                _stream.writeInt(offset);
                _stream.writeInt(length);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeBoolean(monospaced);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawString(string str, int x, int y, bool monospaced)
        {
            try
            {
                _stream.writeByte(114);
                _stream.writeString(str);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeBoolean(monospaced);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void CreateSprite(int id, int width, int height, int[] pixels)
        {
            try
            {
                _stream.writeByte(115);
                _stream.writeInt(id);
                _stream.writeInt(width);
                _stream.writeInt(height);
                _stream.writeIntArray(pixels);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DrawSprite(int id, int x, int y)
        {
            try
            {
                _stream.writeByte(116);
                _stream.writeInt(id);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void SetPixel(int x, int y, int color)
        {
            try
            {
                _stream.writeByte(117);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.writeInt(color);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetPixel(int x, int y)
        {
            try
            {
                _stream.writeByte(118);
                _stream.writeInt(x);
                _stream.writeInt(y);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void PowerCycle()
        {
            try
            {
                _stream.writeByte(120);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void Reset()
        {
            try
            {
                _stream.writeByte(121);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void DeleteSprite(int id)
        {
            try
            {
                _stream.writeByte(122);
                _stream.writeInt(id);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void SetSpeed(int percent)
        {
            try
            {
                _stream.writeByte(123);
                _stream.writeInt(percent);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void StepToNextFrame()
        {
            try
            {
                _stream.writeByte(124);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void ShowMessage(string message)
        {
            try
            {
                _stream.writeByte(125);
                _stream.writeString(message);
                _stream.flush();
            }
            catch
            {
            }
        }

        public string GetWorkingDirectory()
        {
            try
            {
                _stream.writeByte(126);
                _stream.flush();
                return _stream.readString();
            }
            catch
            {
            }
            return null;
        }

        public string GetContentDirectory()
        {
            try
            {
                _stream.writeByte(127);
                _stream.flush();
                return _stream.readString();
            }
            catch
            {
            }
            return null;
        }

        public void Open(string fileName)
        {
            try
            {
                _stream.writeByte(128);
                _stream.writeString(fileName);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void OpenArchiveEntry(string archiveFileName, string entryFileName)
        {
            try
            {
                _stream.writeByte(129);
                _stream.writeString(archiveFileName);
                _stream.writeString(entryFileName);
                _stream.flush();
            }
            catch
            {
            }
        }

        public string[] GetArchiveEntries(string archiveFileName)
        {
            try
            {
                _stream.writeByte(130);
                _stream.writeString(archiveFileName);
                _stream.flush();
                return _stream.readDynamicStringArray();
            }
            catch
            {
            }
            return null;
        }

        public string GetDefaultArchiveEntry(string archiveFileName)
        {
            try
            {
                _stream.writeByte(131);
                _stream.writeString(archiveFileName);
                _stream.flush();
                return _stream.readString();
            }
            catch
            {
            }
            return null;
        }

        public void OpenDefaultArchiveEntry(string archiveFileName)
        {
            try
            {
                _stream.writeByte(132);
                _stream.writeString(archiveFileName);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void Close()
        {
            try
            {
                _stream.writeByte(133);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void SaveState(string stateFileName)
        {
            try
            {
                _stream.writeByte(134);
                _stream.writeString(stateFileName);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void LoadState(string stateFileName)
        {
            try
            {
                _stream.writeByte(135);
                _stream.writeString(stateFileName);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void QuickSaveState(int slot)
        {
            try
            {
                _stream.writeByte(136);
                _stream.writeInt(slot);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void QuickLoadState(int slot)
        {
            try
            {
                _stream.writeByte(137);
                _stream.writeInt(slot);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void SetTVSystem(string tvSystem)
        {
            try
            {
                _stream.writeByte(138);
                _stream.writeString(tvSystem);
                _stream.flush();
            }
            catch
            {
            }
        }

        public string GetTVSystem()
        {
            try
            {
                _stream.writeByte(139);
                _stream.flush();
                return _stream.readString();
            }
            catch
            {
            }
            return null;
        }

        public int GetDiskSides()
        {
            try
            {
                _stream.writeByte(140);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void InsertDisk(int disk, int side)
        {
            try
            {
                _stream.writeByte(141);
                _stream.writeInt(disk);
                _stream.writeInt(side);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void FlipDiskSide()
        {
            try
            {
                _stream.writeByte(142);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void EjectDisk()
        {
            try
            {
                _stream.writeByte(143);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void InsertCoin()
        {
            try
            {
                _stream.writeByte(144);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void PressServiceButton()
        {
            try
            {
                _stream.writeByte(145);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void ScreamIntoMicrophone()
        {
            try
            {
                _stream.writeByte(146);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void Glitch()
        {
            try
            {
                _stream.writeByte(147);
                _stream.flush();
            }
            catch
            {
            }
        }

        public string GetFileInfo()
        {
            try
            {
                _stream.writeByte(148);
                _stream.flush();
                return _stream.readString();
            }
            catch
            {
            }
            return null;
        }

        public void SetFullscreenMode(bool fullscreenMode)
        {
            try
            {
                _stream.writeByte(149);
                _stream.writeBoolean(fullscreenMode);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void SaveScreenshot()
        {
            try
            {
                _stream.writeByte(150);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void AddCheat(int address, int value, int compare,
            string description, bool enabled)
        {
            try
            {
                _stream.writeByte(151);
                _stream.writeInt(address);
                _stream.writeInt(value);
                _stream.writeInt(compare);
                _stream.writeString(description);
                _stream.writeBoolean(enabled);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void RemoveCheat(int address, int value, int compare)
        {
            try
            {
                _stream.writeByte(152);
                _stream.writeInt(address);
                _stream.writeInt(value);
                _stream.writeInt(compare);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void AddGameGenie(string gameGenieCode, string description,
            bool enabled)
        {
            try
            {
                _stream.writeByte(153);
                _stream.writeString(gameGenieCode);
                _stream.writeString(description);
                _stream.writeBoolean(enabled);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void RemoveGameGenie(string gameGenieCode)
        {
            try
            {
                _stream.writeByte(154);
                _stream.writeString(gameGenieCode);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void AddProActionRocky(string proActionRockyCode, string description,
            bool enabled)
        {
            try
            {
                _stream.writeByte(155);
                _stream.writeString(proActionRockyCode);
                _stream.writeString(description);
                _stream.writeBoolean(enabled);
                _stream.flush();
            }
            catch
            {
            }
        }

        public void RemoveProActionRocky(string proActionRockyCode)
        {
            try
            {
                _stream.writeByte(156);
                _stream.writeString(proActionRockyCode);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetPrgRomSize()
        {
            try
            {
                _stream.writeByte(157);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public int ReadPrgRom(int index)
        {
            try
            {
                _stream.writeByte(158);
                _stream.writeInt(index);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void WritePrgRom(int index, int value)
        {
            try
            {
                _stream.writeByte(159);
                _stream.writeInt(index);
                _stream.writeInt(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetChrRomSize()
        {
            try
            {
                _stream.writeByte(160);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public int ReadChrRom(int index)
        {
            try
            {
                _stream.writeByte(161);
                _stream.writeInt(index);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public void WriteChrRom(int index, int value)
        {
            try
            {
                _stream.writeByte(162);
                _stream.writeInt(index);
                _stream.writeInt(value);
                _stream.flush();
            }
            catch
            {
            }
        }

        public int GetStringWidth(string str, bool monospaced)
        {
            try
            {
                _stream.writeByte(163);
                _stream.writeString(str);
                _stream.writeBoolean(monospaced);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }

        public int GetCharsWidth(char[] chars, bool monospaced)
        {
            try
            {
                _stream.writeByte(164);
                _stream.writeCharArray(chars);
                _stream.writeBoolean(monospaced);
                _stream.flush();
                return _stream.readInt();
            }
            catch
            {
            }
            return -1;
        }
    }
}