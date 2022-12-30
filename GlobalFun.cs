using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shoping_Site
{
    //class just for using global function:
    class GlobalFun
    {
        //Welcoming screen:
        public static void Welcoming()
        {
            Console.WriteLine("Welcome To Our Online shopping site, Please select the USER TYPE:");
            Console.WriteLine("1. Seller.");
            Console.WriteLine("2. customer.");
            Console.WriteLine("Enter your choice: ");
            int user = Convert.ToInt32(Console.ReadLine());
            if (user == 1 || user == 2)
            {
                switch (user)
                {
                    case 1:
                        //Seller
                        Console.WriteLine("If this is your first visit to the site,");
                        Console.WriteLine("choose the first option (Sign Up),");
                        Console.WriteLine("If you have already registered, choose the second option (Log In).");
                        Console.WriteLine("1. SignUp.");
                        Console.WriteLine("2. Login.");
                        int Action = Convert.ToInt32(Console.ReadLine());
                        if (Action == 1)
                        {   
                            //New Seller Account

                            Seller NewAccount= new Seller();
                            NewAccount.SignUpSeller( );
                        }
                        else if (Action == 2)
                        {
                            //LogInSeller();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice, please try agian...");
                            GlobalFun.Welcoming();
                        }
                        break;

                    case 2:
                        //Cusromer
                        Console.WriteLine("If this is your first visit to the site,");
                        Console.WriteLine("choose the first option (Sign Up),");
                        Console.WriteLine("If you have already registered, choose the second option (Log In).");
                        Console.WriteLine("1. SignUp.");
                        Console.WriteLine("2. Login.");
                        int Choice = Convert.ToInt32(Console.ReadLine());
                        if (Choice == 1)
                        {
                            //SignUpCustomer();
                        }
                        else if (Choice == 2)
                        {
                            //LogInCustomer();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Choice, please try agian...");
                            GlobalFun.Welcoming();
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Choice, please try agian...");
                GlobalFun.Welcoming();
            }
        }
    }
    //******************************************************************************************************
}
