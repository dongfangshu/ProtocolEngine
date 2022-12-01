namespace ProtocolEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            if (args!=null&&args.Length>0)
            {
                //output path
                string outputPath = args[0];
                string referencePath = args[1];
                string[] scriptsPath = args.Skip(1).ToArray();
                Console.WriteLine("OutPutPath->"+ outputPath);
                Console.WriteLine("ReferencePath->" + referencePath);
                foreach (var s in scriptsPath)
                {
                    Console.WriteLine("scriptsPath->" + s);
                }
                Config.OutPathPath = outputPath;
                Config.ExtraReference = referencePath;
                GenerateCode.Generate(scriptsPath);//target cs directory
            }
            else
            {
                Console.WriteLine("not paramter ,paramter style:outputPath refdllPath scriptsPaths");
                Config.OutPathPath = System.AppDomain.CurrentDomain.BaseDirectory;
                GenerateCode.Generate(new string[] { System.AppDomain.CurrentDomain.BaseDirectory + "/Scripts" });
            }

            //Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);

            //CodeWriter codeWriter=new CodeWriter();
            //codeWriter.Reset();
            //codeWriter.WriteLine("Public Class MyClass");
            //codeWriter.StartBlock();
            //codeWriter.WriteLine("public int Id;");
            //codeWriter.WriteLine("public void Create()");
            //codeWriter.StartBlock();
            //codeWriter.WriteLine("Consolo.WriteLine();");
            //codeWriter.EndBlock();
            //codeWriter.EndBlock();
            //codeWriter.Save(System.AppDomain.CurrentDomain.BaseDirectory + "/MyClass.cs");

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

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("error see log->"+AppDomain.CurrentDomain.BaseDirectory+"/log.txt");
            LogWriter.Write(e.ExceptionObject.ToString());
        }
    }
}