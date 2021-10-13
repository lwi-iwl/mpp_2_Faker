using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Types.Basic
{
    public class AutoGenerator: BasicInterface
    {
        private Random _rnd = new Random();
        private List<string> _cars = new List<string> { "Mercedes", "Volkswagen", "KIA", "BMW", "Audi", "Chrysler", "Ford", "Peugeot", "Citroen", "Renault" };

        public Type TypeGetting
        {
            get
            {
                return typeof(string);
            }
        }

        public object getObj()
        {
            return _cars[_rnd.Next(10)];     
        }
    }
}
