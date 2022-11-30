using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class Referenced
    {
        public static IEnumerable<MetadataReference> GetReference()
        {
            List< MetadataReference > references = new List< MetadataReference >();
            string[] runtime = AppDomain.CurrentDomain.GetAssemblies().Select(assembly => assembly.GetName().CodeBase).ToArray();
            foreach (var file in runtime)//runtime
            {
                Uri uri = new Uri(file);
                var Ref = MetadataReference.CreateFromFile(uri.LocalPath);
                references.Add(Ref);
            }
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory+ "Protocol.dll"))//ProtocolCore
            {
                var Ref = MetadataReference.CreateFromFile(AppDomain.CurrentDomain.BaseDirectory + "Protocol.dll");
                references.Add(Ref);
            }
            if (!string.IsNullOrEmpty(Config.ExtraReference))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Config.ExtraReference);
                if (directoryInfo.Exists)
                {
                    var files = directoryInfo.GetFiles("*.dll");
                    foreach (var file in files)
                    {
                        var Ref = MetadataReference.CreateFromFile(file.FullName);
                        references.Add(Ref);
                    }
                }
            }
            return references;
        }
    }
}
