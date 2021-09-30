using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    interface BasicInterface
    {
        public Type TypeGetting
        {
            get;
        }

        public T getObj<T>();
    }
}
