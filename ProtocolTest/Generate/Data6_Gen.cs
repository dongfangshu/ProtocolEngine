using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
namespace Data6
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class Data6:Protocol
	{
		public string s1;
		public string s2;
		public string s3;
		public string s4;
		public string s5;
		public string s6;
		public Data6()
		{
			s1 = string.Empty;
			s2 = string.Empty;
			s3 = string.Empty;
			s4 = string.Empty;
			s5 = string.Empty;
			s6 = string.Empty;
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			s1 = ByteBuffer.ReadString(data,ref offset);
			s2 = ByteBuffer.ReadString(data,ref offset);
			s3 = ByteBuffer.ReadString(data,ref offset);
			s4 = ByteBuffer.ReadString(data,ref offset);
			s5 = ByteBuffer.ReadString(data,ref offset);
			s6 = ByteBuffer.ReadString(data,ref offset);
			}
			catch (Exception ex)
			{
			throw;
			}
		}
		public override void Write(byte[] data, ref int offset)
		{
			ByteBuffer.WriteString(s1,data,ref offset);
			ByteBuffer.WriteString(s2,data,ref offset);
			ByteBuffer.WriteString(s3,data,ref offset);
			ByteBuffer.WriteString(s4,data,ref offset);
			ByteBuffer.WriteString(s5,data,ref offset);
			ByteBuffer.WriteString(s6,data,ref offset);
		}
	}
}
