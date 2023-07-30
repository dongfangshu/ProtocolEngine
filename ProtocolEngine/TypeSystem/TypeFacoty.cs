using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Numerics;
using ProtocolEngine.TypeSystem;

namespace ProtocolEngine
{
    internal class TypeFacoty
    {
        public static BaseType GetType(Type type,string Name)
        {
            if (type == typeof(int))
            {
                return new IntType(Name);
            }
            else if (type == typeof(long))
            {
                return new LongType(Name);
            }
            else if (type == typeof(string))
            {
                return new StringType(Name);
            }
            else if (type == typeof(short))
            {
                return new ShortType(Name);
            }
            //else if (type == typeof(List<>))
            //{
            //    return new ListType(type.GenericTypeArguments[0], Name);
            //}
            else if (type == typeof(bool))
            {
                return new BoolType(Name);
            }
            else if (type == typeof(byte))
            {
                return new ByteType(Name);
            }
            else if (type == typeof(byte[]))
            {
                return new BytesType(Name);
            }
            else if (type == typeof(float))
            {
                return new FloatType(Name);
            }
            else if (type == typeof(Vector3))
            {
                return new Vector3Type(Name);
            }
            else if (type == typeof(char))
            {
                return new CharType(Name);
            }
            else if (type == typeof(DateTime))
            {
                return new DateTimeType(Name);
            }
            else if (type == typeof(TimeSpan))
            {
                return new TimeSpanType(Name);
            }
            else if (type.IsEnum)
            {
                return new EnumType(type, Name);
            }
            else if (type.IsArray)
            {
                return new ArrayType(type, Name);
            }
            else
            {
                if (type.IsGenericType)
                {
                    string TypeName = type.Name.ToLower();
                    Type[] genericArguments = type.GetGenericArguments();
                    if (TypeName.StartsWith("list"))
                    {
                        return new ListType(genericArguments[0], Name);
                    }
                    else if (TypeName.StartsWith("dictionary"))
                    {
                        return new DictionaryType(type, Name);
                    }
                    else if (TypeName.StartsWith("stack"))
                    {
                        return new StackType(type, Name);
                    }
                    else if (TypeName.StartsWith("queue"))
                    {
                        return new QueueType(type, Name);
                    }
                    else if (TypeName.StartsWith("linkedlist"))
                    {
                        return new LinkedListType(type, Name);
                    }

                    throw new NotSupportedException("未支持的泛型结构");
                }


                //var parentType = type.BaseType;
                return new ConstomType(type, Name);
            }
        }
    }
}
