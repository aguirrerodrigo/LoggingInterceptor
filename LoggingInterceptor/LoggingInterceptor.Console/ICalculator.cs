namespace LoggingInterceptor.Console
{
    public interface ICalculator
    {
        void Clear();
        void Add(double number);
        void Subtract(double number);
        void Multiply(double number);
        void Divide(double number);
        double GetValue();
    }
}