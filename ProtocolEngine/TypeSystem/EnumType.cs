using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class EnumType : BaseType
    {
        Type Type;
        public EnumType(Type eType,string name) : base(name)
        {
            Type = eType;
        }

        public override Type ClrType => typeof(System.Enum);

        public override string TypeName => Type.FullName;

        public override string ReadCode => $"{Name} = ({Type.FullName})ByteBuffer.ReadInt(data,ref offset);";

        public override string WriteCode => $"ByteBuffer.WriteInt((int){Name},data,ref offset);";
    }
}
