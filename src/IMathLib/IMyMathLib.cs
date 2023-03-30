namespace IMathLib
{
    public interface IMyMathLib
    {
        decimal Add(decimal a, decimal b );

        decimal Subtract(decimal a, decimal b );

        decimal Divide(decimal a, decimal b);

        decimal Multiply(decimal a, decimal b);

        string Add(string a, string b);
        string Subtract(string a, string b);
        string Multiply(string a, string b);
        string Divide(string a, string b);
    }
}