
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using ProtocolEngine;

using Test;

/*
 * Automatic generation Do not modify
 * */
namespace Proto.Test
{
//enumDefinition

public enum MyEnum
{
    
        Name,
        
}





    public class MyProtocol:Protocol
    {
    //fieldDefinition
    
        public int ID;
        
        public string Name;
        
        public bool Bool;
        
        public long Long;
        
        public short Short;
        
        public byte Byte;
        
        public byte[] Bytes;
        
        public ItemInfo itemInfo;
        
        public List<int> items;
        
        public Dictionary<int,ItemInfo> itemsDict;
        

    //ctor
    public  MyProtocol()
    {
    
        ID = default(int);
        
        Name = string.Empty;
        
        Bool = default(bool);
        
        Long = default(long);
        
        Short = default(short);
        
        Byte = default(byte);
        
        Bytes = new byte[0];
        
        itemInfo = null;
        
        items = new List<int>();
        
        itemsDict = new Dictionary<int,ItemInfo>();
        
    }

    //Read
    public override void Read(byte[] data, ref int offset)
    {
        

        
                ID = ByteBuffer.ReadInt(data,ref offset);
                
                Name = ByteBuffer.ReadString(data,ref offset);
                
                Bool = ByteBuffer.ReadBool(data,ref offset);
                
                Long = ByteBuffer.ReadLong(data,ref offset);
                
                Short = ByteBuffer.ReadShort(data,ref offset);
                
                Byte = ByteBuffer.ReadByte(data,ref offset);
                
                Bytes = ByteBuffer.ReadBytes(data,ref offset);
                
                itemInfo = new ItemInfo();
        itemInfo.Read(data,ref offset);
                
                
        {
        int listCount = ByteBuffer.ReadInt(data,ref offset);
        for(int i = 0;i<listCount;i++ )
        {
           int listElement = ByteBuffer.ReadInt(data,ref offset);
            items.Add(listElement);
        }
        }
        
                
                
        {
        int Count = ByteBuffer.ReadInt(data,ref offset);;
        for(int i =0;i<Count;i++)
        {
            int Key = ByteBuffer.ReadInt(data,ref offset);;
            ItemInfo Value = new ItemInfo();
        Value.Read(data,ref offset);;
            itemsDict.Add(Key,Value);
        }
        }
                
    }

    //Write
    public override void Write(byte[] data, ref int offset)
    {
        
                ByteBuffer.WriteInt(ID,data,ref offset);
                
                ByteBuffer.WriteString(Name,data,ref offset);
                
                ByteBuffer.WriteBool(Bool,data,ref offset);
                
                ByteBuffer.WriteLong(Long,data,ref offset);
                
                ByteBuffer.WriteShort(Short,data,ref offset);
                
                ByteBuffer.WriteByte(Byte,data,ref offset);
                
                ByteBuffer.WriteBytes(Bytes,data,ref offset);
                
                itemInfo.Write(data,ref offset);
                
                
        {
        int Count = items.Count;
        ByteBuffer.WriteInt(Count,data,ref offset);
        for(int i =0;i<Count;i++)
        {
            int listElement=items[i];
            ByteBuffer.WriteInt(listElement,data,ref offset);
        }
        }
                
                
        {
        int Count = itemsDict.Count;
        ByteBuffer.WriteInt(Count,data,ref offset);;
        foreach(var item in itemsDict)
        {
            int Key = item.Key;
            ByteBuffer.WriteInt(Key,data,ref offset);
            ItemInfo Value = item.Value;
            Value.Write(data,ref offset);
        }
        }
                
    }
    }

    public class Parent:Protocol
    {
    //fieldDefinition
    
        public int Name;
        
        public Dictionary<Test.MyEnum,GridInfo> GridInfoDic;
        

    //ctor
    public  Parent()
    {
    
        Name = default(int);
        
        GridInfoDic = new Dictionary<Test.MyEnum,GridInfo>();
        
    }

    //Read
    public override void Read(byte[] data, ref int offset)
    {
        

        
                Name = ByteBuffer.ReadInt(data,ref offset);
                
                
        {
        int Count = ByteBuffer.ReadInt(data,ref offset);;
        for(int i =0;i<Count;i++)
        {
            Test.MyEnum Key = (Test.MyEnum)ByteBuffer.ReadInt(data,ref offset);;
            GridInfo Value = new GridInfo();
        Value.Read(data,ref offset);;
            GridInfoDic.Add(Key,Value);
        }
        }
                
    }

    //Write
    public override void Write(byte[] data, ref int offset)
    {
        
                ByteBuffer.WriteInt(Name,data,ref offset);
                
                
        {
        int Count = GridInfoDic.Count;
        ByteBuffer.WriteInt(Count,data,ref offset);;
        foreach(var item in GridInfoDic)
        {
            Test.MyEnum Key = item.Key;
            ByteBuffer.WriteInt((int)Key,data,ref offset);
            GridInfo Value = item.Value;
            Value.Write(data,ref offset);
        }
        }
                
    }
    }

    public class Son:Test.Parent
    {
    //fieldDefinition
    
        public int Speed;
        

    //ctor
    public  Son()
    {
    
        Speed = default(int);
        
    }

    //Read
    public override void Read(byte[] data, ref int offset)
    {
        
                base.Read(data,ref offset);
                

        
                Speed = ByteBuffer.ReadInt(data,ref offset);
                
    }

    //Write
    public override void Write(byte[] data, ref int offset)
    {
        
                ByteBuffer.WriteInt(Speed,data,ref offset);
                
    }
    }

    public class ItemInfo:Protocol
    {
    //fieldDefinition
    
        public int ID;
        
        public GridInfo GridInfo;
        

    //ctor
    public  ItemInfo()
    {
    
        ID = default(int);
        
        GridInfo = null;
        
    }

    //Read
    public override void Read(byte[] data, ref int offset)
    {
        

        
                ID = ByteBuffer.ReadInt(data,ref offset);
                
                GridInfo = new GridInfo();
        GridInfo.Read(data,ref offset);
                
    }

    //Write
    public override void Write(byte[] data, ref int offset)
    {
        
                ByteBuffer.WriteInt(ID,data,ref offset);
                
                GridInfo.Write(data,ref offset);
                
    }
    }

    public class GridInfo:Protocol
    {
    //fieldDefinition
    
        public int GridPos;
        

    //ctor
    public  GridInfo()
    {
    
        GridPos = default(int);
        
    }

    //Read
    public override void Read(byte[] data, ref int offset)
    {
        

        
                GridPos = ByteBuffer.ReadInt(data,ref offset);
                
    }

    //Write
    public override void Write(byte[] data, ref int offset)
    {
        
                ByteBuffer.WriteInt(GridPos,data,ref offset);
                
    }
    }

}
