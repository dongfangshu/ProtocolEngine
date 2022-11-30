using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class IntType : BaseType
    {
        public IntType(string name) : base(name)
        {
        }

        public override Type ClrType => typeof(int);

        public override string TypeName => "int";

        public override bool IsValueType => true;

        public override string ReadCode(int layer) => $"{Name}= ByteBuffer.ReadInt(data,ref offset);";

        public override string WriteCode(int layer) => $"ByteBuffer.WriteInt({Name},data,ref offset);";
    }
}
