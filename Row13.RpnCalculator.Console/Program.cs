namespace Row13.RpnCalculator.Console
{
    using System;

    using Row13.RpnCalculator.Calculator;
    using Row13.RpnCalculator.Output;

    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new ExpressionEvaluator(true, new ConsoleOutputProcessor());
            string toParse = String.Empty;

            do
            {
                try
                {
                    Console.WriteLine("Enter an expression to evaluate: ([q] to quit.)");
                    toParse = Console.ReadLine();
                    calculator.Eval(toParse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (toParse != "q");
        }
    }

    public class ConsoleOutputProcessor : IOutputProcessor
    {
        public Action Write(double result, string expression)
        {
            return () =>
            {
                this.Result = result;
                Expression = expression;
                Console.WriteLine("Result :");
                Console.WriteLine(result);
                Console.WriteLine("Expression :");
                Console.WriteLine(expression);
            };
        }

        public double Result { get; set; }
        public string Expression { get; set; }
    }
}
