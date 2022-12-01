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
            UseNameSpace.Add("UnityEngine");
            UseNameSpace.Add("CoreLib");
            //UseNameSpace.Add("ProtocolEngine");
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
                UseNameSpace.Add(nameSpace);
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

            codeWriter.WriteLine("/** This is an automatically generated class by Protocol. Please do not modify it. **/");
            if (EunmTypes.Count>0)
            {
                //enum
                foreach (var enumType in EunmTypes)
                {
                    codeWriter.WriteLine($"public enum {enumType.Name}");
                    codeWriter.StartBlock();
                    int subEnumLength = enumType.SunItem.Length;
                    for (int i = 0; i < subEnumLength; i++)
                    {
                        string subItem = enumType.SunItem[i];
                        string itemValue = enumType.EnumValues[i];
                        codeWriter.WriteLine($"{subItem} = {itemValue},");
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
                        codeWriter.WriteLine($"public {fp.TypeName} {fp.Name};");
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
                    codeWriter.WriteLine("try");
                    codeWriter.WriteLine("{");
                    if (type.IsSubClass)
                    {
                        codeWriter.WriteLine("base.Read(data,ref offset);");
                    }
                    foreach (var fp in type.Field_Property_Info)
                    {
                        codeWriter.WriteLine(fp.ReadCode(codeWriter.blockCount));
                    }
                    codeWriter.WriteLine("}");
                    codeWriter.WriteLine("catch (Exception ex)");
                    codeWriter.WriteLine("{");
                    codeWriter.WriteLine("\tUnityEngine.Debug.LogError(ex.Message);");
                    codeWriter.WriteLine("throw;");
                    codeWriter.WriteLine("}");
                    codeWriter.EndBlock();//end read

                    //write
                    codeWriter.WriteLine("public override void Write(byte[] data, ref int offset)");
                    codeWriter.StartBlock();
                    foreach (var fp in type.Field_Property_Info)
                    {
                        codeWriter.WriteLine(fp.WriteCode(codeWriter.blockCount));
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
