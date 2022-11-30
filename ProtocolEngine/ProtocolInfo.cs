using System.Xml.Linq;

namespace ProtocolEngine
{

    internal class ProtocolInfo
    {
        public string NameSpace;
        public List<TypeInfo> TypeInfo=new List<TypeInfo>();
        public List<EnumDefinition> EunmTypes = new List<EnumDefinition>();
        public HashSet<string> UseNameSpace = new HashSet<string>();
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
        public void Wirte()
        {
            if (!Directory.Exists(Config.OutPathPath))
            {
                Directory.CreateDirectory(Config.OutPathPath);
            }
            CodeWriter codeWriter=new CodeWriter();
            //using
            foreach (var nameSpace in UseNameSpace)
            {
                codeWriter.WriteLine($"using {nameSpace};" );
            }
            codeWriter.WriteLine($"namespace {NameSpace}");
            codeWriter.StartBlock();

            if (EunmTypes.Count>0)
            {
                //enum
                foreach (var enumType in EunmTypes)
                {
                    codeWriter.WriteLine($"public enum {enumType.Name}");
                    codeWriter.StartBlock();
                    foreach (var subItem in enumType.SunItem)
                    {
                        codeWriter.WriteLine(subItem+",");
                    }
                    codeWriter.EndBlock();
                }

            }
            if (TypeInfo.Count>0)
            {
                foreach (TypeInfo type in TypeInfo)
                {
                    string code = $"public class {type.ClssName}";
                    if (type.IsSubClass)
                    {
                        code += type.BaseClass;
                    }
                    else
                    {
                        code += type.Subclass;
                    }
                    codeWriter.WriteLine(code);
                    codeWriter.StartBlock();
                    //definition
                    foreach (var fp in type.Field_Property_Info)
                    {
                        codeWriter.WriteLine($"{fp.TypeName} {fp.Name};");
                    }
                    //ctor
                    codeWriter.WriteLine($"public {type.ClssName}()");
                    codeWriter.StartBlock();
                    foreach (var fp in type.Field_Property_Info)
                    {
                        codeWriter.WriteLine(fp.CtorCode);
                    }
                    codeWriter.EndBlock();//end ctor

                    //read
                    codeWriter.WriteLine("public override void Read(byte[] data, ref int offset)");
                    codeWriter.StartBlock();
                    if (type.IsSubClass)
                    {
                        codeWriter.WriteLine("base.Read(data,ref offset);");
                    }
                    foreach (var fp in type.Field_Property_Info)
                    {
                        //if (fp is ListType list)
                        //{
                        //    //CodeWriter codeWriter = new CodeWriter();
                        //    codeWriter.StartBlock();
                        //    codeWriter.WriteLine("int listCount = ByteBuffer.ReadInt(data,ref offset);");
                        //    codeWriter.WriteLine("for(int i = 0;i<listCount;i++ )");
                        //    codeWriter.StartBlock();
                        //    codeWriter.WriteLine($"{list.GenericityType.TypeName} {list.GenericityType.ReadCode()}");
                        //    codeWriter.WriteLine($"{list.Name}.Add({list.GenericityType.Name});");
                        //    codeWriter.EndBlock();
                        //    codeWriter.EndBlock();
                        //}
                        //else if (fp is DictionaryType)
                        //{

                        //}
                        //else
                        //{
                        //    codeWriter.WriteLine(fp.ReadCode());
                        //}
                        codeWriter.WriteLine(fp.ReadCode(codeWriter.blockCount));
                    }
                    codeWriter.EndBlock();//end read

                    //write
                    codeWriter.WriteLine("public override void Write(byte[] data, ref int offset)");
                    codeWriter.StartBlock();
                    foreach (var fp in type.Field_Property_Info)
                    {
                        codeWriter.WriteLine(fp.WriteCode());
                    }
                    codeWriter.EndBlock();//end write

                    codeWriter.EndBlock();//class
                }
            }

            codeWriter.EndBlock();//namespace

            codeWriter.Save(Config.OutPathPath+ $"/{NameSpace}_Gen.cs");
            Console.WriteLine("导出=>{0}", Config.OutPathPath + $"/{NameSpace}_Gen.cs");
        }
    }
}
