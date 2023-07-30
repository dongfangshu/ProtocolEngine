using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{

    internal class QueueType : BaseType
    {
        public BaseType GenericityType;
        public BaseType Count;
        private string tempCountName;
        private string tempListIndex;
        public QueueType(Type QueueType, string name) : base(name)
        {
            //genericityType = type;
            tempCountName = name + "_temp_count";
            tempListIndex = name + "_index";
            GenericityType = TypeFacoty.GetType(QueueType.GetGenericArguments()[0], $"{name}_queue_element");
            Count = TypeFacoty.GetType(typeof(int), $"{name}_count");
        }
        public override bool IsValueType => false;
        public override string CtorCode =>$"{Name} = new Queue<{GenericityType.TypeName}>();";

        public override Type ClrType => throw new NotImplementedException();

        public override string TypeName =>$"Queue<{GenericityType.TypeName}>";

        public override string ReadCode(int layer)
        {
            //Queue<int> ints = new Queue<int>();
            //ints.Enqueue(0);
            //ints.Dequeue();

            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"int {tempCountName} = ByteBuffer.ReadInt(data,ref offset);");
            codeWriter.WriteLine($"for(int {tempListIndex} = 0;{tempListIndex}<{tempCountName};{tempListIndex}++ )");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{GenericityType.TypeName} {GenericityType.CtorCode}");
            codeWriter.WriteLine(GenericityType.ReadCode(layer + 1));
            codeWriter.WriteLine($"{Name}.Enqueue({GenericityType.Name});");
            codeWriter.EndBlock();
            //codeWriter.WriteLine($"{Name}.AddRange({tempListName});");
            //codeWriter.WriteLine($"{Name} = {tempListName};");
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }

        public override string WriteCode(int layer)
        {
            //Queue<int> ints = new Queue<int>();
            //foreach (var item in ints)
            //{
                
            //}
            //ints.GetEnumerator();
            //ints.Dequeue();

            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"ByteBuffer.WriteInt({Name}.Count,data,ref offset);");
            codeWriter.WriteLine($"foreach (var {GenericityType.Name} in {Name})");
            codeWriter.StartBlock();
            codeWriter.WriteLine(GenericityType.WriteCode(layer));
            codeWriter.EndBlock();
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }
    }
}
