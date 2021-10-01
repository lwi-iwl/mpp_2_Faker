using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    class BasicLong: BasicInterface
    {
        private Type _type = typeof(long);
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
            var buffer = new byte[8];
            _rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
