using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class CharType : BaseType
    {
        public CharType(string name) : base(name)
        {
        }

        public override Type ClrType => typeof(char);

        public override string TypeName => "char";

        public override bool IsValueType => true;

        public override string ReadCode(int layer) => $"{Name}= (char)ByteBuffer.ReadShort(data,ref offset);";

        public override string WriteCode(int layer) => $"ByteBuffer.WriteShort((short){Name},data,ref offset);";
    }
}
