namespace ProtocolEngine
{
    internal class DateTimeType : BaseType
    {
        public DateTimeType(string name) : base(name)
        {
        }

        public override bool IsValueType => throw new NotImplementedException();

        public override Type ClrType => throw new NotImplementedException();

        public override string TypeName => "DateTime";

        public override string ReadCode(int layer)
        {
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"long {Name}_tick = ByteBuffer.ReadLong(data,ref offset);");
            codeWriter.WriteLine($"{Name} = new DateTime({Name}_tick);");
            codeWriter.EndBlock();
            return codeWriter.ToString();   
        }

        public override string WriteCode(int layer)
        {
            //DateTime now;
            //now.Ticks
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"ByteBuffer.WriteLong({Name}.Ticks,data,ref offset);");
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }
    }
}