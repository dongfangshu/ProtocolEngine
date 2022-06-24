using Scriban;
using System.Reflection;
using System.Windows;

namespace ProtocolEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Config.Ins.Init();
            GenerateCode.Generate(new string[] { Config.Ins.CSPath });
            //MyClass myClass = new MyClass();
            //var field = typeof(MyClass).GetField("Values", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            //var type=  TypeFacoty.GetType(field.FieldType, field.Name);
            //Console.WriteLine($"typeName:{type.TypeName} name:{type.Name}");
            //string inter = list.GetInternal();
            //var code = list.ReadCode;
            //string templateScripts = "Name IS {{Name}}";
            //var template = Template.Parse(templateScripts);
            //var model = new MyClass() { Name = "new MyClass()" };
            //var scripts = template.Render(model);
            //Console.WriteLine  (scripts);
        }
    }
}