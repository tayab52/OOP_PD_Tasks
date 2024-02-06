using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4_Week3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();
            Book book = new Book("Pride and Prejudice", "Jane Austen", 1813,19.99f,25);
        Start:
            int option = mainMenu();
            if (option == 1)
            {
                Console.Write("Enter Book Name: ");
                string name=Console.ReadLine();
                Console.Write("Enter Book Author: ");
                string author=Console.ReadLine();
                Console.Write("Enter Book Publication Year: ");
                int year=int.Parse(Console.ReadLine());
                Console.Write("Enter Book Price: ");
                float price=float.Parse(Console.ReadLine());
                Console.Write("Enter Book Quantity: ");
                int quantity=int.Parse(Console.ReadLine());
                Book addBook=new Book(name, author, year, price, quantity);
                bookList.Add(addBook);
            }
            else if (option == 2)
            {
                Console.WriteLine("BookName\t\tBookAuther\tPublicationYear\t\tBookPrice\tQuantityInStock");
                for (int i = 0; i < bookList.Count; i++)
                {
                    bookList[i].bookDetail();
                }
            }
            else if (option == 3)
            {

                Console.WriteLine("Enter Book Title: ");
                string name=Console.ReadLine() ;
                bool value = false;
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (name == bookList[i].bookTitle)
                    {
                        Console.WriteLine("Author Name: " + bookList[i].bookAuthor);
                        value = true;
                        break;
                    }
                }
                if (value) { }
                else
                {
                    Console.WriteLine("Enter Correct Name.");
                    Console.ReadKey();
                    goto Start;
                }
            }
            else if (option == 4)
            {
                Console.WriteLine("Enter Book Title: ");
                string name = Console.ReadLine();
                bool value = false;
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (name == bookList[i].bookTitle)
                    {
                        Console.WriteLine("Enter Copies amount: ");
                        int copies=int.Parse(Console.ReadLine());
                        Console.WriteLine("Remaining Copies: "+bookList[i].sellCopies(copies));
                        value = true;
                        break;
                    }
                }
                if (value) { }
                else
                {
                    Console.WriteLine("Enter Correct Name.");
                    Console.ReadKey();
                    goto Start;
                }
            }
            else if (option == 5)
            {
                Console.WriteLine("Enter Book Title: ");
                string name = Console.ReadLine();
                bool value = false;
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (name == bookList[i].bookTitle)
                    {
                        Console.WriteLine("Enter Copies amount: ");
                        int copies = int.Parse(Console.ReadLine());
                        Console.WriteLine("Available Copies: " + bookList[i].restock(copies));
                        value = true;
                        break;
                    }
                }
                if (value) { }
                else
                {
                    Console.WriteLine("Enter Correct Name.");
                    Console.ReadKey();
                    goto Start;
                }
            }
            else if (option == 6)
            {
                Console.WriteLine("Total Books in Store: " + bookList.Count);

            }
            else if (option == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("Enter correct option.");
            }

            /* if (option == 1)
             {
                Console.WriteLine( book.getTitle());
             }
             else if (option == 2)
             {
                Console.WriteLine( book.getAuthor());
             }
             else if (option == 3)
             {
                 Console.WriteLine(book.getPublicationYear());
             }
             else if (option == 4)
             {
                 Console.WriteLine(book.getPrice());
             }
             else if (option == 5)
             {
                 Console.WriteLine("Remaining Copies: "+book.sellCopies(10));
             }
             else if (option == 6)
             {
                 Console.WriteLine("Quanity Available: "+book.restock(10));
             }
             else if (option == 7)
             {
                book.bookDetail();
             }
             else
             {
                 Console.WriteLine("Enter correct option.");
             }*/
            Console.ReadKey();
            goto Start;

        }
       /* static int mainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Get Boook Title.");
            Console.WriteLine("2. Get Boook Author.");
            Console.WriteLine("3. Get Boook Publication Year.");
            Console.WriteLine("4. Get Boook Price.");
            Console.WriteLine("5. Buy Book.");
            Console.WriteLine("6. Add Book.");
            Console.WriteLine("7. Book Detail.");
            Console.Write("Enter your option: ");
            int option=int.Parse(Console.ReadLine());
            return option;
        }*/
        static int mainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Book.");
            Console.WriteLine("2. View All Books.");
            Console.WriteLine("3. Author Detail of specific book.");
            Console.WriteLine("4. Sell Specific Book.");
            Console.WriteLine("5. Restock a Book.");
            Console.WriteLine("6. Count of Books.");
            Console.WriteLine("0. Exit.");
            Console.Write("Enter your option: ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
