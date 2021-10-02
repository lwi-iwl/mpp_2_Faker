using System;
using System.Collections.Generic;
using Faker;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainFaker faker = new MainFaker();
            List<Foo> list = faker.Create<List<Foo>>();
            foreach (Foo i in list)
            {
                Console.WriteLine(i.In);
            }
            Console.WriteLine(faker.Create<int>());
            Console.WriteLine(faker.Create<IList<int>>());
        }

    }
    public class Foo
    {
        private int _i;
        private string _g;
        public int _h;

        public Foo(int i)
        {
            _i = i;
        }
        public string In
        {
            set
            {
                _g = value;
            }
            get
            {
                return _g;
            }
        }

        public void asd()
        { 
        }
    }
}
