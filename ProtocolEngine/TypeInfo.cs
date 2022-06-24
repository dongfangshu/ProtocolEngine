using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProtocolEngine
{
    internal class TypeInfo
    {
        public string ClssName;
        public List<BaseType> Field_Property_Info;
        public string Subclass=":Protocol";
        public bool IsSubClass=false;
        public string BaseClass = ":Protocol";
        public HashSet<string> ImportNameSpace = new HashSet<string>();
        public TypeInfo(Type clrType)
        {
            if (clrType.BaseType != typeof(object))
            {
                IsSubClass = true;
                Subclass = "";
                BaseClass = $":{clrType.BaseType.FullName}";
            }

            ClssName = clrType.Name;
            Field_Property_Info = new List<BaseType>(); 
            var fields = clrType.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo? field in fields)
            {
                if (Attribute.IsDefined(field, typeof(Ignore)))
                    continue;
                if (field.IsPrivate)
                    continue;
                var DeclaringType = field.DeclaringType;
                if (DeclaringType!=clrType)
                {
                    continue;//父类中声明由父类初始
                }
                if (!string.IsNullOrEmpty(field.FieldType.Namespace))
                {
                    ImportNameSpace.Add(field.FieldType.Namespace);
                }
                Field_Property_Info.Add(TypeFacoty.GetType(field.FieldType, field.Name));
            }
            var Properties = clrType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in Properties)
            {
                if (Attribute.IsDefined(property, typeof(Ignore)))
                    continue;
                if (property.GetMethod == null || property.SetMethod == null || property.Name == "Item")
                    continue;
                var DeclaringType = property.DeclaringType;
                if (DeclaringType != clrType)
                {
                    continue;//父类中声明由父类初始
                }
                Field_Property_Info.Add( TypeFacoty.GetType(property.PropertyType, property.Name));
            }

        }
    }
}
