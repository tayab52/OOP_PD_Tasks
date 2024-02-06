using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.Clear();
           Calculator newObject =new Calculator();
        StartMenu:
            int option = MainMenu();
           
            if (option == 1)
            {
                Console.Write("Enter First Value: ");
                float value1=float.Parse(Console.ReadLine());
                Console.Write("Enter second Value: ");
                float value2=float.Parse(Console.ReadLine());
                Calculator object1 =new Calculator(value1,value2);
                newObject = object1;
            }
            else if(option == 2)
            {
                Console.WriteLine("Enter Updated First Value: ");
                float value1 = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Updated second Value: ");
                float value2 = float.Parse(Console.ReadLine());
                newObject.updateObjectValues(value1,value2);
            }
            else if(option == 3)
            {
                float result=newObject.addition();
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
            else if(option == 6){
                float result = newObject.division();
                Console.WriteLine("{0} / {1} = {2}", newObject.value1, newObject.value2, result);
            }
            else if(option == 7){
                float result = newObject.Modulo();
                Console.WriteLine("{0} % {1} = {2}", newObject.value1, newObject.value2, result);
            }
            else if(option == 8)
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
            Console.WriteLine("1. Create a Single Object of Calculator.");
            Console.WriteLine("2. Change Values of Attributes.");
            Console.WriteLine("3. Add.");
            Console.WriteLine("4. Subtract.");
            Console.WriteLine("5. Multiply.");
            Console.WriteLine("6. Divide.");
            Console.WriteLine("7. Modulo.");
            Console.WriteLine("8. Exit.");
            Console.WriteLine("\tEnter Option: ");
            result=int.Parse(Console.ReadLine());
            return result;
        }
    }
}
