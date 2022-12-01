using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine.TypeSystem
{
    internal class Vector3Type : BaseType
    {
        private string X; private string Y; private string Z;
        public Vector3Type(string name) : base(name)
        {
            X = name + "_x";
            Y = name + "_y";
            Z = name + "_z";
        }

        public override bool IsValueType => true;

        public override Type ClrType => typeof(Vector3);

        public override string TypeName => "Vector3";

        public override string ReadCode(int layer)
        {
            //return $"{Name} = new Vector3()";
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.WriteLine($"float {X} = ByteBuffer.ReadFloat(data,ref offset);");
            codeWriter.WriteLine($"float {Y} = ByteBuffer.ReadFloat(data,ref offset);");
            codeWriter.WriteLine($"float {Z} = ByteBuffer.ReadFloat(data,ref offset);");
            codeWriter.WriteLine($"{Name} = new Vector3({X},{Y},{Z});");
            return codeWriter.ToString();
        }

        public override string WriteCode(int layer)
        {
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.WriteLine($"ByteBuffer.WriteFloat({Name}.X,data,ref offset);");
            codeWriter.WriteLine($"ByteBuffer.WriteFloat({Name}.Y,data,ref offset);");
            codeWriter.WriteLine($"ByteBuffer.WriteFloat({Name}.Y,data,ref offset);");
            return codeWriter.ToString();
        }
    }
}
