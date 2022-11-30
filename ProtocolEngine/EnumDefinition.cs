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
        public string[] EnumValues { get;}
        public EnumDefinition(Type enumType)
        {
            Name = enumType.Name;
            SunItem = enumType.GetEnumNames();
            var Values = enumType.GetEnumValues();
            List<string> listValue = new List<string>();
            foreach ( var enumValue in Values )
            {
                listValue.Add(((int)enumValue).ToString());
            }
            EnumValues = listValue.ToArray();
        }
    }
}
