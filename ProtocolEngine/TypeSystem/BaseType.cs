using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolEngine
{
    internal abstract class BaseType
    {
        protected BaseType(string name)
        {
            Name = name;
        }

        public string Name;
        public virtual string CtorCode { 
            get { return $"{Name} = default({TypeName});"; }
        }
        public abstract Type ClrType { get; }

        public abstract string TypeName { get; }

        public abstract string ReadCode(int layer);
        public abstract string WriteCode();
        //public abstract string ComplateReadCode { get; }
    }
}
