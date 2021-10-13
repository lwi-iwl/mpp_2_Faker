using System;
using System.Collections.Generic;
using Faker;
using Faker.Types.Basic;

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
            //Console.WriteLine(faker.Create<IList<int>>());
            //Console.WriteLine(faker.Create<A>().GetSetB.GetSetC);
            A a = faker.Create<A>();
            Console.WriteLine(a.GetSetB.GetSetC);
            Foo foo = faker.Create<Foo>();
            Console.WriteLine(foo.I1);
            Console.WriteLine(foo.I2);
            Console.WriteLine(foo.I3);


            var config = new FakerConfig();
            config.Add<Auto, string, AutoGenerator>(auto => auto.Name);
            var faker1 = new MainFaker(config);
            Auto auto = faker1.Create<Auto>();
            Console.WriteLine(auto.Name);
            Console.WriteLine(auto.Cost);
        }

    }
    public class Foo
    {
        private int _i;
        private int _i2;
        private int _i3;
        private string _g;
        public int _h;

        public Foo(int i)
        {
            _i = i;
        }
        public Foo(IEnumerator<int> a, int i, int i2, int i3)
        {
            _i = i;
            _i2 = i2;
            _i3 = i3;
        }
        public Foo(int i, int i2)
        {
            _i = i;
            _i2 = i2;
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

        public int I1
        {
            get
            {
                return _i;
            }
        }

        public int I2
        {
            get
            {
                return _i2;
            }
        }

        public int I3
        {
            get
            {
                return _i3;
            }
        }
    }

    class A
    {
        public B GetSetB 
        {
            set; get;
        }
    }

    class B
    {
        public C GetSetC
        {
            set; get;
        }
    }

    class C
    {
        public A GetSetA
        {
            set; get;
        }
    }


    class Auto
    {
        public string Name { get;}
        public Auto(string name) 
        { 
            Name = name; 
        }

        public int Cost { get; set; }
    }
}
