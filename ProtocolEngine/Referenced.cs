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
            var runtime = AppDomain.CurrentDomain.GetAssemblies().ToDictionary(assembly=>assembly.GetName().Name,assembly => assembly.Location);
            foreach (var file in runtime)//runtime
            {
                if (file.Value=="")
                {
                    continue;
                }
                var Ref = MetadataReference.CreateFromFile(file.Value);
                references.Add(Ref);
            }
            //if (File.Exists(AppDomain.CurrentDomain.BaseDirectory+ "Protocol.dll"))//ProtocolCore
            //{
            //    var Ref = MetadataReference.CreateFromFile(AppDomain.CurrentDomain.BaseDirectory + "Protocol.dll");
            //    references.Add(Ref);
            //}
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
