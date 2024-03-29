using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
namespace Data9
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class Data9:Protocol
	{
		public DataType1 e1;
		public string s1;
		public string s2;
		public long l1;
		public Data9()
		{
			e1 = default(DataType1);
			s1 = string.Empty;
			s2 = string.Empty;
			l1 = default(long);
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			e1 = (DataType1)ByteBuffer.ReadInt(data,ref offset);
			s1 = ByteBuffer.ReadString(data,ref offset);
			s2 = ByteBuffer.ReadString(data,ref offset);
			l1 = ByteBuffer.ReadLong(data,ref offset);
			}
			catch (Exception ex)
			{
			throw;
			}
		}
		public override void Write(byte[] data, ref int offset)
		{
			ByteBuffer.WriteInt((int)e1,data,ref offset);
			ByteBuffer.WriteString(s1,data,ref offset);
			ByteBuffer.WriteString(s2,data,ref offset);
			ByteBuffer.WriteLong(l1,data,ref offset);
		}
	}
}
