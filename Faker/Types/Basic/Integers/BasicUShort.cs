using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    class BasicUShort: BasicInterface
    {
        private Type _type = typeof(ushort);
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
            return (T)Convert.ChangeType(_rnd.Next(65535), typeof(T));
        }
    }
}
