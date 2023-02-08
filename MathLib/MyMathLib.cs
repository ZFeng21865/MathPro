using IMathLib;

namespace MathLib
{
    public class MyMathLib : IMyMathLib
    {
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }
    }
}