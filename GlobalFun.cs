using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shoping_Site
{
    //Class just for using global function:
    class GlobalFun
    {
        //Welcoming screen:
        public static void Welcoming()
        {
            Console.WriteLine("Welcome To Our Online shopping site, Please select the USER TYPE:");
            Console.WriteLine("1. Seller.");
            Console.WriteLine("2. Customer.");
            Console.WriteLine("3. Exit The System.");
            Console.WriteLine("4. Clear Screen And Start Again.");
            Console.WriteLine("Enter your choice: ");

            int user = Convert.ToInt32(Console.ReadLine());
            if (user == 1 || user == 2 || user == 3 || user==4)
            {
                switch (user)
                {
                    //Seller:
                    case 1:
                        Console.WriteLine("\nIf this is your first visit to the site,");
                        Console.WriteLine("choose the first option (Sign Up),");
                        Console.WriteLine("If you have already registered, choose the second option (Log In).");
                        Console.WriteLine("1. SignUp.");
                        Console.WriteLine("2. Login.");
                        int Action = Convert.ToInt32(Console.ReadLine());
                        //Seller SignUp:
                        if (Action == 1)
                        {   
                            //New Seller Account:
                            Seller NewAccount= new Seller();
                            NewAccount.SignUpSeller();
                        }
                        //Seller LogIn:
                        else if (Action == 2)
                        {
                            Seller NewAccount = new Seller();
                            NewAccount.LogInSeller();
                        }
                        //Invalid Choice:
                        else
                        {
                            Console.WriteLine("Invalid Choice, please try agian.");
                            GlobalFun.Welcoming();
                        }
                        break;

                    //Customer:
                    case 2:                       
                        Console.WriteLine("\nIf this is your first visit to the site,");
                        Console.WriteLine("choose the first option (Sign Up),");
                        Console.WriteLine("If you have already registered, choose the second option (Log In).");
                        Console.WriteLine("1. SignUp.");
                        Console.WriteLine("2. Login.");
                        int Choice = Convert.ToInt32(Console.ReadLine());
                        //Cutomer SignUp:
                        if (Choice == 1)
                        {
                             //New Customer Account:
                             Customer NewAccount = new Customer();
                             NewAccount.SignUpCustomer();
                        }
                        //Customer LogIn:
                        else if (Choice == 2)
                        {
                            Customer NewAccount = new Customer();
                            NewAccount.LogInCustomer();
                        }
                        //Invalid Choice:
                        else
                        {
                            Console.WriteLine("Invalid Choice, please try agian.");
                            GlobalFun.Welcoming();
                        }
                        break;

                    //Exit The system:
                    case 3:
                        System.Environment.Exit(0);
                        break;

                    //Clear Screen And Start Again:
                    case 4:
                        Console.Clear();
                        GlobalFun.Welcoming();
                        break;
                }
            }

            else
            {
                Console.WriteLine("Invalid Choice, please try agian.");
                GlobalFun.Welcoming();
            }
        }
    }
}
