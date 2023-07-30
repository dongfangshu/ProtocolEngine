using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class ArrayType : BaseType
    {

        public BaseType InstanceType;
        public BaseType Count;
        private string tempListCountName;
        private string tempListIndex;
        public ArrayType(Type arrayType,string name):base(name)
        {
            Count = TypeFacoty.GetType(typeof(int),"array_count");
            InstanceType =TypeFacoty.GetType(arrayType.GetElementType(),name+"array_element");
            tempListCountName = name+"array_count";
            tempListIndex = name+"array_index";
        }
        public override bool IsValueType => false;

        public override Type ClrType => throw new NotImplementedException();

        public override string TypeName => $"{InstanceType.TypeName}[]";
        //public override string CtorCode => $"{Name} =new {InstanceType.TypeName}[]();";

        public override string ReadCode(int layer)
        {
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"int {tempListCountName} = ByteBuffer.ReadInt(data,ref offset);");
            codeWriter.WriteLine($"{Name} =new {InstanceType.TypeName}[{tempListCountName}];");
            codeWriter.WriteLine($"for(int {tempListIndex} = 0;{tempListIndex}<{tempListCountName};{tempListIndex}++ )");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{InstanceType.TypeName} {InstanceType.CtorCode}");
            codeWriter.WriteLine(InstanceType.ReadCode(layer + 1));
            codeWriter.WriteLine($"{Name}[{tempListIndex}] = {InstanceType.Name};");
            codeWriter.EndBlock();
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }

        public override string WriteCode(int layer)
        {
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{Count.TypeName} {Count.Name} = {Name}.Length;");
            codeWriter.WriteLine(Count.WriteCode(layer));
            codeWriter.WriteLine($"for(int {tempListIndex} =0;{tempListIndex}<{Count.Name};{tempListIndex}++)");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{InstanceType.TypeName} {InstanceType.Name}={Name}[{tempListIndex}];");
            codeWriter.WriteLine(InstanceType.WriteCode(layer));
            codeWriter.EndBlock();
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }
    }
}
