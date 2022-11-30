using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class ConstomType : BaseType
    {
        Type Type;

        public ConstomType(Type type,string name) : base(name)
        {
            Type = type;
        }

        public override Type ClrType => Type;

        public override string TypeName => Type.Name;

        public override string ReadCode(int layer)
        {
            CodeWriter codeWriter = new CodeWriter(layer);
            //codeWriter.WriteLine($"{Name} = new {TypeName}();");
            codeWriter.WriteLine($"{Name}.Read(data,ref offset);");
            return codeWriter.ToString();
        }
//        => @$"{Name} = new {TypeName}();
//{Name}.Read(data,ref offset);";

        public override string WriteCode(int layer) => $"{Name}.Write(data,ref offset);";
        public override string CtorCode => $"{Name} = new {TypeName}();";

        public override bool IsValueType => false;
        //public override string ComplateReadCode => @$"{TypeName} {Name} = new {Type.FullName}();
        //{Name}.Read(data,ref offset);";
    }
}
