using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            CarPool.Controllers.GeographyController GC = new CarPool.Controllers.GeographyController();
        }
    }
}