using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class BoolType : BaseType
    {
        public BoolType(string name) : base(name)
        {
        }

        public override Type ClrType => typeof(bool);

        public override string TypeName => "bool";

        public override bool IsValueType => true;

        public override string ReadCode(int layer) => $"{Name} = ByteBuffer.ReadBool(data,ref offset);";

        public override string WriteCode(int layer) => $"ByteBuffer.WriteBool({Name},data,ref offset);";


        //public override string ComplateReadCode => $"{TypeName} {Name} = ByteBuffer.ReadBool(data,ref offset);";
    }
}
