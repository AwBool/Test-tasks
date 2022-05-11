using NUnit.Framework;

namespace LuckyNumber.Tests
{
    public class Test
    {
        [TestCase(10,4)]
        [TestCase(13,2)]
        [TestCase(13,3)]
        [TestCase(13,4)]
        public void TestIdenticalResults(int basis, int digits)
        {
            ILuckyNumbers bf = new BruteForce();
            ILuckyNumbers dp = new DynaProg();
            Assert.AreEqual(bf.GetCount(digits, basis), dp.GetCount(digits, basis));
        }
    }
}