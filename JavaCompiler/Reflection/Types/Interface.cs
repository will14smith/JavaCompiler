﻿using System;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection.Types
{
    public class Interface : DefinedType
    {
        public override bool IsAssignableTo(Type c)
        {
            throw new NotImplementedException();
        }
    }
}