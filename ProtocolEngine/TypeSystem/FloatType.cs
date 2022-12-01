using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine.TypeSystem
{
    internal class FloatType : BaseType
    {
        public FloatType(string name) : base(name)
        {
        }

        public override bool IsValueType => true;

        public override Type ClrType => typeof(float);

        public override string TypeName => "float";

        public override string ReadCode(int layer)
        {
            return $"{Name} = ByteBuffer.ReadFloat(data,ref offset);";
        }

        public override string WriteCode(int layer)
        {
            return $"ByteBuffer.WriteFloat({Name},data,ref offset);";
        }
    }
}
