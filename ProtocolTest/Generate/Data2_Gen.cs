using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
namespace Data2
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class Data2:Protocol
	{
		public int i1;
		public int i2;
		public int i3;
		public Data9 d9;
		public int i4;
		public int i5;
		public int i6;
		public int i7;
		public int i8;
		public int i9;
		public int i10;
		public int i11;
		public int i12;
		public int i13;
		public Data2()
		{
			i1 = default(int);
			i2 = default(int);
			i3 = default(int);
			d9 = new Data9();
			i4 = default(int);
			i5 = default(int);
			i6 = default(int);
			i7 = default(int);
			i8 = default(int);
			i9 = default(int);
			i10 = default(int);
			i11 = default(int);
			i12 = default(int);
			i13 = default(int);
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			i1= ByteBuffer.ReadInt(data,ref offset);
			i2= ByteBuffer.ReadInt(data,ref offset);
			i3= ByteBuffer.ReadInt(data,ref offset);
						d9.Read(data,ref offset);

			i4= ByteBuffer.ReadInt(data,ref offset);
			i5= ByteBuffer.ReadInt(data,ref offset);
			i6= ByteBuffer.ReadInt(data,ref offset);
			i7= ByteBuffer.ReadInt(data,ref offset);
			i8= ByteBuffer.ReadInt(data,ref offset);
			i9= ByteBuffer.ReadInt(data,ref offset);
			i10= ByteBuffer.ReadInt(data,ref offset);
			i11= ByteBuffer.ReadInt(data,ref offset);
			i12= ByteBuffer.ReadInt(data,ref offset);
			i13= ByteBuffer.ReadInt(data,ref offset);
			}
			catch (Exception ex)
			{
			throw;
			}
		}
		public override void Write(byte[] data, ref int offset)
		{
			ByteBuffer.WriteInt(i1,data,ref offset);
			ByteBuffer.WriteInt(i2,data,ref offset);
			ByteBuffer.WriteInt(i3,data,ref offset);
			d9.Write(data,ref offset);
			ByteBuffer.WriteInt(i4,data,ref offset);
			ByteBuffer.WriteInt(i5,data,ref offset);
			ByteBuffer.WriteInt(i6,data,ref offset);
			ByteBuffer.WriteInt(i7,data,ref offset);
			ByteBuffer.WriteInt(i8,data,ref offset);
			ByteBuffer.WriteInt(i9,data,ref offset);
			ByteBuffer.WriteInt(i10,data,ref offset);
			ByteBuffer.WriteInt(i11,data,ref offset);
			ByteBuffer.WriteInt(i12,data,ref offset);
			ByteBuffer.WriteInt(i13,data,ref offset);
		}
	}
}
