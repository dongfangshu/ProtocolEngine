using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
namespace Data8
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class Data8:Protocol
	{
		public int i1;
		public int i2;
		public float f1;
		public float f2;
		public Data8()
		{
			i1 = default(int);
			i2 = default(int);
			f1 = default(float);
			f2 = default(float);
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			i1= ByteBuffer.ReadInt(data,ref offset);
			i2= ByteBuffer.ReadInt(data,ref offset);
			f1 = ByteBuffer.ReadFloat(data,ref offset);
			f2 = ByteBuffer.ReadFloat(data,ref offset);
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
			ByteBuffer.WriteFloat(f1,data,ref offset);
			ByteBuffer.WriteFloat(f2,data,ref offset);
		}
	}
}
