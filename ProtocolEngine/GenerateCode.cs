using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class GenerateCode
    {
        public static void Generate(string[] CodeDirectorys)
        {
            List<string> scripts = new List<string>();
            for (int i = 0; i < CodeDirectorys.Length; i++)
            {
                DirectoryInfo dti = new DirectoryInfo(CodeDirectorys[i]);
                if (!dti.Exists)
                {
                    Console.WriteLine($"未找到{CodeDirectorys[i]}路径");
                    continue;
                }
                FileInfo[] fileInfos = dti.GetFiles("*.cs", System.IO.SearchOption.AllDirectories);
                for (int j = 0; j < fileInfos.Length; j++)
                {
                    scripts.Add(fileInfos[j].FullName);
                }
            }
            if (scripts.Count==0)
            {
                Console.WriteLine("没有cs_protocol文件");
                return;
            }
            List<SyntaxTree> tree = new List<SyntaxTree>();
            for (int i = 0; i < scripts.Count; i++)
            {
                string script = scripts[i];
                string text = File.ReadAllText(script);
                tree.Add(CSharpSyntaxTree.ParseText(text));
            }

            CSharpCompilationOptions defaultCompilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithOptimizationLevel(OptimizationLevel.Debug).WithPlatform(Platform.AnyCpu);
            using (MemoryStream dllStream = new MemoryStream())
            {
                string assemblyName = Path.GetRandomFileName();
                var csCompliation = CSharpCompilation.Create(assemblyName, tree, Referenced.GetReference(), defaultCompilationOptions);
                //csCompliation.AddSyntaxTrees(tree.ToArray());
                Console.WriteLine("Start Complier");
                var result = csCompliation.Emit(dllStream);
                if (result.Success)
                {
                    Console.WriteLine("Start Complier Success");
                    //List<ProtocolInfo> protocolInfos = new List<ProtocolInfo>();
                    Dictionary<string, ProtocolInfo> ProtocolMap=new Dictionary<string, ProtocolInfo>();
                    Assembly assembly = Assembly.Load(dllStream.ToArray());
                    var types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.GetCustomAttribute<Ignore>() != null)
                            continue;
                        string nameSpaceKey = string.Empty;
                        if (!string.IsNullOrEmpty(type.Namespace))
                        {
                            nameSpaceKey = type.Namespace;
                        }
                        if (ProtocolMap.ContainsKey(nameSpaceKey))
                        {
                            ProtocolInfo protocol = ProtocolMap[nameSpaceKey];
                            protocol.AddType(type);
                        }
                        else
                        {
                            ProtocolMap.Add(nameSpaceKey,new ProtocolInfo(nameSpaceKey));
                            ProtocolInfo protocol = ProtocolMap[nameSpaceKey];
                            protocol.AddType(type);
                        }
                    }
                    foreach (var protocolInfo in ProtocolMap)
                    {
                        protocolInfo.Value.Wirte();
                    }
                }
                else
                {
                    Console.WriteLine("CSharp Emit Error");
                    foreach (var dig in result.Diagnostics)
                    {
                        Console.WriteLine(dig.GetMessage());
                    }
                }
            }
        }
    }
}
