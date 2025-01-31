﻿using System;
using ProductsCleanArch.Common;

namespace ProductsCleanArch.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
