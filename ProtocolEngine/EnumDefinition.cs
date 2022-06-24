using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal class EnumDefinition
    {
        public string Name { get;}
        public string[] SunItem;
        public EnumDefinition(Type enumType)
        {
            Name = enumType.Name;
            SunItem = enumType.GetEnumNames();
        }
    }
}
