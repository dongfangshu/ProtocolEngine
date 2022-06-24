using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class ByteType : BaseType
    {
        public ByteType(string name) : base(name)
        {
        }

        public override Type ClrType => typeof(byte);

        public override string TypeName => "byte";

        public override string ReadCode => $"{Name} = ByteBuffer.ReadByte(data,ref offset);";

        public override string WriteCode => $"ByteBuffer.WriteByte({Name},data,ref offset);";

        //public override string ComplateReadCode => $"{TypeName} {Name} = ByteBuffer.ReadByte(data,ref offset);";
    }
}
