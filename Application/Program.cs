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
            //Int32 i = faker.Create<Int32>();
            //Console.WriteLine(faker.Create<byte>());
            //Console.WriteLine(i);
            //Console.WriteLine(faker.Create<bool>());
            //Console.WriteLine(faker.Create<string>());
            //Console.WriteLine(typeof(List<int>));
            //Console.WriteLine(faker.Create<Foo>().In);
            Console.WriteLine(faker.Create<Foo>()._h);
        }

    }
    public class Foo
    {
        private int _i;
        private int _g;
        public int _h;

        public Foo(int i)
        {
            _i = i;
        }
        public int In
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
