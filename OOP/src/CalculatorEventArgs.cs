namespace OOP
{
    public class CalculatorEventArgs
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Result { get; set; }

        public CalculatorEventArgs(double x, double y, double result)
        {
            X = x;
            Y = y;
            Result = result;
        }
    }
}