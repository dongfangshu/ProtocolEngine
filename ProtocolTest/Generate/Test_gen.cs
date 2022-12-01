using ProtocolEngine;
namespace Hero
{
    public enum MyEnum
    {
        One = 1,
        Two = 2,
        Three,
        Four = 3,
    }
    public class HeroInfo : Protocol
    {
        public List<Suit> suitList;
        public List<List<Hero.MyEnum>> list;
        public List<Dictionary<int, int>> list3;
        public Dictionary<int, Suit> suitMap;
        public Dictionary<int, List<int>> dic;
        public Dictionary<int, Dictionary<int, int>> dic3;
        public HeroInfo()
        {
            suitList = new List<Suit>();
            list = new List<List<Hero.MyEnum>>();
            list3 = new List<Dictionary<int, int>>();
            suitMap = new Dictionary<int, Suit>();
            dic = new Dictionary<int, List<int>>();
            dic3 = new Dictionary<int, Dictionary<int, int>>();
        }
        public override void Read(byte[] data, ref int offset)
        {
            try
            {
                {
                    List<Suit> suitList_temp_list = new List<Suit>();
                    int suitList_temp_list_count = ByteBuffer.ReadInt(data, ref offset);
                    for (int suitList_index = 0; suitList_index < suitList_temp_list_count; suitList_index++)
                    {
                        Suit suitList_list_element = new Suit();
                        suitList_list_element.Read(data, ref offset);

                        suitList_temp_list.Add(suitList_list_element);
                    }
                    suitList.AddRange(suitList_temp_list);
                }

                {
                    List<List<Hero.MyEnum>> list_temp_list = new List<List<Hero.MyEnum>>();
                    int list_temp_list_count = ByteBuffer.ReadInt(data, ref offset);
                    for (int list_index = 0; list_index < list_temp_list_count; list_index++)
                    {
                        List<Hero.MyEnum> list_list_element = new List<Hero.MyEnum>();
                        {
                            List<Hero.MyEnum> list_list_element_temp_list = new List<Hero.MyEnum>();
                            int list_list_element_temp_list_count = ByteBuffer.ReadInt(data, ref offset);
                            for (int list_list_element_index = 0; list_list_element_index < list_list_element_temp_list_count; list_list_element_index++)
                            {
                                Hero.MyEnum list_list_element_list_element = default(Hero.MyEnum);
                                list_list_element_list_element = (Hero.MyEnum)ByteBuffer.ReadInt(data, ref offset);
                                list_list_element_temp_list.Add(list_list_element_list_element);
                            }
                            list_list_element.AddRange(list_list_element_temp_list);
                        }

                        list_temp_list.Add(list_list_element);
                    }
                    list.AddRange(list_temp_list);
                }

                {
                    List<Dictionary<int, int>> list3_temp_list = new List<Dictionary<int, int>>();
                    int list3_temp_list_count = ByteBuffer.ReadInt(data, ref offset);
                    for (int list3_index = 0; list3_index < list3_temp_list_count; list3_index++)
                    {
                        Dictionary<int, int> list3_list_element = new Dictionary<int, int>();
                        {
                            int list3_list_element_count = ByteBuffer.ReadInt(data, ref offset);
                            for (int list3_list_element_index = 0; list3_list_element_index < list3_list_element_count; list3_list_element_index++)
                            {
                                int list3_list_element_key = default(int);
                                list3_list_element_key = ByteBuffer.ReadInt(data, ref offset);
                                int list3_list_element_value = default(int);
                                list3_list_element_value = ByteBuffer.ReadInt(data, ref offset);
                                list3_list_element.Add(list3_list_element_key, list3_list_element_value);
                            }
                        }

                        list3_temp_list.Add(list3_list_element);
                    }
                    list3.AddRange(list3_temp_list);
                }

                {
                    int suitMap_count = ByteBuffer.ReadInt(data, ref offset);
                    for (int suitMap_index = 0; suitMap_index < suitMap_count; suitMap_index++)
                    {
                        int suitMap_key = default(int);
                        suitMap_key = ByteBuffer.ReadInt(data, ref offset);
                        Suit suitMap_value = new Suit();
                        suitMap_value.Read(data, ref offset);

                        suitMap.Add(suitMap_key, suitMap_value);
                    }
                }

                {
                    int dic_count = ByteBuffer.ReadInt(data, ref offset);
                    for (int dic_index = 0; dic_index < dic_count; dic_index++)
                    {
                        int dic_key = default(int);
                        dic_key = ByteBuffer.ReadInt(data, ref offset);
                        List<int> dic_value = new List<int>();
                        {
                            List<int> dic_value_temp_list = new List<int>();
                            int dic_value_temp_list_count = ByteBuffer.ReadInt(data, ref offset);
                            for (int dic_value_index = 0; dic_value_index < dic_value_temp_list_count; dic_value_index++)
                            {
                                int dic_value_list_element = default(int);
                                dic_value_list_element = ByteBuffer.ReadInt(data, ref offset);
                                dic_value_temp_list.Add(dic_value_list_element);
                            }
                            dic_value.AddRange(dic_value_temp_list);
                        }

                        dic.Add(dic_key, dic_value);
                    }
                }

                {
                    int dic3_count = ByteBuffer.ReadInt(data, ref offset);
                    for (int dic3_index = 0; dic3_index < dic3_count; dic3_index++)
                    {
                        int dic3_key = default(int);
                        dic3_key = ByteBuffer.ReadInt(data, ref offset);
                        Dictionary<int, int> dic3_value = new Dictionary<int, int>();
                        {
                            int dic3_value_count = ByteBuffer.ReadInt(data, ref offset);
                            for (int dic3_value_index = 0; dic3_value_index < dic3_value_count; dic3_value_index++)
                            {
                                int dic3_value_key = default(int);
                                dic3_value_key = ByteBuffer.ReadInt(data, ref offset);
                                int dic3_value_value = default(int);
                                dic3_value_value = ByteBuffer.ReadInt(data, ref offset);
                                dic3_value.Add(dic3_value_key, dic3_value_value);
                            }
                        }

                        dic3.Add(dic3_key, dic3_value);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public override void Write(byte[] data, ref int offset)
        {
            {
                int suitList_count = suitList.Count;
                ByteBuffer.WriteInt(suitList_count, data, ref offset);
                for (int suitList_index = 0; suitList_index < suitList_count; suitList_index++)
                {
                    Suit suitList_list_element = suitList[suitList_index];
                    suitList_list_element.Write(data, ref offset);
                }
            }

            {
                int list_count = list.Count;
                ByteBuffer.WriteInt(list_count, data, ref offset);
                for (int list_index = 0; list_index < list_count; list_index++)
                {
                    List<Hero.MyEnum> list_list_element = list[list_index];
                    {
                        int list_list_element_count = list_list_element.Count;
                        ByteBuffer.WriteInt(list_list_element_count, data, ref offset);
                        for (int list_list_element_index = 0; list_list_element_index < list_list_element_count; list_list_element_index++)
                        {
                            Hero.MyEnum list_list_element_list_element = list_list_element[list_list_element_index];
                            ByteBuffer.WriteInt((int)list_list_element_list_element, data, ref offset);
                        }
                    }

                }
            }

            {
                int list3_count = list3.Count;
                ByteBuffer.WriteInt(list3_count, data, ref offset);
                for (int list3_index = 0; list3_index < list3_count; list3_index++)
                {
                    Dictionary<int, int> list3_list_element = list3[list3_index];
                    {
                        int list3_list_element_count = list3_list_element.Count;
                        ByteBuffer.WriteInt(list3_list_element_count, data, ref offset);
                        foreach (var list3_list_element_item in list3_list_element)
                        {
                            int list3_list_element_key = list3_list_element_item.Key;
                            ByteBuffer.WriteInt(list3_list_element_key, data, ref offset);
                            int list3_list_element_value = list3_list_element_item.Value;
                            ByteBuffer.WriteInt(list3_list_element_value, data, ref offset);
                        }
                    }

                }
            }

            {
                int suitMap_count = suitMap.Count;
                ByteBuffer.WriteInt(suitMap_count, data, ref offset);
                foreach (var suitMap_item in suitMap)
                {
                    int suitMap_key = suitMap_item.Key;
                    ByteBuffer.WriteInt(suitMap_key, data, ref offset);
                    Suit suitMap_value = suitMap_item.Value;
                    suitMap_value.Write(data, ref offset);
                }
            }

            {
                int dic_count = dic.Count;
                ByteBuffer.WriteInt(dic_count, data, ref offset);
                foreach (var dic_item in dic)
                {
                    int dic_key = dic_item.Key;
                    ByteBuffer.WriteInt(dic_key, data, ref offset);
                    List<int> dic_value = dic_item.Value;
                    {
                        int dic_value_count = dic_value.Count;
                        ByteBuffer.WriteInt(dic_value_count, data, ref offset);
                        for (int dic_value_index = 0; dic_value_index < dic_value_count; dic_value_index++)
                        {
                            int dic_value_list_element = dic_value[dic_value_index];
                            ByteBuffer.WriteInt(dic_value_list_element, data, ref offset);
                        }
                    }

                }
            }

            {
                int dic3_count = dic3.Count;
                ByteBuffer.WriteInt(dic3_count, data, ref offset);
                foreach (var dic3_item in dic3)
                {
                    int dic3_key = dic3_item.Key;
                    ByteBuffer.WriteInt(dic3_key, data, ref offset);
                    Dictionary<int, int> dic3_value = dic3_item.Value;
                    {
                        int dic3_value_count = dic3_value.Count;
                        ByteBuffer.WriteInt(dic3_value_count, data, ref offset);
                        foreach (var dic3_value_item in dic3_value)
                        {
                            int dic3_value_key = dic3_value_item.Key;
                            ByteBuffer.WriteInt(dic3_value_key, data, ref offset);
                            int dic3_value_value = dic3_value_item.Value;
                            ByteBuffer.WriteInt(dic3_value_value, data, ref offset);
                        }
                    }

                }
            }

        }
    }
    public class Suit : Protocol
    {
        int Id;
        string icon;
        string name;
        public Suit()
        {
            Id = default(int);
            icon = string.Empty;
            name = string.Empty;
        }
        public override void Read(byte[] data, ref int offset)
        {
            try
            {
                Id = ByteBuffer.ReadInt(data, ref offset);
                icon = ByteBuffer.ReadString(data, ref offset);
                name = ByteBuffer.ReadString(data, ref offset);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override void Write(byte[] data, ref int offset)
        {
            ByteBuffer.WriteInt(Id, data, ref offset);
            ByteBuffer.WriteString(icon, data, ref offset);
            ByteBuffer.WriteString(name, data, ref offset);
        }
    }
}
