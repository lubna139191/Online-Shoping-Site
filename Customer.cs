using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shoping_Site
{ 
    [Serializable]
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
}
