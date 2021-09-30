using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic.Floating
{
    class BasicDouble: BasicInterface
    {
        private Type _type = typeof(double);
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
            var buffer = new byte[8];
            _rnd.NextBytes(buffer);
            return (T)Convert.ChangeType(BitConverter.ToDouble(buffer, 0), typeof(T));
        }
    }
}
