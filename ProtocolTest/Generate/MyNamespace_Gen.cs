using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
using MyNamespace;
using System.Numerics;
namespace MyNamespace
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public enum DataType1
	{
		t1 = 0,
		t2 = 1,
		t3 = 2,
		t4 = 3,
		t5 = 4,
		t6 = 5,
		t7 = 6,
		t8 = 7,
	}
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
			throw new Exception();
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
			throw new Exception();
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
			throw new Exception();
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
			throw new Exception();
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
			throw new Exception();
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
			throw new Exception();
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
	public class Data7:Protocol
	{
		public string str1;
		public List<string> list1;
		public List<string> list2;
		public List<string> list3;
		public List<string> list4;
		public List<string> list5;
		public Data7()
		{
			str1 = string.Empty;
			list1 = new List<string>();
			list2 = new List<string>();
			list3 = new List<string>();
			list4 = new List<string>();
			list5 = new List<string>();
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			str1 = ByteBuffer.ReadString(data,ref offset);
						{
				List<string> list1_temp_list =new List<string>();
				int list1_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int list1_index = 0;list1_index<list1_temp_list_count;list1_index++ )
				{
					string list1_list_element = string.Empty;
					list1_list_element = ByteBuffer.ReadString(data,ref offset);
					list1_temp_list.Add(list1_list_element);
				}
				list1.AddRange(list1_temp_list);
			}

						{
				List<string> list2_temp_list =new List<string>();
				int list2_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int list2_index = 0;list2_index<list2_temp_list_count;list2_index++ )
				{
					string list2_list_element = string.Empty;
					list2_list_element = ByteBuffer.ReadString(data,ref offset);
					list2_temp_list.Add(list2_list_element);
				}
				list2.AddRange(list2_temp_list);
			}

						{
				List<string> list3_temp_list =new List<string>();
				int list3_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int list3_index = 0;list3_index<list3_temp_list_count;list3_index++ )
				{
					string list3_list_element = string.Empty;
					list3_list_element = ByteBuffer.ReadString(data,ref offset);
					list3_temp_list.Add(list3_list_element);
				}
				list3.AddRange(list3_temp_list);
			}

						{
				List<string> list4_temp_list =new List<string>();
				int list4_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int list4_index = 0;list4_index<list4_temp_list_count;list4_index++ )
				{
					string list4_list_element = string.Empty;
					list4_list_element = ByteBuffer.ReadString(data,ref offset);
					list4_temp_list.Add(list4_list_element);
				}
				list4.AddRange(list4_temp_list);
			}

						{
				List<string> list5_temp_list =new List<string>();
				int list5_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int list5_index = 0;list5_index<list5_temp_list_count;list5_index++ )
				{
					string list5_list_element = string.Empty;
					list5_list_element = ByteBuffer.ReadString(data,ref offset);
					list5_temp_list.Add(list5_list_element);
				}
				list5.AddRange(list5_temp_list);
			}

			}
			catch (Exception ex)
			{
			throw new Exception();
			}
		}
		public override void Write(byte[] data, ref int offset)
		{
			ByteBuffer.WriteString(str1,data,ref offset);
						{
				int list1_count = list1.Count;
				ByteBuffer.WriteInt(list1_count,data,ref offset);
				for(int list1_index =0;list1_index<list1_count;list1_index++)
				{
					string list1_list_element=list1[list1_index];
					ByteBuffer.WriteString(list1_list_element,data,ref offset);
				}
			}

						{
				int list2_count = list2.Count;
				ByteBuffer.WriteInt(list2_count,data,ref offset);
				for(int list2_index =0;list2_index<list2_count;list2_index++)
				{
					string list2_list_element=list2[list2_index];
					ByteBuffer.WriteString(list2_list_element,data,ref offset);
				}
			}

						{
				int list3_count = list3.Count;
				ByteBuffer.WriteInt(list3_count,data,ref offset);
				for(int list3_index =0;list3_index<list3_count;list3_index++)
				{
					string list3_list_element=list3[list3_index];
					ByteBuffer.WriteString(list3_list_element,data,ref offset);
				}
			}

						{
				int list4_count = list4.Count;
				ByteBuffer.WriteInt(list4_count,data,ref offset);
				for(int list4_index =0;list4_index<list4_count;list4_index++)
				{
					string list4_list_element=list4[list4_index];
					ByteBuffer.WriteString(list4_list_element,data,ref offset);
				}
			}

						{
				int list5_count = list5.Count;
				ByteBuffer.WriteInt(list5_count,data,ref offset);
				for(int list5_index =0;list5_index<list5_count;list5_index++)
				{
					string list5_list_element=list5[list5_index];
					ByteBuffer.WriteString(list5_list_element,data,ref offset);
				}
			}

		}
	}
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
			throw new Exception();
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
	public class Data9:Protocol
	{
		public MyNamespace.DataType1 e1;
		public string s1;
		public string s2;
		public long l1;
		public Data9()
		{
			e1 = default(MyNamespace.DataType1);
			s1 = string.Empty;
			s2 = string.Empty;
			l1 = default(long);
		}
		public override void Read(byte[] data, ref int offset)
		{
			try
			{
			e1 = (MyNamespace.DataType1)ByteBuffer.ReadInt(data,ref offset);
			s1 = ByteBuffer.ReadString(data,ref offset);
			s2 = ByteBuffer.ReadString(data,ref offset);
			l1 = ByteBuffer.ReadLong(data,ref offset);
			}
			catch (Exception ex)
			{
			throw new Exception();
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
