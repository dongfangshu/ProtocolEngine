using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchMark;
using ProtocolEngine;

namespace BenchMark
{
    /** This is an automatically generated class by Protocol. Please do not modify it. **/
    public enum EResourceType
    {
        Type1 = 0,
        Type2 = 1,
        Type3 = 2,
        Type4 = 3,
        Type5 = 4,
    }
    public class User : Protocol
    {
        public long ID;
        public string Name;
        public List<Resources> UserResources;
        public Dictionary<string, string> UserResourcesDictionary;
        public DateTime DateTime;
        public int[] IntArray;
        public char SingleChar;
        public char[] CharArray;
        public int Count;
        public string Str;
        public string Title;
        public List<string> Tags;
        public bool BoolValue;
        public Dictionary<int, Commit> CommitDir;
        public TimeSpan TimeSpan;
        public Queue<int> Queue;
        public Stack<int> Stack;
        public LinkedList<int> LinkedList;
        public User()
        {
            ID = default(long);
            Name = string.Empty;
            UserResources = new List<Resources>();
            UserResourcesDictionary = new Dictionary<string, string>();
            DateTime = default(DateTime);
            IntArray = new int[0];
            SingleChar = default(char);
            CharArray = new char[0];
            Count = default(int);
            Str = string.Empty;
            Title = string.Empty;
            Tags = new List<string>();
            BoolValue = default(bool);
            CommitDir = new Dictionary<int, Commit>();
            TimeSpan = default(TimeSpan);
            Queue = default(Queue<int>);
            Stack = new Stack<int>();
            LinkedList = default(LinkedList<int>);
        }
        public override void Read(byte[] data, ref int offset)
        {
            ID = ByteBuffer.ReadLong(data, ref offset);
            Name = ByteBuffer.ReadString(data, ref offset);
            {
                List<Resources> UserResources_temp_list = new List<Resources>();
                int UserResources_temp_list_count = ByteBuffer.ReadInt(data, ref offset);
                for (int UserResources_index = 0; UserResources_index < UserResources_temp_list_count; UserResources_index++)
                {
                    Resources UserResources_list_element = new Resources();
                    UserResources_list_element.Read(data, ref offset);

                    UserResources_temp_list.Add(UserResources_list_element);
                }
                UserResources.AddRange(UserResources_temp_list);
            }

            {
                int UserResourcesDictionary_count = ByteBuffer.ReadInt(data, ref offset);
                for (int UserResourcesDictionary_index = 0; UserResourcesDictionary_index < UserResourcesDictionary_count; UserResourcesDictionary_index++)
                {
                    string UserResourcesDictionary_key = string.Empty;
                    UserResourcesDictionary_key = ByteBuffer.ReadString(data, ref offset);
                    string UserResourcesDictionary_value = string.Empty;
                    UserResourcesDictionary_value = ByteBuffer.ReadString(data, ref offset);
                    UserResourcesDictionary.Add(UserResourcesDictionary_key, UserResourcesDictionary_value);
                }
            }

            {
                long DateTime_tick = ByteBuffer.ReadLong(data, ref offset);
                DateTime = new DateTime(DateTime_tick);
            }

            {
                int IntArrayarray_count = ByteBuffer.ReadInt(data, ref offset);
                IntArray = new int[IntArrayarray_count];
                for (int IntArrayarray_index = 0; IntArrayarray_index < IntArrayarray_count; IntArrayarray_index++)
                {
                    int IntArrayarray_element = default(int);
                    IntArrayarray_element = ByteBuffer.ReadInt(data, ref offset);
                    IntArray[IntArrayarray_index] = IntArrayarray_element;
                }
            }

            SingleChar = (char)ByteBuffer.ReadShort(data, ref offset);
            {
                int CharArrayarray_count = ByteBuffer.ReadInt(data, ref offset);
                CharArray = new char[CharArrayarray_count];
                for (int CharArrayarray_index = 0; CharArrayarray_index < CharArrayarray_count; CharArrayarray_index++)
                {
                    char CharArrayarray_element = default(char);
                    CharArrayarray_element = (char)ByteBuffer.ReadShort(data, ref offset);
                    CharArray[CharArrayarray_index] = CharArrayarray_element;
                }
            }

            Count = ByteBuffer.ReadInt(data, ref offset);
            Str = ByteBuffer.ReadString(data, ref offset);
            Title = ByteBuffer.ReadString(data, ref offset);
            {
                List<string> Tags_temp_list = new List<string>();
                int Tags_temp_list_count = ByteBuffer.ReadInt(data, ref offset);
                for (int Tags_index = 0; Tags_index < Tags_temp_list_count; Tags_index++)
                {
                    string Tags_list_element = string.Empty;
                    Tags_list_element = ByteBuffer.ReadString(data, ref offset);
                    Tags_temp_list.Add(Tags_list_element);
                }
                Tags.AddRange(Tags_temp_list);
            }

            BoolValue = ByteBuffer.ReadBool(data, ref offset);
            {
                int CommitDir_count = ByteBuffer.ReadInt(data, ref offset);
                for (int CommitDir_index = 0; CommitDir_index < CommitDir_count; CommitDir_index++)
                {
                    int CommitDir_key = default(int);
                    CommitDir_key = ByteBuffer.ReadInt(data, ref offset);
                    Commit CommitDir_value = new Commit();
                    CommitDir_value.Read(data, ref offset);

                    CommitDir.Add(CommitDir_key, CommitDir_value);
                }
            }

            {
                long TimeSpan_tick = ByteBuffer.ReadLong(data, ref offset);
                TimeSpan = TimeSpan.FromTicks(TimeSpan_tick);
            }

            {
                int Queue_temp_count = ByteBuffer.ReadInt(data, ref offset);
                for (int Queue_index = 0; Queue_index < Queue_temp_count; Queue_index++)
                {
                    int Queue_queue_element = default(int);
                    Queue_queue_element = ByteBuffer.ReadInt(data, ref offset);
                    Queue.Enqueue(Queue_queue_element);
                }
            }

            {
                int Stack_temp_count = ByteBuffer.ReadInt(data, ref offset);
                for (int Stack_index = 0; Stack_index < Stack_temp_count; Stack_index++)
                {
                    int Stack_stack_element = default(int);
                    Stack_stack_element = ByteBuffer.ReadInt(data, ref offset);
                    Stack.Push(Stack_stack_element);
                }
            }

            {
                LinkedList<int> LinkedList_temp_linkedlist = new LinkedList<int>();
                int LinkedList_temp_linkedlist_count = ByteBuffer.ReadInt(data, ref offset);
                for (int LinkedList_index = 0; LinkedList_index < LinkedList_temp_linkedlist_count; LinkedList_index++)
                {
                    int LinkedList_linkedlist_node = default(int);
                    LinkedList_linkedlist_node = ByteBuffer.ReadInt(data, ref offset);
                    LinkedList_temp_linkedlist.AddLast(LinkedList_linkedlist_node);
                }
                LinkedList = LinkedList_temp_linkedlist;
            }

        }
        public override void Write(byte[] data, ref int offset)
        {
            ByteBuffer.WriteLong(ID, data, ref offset);
            ByteBuffer.WriteString(Name, data, ref offset);
            {
                int UserResources_count = UserResources.Count;
                ByteBuffer.WriteInt(UserResources_count, data, ref offset);
                for (int UserResources_index = 0; UserResources_index < UserResources_count; UserResources_index++)
                {
                    Resources UserResources_list_element = UserResources[UserResources_index];
                    UserResources_list_element.Write(data, ref offset);
                }
            }

            {
                int UserResourcesDictionary_count = UserResourcesDictionary.Count;
                ByteBuffer.WriteInt(UserResourcesDictionary_count, data, ref offset);
                foreach (var UserResourcesDictionary_item in UserResourcesDictionary)
                {
                    string UserResourcesDictionary_key = UserResourcesDictionary_item.Key;
                    ByteBuffer.WriteString(UserResourcesDictionary_key, data, ref offset);
                    string UserResourcesDictionary_value = UserResourcesDictionary_item.Value;
                    ByteBuffer.WriteString(UserResourcesDictionary_value, data, ref offset);
                }
            }

            {
                ByteBuffer.WriteLong(DateTime.Ticks, data, ref offset);
            }

            {
                int array_count = IntArray.Length;
                ByteBuffer.WriteInt(array_count, data, ref offset);
                for (int IntArrayarray_index = 0; IntArrayarray_index < array_count; IntArrayarray_index++)
                {
                    int IntArrayarray_element = IntArray[IntArrayarray_index];
                    ByteBuffer.WriteInt(IntArrayarray_element, data, ref offset);
                }
            }

            ByteBuffer.WriteShort((short)SingleChar, data, ref offset);
            {
                int array_count = CharArray.Length;
                ByteBuffer.WriteInt(array_count, data, ref offset);
                for (int CharArrayarray_index = 0; CharArrayarray_index < array_count; CharArrayarray_index++)
                {
                    char CharArrayarray_element = CharArray[CharArrayarray_index];
                    ByteBuffer.WriteShort((short)CharArrayarray_element, data, ref offset);
                }
            }

            ByteBuffer.WriteInt(Count, data, ref offset);
            ByteBuffer.WriteString(Str, data, ref offset);
            ByteBuffer.WriteString(Title, data, ref offset);
            {
                int Tags_count = Tags.Count;
                ByteBuffer.WriteInt(Tags_count, data, ref offset);
                for (int Tags_index = 0; Tags_index < Tags_count; Tags_index++)
                {
                    string Tags_list_element = Tags[Tags_index];
                    ByteBuffer.WriteString(Tags_list_element, data, ref offset);
                }
            }

            ByteBuffer.WriteBool(BoolValue, data, ref offset);
            {
                int CommitDir_count = CommitDir.Count;
                ByteBuffer.WriteInt(CommitDir_count, data, ref offset);
                foreach (var CommitDir_item in CommitDir)
                {
                    int CommitDir_key = CommitDir_item.Key;
                    ByteBuffer.WriteInt(CommitDir_key, data, ref offset);
                    Commit CommitDir_value = CommitDir_item.Value;
                    CommitDir_value.Write(data, ref offset);
                }
            }

            {
                ByteBuffer.WriteLong(TimeSpan.Ticks, data, ref offset);
            }

            {
                foreach (var Queue_queue_element in Queue)
                {
                    ByteBuffer.WriteInt(Queue_queue_element, data, ref offset);
                }
            }

            {
                foreach (var Stack_stack_element in Stack)
                {
                    ByteBuffer.WriteInt(Stack_stack_element, data, ref offset);
                }
            }

            {
                int LinkedList_count = LinkedList.Count;
                ByteBuffer.WriteInt(LinkedList_count, data, ref offset);
                LinkedListNode<int> first = LinkedList.First;
                while (first != null)
                {
                    int LinkedList_linkedlist_node = first.Value;
                    ByteBuffer.WriteInt(LinkedList_linkedlist_node, data, ref offset);
                    first = first.Next;
                }
            }

        }
    }
    public class Resources : Protocol
    {
        public BenchMark.EResourceType ResourceType;
        public string ResourceName;
        public int ResourceCount;
        public Resources()
        {
            //			ResourceType = default(BenchMark.EResourceType);
            //			ResourceName = string.Empty;
            //			ResourceCount = default(int);
        }
        public override void Read(byte[] data, ref int offset)
        {
            ResourceType = (BenchMark.EResourceType)ByteBuffer.ReadInt(data, ref offset);
            ResourceName = ByteBuffer.ReadString(data, ref offset);
            ResourceCount = ByteBuffer.ReadInt(data, ref offset);
        }
        public override void Write(byte[] data, ref int offset)
        {
            ByteBuffer.WriteInt((int)ResourceType, data, ref offset);
            ByteBuffer.WriteString(ResourceName, data, ref offset);
            ByteBuffer.WriteInt(ResourceCount, data, ref offset);
        }
    }
    public class Commit : Protocol
    {
        public int ID;
        public string Event;
        public Commit()
        {
            //			ID = default(int);
            //			Event = string.Empty;
        }
        public override void Read(byte[] data, ref int offset)
        {
            ID = ByteBuffer.ReadInt(data, ref offset);
            Event = ByteBuffer.ReadString(data, ref offset);
        }
        public override void Write(byte[] data, ref int offset)
        {
            ByteBuffer.WriteInt(ID, data, ref offset);
            ByteBuffer.WriteString(Event, data, ref offset);
        }
    }
}
