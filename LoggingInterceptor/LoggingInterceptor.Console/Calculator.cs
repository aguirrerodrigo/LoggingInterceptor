namespace LoggingInterceptor.Console
{
    public class Calculator : ICalculator
    {
        private double value = 0;

        public void Add(double number)
        {
            value += number;
        }

        public void Clear()
        {
            value = 0;
        }

        public void Divide(double number)
        {
            value /= number;
        }

        public void Multiply(double number)
        {
            value *= number;
        }

        public void Subtract(double number)
        {
            value -= number;
        }

        public double GetValue()
        {
            return value;
        }
    }
}
