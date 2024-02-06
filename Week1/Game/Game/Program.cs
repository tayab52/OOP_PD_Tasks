using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int pX = 10, pY = 20;
            int e1X = 1, e1Y = 1;
            int e12X = 72, e12Y = 1;
            int e2X = 81, e2Y = 4;
            int fX = pX + 3, fY = pY - 1;
            int fLX = pX - 1, fLY = pY + 1;
            int fRX = pX + 7, fRY = pY + 1;
            int EfX = e1X + 3, EfY = e1Y + 3;
            int E12fX = e12X + 3, E12fY = e12Y + 3;
            int E2fX = e2X - 1, E2fY = e2Y + 1;
            int E1score = 6;
            int E12score = 6;
            int E2score = 6;
            int Pscore = 9;
            int Lives = 3;
            int screenWidth = 100;
            int screenHeight = 40;
            char currentChar;
            int value = startingInterface();
            if (value == 2)
            {
                instruction();
                Main(args);
            }
            else
            {
                int removeEnemy1 = 0;
                int removeEnemy12 = 0;
                int removeEnemy2 = 0;
                E12score = 6;
                E2score = 6;
                printMaze();
                E1board(E1score,E12score,E2score);
                printPboard(Pscore);
                printEnemy1(e1X,e1Y);
                printEnemy12(e12X,e12Y);
                printEnemyDown2();
                printPlayer();
            }
        }
        static int startingInterface()
        {
            header();
            //   vector<string> j = { "1. Load Game", "2. Instruction" }; // to move by button
            // ShowMenu(j);
            // return option + 1;
            return 1;
        }
        static void header()
        {
            Console.WriteLine( "\t\t   __    ___  ___    __    ___  ___  ____  _  _    ___     ___    " );
            Console.WriteLine("\t\t  /__\\  / __)/ __)  /__\\  / __)/ __)(_  _)( \\( )  (__ \\   / _ \\   ");
            Console.WriteLine("\t\t /(__)\\ \\__ \\\\__ \\ /(__)\\ \\__ \\\\__ \\ _)(_  )  (    / _/  ( (_) )  ");
            Console.WriteLine("\t\t(__)(__)(___/(___/(__)(__)(___/(___/(____)(_)(_)  (____)()\\___/   ");
        }
        static void instruction()
        {
            //system("cls");
            //////color(10);
            Console.WriteLine( "\t\tINSTRUCTIONS:" );

            Console.WriteLine( "Movenment:" );
            ////color(6);
            Console.WriteLine( "\tUp key                move player Upward" );
            Console.WriteLine( "\tDown key                move player Downward" );
            Console.WriteLine( "\tLeft key                move player Left" );
            Console.WriteLine( "\tRight key                move player Right" );
            Console.WriteLine( "\tspace key                player bullet towards face of player" );
            ////color(10);
            Console.WriteLine( "Player:" );
            ////color(6);
            Console.WriteLine( "\tContain Three Lives" );
            Console.WriteLine( "\tlive decrement by 3 bullets or collision with enemy." );
            Console.WriteLine( "\tlive increment by removal of any enemy" );
            Console.WriteLine( "\tPlayer dead if live is 0" );
            ////color(10);
            Console.WriteLine( "Enemies:" );
            ////color(6);
            Console.WriteLine( "\tContain Three Enemies" );
            Console.WriteLine( "\tEach enemy ////color change from green to yellow and to red by hitting bullets." );
            Console.WriteLine( "\tEnemy dead after red ////color" );

            Console.WriteLine( "Press any key to continue..");
          

        }
        static void printMaze()
            {
                // Define the pattern as a 2D array
                string[,] pattern = {
            { "#########################################################################################", },
            { "#                                                                                       #", },
            { "#                                                                              #        #", },
            { "#                                                                              #        #", },
            { "#                                                                              #        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|                                    #        #", },
            { "####         #######                   |$%|                                    #        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|&&||%$||&&|                  ########        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|                                    #        #", },
            { "#                                      |$%|                                             #", },
            { "#                         |!&||%$||&&|@|$%|                                             #", },
            { "#                                                                                       #", },
            { "#                                                                                       #", },
            { "#                                                                                       #", },
            { "#                                                                                       #", },
            { "#                                                                                       #", },
            { "#                                                                                       #", },
            { "#########################################################################################", },
        };

                // Print the pattern
                PrintPattern(pattern);
            }

            static void PrintPattern(string[,] pattern)
            {
                // Get the dimensions of the array
                int rows = pattern.GetLength(0);
                int cols = pattern.GetLength(1);

                // Iterate through the array and print each element
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(pattern[i, j]);
                    }
                    // Move to the next line after printing each row
                    Console.WriteLine();
                }
            }
            static void E1board(int E1score,int E12score,int E2score)
        {
            //color(10);
            Console.SetCursorPosition(106, 2);
            Console.WriteLine( "Enemy 1 Health:" + E1score );
            Console.SetCursorPosition(106, 3);
            Console.WriteLine( "Enemy 2 Health:" + E12score );
            Console.SetCursorPosition(106, 4);
            Console.WriteLine( "Enemy 3 Health:" + E2score );
            //color(7);
        }
        static void printPboard(int Pscore)
        {
            
            Console.SetCursorPosition(106, 20);
            Console.Write( "@@@@@@@@@" );
            Console.SetCursorPosition(106, 21);
            Console.Write( "@       @" );
            Console.SetCursorPosition(106, 22);
            Console.Write( "@@@@@@@@@" );
            Console.SetCursorPosition(107, 21);
           
            Console.Write( Pscore);
           
        }
        static void printEnemy1(int e1X,int e1Y)
        {
           
            Console.SetCursorPosition(e1X, e1Y);
            Console.Write( "  /\\  ");
            Console.SetCursorPosition(e1X, e1Y + 1);
            Console.Write( "||~~||");
            Console.SetCursorPosition(e1X, e1Y + 2);
            Console.Write( "  \\/  ");
            
        }
        static void printEnemy12(int e12X,int e12Y)
        {
           /* if (E12score >= 5)
            {
                Color(10);
            }
            else if (E12score < 5 && E12score >= 3)
            {
                Color(6);
            }
            else if (E12score < 3)
            {
                Color(4);
            }*/
            Console.SetCursorPosition(e12X, e12Y);
            Console.Write( "  /\\  ");
            Console.SetCursorPosition(e12X, e12Y + 1);
            Console.Write( "||~~||");
            Console.SetCursorPosition(e12X, e12Y + 2);
            Console.Write( "  \\/  ");
           
        }
        static void printEnemyDown2()
        {
           /* if (E2score >= 5)
            {
                Color(10);
            }
            else if (E2score < 5 && E2score >= 3)
            {
                Color(6);
            }
            else if (E2score < 3)
            {
                Color(4);
            }

            gotoxy(e2X, e2Y);
            cout << "=====" << endl;
            gotoxy(e2X, e2Y + 1);
            cout << "\\~~~/" << endl;
            gotoxy(e2X, e2Y + 2);
            cout << " \\~/ " << endl;
            Color(7);*/
        }
    }
}
