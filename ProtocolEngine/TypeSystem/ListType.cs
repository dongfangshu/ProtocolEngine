using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class ListType : BaseType
    {
        BaseType GenericityType;
        BaseType Count;
        public ListType(Type type,string name) : base(name)
        {
            //genericityType = type;
            GenericityType = TypeFacoty.GetType(type, "listElement");
            Count = TypeFacoty.GetType(typeof(int), "Count");
        }
        //public Type genericityType;
        public override Type ClrType => GetGenerType(GenericityType.ClrType);
        Type GetGenerType<T>(T gen)
        {
            return typeof(List<T>);
        }

        public override string TypeName => $"List<{GenericityType.TypeName}>";

        public override string ReadCode => @$"
{{
int listCount = ByteBuffer.ReadInt(data,ref offset);
for(int i = 0;i<listCount;i++ )
{{
{GetInternal()};
}}
}}
";

        public string GetInternal()
        {
            //var InternalType = TypeFacoty.GetType(genericityType, $"temp{genericityType.Name}");
            //return GenericityType.TypeName +" "+ GenericityType.ReadCode;
            var scripts = @$"   {GenericityType.TypeName} {GenericityType.ReadCode}
    {Name}.Add({GenericityType.Name})";
            return scripts;
        }

        public override string WriteCode => @$"
{{
{Count.TypeName} {Count.Name} = {Name}.Count;
{Count.WriteCode}
for(int i =0;i<{Count.Name};i++)
{{
    {GenericityType.TypeName} {GenericityType.Name}={Name}[i];
    {GenericityType.WriteCode}
}}
}}";
        public override string CtorCode => $"{Name} = new List<{GenericityType.TypeName}>();";
    }
}
