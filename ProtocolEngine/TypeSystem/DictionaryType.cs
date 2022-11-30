using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class DictionaryType : BaseType
    {
        Type OriginType;
        BaseType KeyType;
        BaseType ValueType;
        BaseType CountType;
        public DictionaryType(Type origin,string name) : base(name)
        {
            OriginType = origin;
            var gas = OriginType.GetGenericArguments();
            KeyType = TypeFacoty.GetType(gas[0],"Key");
            ValueType = TypeFacoty.GetType(gas[1],"Value");
            CountType = TypeFacoty.GetType(typeof(int),"Count");
        }
        Type GetGenerType<TKey,TValue>(TKey Key, TValue Value)
        {
            return typeof(Dictionary<TKey,TValue>);
        }
        public override Type ClrType => GetGenerType(KeyType.ClrType,ValueType.ClrType);

        public override string TypeName => $"Dictionary<{KeyType.TypeName},{ValueType.TypeName}>";

        public override string ReadCode(int layer)
        {
            CodeWriter codeWriter =new CodeWriter(layer);
            codeWriter.StartBlock();

            codeWriter.WriteLine($"{CountType.TypeName} {CountType.ReadCode(++layer)}");

            codeWriter.WriteLine($"for(int i =0;i<{CountType.Name};i++)");
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{KeyType.TypeName} {KeyType.ReadCode(++layer)};");
            codeWriter.WriteLine($"{ValueType.TypeName} {ValueType.ReadCode(++layer)};");
            codeWriter.WriteLine($"{Name}.Add({KeyType.Name},{ValueType.Name});");
            codeWriter.EndBlock();

            codeWriter.EndBlock();
            return codeWriter.ToString();
        }
        //        => @$"
        //{{
        //{CountType.TypeName} {CountType.ReadCode};
        //for(int i =0;i<{CountType.Name};i++)
        //{{
        //    {KeyType.TypeName} {KeyType.ReadCode};
        //    {ValueType.TypeName} {ValueType.ReadCode};
        //    {Name}.Add({KeyType.Name},{ValueType.Name});
        //}}
        //}}";

        public override string WriteCode()
        {
            CodeWriter codeWriter =new CodeWriter();
            codeWriter.StartBlock();
            codeWriter.WriteLine($"{CountType.TypeName} {CountType.Name} = {Name}.Count;");
            codeWriter.WriteLine(CountType.WriteCode());
            codeWriter.WriteLine($"foreach(var item in {Name})");

            codeWriter.StartBlock();
            codeWriter.WriteLine($"{KeyType.TypeName} {KeyType.Name} = item.Key;");
            codeWriter.WriteLine(KeyType.WriteCode());
            codeWriter.WriteLine($"{ValueType.TypeName} {ValueType.Name} = item.Value;");
            codeWriter.WriteLine(ValueType.WriteCode());

            codeWriter.EndBlock();

            codeWriter.EndBlock() ;
            return codeWriter.ToString();
        }
//        => @$"
//{{
//{CountType.TypeName} {CountType.Name} = {Name}.Count;
//{CountType.WriteCode};
//foreach(var item in {Name})
//{{
//    {KeyType.TypeName} {KeyType.Name} = item.Key;
//    {KeyType.WriteCode}
//    {ValueType.TypeName} {ValueType.Name} = item.Value;
//    {ValueType.WriteCode}
//}}
//}}";
        public override string CtorCode => $"{Name} = new {TypeName}();";
    }
}
