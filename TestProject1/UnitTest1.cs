using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faker;
using Application;
using Faker.Types.Basic;
using System.Collections.Generic;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private FakerConfig _config;
        private MainFaker _faker;

        [TestInitialize]
        public void Initialize()
        {
            _config = new FakerConfig();
            _config.Add<Auto, string, AutoGenerator>(auto => auto.Name);
            _faker = new MainFaker(_config);
        }

        [TestMethod]
        public void CreateAuto()
        {
            Auto auto = _faker.Create<Auto>();
            Assert.AreEqual(auto.Name.GetType(), typeof(string));
            Assert.AreEqual(auto.Cost.GetType(), typeof(int));
        }

        [TestMethod]
        public void Cycle()
        {
            A a = _faker.Create<A>();
            Assert.AreEqual(a.GetSetB.GetSetC.GetSetA, null);
        }

        [TestMethod]
        public void SeveralConstructors()
        {
            Foo foo = _faker.Create<Foo>();
            Assert.AreNotEqual(foo.I1, null);
            Assert.AreNotEqual(foo.I2, null);
            Assert.AreNotEqual(foo.I3, null);
        }

        [TestMethod]
        public void CustomObjectsList()
        {
            List<Foo> list = _faker.Create<List<Foo>>();
            foreach (Foo i in list)
            {
                Assert.AreNotEqual(i.I1, null);
                Assert.AreNotEqual(i.I2, null);
                Assert.AreNotEqual(i.I3, null);
                Assert.AreNotEqual(i.In, null);
            }
        }

        [TestMethod]
        public void PrivateConstructor()
        {
            NewClass newObj = _faker.Create<NewClass>();
            Assert.AreNotEqual(newObj.I1, null);
        }

        [TestMethod]
        public void Module()
        {
            var basicChar = _faker.Create<char>();
            Assert.AreEqual(basicChar.GetType(), typeof(char));
        }


        [TestMethod]
        public void Sys()
        {
            var dateTime = _faker.Create<DateTime>();
            Assert.AreEqual(dateTime.GetType(), typeof(DateTime));
        }
    }
}
