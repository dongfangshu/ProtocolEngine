using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class BytesType : BaseType
    {
        public BytesType(string name) : base(name)
        {

        }

        public override Type ClrType => typeof(byte[]);

        public override string TypeName => "byte[]";

        public override string ReadCode(int layer) => $"{Name}= ByteBuffer.ReadBytes(data,ref offset);";

        public override string WriteCode() => $"ByteBuffer.WriteBytes({Name},data,ref offset);";
        public override string CtorCode => $"{Name} = new byte[0];";

        //public override string ComplateReadCode => $"{TypeName} {Name} = ByteBuffer.ReadBytes(data,ref offset);";
    }
}
