using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class StackType : BaseType
    {
        private string tempListIndex;
        public BaseType GenericityType;
        private string tempCountName;

        public StackType(Type stackType, string name) : base(name)
        {
            //genericityType = type;
            tempCountName = name + "_temp_count";
            tempListIndex = name + "_index";
            GenericityType = TypeFacoty.GetType(stackType.GetGenericArguments()[0], $"{name}_stack_element");
        }
        public override string CtorCode => $"{Name} = new Stack<{GenericityType.TypeName}>();";
        public override bool IsValueType => false;

        public override Type ClrType => throw new NotImplementedException();

        public override string TypeName => $"Stack<{GenericityType.TypeName}>";

        public override string ReadCode(int layer)
        {
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"int {tempCountName} = ByteBuffer.ReadInt(data,ref offset);");
            codeWriter.WriteLine($"for(int {tempListIndex} = 0;{tempListIndex}<{tempCountName};{tempListIndex}++ )");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{GenericityType.TypeName} {GenericityType.CtorCode}");
            codeWriter.WriteLine(GenericityType.ReadCode(layer + 1));
            codeWriter.WriteLine($"{Name}.Push({GenericityType.Name});");
            codeWriter.EndBlock();
            //codeWriter.WriteLine($"{Name}.AddRange({tempListName});");
            //codeWriter.WriteLine($"{Name} = {tempListName};");
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }

        public override string WriteCode(int layer)
        {
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
