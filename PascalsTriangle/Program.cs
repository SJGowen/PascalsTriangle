using System;
using System.Diagnostics;
using System.Text;

namespace PascalsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many lines would you like your Pascal's Triangle to occupy?");

            int lines;
            while (!int.TryParse(Console.ReadLine(), out lines))
            {
                Console.WriteLine("Your entry was not an integer number, please try again!");
            }

            lines = CheckForValidNumberOfLines(lines, 1, 61);
            var sb = new StringBuilder();

            for (int n = 0; n < lines; n++)
            {
                sb.Clear();
                long val = 0;
                for (int k = 0; k <= n; k++)
                {
                    val = k == 0 ? 1 : val * (n + 1 - k) / k;

                    sb.Append($" {val} ");
                }

                var output = sb.ToString().Trim();
                output = TryToCentreOutputOnScreen(output);

                Console.WriteLine(output);
            }
        }

        private static string TryToCentreOutputOnScreen(string output)
        {
            try
            {
                Console.SetCursorPosition((Console.WindowWidth - output.Length) / 2, Console.CursorTop);
            }
            catch (ArgumentOutOfRangeException)
            {
                Debug.WriteLine("Output length is greater than WindowWidth.");

                if (output.Contains("  "))
                {
                    output = output.Replace("  ", " ");
                    TryToCentreOutputOnScreen(output);
                }
            }

            return output;
        }

        private static int CheckForValidNumberOfLines(int lines, int min, int max)
        {
            if (lines < min)
            {
                Console.WriteLine($"The minimum number of lines is {min}!");
                lines = min;
            }

            if (lines > max)
            {
                Console.WriteLine($"The maximum number of lines is {max}!");
                lines = max;
            }

            return lines;
        }
    }
}
