using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;



namespace Online_Shoping_Site
{
    class Program
    {
        //First comment test 
        //second comment test
        //third comment test
        //comment tset

        static void Main(string[] args)
        {
            FileStream SD = new FileStream("SellerData.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter SDformatter = new BinaryFormatter();

            FileStream CD = new FileStream("CustomerData.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter CDformatter = new BinaryFormatter();

            Console.WriteLine("Welcome To The Online shopping site, Please select the USER TYPE:");
            Console.WriteLine("1. Seller.");
            Console.WriteLine("2. customer.");
            Console.WriteLine("Enter your choice: ");
            int user = Convert.ToInt32(Console.ReadLine());

            switch (user)
            {
                case 1:
                    Console.WriteLine("If this is your first visit to the site,");
                    Console.WriteLine("choose the first option (Sign Up),");
                    Console.WriteLine("If you have already registered, choose the second option (Log In).");
                    Console.WriteLine("1. SignUp.");
                    Console.WriteLine("2. Login.");
                    int Action = Convert.ToInt32(Console.ReadLine());
                    if (Action == 1)
                    {

                    }
                    else if (Action == 2)
                    {

                    }
                    else
                        Console.WriteLine("Wrong choice");
                    break;
                case 2:
                    Console.WriteLine("If this is your first visit to the site,");
                    Console.WriteLine("choose the first option (Sign Up),");
                    Console.WriteLine("If you have already registered, choose the second option (Log In).");
                    Console.WriteLine("1. SignUp.");
                    Console.WriteLine("2. Login.");
                    int Choice = Convert.ToInt32(Console.ReadLine());
                    if (Choice == 1)
                    {

                    }
                    else if (Choice == 2)
                    {

                    }
                    else
                        Console.WriteLine("Wrong choice");
                    break;
            }
        }

    }
}
            /*string
            in the main, create boolean variable(name:tryagain) with initial value True
            then in while loop with the boolean variable as condition
            ask if the user is seller or customer,
            then ask if the user want to signup or login.*/




