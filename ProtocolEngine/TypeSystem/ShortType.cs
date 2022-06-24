using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class ShortType : BaseType
    {
        public ShortType(string name) : base(name)
        {
        }

        public override Type ClrType => typeof(short);

        public override string TypeName => "short";

        public override string ReadCode => $"{Name} = ByteBuffer.ReadShort(data,ref offset);";

        public override string WriteCode => $"ByteBuffer.WriteShort({Name},data,ref offset);";
    }
}
