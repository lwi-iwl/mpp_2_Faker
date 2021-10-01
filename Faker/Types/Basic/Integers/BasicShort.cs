using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    class BasicShort: BasicInterface
    {
        private Type _type = typeof(short);
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
            return _rnd.Next(-32768, 32767);
        }
    }
}
