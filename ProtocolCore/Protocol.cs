﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Automatic generation Do not modify
 * */
namespace ProtocolEngine
{
    public abstract class Protocol
    {
        public abstract void Read(byte[] data, ref int offset);
        public abstract void Write(byte[] data, ref int offset);
    }
}
