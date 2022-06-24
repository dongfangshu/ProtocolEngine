using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class ProtocolInfo
    {
        public string NameSpace;
        //public List<Type> Types=new List<Type>();//此命名空间下的protocol类型
        public List<TypeInfo> TypeInfo=new List<TypeInfo>();
        public List<EnumDefinition> EunmTypes = new List<EnumDefinition>();
        public HashSet<string> UseNameSpace = new HashSet<string>();
        static Regex EmptyLine = new Regex(@"^(\s *)\r\n");
        static Regex DuplicateLine = new Regex("^\r\n\r\n");
        public ProtocolInfo(string nameSpace)
        {
            NameSpace =nameSpace;
            UseNameSpace.Add("System");
            UseNameSpace.Add("System.Collections.Generic");
            UseNameSpace.Add("System.Linq");
            UseNameSpace.Add("System.Text");
            UseNameSpace.Add("System.Threading.Tasks");
            UseNameSpace.Add("ProtocolEngine");
        }
        public void AddType(Type type)
        {
            if (type.IsEnum)
            {
                var enumType = new EnumDefinition(type);
                EunmTypes.Add(enumType);
                return;
            }
            var Info = new TypeInfo(type);
            TypeInfo.Add(Info);
            foreach (var nameSpace in Info.ImportNameSpace)
            {
                UseNameSpace.Add(NameSpace);
            }
        }
        static string NameChange(System.Reflection.MemberInfo memberInfo)
        {
            return memberInfo.Name;//.net 编译之后是小写加下划线，转一下字段属性的名字
        }
        public void Wirte()
        {
            string templateScripts = File.ReadAllText(Config.Ins.TemplatePath);
            Template template = Template.Parse(templateScripts);
            string scripts = template.Render(this, NameChange);
            if (!Directory.Exists(Config.Ins.OutPathPath))
            {
                Directory.CreateDirectory(Config.Ins.OutPathPath);
            }
            using (var writer = File.CreateText(Config.Ins.OutPathPath+"/"+NameSpace+"_gen.cs"))
            {

                //scripts = EmptyLine.Replace(scripts,"");
                //scripts = DuplicateLine.Replace(scripts,"");
                //scripts = scripts.Replace("\r\n\r\n","\r\n");
                //scripts = Regex.Replace(scripts, @"^(\s *)\r\n","");
                writer.Write(scripts);
                writer.Flush();
                writer.Close();
            } 
            //File.WriteAllText(Config.Ins.OutPathPath+$"/{NameSpace}_Gen.cs", scripts, Encoding.UTF8);
            Console.WriteLine("导出=>{0}", NameSpace);
        }
    }
}
