using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtocolEngine
{
    internal class Config
    {
        public string CSPath { get; set; }
        public string OutPathPath { get; set; }
        public string ReferencePath { get; set; }
        public string ExtraReference { get; set; }
        public string TemplatePath { get; set; }
        public static Config Ins
        {

            get
            {
                if (ins == null)
                {
                    ins = new Config();
                }
                return ins;
            }
        }
        private static Config ins;
        public void Init()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config//Config.xml");
            if (!File.Exists(path))
            {
                throw new Exception("不存在Config.xml配置文件");
            }
            XmlDocument xmlDocument = new XmlDocument();
            using (var stream = File.Open(path, FileMode.Open))
            {
                XmlReader xmlReader = new XmlTextReader(stream);
                xmlDocument.Load(xmlReader);
                var cs = xmlDocument.GetElementsByTagName("CSProtocolPath");
                CSPath =Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cs.Item(0).InnerText);
                var outPath = xmlDocument.GetElementsByTagName("OutPutPath");
                OutPathPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, outPath.Item(0).InnerText);
                var refPath = xmlDocument.GetElementsByTagName("Reference");
                ReferencePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, refPath.Item(0).InnerText);
                var temPatyh = xmlDocument.GetElementsByTagName("Template");
                TemplatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, temPatyh.Item(0).InnerText);
                var exrefPath = xmlDocument.GetElementsByTagName("ExtraReference");
                ExtraReference = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, exrefPath.Item(0).InnerText);
            }
        }
    }
}
