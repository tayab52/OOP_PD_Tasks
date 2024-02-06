using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week3_LabOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Calculator newObject = new Calculator();
        StartMenu:
            int option = MainMenu();

            if (option == 1)
            {
                Console.Write("Enter First Value: ");
                float value1 = float.Parse(Console.ReadLine());
                Console.Write("Enter second Value: ");
                float value2 = float.Parse(Console.ReadLine());
                Calculator object1 = new Calculator(value1, value2);
                newObject = object1;
            }
            else if (option == 2)
            {
                Console.WriteLine("Enter Updated First Value: ");
                float value1 = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Updated second Value: ");
                float value2 = float.Parse(Console.ReadLine());
                newObject.updateObjectValues(value1, value2);
            }
            else if (option == 3)
            {
                float result = newObject.addition();
                Console.WriteLine("{0} + {1} = {2}", newObject.value1, newObject.value2, result);
            }
            else if (option == 4)
            {
                float result = newObject.subtraction();
                Console.WriteLine("{0} - {1} = {2}", newObject.value1, newObject.value2, result);
            }
            else if (option == 5)
            {
                float result = newObject.multiplication();
                Console.WriteLine("{0} * {1} = {2}", newObject.value1, newObject.value2, result);
            }
            else if (option == 6)
            {
                float result = newObject.division();
                Console.WriteLine("{0} / {1} = {2}", newObject.value1, newObject.value2, result);
            }
            else if (option == 7)
            {
                float result = newObject.Modulo();
                Console.WriteLine("{0} % {1} = {2}", newObject.value1, newObject.value2, result);
            }
            else if (option == 8)
            {
                Console.Write("Enter Square root Value: ");
                newObject.value=float.Parse(Console.ReadLine());
                Console.Write("Square Root({0}) = ", newObject.value);
                newObject.SquareRoot();
            }
            else if (option == 9)
            {
                Console.Write("Enter Exponent Value: ");
                newObject.value = float.Parse(Console.ReadLine());
                Console.Write("Exponent({0}) = ", newObject.value);
                newObject.Exponent();

            }
            else if (option == 10)
            {
                Console.Write("Enter Log Value: ");
                newObject.value = float.Parse(Console.ReadLine());
                Console.Write("Log({0}) = ", newObject.value);
                newObject.Logarithm();
            }
            else if (option == 11)
            {
                Console.Write("Enter trigonomatric Operator (sin,cos,tan): ");
                newObject.operation = (Console.ReadLine());
                Console.Write("Enter Value: ");
                newObject.value = float.Parse(Console.ReadLine());

                Console.Write("{0}({1}) = ", newObject.operation,newObject.value);
                newObject.trigonomatricOperations();
            }
            else if (option == 0)
            {

                return;
            }
            else
            {
                Console.WriteLine("Enter Valid Option.");
                Console.ReadKey();
                goto StartMenu;
            }
            Console.ReadKey();
            goto StartMenu;

        }




        static int MainMenu()
        {
            Console.Clear();

            int result = 0;
            Console.WriteLine("1.  Create a Single Object of Calculator.");
            Console.WriteLine("2.  Change Values of Attributes.");
            Console.WriteLine("3.  Add.");
            Console.WriteLine("4.  Subtract.");
            Console.WriteLine("5.  Multiply.");
            Console.WriteLine("6.  Divide.");
            Console.WriteLine("7.  Modulo.");
            Console.WriteLine("8.  Square Root.");
            Console.WriteLine("9.  Exponent.");
            Console.WriteLine("10. Logarithm.");
            Console.WriteLine("11. Trigonomatric Operations.");
            Console.WriteLine("0.  Exit.");
            Console.Write("\tEnter Option: ");
            result = int.Parse(Console.ReadLine());
            return result;
        }
    }
}
