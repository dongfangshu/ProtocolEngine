using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
namespace Protocol_Data4
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class Data4:Protocol
	{
		public string str1;
		public string str2;
		public bool b1;
		public int i1;
		public string str3;
		public Data4()
		{
			str1 = string.Empty;
			str2 = string.Empty;
			b1 = default(bool);
			i1 = default(int);
			str3 = string.Empty;
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			str1 = ByteBuffer.ReadString(data,ref offset);
			str2 = ByteBuffer.ReadString(data,ref offset);
			b1 = ByteBuffer.ReadBool(data,ref offset);
			i1= ByteBuffer.ReadInt(data,ref offset);
			str3 = ByteBuffer.ReadString(data,ref offset);
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
			ByteBuffer.WriteString(str3,data,ref offset);
		}
	}
}
