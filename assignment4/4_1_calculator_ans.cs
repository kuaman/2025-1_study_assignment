using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        public double Calculate(double num1, string op, double num2)
        {
            switch (op)
            {
                case "+":
                    return num1 + num2;
                    break;

                case "-":
                    return num1 - num2;
                    break;

                case "*":
                    return num1 * num2;
                    break;

                case "/":
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Division by zero is not allowed");
                    }
                    else
                    {
                        return num1 / num2;
                    }
                    break;

                case "**":
                    double result1 = num1;
                    if (num2 > 0)
                    {
                        for (int i = 1; i < num2; i++)
                        {
                            result1 *= num1;
                        }
                        return result1;
                    }
                    else if (num2 < 0)
                    {
                        for (int i = 1; i < -num2; i++)
                        {
                            result1 *= num1;
                        }
                        return 1 / result1;
                    }
                    else
                    {
                        return 1;
                    }
                    break;

                case "%":
                    return num1 % num2;
                    break;

                case "G":
                    double r2 = 0;
                    double G = num1 * num2;
                    if (num1 < num2)
                    {
                        (num1, num2) = (num2, num1);
                    }
                    while (num2 != 0)
                    {
                        r2 = num1 % num2;
                        num1 = num2;
                        num2 = r2;
                    }
                    return G / num1;
                    break;

                case "L":
                    double r3 = 0;
                    if (num1 < num2)
                    {
                        (num1, num2) = (num2, num1);
                    }
                    while (num2 != 0)
                    {
                        r3 = num1 % num2;
                        num1 = num2;
                        num2 = r3;
                    }
                    return num1;
                    break;

                default:
                    throw new InvalidOperationException("Invalid operator");
                    break;
            }
        }
    }
}

/* example output

Enter an expression (ex. 2 + 3):
>> 4 * 3
Result: 12

*/


/* example output (CHALLANGE)

Enter an expression (ex. 2 + 3):
>> 4 ** 3
Result: 64

Enter an expression (ex. 2 + 3):
>> 5 ** -2
Result: 0.04

Enter an expression (ex. 2 + 3):
>> 12 G 15
Result: 3

Enter an expression (ex. 2 + 3):
>> 12 L 15
Result: 60

Enter an expression (ex. 2 + 3):
>> 12 % 5
Result: 2

*/