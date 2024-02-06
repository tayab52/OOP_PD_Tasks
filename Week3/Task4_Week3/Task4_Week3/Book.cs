using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Week3
{
    internal class Book
    {
        public Book(string name,string author,int year,float price,int stock) { 
        bookTitle = name;
        bookAuthor = author;
        publicationYear = year;
        bookPrice = price;
        quantityInStock = stock;
        }
        public Book() { }
        public string bookTitle;
        public string bookAuthor;
        public int publicationYear;
        public float bookPrice;
        public int quantityInStock;

        public string getTitle()
        {
            return bookTitle;
        }
        public string getAuthor()
        {
            return bookAuthor;
        }
        public int getPublicationYear()
        {
            return publicationYear;
        }
        public float getPrice()
        {
            return bookPrice;
        }
        public int sellCopies(int copies)
        {
            if (copies > 0 && copies <= quantityInStock)
            {
                quantityInStock -= copies;
                Console.WriteLine("Copies Selled");
                return quantityInStock;

            }
            else
            {
                Console.WriteLine("Enter correct input");
                return 0;
            }
        }

        public int restock(int additionalCopies)
        {
            if (additionalCopies > 0)
            {
                quantityInStock += additionalCopies;
                Console.WriteLine("Copies Added");
                return quantityInStock;

            }
            else
            {
                Console.WriteLine("Enter correct input");
                return 0;
            }
        }

        public void bookDetail()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t\t\t{3}\t\t{4}",bookTitle,bookAuthor,publicationYear,bookPrice,quantityInStock);

        }
    }
}
