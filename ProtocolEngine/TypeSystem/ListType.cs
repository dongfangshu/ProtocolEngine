using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class ListType : BaseType
    {
        public BaseType GenericityType;
        public BaseType Count;
        private string tempListName;
        private string tempListCountName;
        private string tempListIndex;
        public ListType(Type type,string name) : base(name)
        {
            //genericityType = type;
            GenericityType = TypeFacoty.GetType(type, $"{name}_list_element");
            Count = TypeFacoty.GetType(typeof(int), $"{name}_count");
            tempListName = name + "_temp_list";
            tempListCountName = name + "_temp_list_count";
            tempListIndex = name + "_index";
        }
        //public Type genericityType;
        public override Type ClrType => GetGenerType(GenericityType.ClrType);
        Type GetGenerType<T>(T gen)
        {
            return typeof(List<T>);
        }

        public override string TypeName => $"List<{GenericityType.TypeName}>";

        public override string ReadCode(int layer)
        {
            CodeWriter codeWriter = new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{TypeName} {tempListName} =new {TypeName}();");
            codeWriter.WriteLine($"int {tempListCountName} = ByteBuffer.ReadInt(data,ref offset);");
            codeWriter.WriteLine($"for(int {tempListIndex} = 0;{tempListIndex}<{tempListCountName};{tempListIndex}++ )");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{GenericityType.TypeName} {GenericityType.CtorCode}");
            codeWriter.WriteLine(GenericityType.ReadCode(layer+1));
            codeWriter.WriteLine($"{tempListName}.Add({GenericityType.Name});");
            codeWriter.EndBlock();
            codeWriter.WriteLine($"{Name}.AddRange({tempListName});");
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }
//        => @$"
//{{
//int listCount = ByteBuffer.ReadInt(data,ref offset);
//for(int i = 0;i<listCount;i++ )
//{{
//{GetInternal()};
//}}
//}}
//";

        public string GetInternal()
        {
            //var InternalType = TypeFacoty.GetType(genericityType, $"temp{genericityType.Name}");
            //return GenericityType.TypeName +" "+ GenericityType.ReadCode;
            var scripts = @$"   {GenericityType.TypeName} {GenericityType.ReadCode}
    {Name}.Add({GenericityType.Name})";
            return scripts;
        }

        public override string WriteCode(int layer)
        {
            CodeWriter codeWriter= new CodeWriter(layer);
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{Count.TypeName} {Count.Name} = {Name}.Count;");
            codeWriter.WriteLine(Count.WriteCode(layer));
            codeWriter.WriteLine($"for(int {tempListIndex} =0;{tempListIndex}<{Count.Name};{tempListIndex}++)");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{GenericityType.TypeName} {GenericityType.Name}={Name}[{tempListIndex}];");
            codeWriter.WriteLine(GenericityType.WriteCode(layer));
            codeWriter.EndBlock();
            codeWriter.EndBlock();
            return codeWriter.ToString();
        }
//        => @$"
//{{
//{Count.TypeName} {Count.Name} = {Name}.Count;
//{Count.WriteCode}
//for(int i =0;i<{Count.Name};i++)
//{{
//    {GenericityType.TypeName} {GenericityType.Name}={Name}[i];
//    {GenericityType.WriteCode}
//}}
//}}";
        public override string CtorCode => $"{Name} = new List<{GenericityType.TypeName}>();";

        public override bool IsValueType => false;
    }
}
