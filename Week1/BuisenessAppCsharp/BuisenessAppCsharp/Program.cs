using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuisenessAppCsharp
{
    internal class Program
    {
        static int x = 55, y = 15;

        static void Main(string[] args)
        {
            const string adminName = "tayyab";
            const string adminPassword = "Tayyab146";
            int dealerCount = 0;

            int count = 0, productCount = 0;
            int size = 15, customerSize = 100;
           // int userIterations = 0;
           // int productIterations;
            int[] quantity = new int[size];
            string[] quantityString = new string[size];
            float[] price = new float[size];
            string[] priceString = new string[size];
            int deleteCount = 0;
            string[] customerName = new string[customerSize];
            string path1 = "customerData.txt";
            string path2 = "productData.txt";
            string[] customerPassword = new string[customerSize];
            string[] customerRole = new string[customerSize];
            string[] Feedback = new string[customerSize];
            string[] companyName = new string[size];

            string[] selledProducts = new string[10];
            int[] selledQuantity = new int[10];
            int sellCount = 0;
            float[] totalBill = new float[size];
            initializeBill(totalBill, size);

            int value = 1;

            while (value != 0)
            {
                printHeader();
                value = menu();
                string role;
                // load users data from the file
                /* count = readData(path1, customerName, customerPassword, customerRole, count);
                 // load product data from the file
                 productCount = readData(path2, companyName, priceString, quantityString, productCount);
                 for (int i = 0; i < productCount; i++)
                 {
                     quantity[i] = stoi(quantityString[i]);   // convert string to int
                     price[i] = stof(priceString[i]);       // convert string to float
                 }*/
                if (value == 1)
                {
                    role = checkRole();
                    if (role == "invalid")
                    {
                        //red Color for invalid input
                        Console.WriteLine("Please Enter valid role.");
                        Console.ReadKey();
                        continue;
                    }
                    printHeader();
                    int number = 0;
                    string Name;
                    string Password;
                    Color(12);           //light red Color for header
                    Console.WriteLine("S I G N-I N    M E N U <<");
                    Color(10);           // Color for header

                    Console.Write("\t\t\t\t\t\t\tEnter Name(atleast 5 characters): ");

                    Name = Console.ReadLine();
                    // cin>>Name;
                    if (!checkString(Name))
                    {
                        //   Color(4);     //red Color for header
                        Console.WriteLine("Enter valid String.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("\t\t\t\t\t\t\tEnter Password(atleast 8 characters): ");
                    // getline(cin, Password);
                    Password = Console.ReadLine();
                    if (!checkPassword(Password))
                    {
                        Console.WriteLine("Password contains at least 1 Uppercase and no special character!.");
                        Console.ReadKey();
                        continue;
                    }
                    if (Name == adminName && Password == adminPassword)
                    {
                        if (role == "admin" || role == "Admin")
                        {
                            int select = 1;
                            for (int i = 0; i < count; i++)
                            {
                                if (customerRole[i] == "Customer" || customerRole[i] == "customer")
                                {
                                    continue;
                                }
                                dealerCount++;
                            }
                            while (select != 0)
                            {
                                select = adminInterface(adminName);
                                if (select == 1)
                                {
                                    viewDealersDetail(customerName, customerPassword, customerRole, adminName, count);
                                }
                                else if (select == 2)
                                {
                                    addDealer(customerName, customerRole, customerPassword, ref count, ref dealerCount, adminName, path1);
                                }
                                else if (select == 3)
                                {
                                    removeDealer(customerName, customerPassword, customerRole, adminName, path1, ref count);
                                }
                                else if (select == 4)
                                {
                                    customerList(customerName, customerPassword, customerRole, adminName, count);
                                }
                                else if (select == 5)
                                {
                                    removecustomer(customerName, customerPassword, customerRole, path1, adminName, ref count);
                                }

                                else if (select == 6)
                                {
                                    viewProducts(companyName, price, quantity, productCount);
                                }
                                else if (select == 7)
                                {
                                    updateProduct(companyName, price, quantity, priceString, quantityString, path2, productCount, deleteCount);
                                }
                                else if (select == 8)
                                {
                                    sellProducts(selledProducts, selledQuantity, sellCount);
                                }
                                else
                                {
                                    break;
                                }
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine( "Enter valid role.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        bool signInValue = signIn(Name, Password, customerName, customerPassword, count);
                        if (signInValue == true)
                        {
                            for (int i = 0; i <= count; i++)
                            {
                                if (Name == customerName[i] && Password == customerPassword[i])
                                {
                                    number = i;
                                    break;
                                }
                            }
                            if (role == customerRole[number])
                            {

                                if (role == "Dealer" && (Name == customerName[number]) && (Password == customerPassword[number]))
                                {
                                    string name = customerName[number];
                                    int option = 1;
                                    while (option != 0)
                                    {
                                        option = DealerInterface();
                                        if (option == 1)
                                        {
                                            customerList(customerName, customerPassword, customerRole, name, count);
                                        }
                                        else if (option == 2)
                                        {
                                            removecustomer(customerName, customerPassword, customerRole, path1, name,ref count);
                                        }
                                        else if (option == 3)
                                        {
                                            addProduct(companyName, price, quantity, priceString, quantityString, path2,ref productCount, size);
                                        }
                                        else if (option == 4)
                                        {
                                            updateProduct(companyName, price, quantity, priceString, quantityString, path2, productCount, deleteCount);
                                        }
                                        else if (option == 5)
                                        {
                                            viewProducts(companyName, price, quantity, productCount);
                                        }
                                        else if (option == 6)
                                        {
                                            deleteProduct(companyName, price, quantity, priceString, quantityString, path2,ref productCount,ref deleteCount);
                                        }
                                        else if (option == 7)
                                        {
                                            viewFeedback(customerName, customerRole, number, Feedback, count);
                                        }
                                        Console.ReadKey();
                                    }
                                }
                                else if (role == "Customer")
                                {

                                    string[] boughtProduct = new string[10];
                                    int[] buyQuantity = new int[10];
                                    int buyCount = 0;
                                    int choice = 1;

                                    while (choice != 0)
                                    {
                                        choice = customerInterface(customerName, customerRole, number);
                                        if (choice == 1)
                                        {
                                            viewProducts(companyName, price, quantity, productCount);
                                        }
                                        else if (choice == 2)
                                        {
                                            buyProduct(companyName, price, quantity, number, totalBill, boughtProduct,ref buyCount, buyQuantity, selledProducts, selledQuantity,ref sellCount, productCount);
                                        }
                                        else if (choice == 3)
                                        {
                                            cartProducts(boughtProduct, buyQuantity, buyCount);
                                        }
                                        else if (choice == 4)
                                        {
                                            customerFeedback(number, Feedback);
                                        }
                                        else if (choice == 5)
                                        {
                                            resetPassword(customerName, customerPassword, customerRole, path1, count, number);
                                        }
                                        else if (choice == 6)
                                        {
                                            customerBill(customerName, boughtProduct, buyQuantity, totalBill, number, buyCount);
                                        }
                                        else if (choice == 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Color(4);
                                            Console.WriteLine( "Invalid input.");
                                        }
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Color(4);
                                    Console.WriteLine( "Invalid input.");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine( "Enter valid role.");
                                Console.ReadKey();
                                continue;
                            }
                        }
                        else
                        {
                            Color(4);
                            Console.WriteLine( "Incorrect password or Name.");
                            Console.WriteLine( "Try again...");
                            Console.ReadKey();
                        }
                    }
                    Console.ReadKey();
                }

                else if (value == 2)
                {
                    string number = "1";
                    while (number == "1")
                    {
                        string Name = "";
                        string password;
                        customerRole[count] = "Customer";
                        printHeader();
                        Color(4);
                        Console.WriteLine( "S I G N U P    M E N U <<" );
                        Color(9);
                        Console.WriteLine("\t\tSIGN UP AS A:\t" + customerRole[count] );
                        Color(10);
                        Console.Write( "\t\t\t\t\t\t\tEnter Name(atleast 4 characters): ");
                        // cin.ignore();                        // so that cin not contain garbage value
                         Name = Console.ReadLine();
                        if (!checkString(Name))
                        {
                            Console.WriteLine( "Enter valid String.");
                            Console.ReadKey();
                            continue;
                        }
                        if (Name == adminName)
                        {
                            Console.WriteLine( "Enter valid Name.");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write( "\n\t\t\t\t\t\t\tEnter Password(atleast 8 letters): ");
                        password = Console.ReadLine();
                        if (!checkPassword(password))
                        {
                            Color(9);
                            Console.WriteLine( "Password contains at least 1 Uppercase and no special character!");
                            Console.ReadKey();
                            continue;
                        }
                        customerName[count] = Name;
                        customerPassword[count] = password; // if validation correct then store data in array
                        bool signUpValue = signUp(customerName, customerPassword, count);
                        if (signUpValue)
                        {
                            count++;
                            //    storeData(path1, customerName, customerPassword, customerRole, count);
                            Color(3);

                            Console.WriteLine( "Registered successfully." );
                            Console.ReadKey();
                        }
                        else if (!signUpValue)
                        {
                            Color(4);
                            Console.WriteLine( "Sorry , customerName is already taken." );
                            customerName[count] = "";
                            customerPassword[count] = "";
                            Console.ReadKey();
                        }

                        printHeader();
                        Color(6);

                        Console.WriteLine( "Enter 1 to add customer or 0 to continue: ");
                        //  cin.ignore();
                        number = Console.ReadLine();

                        if (number == "0")
                        {
                            break;
                        }
                        else if (number == "1")
                        {
                            continue;
                        }

                        else
                        {
                            Color(4);
                            Console.WriteLine( "Enter valid number.");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else if (value == 3)
                {
                    Console.WriteLine("Thank you for shopping here...");
                    Console.ReadKey();
                }
                else
                {
                    Color(4); // dark red color for invalid number
                    Console.WriteLine( "Please enter valid number." );
                    Console.ReadKey();
                }
                for (int i = 0; i < productCount; i++)
                {
                //    quantityString[i] = number.ToString (quantity[i]); // convert data from array to string to store in the file
                 //   priceString[i] = number.ToString (price[i]);
                }

                //   storeData(path1, customerName, customerPassword, customerRole, count);    // to store all users data in file
            }  //   storeData(path2, companyName, priceString, quantityString, productCount); // to store the products data in file
        }


        static void initializeBill(float[] totalBill, int size)
        {

            for (int i = 0; i < size; i++)
            {
                totalBill[i] = 0;
            }
        }
        static void printHeader()
        {
            Console.Clear();
            Console.WriteLine("\t$$$$$$$$\\                $$$$$$\\      $$$$$$$$\\      $$$$$$\\      $$$$$$$\\      $$$$$$$$\\ ");
            Console.WriteLine("\t$$  _____|              $$  __$$\\     \\__$$  __|    $$  __$$\\     $$  __$$\\     $$  _____|");
            Console.WriteLine("\t$$ |                    $$ /  \\__|       $$ |       $$ /  $$ |    $$ |  $$ |    $$ |      ");
            Console.WriteLine("\t$$$$$\\       $$$$$$\\    \\$$$$$$\\         $$ |       $$ |  $$ |    $$$$$$$  |    $$$$$\\    ");
            Console.WriteLine("\t$$  __|      \\______|    \\____$$\\        $$ |       $$ |  $$ |    $$  __$$<     $$  __|   ");
            Console.WriteLine("\t$$ |                    $$\\   $$ |       $$ |       $$ |  $$ |    $$ |  $$ |    $$ |      ");
            Console.WriteLine("\t$$$$$$$$\\               \\$$$$$$  |       $$ |        $$$$$$  |    $$ |  $$ |    $$$$$$$$\\ ");
            Console.WriteLine("\t\\________|               \\______/        \\__|        \\______/     \\__|  \\__|    \\________|");
            Console.WriteLine("\n\n\n\n");
        }
        static int menu()
        {
            printHeader();

            int value = 0;
            string menuOption;
            Color(4);
            Console.WriteLine("L O G I N    M E N U <<");
            Color(10);
            Console.WriteLine("\t\t\t\t\t\t\t1. Sign In");
            Console.WriteLine("\t\t\t\t\t\t\t2. Sign Up");
            Console.WriteLine("\t\t\t\t\t\t\t3. Exit");
            Color(6);
            Console.Write("\t\t\t\t\t\t\tEnter any number: ");
            menuOption = Console.ReadLine();
            if (checkInteger(menuOption))
            {
                value = int.Parse(menuOption);
            }
            else if (!checkInteger(menuOption))
            {
                Console.WriteLine("The input must be in integers.");

                Console.ReadKey();
                menu();
            }
            return value;
        }
        static string checkRole()
        {
            printHeader();
            Console.WriteLine("S I G N U P    M E N U <<");
            string roleCheck = "";
            Console.Write("\t\t\t\t\tEnter your Role(Admin/Dealer/Customer): ");
            roleCheck = Console.ReadLine();
            changeUppercase(ref roleCheck); // change uppercase to lowercase if any letter is uppercase
            if (roleCheck == "admin")
            {
                // Console.ReadKey();
                return "Admin";
            }
            else if (roleCheck == "dealer")
            {
                return "Dealer";
            }
            else if (roleCheck == "customer")
            {
                return "Customer";
            }
            else
            {
                return "invalid";
            }
        }
        static int adminInterface(string adminName)
        {
            printHeader();
            Color(4);
            Console.WriteLine("A D M I N    I N T E R F A C E  <<");
            Color(10);
            Console.WriteLine("\t\tWelcome " + adminName);
            int option = 0;
            string adminOption;
            Color(6);
            Console.WriteLine("\t\t\t\t\t1.    View Dealers Detail.");
            Console.WriteLine("\t\t\t\t\t2.    Add Dealer.");
            Console.WriteLine("\t\t\t\t\t3.    Remove Dealer.");
            Console.WriteLine("\t\t\t\t\t4.    View Customers Detail.");
            Console.WriteLine("\t\t\t\t\t5.    Remove Customer.");
            Console.WriteLine("\t\t\t\t\t6.    View Products in Store.");
            Console.WriteLine("\t\t\t\t\t7.    Update Products.");
            Console.WriteLine("\t\t\t\t\t8.    Selled Products.");
            Console.WriteLine("\t\t\t\t\t0.    Logout.");
            Console.Write("\t\t\t\tEnter your option:");
            adminOption = Console.ReadLine();
            if (checkInteger(adminOption))
            {
                option = int.Parse(adminOption);
            }
            else if (!checkInteger(adminOption))
            {
                Console.WriteLine("The input must be in integers.");
                Console.ReadKey();
                adminInterface(adminName);
            }
            return option;
        }
        static void viewDealersDetail(string[] customerName, string[] customerPassword, string[] customerRole, string adminName, int count)
        {
            int x = 55, y = 15;
            printHeader();
            Color(12); // header  for red Color
            Console.WriteLine("D E A L E R S    L I S T");
            Color(10); // list hiding  for green Color
            Console.WriteLine("Welcome  " + adminName);
            Console.Write("Here is the list of dealers...");
            Console.SetCursorPosition(x - 20, y);
            Console.WriteLine("Names");
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Password");
            Color(6); // list for yellow Color
            int line = 1;
            for (int i = 0; i <= count; i++)
            {
                if (customerName[i] == "")
                {
                    continue;
                }

                if (customerRole[i] == "Customer")
                {
                    continue;
                }
                else
                {
                    Console.SetCursorPosition(x - 20, y + line);
                    Console.WriteLine(customerName[i]);
                    Console.SetCursorPosition(x, y + line);
                    Console.WriteLine(customerPassword[i]);
                    line++;
                }
            }
            Console.ReadKey();
        }
        static void addDealer(string[] customerName, string[] customerRole, string[] customerPassword, ref int count, ref int dealerCount, string adminName, string path1)
        {
            string number = "1";
            while (number == "1")
            {
                string checkName;
                string check;
                if (dealerCount > 5)
                {
                    Console.WriteLine("Dealers capacity is full. You can't add more Dealers.");
                    Console.ReadKey();
                    break;
                }

                customerRole[count] = "Dealer";
                printHeader();
                Color(4);
                Console.WriteLine("S I G N U P    M E N U <<");
                Color(9);
                Console.WriteLine("\t\tSIGN UP AS A:\t" + customerRole[count]);
                Color(10);
                Console.WriteLine("\t\t\t\t\t\t\tEnter dealer Name: ");
                // cin.ignore(); // so that no crash occur
                checkName = Console.ReadLine();
                if (!checkString(checkName))
                {
                    Console.WriteLine("Enter valid String.");
                    Console.ReadKey();
                    continue;
                }
                if (checkName == adminName)
                {
                    Console.WriteLine("Enter valid Name.");
                    Console.ReadKey();
                    continue;
                }
                else if (checkString(checkName))
                {
                    customerName[count] = checkName;
                }

                Console.WriteLine("\t\t\t\t\t\t\tEnter dealer Password: ");
                check = Console.ReadLine();
                if (!checkPassword(check))
                {
                    Console.WriteLine("Enter valid String.");
                    Console.ReadKey();
                    continue;
                }
                else if (checkPassword(check))
                {
                    customerPassword[count] = check;
                }
                bool signUpValue = signUp(customerName, customerPassword, count);
                if (signUpValue == false)
                {
                    Color(4);
                    Console.WriteLine("Sorry , Dealer Name is already taken.");
                    customerName[count] = "";
                    customerPassword[count] = "";
                    Console.ReadKey();
                }

                else
                {
                    count++;
                    //  storeData(path1, customerName, customerPassword, customerRole, count);
                    Color(3);
                    Console.WriteLine("Registered successfully.");
                    dealerCount += 1;
                    Console.ReadKey();

                    Console.ReadKey();
                }
                printHeader();
                Color(6);

                Console.WriteLine("Enter 1 to add Dealer or 0 to continue: ");
                number = Console.ReadLine();

                if (number == "0")
                {
                    break;
                }
                else if (number != "1")
                {
                    Color(4);
                    Console.WriteLine("Enter valid number.");
                    Console.ReadKey();
                    break;
                }
            }

        }
        static void removeDealer(string[] customerName, string[] customerPassword, string[] customerRole, string path1, string name, ref int count)
        {

            printHeader();
            int countDealer = 0;
            int number = 0;
            Color(4);
            Console.WriteLine("R E M O V E   D E A L E R >>");
            viewDealersDetail(customerName, customerPassword, customerRole, name, count);
            string dealerName;
            Color(6);
            Console.WriteLine("Dealer Name to remove:");
            dealerName = Console.ReadLine();
            for (int i = 0; i < count; i++)
            {
                if (dealerName == customerName[i])
                {
                    number = i;
                    customerName[i] = "";
                    countDealer++;
                    break;
                }
            }
            if (countDealer == 1)
            {
                arrayStringShift(customerName, customerPassword, customerRole, ref count, number); // shift array to cover empty space of removed dealer
                                                                                                   //  storeData(path1, customerName, customerPassword, customerRole, count);         // to update users data in file
                Color(12);                                                                     // red Color for dealer remove
                Console.WriteLine("Dealer is Revomed.");
                Console.ReadKey();
            }
            else
            {
                Color(4);
                Console.WriteLine("Dealer not exist.");
                Console.ReadKey();
            }
        }
        static void customerList(string[] customerName, string[] customerPassword, string[] customerRole, string name, int count)
        {
            int x = 55, y = 15;
            printHeader();
            Color(12); // header  for red Color
            Console.WriteLine("C U S T O M E R S    L I S T");
            Color(10); // list hiding  for green Color
            Console.WriteLine("Welcome  " + name);
            Console.Write("Here is the list of customers...");
            Console.SetCursorPosition(x - 20, y);
            Console.WriteLine("\t\t\tNames");
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Password");
            Color(6); // list for yellow Color
            int line = 1;
            for (int i = 0; i <= count; i++)
            {
                if (customerName[i] == "")
                {
                    continue;
                }

                if (customerRole[i] == "Dealer")
                {
                    continue;
                }
                else
                {
                    Console.SetCursorPosition(x - 20, y+line);
                    Console.Write("\t\t\t" + customerName[i]);
                    Console.SetCursorPosition(x, y + line);
                    Console.WriteLine(customerPassword[i]);
                    line++;
                }
            }
            Console.ReadKey();
        }
        static void removecustomer(string[] customerName, string[] customerPassword, string[] customerRole, string path1, string name, ref int count)
        {

            printHeader();
            int countCustomer = 0;
            int number = 0;
            Color(12); // red Color for hiding
            Console.WriteLine("R E M O V E   U S E R >>");
            customerList(customerName, customerPassword, customerRole, name, count);
            string removeName;
            Color(6); // yellow Color
            Console.WriteLine("Customer Name to remove:");
            removeName = Console.ReadLine();
            for (int i = 0; i < count; i++)
            {
                if (removeName == customerName[i])
                {
                    customerName[i] = "";
                    countCustomer++;
                    number = i;
                    break;
                }
            }
            if (countCustomer == 1)
            {
                arrayStringShift(customerName, customerPassword, customerRole, ref count, number); // shift array to cover empty space of removed customer
                                                                                                   //  storeData(path1, customerName, customerPassword, customerRole, count);         // to update users data in file
                Color(12);                                                                     // red Color for customer remove
                Console.WriteLine("Customer is Revomed.");
                Console.ReadKey();
            }
            else
            {
                Color(4);                                          // red Color for customer remove
                Console.WriteLine("Customer not exist.");
                Console.ReadKey();
            }
        }
        static void buyProduct(string[] companyName, float[] price, int[] quantity, int number, float[] totalBill, string[] boughtProduct,ref int buyCount, int[] buyQuantity, string[] selledProducts, int[] selledQuantity,ref int sellCount, int productCount)
        {
            string add = "1";
            int check = -1;
            int already = -1;
            string checkQuantity;
            while (add != "0")
            {
                printHeader();
                Color(12);                            // red color for customer remove
                string productName;
                int Quantity=0;
                Console.WriteLine( "B U Y   P R O D U C T S" )
                     ;
                viewProducts(companyName, price, quantity, productCount);
                Color(6);                            // for yellow colour
                Console.WriteLine( "Enter Product Name you Want to Buy:");
                productName=Console.ReadLine();
                Console.WriteLine( "Enter Product Quantity:");
                checkQuantity=Console.ReadLine();
                if (checkInteger(checkQuantity))
                {
                    Quantity = int.Parse(checkQuantity);      //store in the variable after checking validation
                    Console.ReadKey();
                }
                else if (!checkInteger(checkQuantity))
                {
                    Color(4);
                    Console.WriteLine( "The input must be in integers." );
                    Console.ReadKey();
                    continue;
                }

                for (int i = 0; i <= productCount; i++)
                {
                  //  if ((companyName[i] == productName) || (number.ToString(i + 1) == productName))
                    {

                        check = i;
                    }
                }
                if (Quantity == 0)
                {
                    Color(4);
                    Console.WriteLine( "The quantity you entered is 0." );            //zero quantity validation
                    Console.WriteLine( "Press 1 to buy product or 0 to go back." );
                    add=Console.ReadLine();
                    continue;
                }

                else if (quantity[check] >= 1 && check != -1)
                {
                    quantity[check] -= Quantity;
                    if ((quantity[check]) >= 0)
                    {
                        float bill = (price[check] * Quantity);
                        totalBill[number] += bill;
                        for (int i = 0; i < buyCount; i++)
                        {
                            if (companyName[check] == boughtProduct[i])
                            {
                                already = i;
                                break;
                            }
                        }
                        if (already != -1)
                        {
                            buyQuantity[already] += Quantity;
                            selledQuantity[already] += Quantity;
                            Color(3); // blue color for successfull buying
                            Console.WriteLine( companyName[check] + " added to your cart successfully.");
                        }
                        else if (already == -1)
                        {

                            boughtProduct[buyCount] = companyName[check];
                            selledProducts[sellCount] = companyName[check];
                            selledQuantity[sellCount] = Quantity;
                            buyQuantity[buyCount] = Quantity;
                            Color(3); // blue color for successfull buying
                            Console.WriteLine( companyName[check] + " added to your cart successfully.");
                            buyCount++;
                            sellCount++;
                            break;
                        }
                    }
                    else
                    {
                        Color(12); // red colour for wrong quantity
                        quantity[check] += Quantity;
                        Console.WriteLine( "Sorry, We have " + quantity[check] + " Left.");
                    }
                    break;
                }
                else if (quantity[check] < 1 && check != -1)
                {
                    Color(12);
                    Console.WriteLine( "This Product is out of stock.");
                    break;
                }
                else if (check == -1)
                {
                    Color(12); // red color for wrong product name
                    Console.WriteLine( "Invalid Product Name.");
                }

                Color(6); // for yellow colour
                Console.WriteLine( "\nEnter 1 to Add Product in cart or 0 to go back");
                add=Console.ReadLine();
            }
        }
        static void customerFeedback(int number, string[] Feedback)
        {
          //  cin.ignore();
            Color(6);
            string feedbackcustomer;
            Console.WriteLine( "Write your feedback:");
            feedbackcustomer=Console.ReadLine();
            Feedback[number] = feedbackcustomer;
            Console.ReadKey();
        }
       // static void initializeBill(float[] totalBill, int size)
       // {

       //     for (int i = 0; i < size; i++)
       //     {
       //         totalBill[i] = 0;
       //     }
       // }
        static void cartProducts(string[] boughtProduct, int[] buyQuantity, int buyCount)
        {
            printHeader();
            Color(12);
            Console.WriteLine( "P R O D U C T S    I N    C A R T" );
            if (buyCount <= 0)
            {
                Console.WriteLine( "You have not bought anything yet.");
            }
            else
            {
                Color(10);
                Console.WriteLine( "\t\t\t\tProduct Names\t\t\tQuantity" );
                Color(6);
                for (int i = 0; i < buyCount; i++)
                {
                    Console.WriteLine( "\t\t\t" + i + 1 + ". " + boughtProduct[i] + "\t\t\t\t" + buyQuantity[i] );
                }
            }
            Console.ReadKey();
        }
        static void sellProducts(string[] selledProducts, int[] selledQuantity, int sellCount)
        {
            printHeader();
            Color(12);
            Console.WriteLine( "P R O D U C T S   S E L L E D" );
            if (sellCount <= 0)
            {
                Console.WriteLine( "Not selled anything yet.");
            }
            else
            {
                Color(10);
                Console.WriteLine( "\t\t\t\tProduct Names");
                Console.SetCursorPosition(x + 5, y);
                Console.WriteLine( "Quantity" );
                Color(6);
                for (int i = 0; i < sellCount; i++)
                {
                    Console.WriteLine( "\t\t\t" + i + 1 + ". " + selledProducts[i]);
                    Console.SetCursorPosition(x + 5, y + (i + 1));
                    Console.WriteLine( selledQuantity[i] );
                }
            }
            Console.ReadKey();
        }
        static void changeProduct(string[] boughtProduct, int[] buyQuantity, int buyCount)
        {
            Console.WriteLine( "Bought Products...." );
            cartProducts(boughtProduct, buyQuantity, buyCount);
        }
        static void resetPassword(string[] customerName, string[] customerPassword, string[] customerRole, string path1, int count, int number)
        {
            string check = "1";
            while (check == "1")
            {
                printHeader();
             //   int countDealer = 0;
                Color(12); // to make header red colour
                Console.WriteLine( "R E S E T   P A S S W O R D>>");
                string newPassword;
                Color(6);

                Console.WriteLine();
                //      << "Previous Password:";
                // cin >> password;
                Console.WriteLine( "\t\t\tNew Password(atleast 8 characters):");
                newPassword=Console.ReadLine();
                if (!checkPassword(newPassword))
                {
                    Color(9);
                    Console.WriteLine( "Password contains at least 1 Uppercase and no special character!");
                    Console.ReadKey();
                    continue;
                }
                check = "0";
                if (newPassword == customerPassword[number])
                {
                    Console.WriteLine( "Already using." );
                    Console.WriteLine( "Press 0 to keep this password or 1 to change.");
                    check=Console.ReadLine();
                }
                if (check == "0")
                {
                    customerPassword[number] = newPassword;
                  //  storeData(path1, customerName, customerPassword, customerRole, count); // to update users password data in file
                    Console.WriteLine( "Password updated successfully.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        static void viewFeedback(string[] customer, string[] customerRole, int number, string[] Feedback, int count)
        {
            Color(12);
            Console.WriteLine( "C U S T O M E R   F E E D B A C K" );
            Console.WriteLine( "\tCustomers Feedback...." );
            Color(10);
            Console.WriteLine( "\t\t\tCustomer Names\t\tFeedback" );
            Color(6);
            for (int i = 0; i < count; i++)
            {
                if (customerRole[i] == "Dealer")
                {
                    continue;
                }

                if (Feedback[i] == "")
                {
                    Feedback[i] = "No Feedback Yet.";
                }
                else
                {
                    Console.WriteLine( "\t\t\t" + customer[i] + "\t\t\t" + Feedback[i] );
                }
            }
        }
        static void customerBill(string[] customerName, string[] boughtProducts, int[] buyQuantity, float[] totalBill, int number, int buyCount)
        {
            printHeader();
            Color(4);
            Console.WriteLine("C U S T O M E R   B I L L >>");                 
            Console.WriteLine( "\t\t\t\t\t\tCustomer Name: " + customerName[number] );
            Color(10);
            Console.WriteLine( "\t\t\tProduct Name");
            Console.SetCursorPosition(x + 5, y);
            Console.WriteLine( "Quantity" );
            Color(6);
            for (int i = 0; i < buyCount; i++)
            {
                Console.WriteLine( "\t\t\t" + boughtProducts[i]);
                Console.SetCursorPosition(x + 5, y + (i + 1));
                Console.WriteLine( buyQuantity[i] );
            }
            Color(3);
            Console.WriteLine( "\n\n\n\t\tTotal Bill........" + totalBill[number]);
        }
        static void viewProducts(string[] companyName, float[] price, int[] quantity, int productCount)
        {
            printHeader();
            Color(4);
            Console.WriteLine("M A I N   M E N U << V I E W   P R O D U C T S\n");
            Color(10);             //bright green color for hiding 
            Console.WriteLine("\tList of Products...");
            Color(5);
            Console.SetCursorPosition(x - 50, y );

            Console.WriteLine("\t\t\t\tNo. Company Name ");
            Console.SetCursorPosition(x + 5, y);
            Console.WriteLine("Price");
            Console.SetCursorPosition(x + 25, y);
            Console.WriteLine("Available Stock");
            Color(6);
            int count = 1;
            int line = 1;
            for (int i = 0; i < productCount; i++)
            {
                if (companyName[i] == "")
                {
                    continue;
                }
                Console.SetCursorPosition(x - 15, y + line);
                Console.Write($"\t\t\t\t{line}. {companyName[i]}");
                Console.SetCursorPosition(x + 5, y + line);
                Console.Write(price[i]);
                Console.SetCursorPosition(x + 25, y + line);
                Console.Write(quantity[i]);
                count++;
                line++;
            }
            Console.ReadKey();
        }
        static void updateProduct(string[] companyName, float[] price, int[] quantity, string[] priceString, string[] quantityString, string path2, int productCount, int deleteCount)
        {
            printHeader();
            Color(12);                       //light red color for header
            Console.WriteLine("U P D A T E   P R O D U C T S\n");
            string number = "";
            string Name;
            int numbr = 0;
            string checkQuantity;
            string checkPrice;
        start:
            viewProducts(companyName, price, quantity, productCount);
            Color(6);                                          //yellow color to take input
            Console.Write("Enter Product No or Name to Update:");
            number = Console.ReadLine();
            if (number.Count() == 1 && number[0] >= '0' && number[0] <= '9')
            {
                numbr = int.Parse(number);
                numbr--;
                numbr += deleteCount;
            }
            else if (number.Count() > 1)
            {
                for (int i = 0; i < productCount; i++)
                {
                    if (companyName[i] == number)
                    {
                        numbr = i;
                    }
                }
            }

            else
            {
                Color(4);                              //red color for invalid input
                Console.WriteLine("Enter valid input.");
                Console.ReadKey();
                goto start;
            }
            if (numbr >= productCount)
            {
                Color(4);
                Console.WriteLine("Enter valid input.");
                Console.ReadKey();
                goto start;
            }

            Color(10);
            Console.Write("Product Detail..");
            Console.Write(numbr + 1);
            Console.WriteLine($". {companyName[numbr]}\t\t{price[numbr]}\t\t{quantity[numbr]} ");
            while (true)
            {

                Color(6);
                Console.WriteLine("Enter Updated Name:");
                Name = Console.ReadLine();
                if (checkString(Name))
                {
                    companyName[numbr] = Name;
                }
                else
                {
                    Color(4);
                    Console.WriteLine("Enter valid Name.");
                    Console.ReadKey();
                    continue;
                }
            start1:
                Console.WriteLine("Enter Updated Price:");
                checkPrice = Console.ReadLine();
                if (checkFloat(checkPrice))
                {
                    price[numbr] = float.Parse(checkPrice);
                }
                else if (!checkFloat(checkPrice))
                {
                    Color(4);
                    Console.WriteLine("The input must be in float.");
                    Console.ReadKey();
                    goto start1;
                }
            start2:
                Console.WriteLine("Enter Updated quantity:");
                checkQuantity = Console.ReadLine();
                if (checkInteger(checkQuantity))
                {
                    quantity[numbr] = int.Parse(checkQuantity);
                //    quantityString[numbr] = number.ToString(quantity[numbr]); // convert data from array to string to store in the file
                //    priceString[numbr] = number.ToString(price[numbr]);
                    //   storeData(path2, companyName, priceString, quantityString, productCount);
                    Console.WriteLine("Product Updated Successfully.");
                }
                else if (!checkInteger(checkQuantity))
                {
                    Color(4);
                    Console.WriteLine("The input must be in integers.");
                    Console.ReadKey();
                    goto start2;
                }
                break;
            }
        }
        static void deleteProduct(string[] companyName, float[] price, int[] quantity, string[] priceString, string[] quantityString, string path2, ref int productCount, ref int deleteCount)
        {
            while (true)
            {
                printHeader();
                Color(12);
                Console.WriteLine("D E L E T E   P R O D U C T S");
                Color(10);
                Console.WriteLine("\tList of Products...");
                viewProducts(companyName, price, quantity, productCount);
                int no = 0, check = 0;
                string number;
                string checkOption;
            start:
                Console.WriteLine("Enter Procuct No or Name to Delete: ");
                number = Console.ReadLine();
                if (number.Count() == 1 && number[0] >= '0' && number[0] <= '9')
                {
                    no = int.Parse(number);
                    no--;
                    // no += deleteCount;
                }
                else if (number.Count() > 1)
                {
                    for (int i = 0; i < productCount; i++)
                    {
                        if (companyName[i] == number)
                        {
                            no = i;
                        }
                    }
                }
                if (no >= productCount)
                {
                    Color(4);
                    Console.WriteLine("Enter valid input.");
                    Console.ReadKey();
                    goto start;
                }

                Color(12);                                              // red color
                Console.WriteLine("Are you sure to delete this Product:"); // recheck if user change mind to not delete
                Console.Write(no + 1);
                Console.WriteLine($". {companyName[no]}\t\t{price[no]}\t\t{quantity[no]}");
                Color(6);                           //yellow color 
                Console.WriteLine("Press 1 to Continue or 0 to Recheck:");
                checkOption = Console.ReadLine();
                if (checkInteger(checkOption))
                {
                    check = int.Parse(checkOption);
                }
                else if (!checkInteger(checkOption))
                {
                    Console.WriteLine("The input must be in integers.");
                    check = 0;
                    Console.ReadKey();
                }
                if (check == 1)
                {
                    arrayShift(companyName, price, quantity, ref productCount, no);
                  //  quantityString[productCount] = to_string(quantity[productCount]); // convert data from array to string to store in the file
                  //  priceString[productCount] = to_string(price[productCount]);
                    // storeData(path2, companyName, priceString, quantityString, productCount);
                    Console.WriteLine("Product Deleted successfully.");
                    Console.ReadKey();
                    deleteCount += 1;
                    break;

                }
            }
        }
     
        static bool signIn(string Name, string Password, string[] customerName, string[] customerPassword, int count)
        {
            bool value = false;
            for (int i = 0; i <= count; i++)
            {
                if (Name == customerName[i] && Password == customerPassword[i])
                {
                    value = true;
                }
            }
            return value;
        }
        static bool signUp(string[] customerName, string[] customerPassword, int count)
        {
            bool value = true;
            for (int i = 0; i < count; i++)
            {
                if (customerName[count] == customerName[i])
                {
                    value = false;
                }
            }

            return value;
        }
        static int DealerInterface()
        {
            printHeader();
            Color(12);
            Console.WriteLine( "D E A L E R   M E N U >>" );
            int option = 0;
            string dealerOption;
            Color(10);
            Console.WriteLine( "\t\t\t\t\t1.    View all customers." );
            Console.WriteLine( "\t\t\t\t\t2.    Remove customer." );
            Console.WriteLine( "\t\t\t\t\t3.    Add Product." );
            Console.WriteLine( "\t\t\t\t\t4.    Update Product." );
            Console.WriteLine( "\t\t\t\t\t5.    View all Products." );
            Console.WriteLine( "\t\t\t\t\t6.    Delete Product." );
            Console.WriteLine( "\t\t\t\t\t7.    View Customer Feedback." );
            Console.WriteLine( "\t\t\t\t\t0.    Logout" );
            Color(6);
            Console.Write( "\t\t\t\tEnter your option:");
            dealerOption = Console.ReadLine();
            if (checkInteger(dealerOption))
            {
                option = int.Parse(dealerOption);
            }
            else if (!checkInteger(dealerOption))
            {
                Console.WriteLine( "The input must be in integers." );
                option = 10;
                Console.ReadKey();
            }

            return option;
        }
        static int customerInterface(string[] customerName, string[] customerRole, int number)
        {
            printHeader();
            Color(4);
            Console.WriteLine( "C U S T O M E R    I N T E R F A C E  <<" );
            Color(10);
            Console.WriteLine( $"\t\tWelcome  {customerName[number]}" )
                 ;
            int option=0;
            string customerOption;
            Color(6);
            Console.WriteLine( "\t\t\t\t\t1.    View Products." );
            Console.WriteLine( "\t\t\t\t\t2.    Buy Product." );
            Console.WriteLine( "\t\t\t\t\t3.    View Products in Cart" );
            Console.WriteLine( "\t\t\t\t\t4.    Product Feedback." );
            Console.WriteLine( "\t\t\t\t\t5.    Change Password." );
            Console.WriteLine( "\t\t\t\t\t6.    Generate Bill." );
            Console.WriteLine( "\t\t\t\t\t0.    Logout." );
            Console.Write( "\t\t\t\tEnter your option:");
            customerOption=Console.ReadLine();
            if (checkInteger(customerOption))
            {
                option = int.Parse(customerOption);
            }
            else if (!checkInteger(customerOption))
            {
                Console.WriteLine( "The input must be in integers." );
                option = 10;
                Console.ReadKey();
            }

            return option;
        }
        static int products()
        {
            printHeader();
            Color(4);
            Console.WriteLine( "P R O D U C T S   M E N U >>" );
            int productName = 0;
            string productOption;
            Color(4);
            Console.WriteLine( "\t\t\t\t\tWhich product you want to add:" );
            Console.WriteLine( "\t\t\t\t\t1.         Mobile" );
            Console.WriteLine( "\t\t\t\t\t2.         Laptop" );
            Console.WriteLine( "\t\t\t\t\t3.         Desktop" );
            Console.WriteLine( "\t\t\t\t\t4.         Electrical Appliances" );
            Console.WriteLine( "\t\t\t\t\t0.         Exit" );
            Color(6);
            Console.WriteLine( "\t\t\t\tEnter your option:" );
            productOption = Console.ReadLine();
            if (checkInteger(productOption))
            {
                productName = int.Parse(productOption);
            }
            else if (!checkInteger(productOption))
            {
                Console.WriteLine( "The input must be in integers." );
                productName = 10;
                Console.ReadKey();
            }
            return productName;
        }
        static void addProduct(string[] companyName, float[] price, int[] quantity, string[] priceString, string[] quantityString, string path2, ref int productCount, int size)
        {
            printHeader();
            Color(4);
            Console.WriteLine( "M A I N   M E N U << A D D   P R O D U C T\n" );
            Color(10);
            while (true)
            {

                string productType = "";
                int product;
                string checkName;
                product = products();
                if (product == 1)
                {
                    productType = "Mobile";
                }

                else if (product == 2)
                {
                    productType = "Laptop";
                }
                else if (product == 3)
                {
                    productType = "Desktop";
                }
                else if (product == 4)
                {
                    productType = "Electrical Appliance";
                }
                else if (product == 0)
                {
                    break;
                }
                else
                {
                    Color(4);
                    Console.WriteLine( "Enter valid option");
                    Console.ReadKey();
                    continue;
                }

                if (productCount < size)
                {
                    int index = -1;
                    Color(6);
                    string checkQuantity;
                    string checkPrice;
                    Console.WriteLine( productType + " Company Name:");
                    checkName = Console.ReadLine();
                    if (!checkString(checkName))
                    {
                        Console.WriteLine( "Enter valid String.");
                        Console.ReadKey();
                        continue;
                    }
                    else if (checkString(checkName))
                    {
                        for (int i = 0; i < productCount; i++)
                        {
                            if (checkName == companyName[i])
                            {
                                index = i;
                            }
                        }
                        companyName[productCount] = checkName;
                    }

                    Console.WriteLine( productType + " Price:");
                    checkPrice = Console.ReadLine();
                    if (checkFloat(checkPrice))
                    {
                        price[productCount] = float.Parse(checkPrice);
                    }
                    else if (!checkFloat(checkPrice))
                    {
                        Console.WriteLine( "The input must be in float." );
                        Console.ReadKey();
                        continue;
                    }
                    Console.WriteLine( productType + " Quantity:");
                    checkQuantity = Console.ReadLine();
                    if (checkInteger(checkQuantity))
                    {

                        quantity[productCount] = int.Parse(checkQuantity);
                        if (index == -1)
                        {

                         //   quantityString[productCount] = to_string(quantity[productCount]); // convert data from array to string to store in the file
                         //   priceString[productCount] = to_string(price[productCount]);
                            //  storeData(path2, companyName, priceString, quantityString, productCount);
                            productCount++;
                        }
                        else
                        {
                            companyName[productCount] = "";
                            price[index] = price[productCount];
                            quantity[index] += quantity[productCount];
                            price[productCount] = 0.0f;
                            quantity[productCount] = 0;
                        }

                        Color(3);
                        Console.WriteLine( "Product Added to stock successfully.");
                        Console.ReadKey();
                    }
                    else if (!checkInteger(checkQuantity))
                    {
                        Console.WriteLine( "The input must be in integers." );
                        Console.ReadKey();
                        continue;
                    }
                }
                else if (productCount >= size)
                {
                    Color(4);
                    Console.WriteLine( "Sorry, capacity is full.");
                }
            }
        }
       
        static bool checkInteger(string value)
        {

            for (int i = 0; i<value.Length; i++)
            {
                if (value[i] < '0' || value[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }
        static void changeUppercase(ref string name)
        {
            int asciiCode;
            for (int i = 0;i< name.Length; i++)
            {
                if (name[i] >= 'A' && name[i] <= 'Z')
                {
                    asciiCode = Convert.ToInt32(name[i]);
                    asciiCode += 32;
                    char value = Convert.ToChar(asciiCode);
              //      name[i] = value;
                }
            }
        }
        static bool checkString(string name)
        {
            int wrong = 0;
            for (int i = 0;i< name.Length; i++)
            {
                if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') || (name[i] >= '0' && name[i] <= '9') || (name[i] == '_')))
                {
                    wrong++;
                    break;
                }
            }
            if ((name.Count() < 4) || wrong >= 1 || name[0] == '\0')
            {
                return false;
            }

            return true;
        }
        static bool checkPassword(string password)
        {
            int value = 1;
            int Uppercase = 0;
            int spacecase = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (!((password[i] >= 'a' && password[i] <= 'z') || (password[i] >= 'A' && password[i] <= 'Z') || (password[i] >= '0' && password[i] <= '9') || (password[i] == '_')))
                {
                    value--;
                }
                if ((password[i] >= 'A' && password[i] <= 'Z'))
                {
                    Uppercase++;
                }
                if ((password[i] == ' '))
                {
                    spacecase++;
                }
            }
            if ((value < 1) || (Uppercase < 1) || (password.Count() < 8) || (Uppercase < 1) || password[0] == '\0')
            {
                return false;
            }
            return true;
        }
        static void arrayStringShift(string[] companyName, string[] password, string[] role, ref int Count, int no)
        {
            for (int i = no; i < Count; i++) // move array one step back as one customer removed
            {
                companyName[i] = companyName[i + 1];
                password[i] = password[i + 1];
                role[i] = role[i + 1];
            }
            companyName[Count] = "";
            password[Count] = "";
            role[Count] = "";
            Count--;
        }
        static void arrayShift(string[] companyName, float[] price, int[] quantity, ref int productCount, int no)
        {
            for (int i = no; i < productCount; i++) // move product array one step back as one product removed
            {
                companyName[i] = companyName[i + 1];
                price[i] = price[i + 1];
                quantity[i] = quantity[i + 1];
            }
            companyName[productCount] = "";
            price[productCount] = 0.0f;
            quantity[productCount] = 0;
            productCount--;
        }
        static void Color(int colorCode)
        {
            Console.ForegroundColor = (ConsoleColor)colorCode;
        }
        static bool checkFloat(string value)
        {
            int count = 0;
            int wrong = 0;

            for (int i = 0; i<value.Length; i++)
            {
                if (value[i] < '0' || value[i] > '9' || value[i] == 'i')
                {
                    wrong++;
                }
                if (value[i] == '.')
                {
                    count++;
                }
            }
            if (count <= 1 && wrong == (0 + count))
            {
                return true;
            }
            else
            {
                return false;
            }
            // for (int i = 0; value[i] != '\0'; i++)
            // {

            //     if ((value[i] >= '0' && value[i] <= '9'))
            //     {
            //             digits++;
            //     }
            // }
            // if (count<=1 && digits<=(value.Count()-1))
            // {

            // }
            // else{
            //     return false;
            // }
        }
    }
}
    