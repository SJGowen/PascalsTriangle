﻿using System;
using System.Diagnostics;

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

            for (int n = 0; n < lines; n++)
            {
                long val = 0;
                string output = "";
                for (int k = 0; k <= n; k++)
                {

                    if (k == 0 || n == 0)
                    {
                        val = 1;
                    }
                    else
                    {
                        val = val * (n + 1 - k) / k;

                    }

                    output += $" {val} ";
                }

                try
                {
                    output = output.Trim();
                    Console.SetCursorPosition((Console.WindowWidth - output.Length) / 2, Console.CursorTop);
                }
                catch (Exception)
                {
                    Debug.WriteLine("Output length is greater than WindowWidth.");
                    
                    var lastOutputLength = Int32.MaxValue;
                    while (lastOutputLength > output.Length && Console.WindowWidth < output.Length)
                    {
                        lastOutputLength = output.Length;
                        output = output.Replace("  ", " ");
                    }
                }

                Console.WriteLine(output);
            }
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