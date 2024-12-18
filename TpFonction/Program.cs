using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFonction
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is an equation solver");

            try
            {
                // Input coefficients
                Console.Write("Enter coefficient a: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Enter coefficient b: ");
                double b = double.Parse(Console.ReadLine());

                Console.Write("Enter coefficient c: ");
                double c = double.Parse(Console.ReadLine());

                // Solve the equation
                Solution solution = SolveQuadratic(a, b, c);

                // Display the results
                if (solution.Count == 2 && solution.ComplexPart == null)
                {
                    Console.WriteLine($"Two real roots:");
                    Console.WriteLine($"x1 = {solution.Sol1}");
                    Console.WriteLine($"x2 = {solution.Sol2}");
                }
                else if (solution.Count == 1)
                {
                    Console.WriteLine($"One real root:");
                    Console.WriteLine($"x = {solution.Sol1}");
                }
                else if (solution.Count == 2 && solution.ComplexPart != null)
                {
                    Console.WriteLine($"Two complex roots:");
                    Console.WriteLine($"x1 = {solution.Sol1} + {solution.ComplexPart}i");
                    Console.WriteLine($"x2 = {solution.Sol1} - {solution.ComplexPart}i");
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format. Please enter valid numbers.");
            }

            // Prevent console from closing immediately
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        public static Solution SolveQuadratic(double a, double b, double c)
        {
            // Check if 'a' is zero
            if (a == 0)
                throw new DivideByZeroException("Coefficient 'a' cannot be zero in a quadratic equation.");

            double discriminant = b * b - 4 * a * c;
            Solution solution = new Solution();

            if (discriminant > 0)
            {
                // Two real roots
                solution.Count = 2;
                solution.Sol1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                solution.Sol2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            }
            else if (discriminant == 0)
            {
                // One real root (repeated)
                solution.Count = 1;
                solution.Sol1 = -b / (2 * a);
            }
            else
            {
                // Complex roots
                solution.Count = 2;
                solution.Sol1 = -b / (2 * a);
                solution.ComplexPart = (Math.Sqrt(-discriminant) / (2 * a)).ToString("F2");
            }

            return solution;
        }
    }
}