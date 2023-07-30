using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class LinkedListType : BaseType
    {
        public BaseType GenericityType;
        public BaseType Count;
        private string tempListName;
        private string tempListCountName;
        private string tempListIndex;
        public LinkedListType(Type linkedListType, string name) : base(name)
        {
            //genericityType = type;
            
            GenericityType = TypeFacoty.GetType(linkedListType.GetGenericArguments()[0], $"{name}_linkedlist_node");
            Count = TypeFacoty.GetType(typeof(int), $"{name}_count");
            tempListName = name + "_temp_linkedlist";
            tempListCountName = name + "_temp_linkedlist_count";
            tempListIndex = name + "_index";
        }
        public override bool IsValueType => false;
        public override string CtorCode => $"{Name} = new LinkedList<{GenericityType.TypeName}>();";
        public override Type ClrType => throw new NotImplementedException();

        public override string TypeName => $"LinkedList<{GenericityType.TypeName}>";

        public override string ReadCode(int layer)
        {

            //ints.Count
            //ints.AddLast(0);
            //ints.AddLast(ints);

            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{TypeName} {tempListName} =new {TypeName}();");
            codeWriter.WriteLine($"int {tempListCountName} = ByteBuffer.ReadInt(data,ref offset);");
            codeWriter.WriteLine($"for(int {tempListIndex} = 0;{tempListIndex}<{tempListCountName};{tempListIndex}++ )");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{GenericityType.TypeName} {GenericityType.CtorCode}");
            codeWriter.WriteLine(GenericityType.ReadCode(layer + 1));
            codeWriter.WriteLine($"{tempListName}.AddLast({GenericityType.Name});");
            codeWriter.EndBlock();
            //codeWriter.WriteLine($"{Name}.AddRange({tempListName});");
            codeWriter.WriteLine($"{Name} = {tempListName};");
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }

        public override string WriteCode(int layer)
        {
            LinkedList<int> ints = new LinkedList<int>();
            var first = ints.First;
            //first.Value
            //while (first != null)
            //{
            //    first = first.Next;
            //}
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            //写入长度
            codeWriter.WriteLine($"{Count.TypeName} {Count.Name} = {Name}.Count;");
            codeWriter.WriteLine(Count.WriteCode(layer));
            codeWriter.WriteLine($"LinkedListNode<{GenericityType.TypeName}> first = {Name}.First;");
            codeWriter.WriteLine("while (first != null)");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{GenericityType.TypeName} {GenericityType.Name}=first.Value;");
            codeWriter.WriteLine(GenericityType.WriteCode(layer + 1));
            codeWriter.WriteLine("first = first.Next;");
            codeWriter.EndBlock();
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }
    }
}
