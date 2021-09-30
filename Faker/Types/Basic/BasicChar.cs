using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    class BasicChar: BasicInterface
    {
        private Type _type = typeof(char);
        private Random _rnd = new Random();
        private Char[] _chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();

        public Type TypeGetting
        {
            get
            {
                return _type;
            }
        }

        public T getObj<T>()
        {
            int num = _rnd.Next(0, 76); 
            return (T)Convert.ChangeType((char)('a' + num), typeof(T));
        }
    }
}
