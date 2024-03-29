using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
using Protocol_Data5;
namespace Protocol_Data5
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class Data5:Protocol
	{
		public string str1;
		public string str2;
		public bool b1;
		public int i1;
		public int i2;
		public int i3;
		public string str3;
		public int i4;
		public bool b2;
		public long l1;
		public int i5;
		public int i6;
		public Data6 d6;
		public Data5()
		{
			str1 = string.Empty;
			str2 = string.Empty;
			b1 = default(bool);
			i1 = default(int);
			i2 = default(int);
			i3 = default(int);
			str3 = string.Empty;
			i4 = default(int);
			b2 = default(bool);
			l1 = default(long);
			i5 = default(int);
			i6 = default(int);
			d6 = new Data6();
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			str1 = ByteBuffer.ReadString(data,ref offset);
			str2 = ByteBuffer.ReadString(data,ref offset);
			b1 = ByteBuffer.ReadBool(data,ref offset);
			i1= ByteBuffer.ReadInt(data,ref offset);
			i2= ByteBuffer.ReadInt(data,ref offset);
			i3= ByteBuffer.ReadInt(data,ref offset);
			str3 = ByteBuffer.ReadString(data,ref offset);
			i4= ByteBuffer.ReadInt(data,ref offset);
			b2 = ByteBuffer.ReadBool(data,ref offset);
			l1 = ByteBuffer.ReadLong(data,ref offset);
			i5= ByteBuffer.ReadInt(data,ref offset);
			i6= ByteBuffer.ReadInt(data,ref offset);
						d6.Read(data,ref offset);

			}
			catch (Exception ex)
			{
			throw;
			}
		}
		public override void Write(byte[] data, ref int offset)
		{
			ByteBuffer.WriteString(str1,data,ref offset);
			ByteBuffer.WriteString(str2,data,ref offset);
			ByteBuffer.WriteBool(b1,data,ref offset);
			ByteBuffer.WriteInt(i1,data,ref offset);
			ByteBuffer.WriteInt(i2,data,ref offset);
			ByteBuffer.WriteInt(i3,data,ref offset);
			ByteBuffer.WriteString(str3,data,ref offset);
			ByteBuffer.WriteInt(i4,data,ref offset);
			ByteBuffer.WriteBool(b2,data,ref offset);
			ByteBuffer.WriteLong(l1,data,ref offset);
			ByteBuffer.WriteInt(i5,data,ref offset);
			ByteBuffer.WriteInt(i6,data,ref offset);
			d6.Write(data,ref offset);
		}
	}
}
