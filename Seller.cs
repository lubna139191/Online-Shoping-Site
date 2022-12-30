using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Online_Shoping_Site
{
    //******************************************************************************************************
    [Serializable]
    class Seller
    {
        
        string Name;
        string Address;
        string EmailAddress;
        string PhoneNumber;
        string StoreNumber;
        string Password;
        public static int counter=0;
        string SellerID;
        //Listings listings;

        public void SetName(string Name) {
            bool condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd name contains any nmubers
                for (int i = 0; i < Name.Length; i++)
                {
                    string x = Convert.ToString(Name[i]);
                    if (x == Convert.ToString("0") || x== Convert.ToString("1") || x == Convert.ToString("2")
                        || x == Convert.ToString("3") || x == Convert.ToString("4") || x == Convert.ToString("5")
                       || x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8") || x == Convert.ToString("9"))
                    {
                        condition = false;
                    }

                }

                //check if enterd name contains any special charachters
                if (Name.ToLower().Contains('~') || Name.ToLower().Contains('!') || Name.ToLower().Contains('@') || Name.ToLower().Contains('#') || Name.ToLower().Contains('$') || Name.ToLower().Contains('^')
                    || Name.ToLower().Contains('&') || Name.ToLower().Contains('*') || Name.ToLower().Contains('(') || Name.ToLower().Contains(')')
                    || Name.ToLower().Contains('_') || Name.ToLower().Contains('-') || Name.ToLower().Contains('=') || Name.ToLower().Contains('+')
                    || Name.ToLower().Contains('{') || Name.ToLower().Contains('[') || Name.ToLower().Contains(']') || Name.ToLower().Contains('}')
                    || Name.ToLower().Contains(';') || Name.ToLower().Contains(';') || Name.ToLower().Contains('\"') || Name.ToLower().Contains('\'')
                    || Name.ToLower().Contains('<') || Name.ToLower().Contains(',') || Name.ToLower().Contains('.') || Name.ToLower().Contains('<')
                    || Name.ToLower().Contains('/') || Name.ToLower().Contains('?') || Name.ToLower().Contains('\\') || Name.ToLower().Contains('|'))
                {
                    condition = false;
                }

                if (condition == false) {
                    Console.WriteLine("Please ReEnter Your Full Name & Make Sure It Does Not Contains Any Numbers Or Special Charachters..");
                    Console.WriteLine("Full Name:");
                    Name = Console.ReadLine();
                }
            }
            this.Name = Name;
        }

        public void SetAddress(string Address) {
            this.Address = Address;
        }

        public void SetEmailAddress(string EmailAddress)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;
                //check if the email is valid
                string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

                condition= Regex.IsMatch(EmailAddress, regex, RegexOptions.IgnoreCase);
                if (condition == false) {
                    Console.WriteLine("Please ReEnter Your EmailAddress & Make Sure Its Valid");
                    Console.WriteLine("EmailAddress:");
                    EmailAddress = Console.ReadLine();
                }
            }
            this.EmailAddress = EmailAddress;
        }

        public void SetPhoneNumber(string PhoneNumber)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;
                
                //check if the phone number is 10 charachters
                if (PhoneNumber.Length != 10) { condition = false; }

                //check if the phone number start with 0
                if (Convert.ToString(PhoneNumber[0]) != Convert.ToString("0")) { condition = false;}

                //check if the phone number start with 0 then 7
                if (Convert.ToString(PhoneNumber[1]) != Convert.ToString("7")) { condition = false;}

                //check if the phone number start with 0 then 7 then 7 or 8 or 9
                if (Convert.ToString(PhoneNumber[2]) != Convert.ToString("7") || Convert.ToString(PhoneNumber[2]) != Convert.ToString("8") || Convert.ToString(PhoneNumber[2]) != Convert.ToString("9")) { }
                else { condition = false; }

                //check if the rest of the phone number is numbers
                for (int i = 3; i < PhoneNumber.Length; i++)
                {
                        string x = Convert.ToString(PhoneNumber[i]);
                        if (x!= Convert.ToString("0") && x!= Convert.ToString("1") &&  x!= Convert.ToString("2")
                        && x!= Convert.ToString("3") && x!= Convert.ToString("4") && x!= Convert.ToString("5")
                        && x!= Convert.ToString("6") && x!= Convert.ToString("7") && x!= Convert.ToString("8")
                        && x!= Convert.ToString("9")) { condition = false;} 
 
                }
                
                if (condition == false) {
                    Console.WriteLine("Please ReEnter Your Phone Number & Make Sure Its Valid");
                    Console.WriteLine("PhoneNumber:");
                    PhoneNumber = Console.ReadLine();
                }
            }
            this.PhoneNumber = PhoneNumber;
        }

        public void SetStoreNumber(string StoreNumber) {
            bool condition = false;
            while (condition == false)
            {
                condition = true;
                //check if the store number is number
                for (int i = 0; i < StoreNumber.Length; i++)
                {
                    string x = Convert.ToString(StoreNumber[i]); 
                    if (x != Convert.ToString("0") && x != Convert.ToString("1") && x != Convert.ToString("2")
                    && x != Convert.ToString("3") && x != Convert.ToString("4") && x != Convert.ToString("5")
                    && x != Convert.ToString("6") && x != Convert.ToString("7") && x != Convert.ToString("8")
                    && x != Convert.ToString("9")) { condition = false; }

                }
                if (condition == false)
                {
                    Console.WriteLine("Please ReEnter Your Store Number & Make Sure It Does Not Contains Any Number Or Special Chrachters:");
                    Console.WriteLine("StoreNumber:");
                    StoreNumber = Console.ReadLine();
                }
            }
            this.StoreNumber = StoreNumber;
        }
        public void SetPassword(string Password,string ConfirmSPassword) {
            bool condition = false;
            //confirm password
            while (condition==false) {
                condition = true;
                if (Password != ConfirmSPassword) { condition = false; }

                if (condition == false)
                {
                    Console.WriteLine("Password Does not Match, ReEnter Password Please:");
                    Console.WriteLine("Password:");
                    Password = Console.ReadLine();
                    Console.WriteLine("Confirm Password:");
                    ConfirmSPassword = Console.ReadLine();
                }
                                 }
            condition = false;
            //check if password 8 charchters & contains one special charachter at least
            //&  one capital charachter at least & one small charachter at least
            while (condition == false)
            {
                condition = true;
                if (Password.Length < 8) { condition = false; }
                if (!(Password.ToLower().Contains('~') || Password.ToLower().Contains('!') || Password.ToLower().Contains('@') || Password.ToLower().Contains('#') || Password.ToLower().Contains('$') || Password.ToLower().Contains('^')
                                 || Password.ToLower().Contains('&') || Password.ToLower().Contains('*') || Password.ToLower().Contains('(') || Password.ToLower().Contains(')')
                                 || Password.ToLower().Contains('_') || Password.ToLower().Contains('-') || Password.ToLower().Contains('=') || Password.ToLower().Contains('+')
                                 || Password.ToLower().Contains('{') || Password.ToLower().Contains('[') || Password.ToLower().Contains(']') || Password.ToLower().Contains('}')
                                 || Password.ToLower().Contains(';') || Password.ToLower().Contains(';') || Password.ToLower().Contains('\"') || Password.ToLower().Contains('\'')
                                 || Password.ToLower().Contains('>') || Password.ToLower().Contains(',') || Password.ToLower().Contains('.') || Password.ToLower().Contains('<')
                                 || Password.ToLower().Contains('/') || Password.ToLower().Contains('?') || Password.ToLower().Contains('\\') || Password.ToLower().Contains('|')))
                {
                    condition = false;
                }
                for (int i=0;i<Password.Length;i++) {
                    if (Char.IsUpper(Password[i])) { break; }
                    else if (i == Password.Length - 1) { condition = false; }
                        }
                for (int i = 0; i < Password.Length; i++)
                {
                    if (Char.IsLower(Password[i])) { break; }
                    else if (i == Password.Length - 1) { condition = false; }
                }
                if (condition == false)
                {
                    Console.WriteLine("Please ReEnter Your Password & Make Sure Its Not Less Than 8 Characters");
                    Console.WriteLine("And Contains One Special Chrachter & one UpperCase & One LowerCase At Least");
                    Console.WriteLine("Password:");
                    Password = Console.ReadLine();
                    Console.WriteLine("Confirm Password:");
                    ConfirmSPassword = Console.ReadLine();
                    bool confirm = false;
                    //confirm password
                    while (confirm == false)
                    {
                        confirm = true;
                        if (Password != ConfirmSPassword) { confirm = false; }

                        if (confirm == false)
                        {
                            Console.WriteLine("Password Does not Match, ReEnter Password Please:");
                            Console.WriteLine("Password:");
                            Password = Console.ReadLine();
                            Console.WriteLine("Confirm Password:");
                            ConfirmSPassword = Console.ReadLine();
                        }
                    }
                }
            }
            this.Password = Password;
        }

        public void SetSellerID( ) {
            counter++;
            SellerID = Convert.ToString(counter);
        }

        public void CheckSeller(string SName, string SEmailAddress, string SPhoneNumber) { }
        public void SignUpSeller()
        {

            Console.WriteLine("Fill The Following To Create Your New Account As A Seller...");

            //Seller Name
            string SName;
            Console.WriteLine("Full Name:");
            SName = Console.ReadLine();
            this.SetName(SName);

            //Seller Address
            string Saddress;
            Console.WriteLine("Address:");
            Saddress = Console.ReadLine();
            this.SetAddress(Saddress);

            //Seller Email Address
            string SEmailAddress;
            Console.WriteLine("Email Address:");
            SEmailAddress = Console.ReadLine();
            this.SetEmailAddress(SEmailAddress);

            //Seller Phone Number
            string SPhoneNumber;
            Console.WriteLine("PhoneNumber:");
            SPhoneNumber = Console.ReadLine();
            this.SetPhoneNumber(SPhoneNumber);

            //Seller StoreNumber 
            string SStoreNumber;
            Console.WriteLine("StoreNumber:");
            SStoreNumber = Console.ReadLine();
            this.SetStoreNumber(SStoreNumber);

            //Seller Password
            string SPassword;
            Console.WriteLine("Password:");
            SPassword = Console.ReadLine();
            string ConfirmSPassword;
            Console.WriteLine("Confirm Password:");
            ConfirmSPassword = Console.ReadLine();
            this.SetPassword(SPassword, ConfirmSPassword);

            //Check if the seller already exist
            this.CheckSeller(SName, SEmailAddress, SPhoneNumber);

            //Seller ID
            this.SetSellerID();

            //save seller to associated file

            Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
            string Answer = Console.ReadLine();
            if (Answer == "Y") { this.LogInSeller(); }
            else { }

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
}
