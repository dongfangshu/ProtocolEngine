using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
using Protocol_Data1;
namespace Protocol_Data1
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class Data1:Protocol
	{
		public string str1;
		public bool b1;
		public int i1;
		public int i2;
		public Data2 d2;
		public Data3 d3;
		public List<Data4> d4;
		public Data5 d5;
		public Data7 d7;
		public List<Data8> d8;
		public int i3;
		public bool b2;
		public Data1()
		{
			str1 = string.Empty;
			b1 = default(bool);
			i1 = default(int);
			i2 = default(int);
			d2 = new Data2();
			d3 = new Data3();
			d4 = new List<Data4>();
			d5 = new Data5();
			d7 = new Data7();
			d8 = new List<Data8>();
			i3 = default(int);
			b2 = default(bool);
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			str1 = ByteBuffer.ReadString(data,ref offset);
			b1 = ByteBuffer.ReadBool(data,ref offset);
			i1= ByteBuffer.ReadInt(data,ref offset);
			i2= ByteBuffer.ReadInt(data,ref offset);
						d2.Read(data,ref offset);

						d3.Read(data,ref offset);

						{
				List<Data4> d4_temp_list =new List<Data4>();
				int d4_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int d4_index = 0;d4_index<d4_temp_list_count;d4_index++ )
				{
					Data4 d4_list_element = new Data4();
									d4_list_element.Read(data,ref offset);

					d4_temp_list.Add(d4_list_element);
				}
				d4.AddRange(d4_temp_list);
			}

						d5.Read(data,ref offset);

						d7.Read(data,ref offset);

						{
				List<Data8> d8_temp_list =new List<Data8>();
				int d8_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int d8_index = 0;d8_index<d8_temp_list_count;d8_index++ )
				{
					Data8 d8_list_element = new Data8();
									d8_list_element.Read(data,ref offset);

					d8_temp_list.Add(d8_list_element);
				}
				d8.AddRange(d8_temp_list);
			}

			i3= ByteBuffer.ReadInt(data,ref offset);
			b2 = ByteBuffer.ReadBool(data,ref offset);
			}
			catch (Exception ex)
			{
			throw;
			}
		}
		public override void Write(byte[] data, ref int offset)
		{
			ByteBuffer.WriteString(str1,data,ref offset);
			ByteBuffer.WriteBool(b1,data,ref offset);
			ByteBuffer.WriteInt(i1,data,ref offset);
			ByteBuffer.WriteInt(i2,data,ref offset);
			d2.Write(data,ref offset);
			d3.Write(data,ref offset);
						{
				int d4_count = d4.Count;
				ByteBuffer.WriteInt(d4_count,data,ref offset);
				for(int d4_index =0;d4_index<d4_count;d4_index++)
				{
					Data4 d4_list_element=d4[d4_index];
					d4_list_element.Write(data,ref offset);
				}
			}

			d5.Write(data,ref offset);
			d7.Write(data,ref offset);
						{
				int d8_count = d8.Count;
				ByteBuffer.WriteInt(d8_count,data,ref offset);
				for(int d8_index =0;d8_index<d8_count;d8_index++)
				{
					Data8 d8_list_element=d8[d8_index];
					d8_list_element.Write(data,ref offset);
				}
			}

			ByteBuffer.WriteInt(i3,data,ref offset);
			ByteBuffer.WriteBool(b2,data,ref offset);
		}
	}
}
