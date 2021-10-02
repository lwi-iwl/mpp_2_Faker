using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    class BasicDate: BasicInterface
    {
        private Type _type = typeof(DateTime);
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
            int year = _rnd.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            int month = _rnd.Next(1, 13);
            return new DateTime(year, month, _rnd.Next(1, DateTime.DaysInMonth(year, month) + 1), _rnd.Next(0, 24),
                _rnd.Next(0, 60), _rnd.Next(0, 60), _rnd.Next(0, 1000));
        }
    }
}
