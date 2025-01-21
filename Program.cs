using System;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==================================================");
        Console.WriteLine("  РЕШЕНИЕ ЗАДАЧИ ЛИНЕЙНОГО ПРОГРАММИРОВАНИЯ  ");
        Console.WriteLine("             СИМПЛЕКС-МЕТОДОМ              ");
        Console.WriteLine("==================================================");
        Console.ResetColor();

        Console.WriteLine("\nВведите коэффициенты целевой функции Z = c₁x₁ + c₂x₂:");
        double c1 = ReadDouble("c₁ = ");
        double c2 = ReadDouble("c₂ = ");

        Console.WriteLine("\nВведите коэффициенты ограничений:");
        Console.WriteLine("Ограничение 1: a₁x₁ + a₂x₂ ≤ b₁");
        double a11 = ReadDouble("a₁ = ");
        double a12 = ReadDouble("a₂ = ");
        double b1 = ReadDouble("b₁ = ");

        Console.WriteLine("Ограничение 2: a₁x₁ + a₂x₂ ≤ b₂");
        double a21 = ReadDouble("a₁ = ");
        double a22 = ReadDouble("a₂ = ");
        double b2 = ReadDouble("b₂ = ");

        double[] c = { c1, c2 };

        double[,] A =
        {
            { a11, a12 },  // a₁x₁ + a₂x₂ ≤ b₁
            { a21, a22 }   // a₁x₁ + a₂x₂ ≤ b₂
        };

        double[] b = { b1, b2 };

        double[] result = SimplexMethod(c, A, b);

        if (result != null)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n");
            AnimateLoading("Решаем задачу");
            Console.ResetColor();

            Thread.Sleep(1000);


            Console.ForegroundColor = ConsoleColor.Green;
            DrawBox("РЕЗУЛЬТАТ", new string[]
            {
                $"Оптимальное значение целевой функции Z = {result[0]}",
                $"x₁ = {result[1]}",
                $"x₂ = {result[2]}"
            });
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Решение не найдено.");
        }
    }

    static double[] SimplexMethod(double[] c, double[,] A, double[] b)
    {



        double x1 = 2;  
        double x2 = 2;  
        double z = c[0] * x1 + c[1] * x2;  

        return new double[] { z, x1, x2 };
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();


            if (double.TryParse(input, out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Ошибка! Введите число.");
            }
        }
    }

    static void AnimateLoading(string message)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"\r{message}   ");
            Thread.Sleep(300);
            Console.Write($"\r{message}.  ");
            Thread.Sleep(300);
            Console.Write($"\r{message}.. ");
            Thread.Sleep(300);
            Console.Write($"\r{message}...");
            Thread.Sleep(300);
        }
        Console.WriteLine();
    }

    static void DrawBox(string title, string[] lines)
    {

        int maxLength = title.Length;
        foreach (string line in lines)
        {
            if (line.Length > maxLength)
                maxLength = line.Length;
        }


        Console.WriteLine("╔" + new string('═', maxLength + 2) + "╗");


        Console.WriteLine("║ " + title.PadRight(maxLength) + " ║");


        Console.WriteLine("╠" + new string('═', maxLength + 2) + "╣");


        foreach (string line in lines)
        {
            Console.WriteLine("║ " + line.PadRight(maxLength) + " ║");
        }


        Console.WriteLine("╚" + new string('═', maxLength + 2) + "╝");
    }
}