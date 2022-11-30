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

        public override bool IsValueType => true;

        public override string ReadCode(int layer) => $"{Name} = ByteBuffer.ReadLong(data,ref offset);";

        public override string WriteCode(int layer) => $"ByteBuffer.WriteLong({Name},data,ref offset);";
    }
}
