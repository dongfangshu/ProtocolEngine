using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
using System.Numerics;
namespace Protocol_Data3
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class Data3:Protocol
	{
		public Vector3 v1;
		public Vector3 v2;
		public Vector3 v3;
		public Vector3 v4;
		public Vector3 v5;
		public int i1;
		public int i2;
		public int i3;
		public int i4;
		public int i5;
		public Data3()
		{
			v1 = default(Vector3);
			v2 = default(Vector3);
			v3 = default(Vector3);
			v4 = default(Vector3);
			v5 = default(Vector3);
			i1 = default(int);
			i2 = default(int);
			i3 = default(int);
			i4 = default(int);
			i5 = default(int);
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
						float v1_x = ByteBuffer.ReadFloat(data,ref offset);
			float v1_y = ByteBuffer.ReadFloat(data,ref offset);
			float v1_z = ByteBuffer.ReadFloat(data,ref offset);
			v1 = new Vector3(v1_x,v1_y,v1_z);

						float v2_x = ByteBuffer.ReadFloat(data,ref offset);
			float v2_y = ByteBuffer.ReadFloat(data,ref offset);
			float v2_z = ByteBuffer.ReadFloat(data,ref offset);
			v2 = new Vector3(v2_x,v2_y,v2_z);

						float v3_x = ByteBuffer.ReadFloat(data,ref offset);
			float v3_y = ByteBuffer.ReadFloat(data,ref offset);
			float v3_z = ByteBuffer.ReadFloat(data,ref offset);
			v3 = new Vector3(v3_x,v3_y,v3_z);

						float v4_x = ByteBuffer.ReadFloat(data,ref offset);
			float v4_y = ByteBuffer.ReadFloat(data,ref offset);
			float v4_z = ByteBuffer.ReadFloat(data,ref offset);
			v4 = new Vector3(v4_x,v4_y,v4_z);

						float v5_x = ByteBuffer.ReadFloat(data,ref offset);
			float v5_y = ByteBuffer.ReadFloat(data,ref offset);
			float v5_z = ByteBuffer.ReadFloat(data,ref offset);
			v5 = new Vector3(v5_x,v5_y,v5_z);

			i1= ByteBuffer.ReadInt(data,ref offset);
			i2= ByteBuffer.ReadInt(data,ref offset);
			i3= ByteBuffer.ReadInt(data,ref offset);
			i4= ByteBuffer.ReadInt(data,ref offset);
			i5= ByteBuffer.ReadInt(data,ref offset);
			}
			catch (Exception ex)
			{
			throw;
			}
		}
		public override void Write(byte[] data, ref int offset)
		{
						ByteBuffer.WriteFloat(v1.X,data,ref offset);
			ByteBuffer.WriteFloat(v1.Y,data,ref offset);
			ByteBuffer.WriteFloat(v1.Y,data,ref offset);

						ByteBuffer.WriteFloat(v2.X,data,ref offset);
			ByteBuffer.WriteFloat(v2.Y,data,ref offset);
			ByteBuffer.WriteFloat(v2.Y,data,ref offset);

						ByteBuffer.WriteFloat(v3.X,data,ref offset);
			ByteBuffer.WriteFloat(v3.Y,data,ref offset);
			ByteBuffer.WriteFloat(v3.Y,data,ref offset);

						ByteBuffer.WriteFloat(v4.X,data,ref offset);
			ByteBuffer.WriteFloat(v4.Y,data,ref offset);
			ByteBuffer.WriteFloat(v4.Y,data,ref offset);

						ByteBuffer.WriteFloat(v5.X,data,ref offset);
			ByteBuffer.WriteFloat(v5.Y,data,ref offset);
			ByteBuffer.WriteFloat(v5.Y,data,ref offset);

			ByteBuffer.WriteInt(i1,data,ref offset);
			ByteBuffer.WriteInt(i2,data,ref offset);
			ByteBuffer.WriteInt(i3,data,ref offset);
			ByteBuffer.WriteInt(i4,data,ref offset);
			ByteBuffer.WriteInt(i5,data,ref offset);
		}
	}
}
