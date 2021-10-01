using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic.Floating
{
    class BasicDecimal: BasicInterface
    {
        private Type _type = typeof(decimal);
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
            int lo = _rnd.Next(int.MinValue, int.MaxValue);
            int mid = _rnd.Next(int.MinValue, int.MaxValue);
            int hi = _rnd.Next(int.MinValue, int.MaxValue);
            bool isNegative = (_rnd.Next(2) == 0); 
            byte scale = Convert.ToByte(_rnd.Next(29));

            decimal randomDecimal = new decimal(lo, mid, hi, isNegative, scale);

            return randomDecimal;
        }
    }
}
