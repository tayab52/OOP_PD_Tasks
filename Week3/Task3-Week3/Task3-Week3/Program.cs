using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3_Week3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
          
            Console.WriteLine("New Game");
            
            List<Shiritori> my_Shiritori = new List<Shiritori>();
            int countWord = 0;
         Start:
            Shiritori shiritori = new Shiritori();
            Console.Write("Enter Word: ");
            string word=Console.ReadLine();
            if (game_check(my_Shiritori, word)) 
            {
                if (my_Shiritori.Count > 0) 
                { 
                     Shiritori Digit = new Shiritori();
                    Digit = my_Shiritori[my_Shiritori.Count-1];
                    if (check_Word(word,Digit.word))
                    {
                    shiritori.word = word;
                    my_Shiritori.Add(shiritori);
                    countWord++;
                    goto Start;
                    }
                    else
                    {
                       Console.WriteLine("The first Digit Not equal last digit.");
                    }
                }
                else
                {
                    shiritori.word = word;
                    my_Shiritori.Add(shiritori);
                    countWord++;
                    goto Start;
                }

            }
            else
            {
                Console.WriteLine("Word Already Exist");
                Console.ReadKey();
                return;
            }
            Console.ReadKey();
            Main(args);
           

            
            
        }
        static bool check_Word(string word,string lastDigit)
        {
            
                if (word[0] == lastDigit[lastDigit.Length-1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
           // return false;
        }
        static bool game_check(List<Shiritori> my_shiritori, string word)
        {
            for (int i = 0; i < my_shiritori.Count; i++)
            {
                if (word == my_shiritori[i].word)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
