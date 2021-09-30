using System;
using Faker;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            MainFaker faker = new MainFaker();
            Int32 i = faker.Create<Int32>();
            Console.WriteLine(faker.Create<byte>());
            Console.WriteLine(i);
            Console.WriteLine(faker.Create<bool>());
        }
    }
}
