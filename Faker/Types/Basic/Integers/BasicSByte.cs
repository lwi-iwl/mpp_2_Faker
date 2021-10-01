﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    class BasicSByte: BasicInterface
    {
        private Type _type = typeof(sbyte);
        private Random _rnd = new Random();

        public Type TypeGetting
        {
            get
            {
                return _type;
            }
        }

        public object getObj()
        {
            return (sbyte)_rnd.Next(-128, 127);
        }
    }
}
