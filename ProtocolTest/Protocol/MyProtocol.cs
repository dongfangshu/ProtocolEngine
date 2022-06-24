using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtocolEngine;

namespace Test
{
    public enum MyEnum
    {
        Name,
    }
    public partial class MyProtocol
    {
        public int ID;
        public string Name;
        public bool Bool;
        public long Long;
        public short Short;
        public byte Byte;
        public byte[] Bytes;
        public ItemInfo itemInfo;
        public List<int> items;
        public Dictionary<int, ItemInfo> itemsDict;
        [Ignore]
        public MyEnum MyEnum;
    }
    public partial class Parent
    {
        public int Name;
        public Dictionary<MyEnum, GridInfo> GridInfoDic;
    }
    public partial class Son : Parent
    {
        public int Speed;
    }
    public partial class ItemInfo
    {
        public int ID;
        public GridInfo GridInfo;
    }
    public partial class GridInfo
    {
        public int GridPos;
    }
}
