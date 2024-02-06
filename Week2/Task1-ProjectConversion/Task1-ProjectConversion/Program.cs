using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week2_PD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SignUp[] signUp = new SignUp[15];
            Products[] product = new Products[15];
            int count = 0;
            int productCount = 0;
            string path1 = "customerData.txt";
            string path2 = "productData.txt";
            readData(signUp, path1, ref count);
            readProductsData(product, path2, ref productCount);
        Start:
            int value = MainMenu();
            int index = -1;
            if (value == 1)
            {
                index = SignIN(signUp, count);

            }
            else if (value == 2)
            {
                SignUP(signUp, ref count);
                goto Start;
            }
            else if (value == 3)
            {
                storeData(signUp, path1, count);
                storeProductsData(product, path2, productCount);
                Console.WriteLine("Thanks for coming.");
                Console.ReadKey();
                return;

            }

            else
            {
                Console.WriteLine("Enter valid Input");
            }
            if (index == -1)
            {
                Console.WriteLine("Enter valid readrmation");
                Console.ReadKey();
                goto Start;
            }
            else
            {
                int Option = 0;
                if (signUp[index].role == "admin")
                {
                admin:
                    Option = adminMenu(signUp[index].userName);
                    if (Option == 1)
                    {
                        viewCustomers(signUp, count);
                    }
                    else if (Option == 2)
                    {
                        removeCustomers(signUp, ref count);
                    }
                    else if (Option == 3)
                    {
                        addProducts(product, ref productCount);
                    }
                    else if (Option == 4)
                    {
                        viewProducts(product, productCount);
                    }
                    else if (Option == 5)
                    {
                        updateProducts(product, productCount);
                    }
                    else if (Option == 6)
                    {
                        deleteProducts(product, ref productCount);
                    }
                    else if (Option == 0)
                    {
                        goto Start;

                    }
                    else
                    {
                        Console.WriteLine("Enter Correct Option.");
                        Console.ReadKey();
                    }

                    goto admin;
                }
            }
            Console.ReadKey();


        }
        static int MainMenu()
        {
            Console.Clear();
            int value = 0;
            // int menuOption;

            Console.WriteLine("L O G I N    M E N U <<");

            Console.WriteLine("\t\t\t\t\t\t\t1. Sign In");
            Console.WriteLine("\t\t\t\t\t\t\t2. Sign Up");
            Console.WriteLine("\t\t\t\t\t\t\t3. Exit");

            Console.Write("\t\t\t\t\t\t\tEnter any number: ");
            value = int.Parse(Console.ReadLine());
            return value;
        }
        static void SignUP(SignUp[] signUp, ref int count)
        {
            string Name = "";
            bool value = true;
            string Password = "";
            string role = "";
            Console.Write("Enter Your Name: ");
            Name = Console.ReadLine();
            for (int x = 0; x < count; x++)
            {
                if (Name == signUp[x].userName)
                {
                    Console.WriteLine("UserName already taken");
                    value = false;
                    break;
                }
            }
            if (value)
            {
                Console.Write("Enter Your Password: ");
                Password = Console.ReadLine();
                Console.Write("Enter Your Role(admin/employee/customer): ");
                role = Console.ReadLine();
            }
            if (checkRole(role))
            {
                /*cust.role = role;
                cust.userName = Name;
                cust.userPassword = Password;*/
                SignUp cust = new SignUp(Name, Password, role);

                signUp[count] = cust;
                count++;
                Console.WriteLine("User Registered Successfully");
            }
            else
            {
                Console.WriteLine("Enter valid readrmation");
                SignUP(signUp, ref count);
            }
            Console.ReadKey();
        }


        static int SignIN(SignUp[] signUp, int count)
        {
            string Name;
            int index = -1;
            string Password = "";
            string role = "";
            Console.Write("Enter Your Name: ");
            Name = Console.ReadLine();
            for (int x = 0; x < count; x++)
            {
                if (Name == signUp[x].userName)
                {
                    index = x;
                    break;
                }
            }
            if (index != -1)
            {
                Console.Write("Enter Your Password: ");
                Password = Console.ReadLine();
                Console.Write("Enter Your Role(admin/employee/customer): ");
                role = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Enter Valid Name.");

            }
            if (checkUser(signUp, Name, Password, role, index))
            {
                return index;
            }
            Console.ReadKey();
            return -1;
        }
        static int adminMenu(string adminName)
        {
            Console.Clear();
            Console.WriteLine("A D M I N    I N T E R F A C E  <<");

            Console.WriteLine("\t\tWelcome " + adminName);
            int option = 0;
            Console.WriteLine("\t\t\t\t\t1.    View Customer Detail.");
            Console.WriteLine("\t\t\t\t\t2.    Remove Customer.");
            Console.WriteLine("\t\t\t\t\t3.    Add Product.");
            Console.WriteLine("\t\t\t\t\t4.    View Products in Store.");
            Console.WriteLine("\t\t\t\t\t5.    Update Products.");
            Console.WriteLine("\t\t\t\t\t6.    Delete Products.");
            Console.WriteLine("\t\t\t\t\t0.    Logout.");
            Console.Write("\t\t\t\tEnter your option:");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void viewCustomers(SignUp[] signUp, int count)
        {
            Console.WriteLine("Name\tPassword\tRole");
            for (int i = 0; i < count; i++)
            {
                if (signUp[i].role == "admin")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"{signUp[i].userName}\t{signUp[i].userPassword}\t{signUp[i].role}");
                }
            }
            Console.ReadLine();
        }
        static void removeCustomers(SignUp[] signUp, ref int count)
        {
            string name;
            int index = -1;
            viewCustomers(signUp, count);
            Console.WriteLine("Enter Customer Name to remove: ");
            name = Console.ReadLine();
            for (int x = 0; x < count; x++)
            {
                if (name == signUp[x].userName)
                {
                    index = x;
                    break;
                }
            }
            if (index != -1)
            {
                signUp[index].userName = "";
                signUp[index].userPassword = "";
                signUp[index].role = "";
                arrayShift(signUp, ref count, index);
                Console.WriteLine("Customer Removed Successfully");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Not Exist.");
            }
        }
        static void addProducts(Products[] product, ref int productCount)
        {
            Products products = new Products();
            Console.Write("Enter Product Name: ");
            products.productName = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            products.productPrice = float.Parse(Console.ReadLine());
            Console.Write("Enter Product Quantity: ");
            products.productQuantity = int.Parse(Console.ReadLine());
            product[productCount] = products;
            productCount++;
        }
        static void viewProducts(Products[] product, int productCount)
        {
            Console.WriteLine($"ProductName\tProductPrice\tProductQuantity");
            for (int x = 0; x < productCount; x++)
            {
                Console.WriteLine($"{product[x].productName}\t\t{product[x].productPrice}\t\t{product[x].productQuantity}");
            }
            Console.ReadKey();
        }
        static void deleteProducts(Products[] product, ref int productCount)
        {
            string name;
            int index = -1;
            viewProducts(product, productCount);
            Console.Write("\tEnter Product Name to Delete: ");
            name = Console.ReadLine();
            for (int x = 0; x < productCount; x++)
            {
                if (name == product[x].productName)
                {
                    index = x;
                    break;
                }
            }
            if (index != -1)
            {
                product[index].productName = "";
                product[index].productPrice = 0.0f;
                product[index].productQuantity = 0;
                productArrayShift(product, ref productCount, index);
                Console.WriteLine("Product Deleted Successfully");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Not Exist.");
            }


        }
        static void updateProducts(Products[] products, int productCount)
        {
            string name;
            int index = -1;
            viewProducts(products, productCount);
            Console.WriteLine("\tEnter Product Name to update: ");
            name = Console.ReadLine();
            for (int x = 0; x < productCount; x++)
            {
                if (name == products[x].productName)
                {
                    index = x;
                    break;
                }
            }
            if (index != -1)
            {
                Console.Write("Updated Name: ");
                products[index].productName = Console.ReadLine();
                Console.Write("Updated Price: ");
                products[index].productPrice = float.Parse(Console.ReadLine());
                Console.Write("Updated Quantity: ");
                products[index].productQuantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Product Updated Successfully.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Not Exist.");
            }

        }
        static void storeData(SignUp[] signUp, string path1, int count)
        {



            for (int x = 0; x < count; x++)
            {
                SignUp store = new SignUp();
                store = signUp[x];
                StreamWriter file = new StreamWriter(path1, true);
                file.WriteLine("{0},{1},{2}", store.userName, store.userPassword, store.role);
                file.Flush();
                file.Close();
            }


        }
        static void storeProductsData(Products[] product, string path2, int productCount)
        {
            for (int x = 0; x < productCount; x++)
            {
                Products storeProduct = new Products();
                storeProduct = product[x];
                StreamWriter file = new StreamWriter(path2, true);
                file.WriteLine(storeProduct.productName + "," + storeProduct.productPrice + "," + storeProduct.productQuantity);
                file.Flush();
                file.Close();
            }

        }
        static void readProductsData(Products[] product, string path2, ref int productCount)
        {

            if (File.Exists(path2))
            {
                StreamReader fileVariable = new StreamReader(path2);
                string value = "";
                while ((value = fileVariable.ReadLine()) != null)
                {
                    Products read = new Products();
                    read.productName = parseData(value, 1);
                    read.productPrice = float.Parse(parseData(value, 2));
                    read.productQuantity = int.Parse(parseData(value, 3));
                    product[productCount] = read;
                    productCount++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Product File Not Exists");
                Console.ReadKey();
            }
        }
        static void readData(SignUp[] signUp, string path1, ref int Count)
        {

            if (File.Exists(path1))
            {
                StreamReader fileVariable = new StreamReader(path1);
                string value = "";
                while ((value = fileVariable.ReadLine()) != null)
                {
                    SignUp read = new SignUp();
                    read.userName = parseData(value, 1);
                    read.userPassword = (parseData(value, 2));
                    read.role = (parseData(value, 3));
                    signUp[Count] = read;
                    Count++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Customer File " +
                    "Not Exists");
                Console.ReadKey();
            }
        }
        static string parseData(string record, int field)
        {
            int count = 1;
            string value = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    count++;
                }
                else
                {
                    value += record[x];
                }
            }
            return value;
        }
        static void arrayShift(SignUp[] signUp, ref int count, int index)
        {
            if (count == 0 || index < 0 || index >= count)
            {
                // Invalid index or empty array
                return;
            }

            for (int x = index; x < count - 1; x++)
            {
                signUp[x].userName = signUp[x + 1].userName;
                signUp[x].userPassword = signUp[x + 1].userPassword;
                signUp[x].role = signUp[x + 1].role;
            }

            // Clear the last element 
            signUp[count - 1].userName = "";
            signUp[count - 1].userPassword = "";
            signUp[count - 1].role = "";

            count--;
        }
        static void productArrayShift(Products[] product, ref int productCount, int index)
        {
            if (productCount == 0 || index < 0 || index >= productCount)
            {
                // Invalid index or empty array
                return;
            }

            for (int x = index; x < productCount - 1; x++)
            {
                product[x].productName = product[x + 1].productName;
                product[x].productPrice = product[x + 1].productPrice;
                product[x].productQuantity = product[x + 1].productQuantity;
            }

            // Clear the last element 
            product[productCount - 1].productName = "";
            product[productCount - 1].productPrice = 0.0f;
            product[productCount - 1].productQuantity = 0;

            productCount--;
        }
        static bool checkUser(SignUp[] signUp, string Name, string password, string role, int index)
        {
            if (index == -1)
            {
                return false;
            }
            else if (Name == signUp[index].userName && password == signUp[index].userPassword && role == signUp[index].role)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool checkRole(string role)
        {
            if (role == "admin" || role == "employee" || role == "customer")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
