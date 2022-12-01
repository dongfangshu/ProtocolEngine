//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//public sealed class ByteWriteBuffer
//{
//    byte[] buffer;
//    private const int DefaultCapacity = 4;
//    public int Capacity { get; private set; }
//    private int Position;
//    public byte[] GetData()
//    {
//        byte[] bytes = new byte[Position];
//        Array.Copy(buffer, bytes, Position);
//        return bytes;
//    }
//    public ByteWriteBuffer()
//    {
//        buffer = new byte[DefaultCapacity];
//        Capacity = DefaultCapacity;
//        Position = 0;
//    }
//    public ByteWriteBuffer(byte[] buffer,int pos)
//    {
//        ArgumentNullException.ThrowIfNull(buffer);
//        this.buffer = buffer;
//        Capacity = buffer.Length;
//        Position = pos;
//    }
//    public ByteWriteBuffer(int capacity)
//    {
//        if (capacity < 0)
//            throw new ArgumentOutOfRangeException(nameof(capacity));
//        buffer = new byte[capacity];
//        Capacity = capacity;
//        Position = 0;
//    }
//    public void WriteBool(bool value)
//    {
//        int capacity = ByteBuffer.BoolSize + Position;
//        if (capacity > buffer.Length)
//        {
//            Grow(capacity);
//        }
//        ByteBuffer.WriteBool(value, buffer, ref Position);
//    }
//    public void WriteInt(int value)
//    {
//        int capacity = ByteBuffer.IntSize + Position;
//        if (capacity > buffer.Length)
//        {
//            Grow(capacity);
//        }
//        ByteBuffer.WriteInt(value, buffer, ref Position);
//    }
//    public void WriteString(string value)
//    {
//        int capacity = Position + value.Length* sizeof(char) + ByteBuffer.ShortSize;
//        if (capacity > buffer.Length)
//        {
//            Grow(capacity);
//        }
//        ByteBuffer.WriteString(value,buffer,ref Position);
//    }
//    public void WriteBytes(byte[] value)
//    {
//        ArgumentNullException.ThrowIfNull(value);
//        int capacity = Position + value.Length+ ByteBuffer.IntSize;
//        if (Position + value.Length + ByteBuffer.IntSize > buffer.Length)//长度+data
//            Grow(capacity);
//        ByteBuffer.WriteBytes(value,buffer,ref Position);
//    }
//    public void WriteFloat(float value)
//    {
//        int capacity = ByteBuffer.FloatSize + Position;
//        if (capacity > buffer.Length)
//        {
//            Grow(capacity);
//        }
//        ByteBuffer.WriteFloat(value, buffer, ref Position);
//    }
//    public void WriteByte(byte value)
//    {
//        int capacity = ByteBuffer.ByteSize + Position;
//        if (capacity > buffer.Length)
//        {
//            Grow(capacity);
//        }
//        ByteBuffer.WriteByte(value, buffer, ref Position);
//    }
//    public void WriteLong(long value)
//    {
//        int capacity = ByteBuffer.LongSize + Position;
//        if (capacity > buffer.Length)
//        {
//            Grow(capacity);
//        }
//        ByteBuffer.WriteLong(value, buffer, ref Position);
//    }
//    private void Grow(int capacity)
//    {
//        int newcapacity = buffer.Length == 0 ? DefaultCapacity : 2 * buffer.Length;
//        if ((uint)newcapacity > Array.MaxLength) newcapacity = Array.MaxLength;
//        if (newcapacity < capacity) newcapacity = capacity;
//        Capacity = newcapacity;
//        byte[] newByteBuffer = new byte[Capacity];
//        Array.Copy(buffer, newByteBuffer, Position);
//        buffer = newByteBuffer;
//    }
//}
