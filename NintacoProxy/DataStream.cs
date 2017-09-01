using System;
using System.IO;

namespace Nintaco
{
    public class DataStream
    {

        public const int ARRAY_LENGTH = 1024;

        private readonly BinaryWriter writer;
        private readonly BinaryReader reader;

        public DataStream(BinaryWriter writer, BinaryReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void writeByte(int value)
        {
            writer.Write((byte)value);
        }

        public int readByte()
        {
            return reader.ReadByte();
        }

        public void writeInt(int value)
        {
            writeByte(value >> 24);
            writeByte(value >> 16);
            writeByte(value >> 8);
            writeByte(value);
        }

        public int readInt()
        {
            return (readByte() << 24) | (readByte() << 16) | (readByte() << 8)
                | readByte();
        }

        public void writeIntArray(int[] array)
        {
            writeInt(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                writeInt(array[i]);
            }
        }

        public int readIntArray(int[] array)
        {
            int length = readInt();
            if (length < 0 || length > array.Length)
            {
                writer.Close();
                reader.Close();
                throw new IOException("Invalid array length: " + length);
            }
            for (int i = 0; i < length; i++)
            {
                array[i] = readInt();
            }
            return length;
        }

        public void writeBoolean(bool value)
        {
            writeByte(value ? 1 : 0);
        }

        public bool readBoolean()
        {
            return readByte() != 0;
        }

        public void writeChar(char value)
        {
            writeByte(value);
        }

        public char readChar()
        {
            return (char)readByte();
        }

        public void writeCharArray(char[] array)
        {
            writeInt(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                writeChar(array[i]);
            }
        }

        public int readCharArray(char[] array)
        {
            int length = readInt();
            if (length < 0 || length > array.Length)
            {
                writer.Close();
                reader.Close();
                throw new IOException("Invalid array length: " + length);
            }
            for (int i = 0; i < length; i++)
            {
                array[i] = readChar();
            }
            return length;
        }

        public void writeString(string value)
        {
            int length = value.Length;
            writeInt(length);
            for (int i = 0; i < length; i++)
            {
                writeChar(value[i]);
            }
        }

        public string readString()
        {
            int length = readInt();
            if (length < 0 || length > ARRAY_LENGTH)
            {
                writer.Close();
                reader.Close();
                throw new IOException("Invalid array length: " + length);
            }
            char[] cs = new char[length];
            for (int i = 0; i < length; i++)
            {
                cs[i] = readChar();
            }
            return new String(cs);
        }

        public void writeStringArray(string[] array)
        {
            writeInt(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                writeString(array[i]);
            }
        }

        public int readStringArray(String[] array)
        {
            int length = readInt();
            if (length < 0 || length > array.Length)
            {
                writer.Close();
                reader.Close();
                throw new IOException("Invalid array length: " + length);
            }
            for (int i = 0; i < length; i++)
            {
                array[i] = readString();
            }
            return length;
        }

        public String[] readDynamicStringArray()
        {
            int length = readInt();
            if (length < 0 || length > ARRAY_LENGTH)
            {
                writer.Close();
                reader.Close();
                throw new IOException("Invalid array length: " + length);
            }
            String[] array = new String[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = readString();
            }
            return array;
        }

        public void flush()
        {
            writer.Flush();
        }
    }
}
