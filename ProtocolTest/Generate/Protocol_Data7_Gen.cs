using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;
namespace Protocol_Data7
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
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
			throw;
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
}
