using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                double number1 = GetNumber("Пожалуйста введите первое число");
                double number2 = GetNumber("Пожалуйста введите второе число");

                Console.WriteLine("Пожалуйста, выберите команду: +, -, *, /, max, min");
                string cmd = Console.ReadLine().ToLower();

                double result = GetResult(number1, number2, cmd);

                Console.WriteLine(result);

            } while (AskContinue());
                 
        }

        private static bool AskContinue()
        {
            while (true)
            {
            Console.WriteLine("Хотите продолжить? Y/N");
                var status = Console.ReadLine().ToUpper();
                if (status == "Y")
                    return true;
                else if (status == "N")
                    return false;
                else
                    Console.WriteLine("Операция не распознана, Введите Y или N:");
            }
        }

        private static double GetResult(double number1, double number2,string cmd)
        {
            double result;

            switch (cmd)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
                case "max":
                    result = GetMax(number1, number2);
                    break;
                case "min":
                    result = GetMin(number1, number2);
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
        static double GetNumber(string text) 
        {
            Console.WriteLine(text);

            while (true)
            {
                string str = Console.ReadLine();
                double result;
                if (Double.TryParse(str, out result))
                    return result;
                else
                    Console.WriteLine("Неправильный формат числа. Попробуйте еще раз");
            }
            
        }
        static double GetMax(double number1,double number2)
        {
            double max = 0;
            if(number1 > number2)
            {
                max = number1;
            }
            else
            {
                max = number2;
            }
            return max;
        }
        static double GetMin(double number1, double number2)
        {
            double min = 0;
            if (number1 < number2)
            {
                min = number1;
            }
            else
            {
                min = number2;
            }
            return min;
        }
    }
}
