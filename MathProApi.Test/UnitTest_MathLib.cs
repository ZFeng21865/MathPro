using IMathLib;
using MathLib;

namespace MathProApi.Test
{
    [TestClass]
    public class UnitTest_MathLib
    {
        private static IMyMathLib _mathLib;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _mathLib = new MyMathLib();
        }

        [TestMethod]
        public void Test_Addition_whole_numbers()
        {
            Assert.IsTrue(_mathLib.Add(1, 2) == 3);
            Assert.IsFalse(_mathLib.Add(1, 3) == 3);
        }

        [TestMethod]
        public void Test_Addition_floating_numbers()
        {
            Assert.IsTrue(_mathLib.Add(1.2m, 2.3m) == 3.5m);
            Assert.IsFalse(_mathLib.Add(5.1m, 7.2m) == 12);
        }
    }
}