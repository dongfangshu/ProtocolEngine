namespace ProtocolEngine
{
    internal class TimeSpanType : BaseType
    {
        public TimeSpanType(string name) : base(name)
        {
        }

        public override bool IsValueType => throw new NotImplementedException();

        public override Type ClrType => throw new NotImplementedException();

        public override string TypeName => "TimeSpan";

        public override string ReadCode(int layer)
        {
            //TimeSpan timeSpan =TimeSpan.FromTicks(0);
            //timeSpan.Ticks = 0;
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"long {Name}_tick = ByteBuffer.ReadLong(data,ref offset);");
            codeWriter.WriteLine($"{Name} = TimeSpan.FromTicks({Name}_tick);");
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }

        public override string WriteCode(int layer)
        {
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"ByteBuffer.WriteLong({Name}.Ticks,data,ref offset);");
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }
    }
}