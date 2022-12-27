using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;



namespace Online_Shoping_Site
{
//******************************************************************************************************
//class just for using global function:
    class GlobalFun
    {
//Welcoming screen:
        public static void Welcoming()
        {
            Console.WriteLine("Welcome To The Online shopping site, Please select the USER TYPE:");
            Console.WriteLine("1. Seller.");
            Console.WriteLine("2. customer.");
            Console.WriteLine("Enter your choice: ");
            int user = Convert.ToInt32(Console.ReadLine());

            if (user == 1 || user == 2)
            {
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
                            //SignUpSeller();
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
    class Seller
    {
        int PhoneNumber;
        string Name;
        string address;
        string EmailAddress;
        string StoreName;
        string listings;

        public void SignUpSeller()
        {

        }
        public void LogInSeller()
        {

            int choice = 0;
            do
            {
                Console.WriteLine("1. Adding new listing.");
                Console.WriteLine("2. Delete existing listing");
                Console.WriteLine("3. Change info and price for existing listing.");
                Console.WriteLine("4. View all listings.");
                Console.WriteLine("5. View sold listings information.");
                Console.WriteLine("6. Change account information.");
                Console.WriteLine("7. logout.");
                Console.Write("\nEnter your choice: ");
                choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //AddingNewListing();
                        break;
                    case 2:
                        //DeleteExistingListing();
                        break;
                    case 3:
                        //ChangeInfoAndPriceForExistingListing();
                        break;
                    case 4:
                        //ViewAllListings();
                        break;
                    case 5:
                        //ViewSoldListingsInformation();                   
                        break;
                    case 6:
                        //ChangeAccountInformation();                   
                        break;
                    case 7:
                        //ViewSoldListingsInformation();                   
                        break;
                    case 8:
                        //RETURN TO THE LOGIN SCREEN TO ENABLE YOU TO LOG IN WITH DIFFERENT USER TYPE.
                        break;
                    default:
                        Console.WriteLine("Invalid Choice, please try agian...");
                        break;
                }
            }
            while (choice != 7);
        }
       
    }
//******************************************************************************************************
    class customer
    {
        int CustomerId;
        int PhoneNumber;
        string Name;
        string ShippingAddress;
        string EmailAddress;
        string Password;
        string PaymentInformation;

        public void SignUpCustomer()
        {

        }

        public void LogInCustomer()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. View all available listings.");
                Console.WriteLine("2. View a chosen listing information.");
                Console.WriteLine("3. Add a listing to their cart.");
                Console.WriteLine("4. View/Edit added listings to their cart.");
                Console.WriteLine("5. Checkout listings.");
                Console.WriteLine("6. Change account information.");
                Console.WriteLine("7. search for a listing.");
                Console.WriteLine("8. logout.");
                Console.Write("\nEnter your choice: ");
                choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //ViewAllAvailableListings();
                        break;
                    case 2:
                        //ViewChosenListingInformation();
                        break;
                    case 3:
                        //AddListingToCart();
                        break;
                    case 4:
                        //ViewEditAddedListingsToCart();
                        break;
                    case 5:
                        //CheckoutListings();
                        break;
                    case 6:
                        //ChangeAccountInformation();
                        break;
                    case 7:
                        //SearchForListing();
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Invalid Choice, please try agian...");
                        break;
                }
            }
            while (choice != 8);
        }
    }
//******************************************************************************************************
    class Payment
    {
  
    }
//******************************************************************************************************
    class Listings
    {
       
    }
//******************************************************************************************************

    class Program
    {
//******************************************************************************************************
//Main:
        static void Main(string[] args)
        {
//File creation: 
            FileStream SD = new FileStream("SellerData.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter SDformatter = new BinaryFormatter();

            FileStream CD = new FileStream("CustomerData.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter CDformatter = new BinaryFormatter();

//Welcoming screen:
            GlobalFun.Welcoming();


        }

    }
}





