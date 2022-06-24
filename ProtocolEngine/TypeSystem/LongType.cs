using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class LongType : BaseType
    {
        public LongType(string name) : base(name)
        {
        }

        public override Type ClrType => typeof(long);

        public override string TypeName => "long";

        public override string ReadCode => $"{Name} = ByteBuffer.ReadLong(data,ref offset);";

        public override string WriteCode => $"ByteBuffer.WriteLong({Name},data,ref offset);";
    }
}
