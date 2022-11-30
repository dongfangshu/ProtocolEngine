using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class StringType : BaseType
    {
        public StringType(string name) : base(name)
        {
        }
        public override string CtorCode => $"{Name} = string.Empty;";
        public override Type ClrType => typeof(string);

        public override string TypeName => "string";

        public override string ReadCode(int layer) => $"{Name} = ByteBuffer.ReadString(data,ref offset);";

        public override string WriteCode() => $"ByteBuffer.WriteString({Name},data,ref offset);";
    }
}
