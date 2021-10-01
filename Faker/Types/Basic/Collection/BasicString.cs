using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic.Collection
{
    class BasicString: BasicInterface
    {
        private Type _type = typeof(string);
        private Random _rnd = new Random();
        private Char[] _chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();

        public Type TypeGetting
        {
            get
            {
                return _type;
            }
        }

        public object getObj()
        {
            int num = _rnd.Next(0, 76);
            return new string(Enumerable.Repeat(_chars, num).Select(s => s[_rnd.Next(s.Length)]).ToArray());
        }
    }
}
