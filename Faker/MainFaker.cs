using Faker.Types;
using Faker.Types.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class MainFaker
    {
        private BasicType _basic = new BasicType();
        public MainFaker()
        {
            
        }
        public T Create<T>()
        {
            var type = typeof(T);
            BasicInterface obj = _basic.BasicTypes.Find(x => x.TypeGetting == type);
            return obj.getObj<T>();
        }
    }
}
