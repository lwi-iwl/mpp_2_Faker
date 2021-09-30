using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    class BasicByte: BasicInterface
    {
        private Type _type = typeof(byte);
        private Random _rnd = new Random();

        public Type TypeGetting
        {
            get
            {
                return _type;
            }
        }

        public T getObj<T>()
        {
            return (T)Convert.ChangeType((byte)_rnd.Next(256), typeof(T));
        }
    }
}
