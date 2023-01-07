using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Online_Shoping_Site
{

    [Serializable]
    class Seller
    {
        ////////////////////////////////////////Attributes///////////////////////////////////////////////////////////////////
        string Name;
        Address addrees;
        string EmailAddress;
        string PhoneNumber;
        string StoreNumber;
        string Password;
        string SellerID;
        public List<Listings> listings = new List<Listings> { };
        public static int counter = 0;
        public static Dictionary<string, object> data = new Dictionary<string, object>();
        public static string ProgramFilesFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/Data";

        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////Set Functions//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetName(string Name) { this.Name = Name; }
        public void SetEmailAddress(string EmailAddress) { this.EmailAddress = EmailAddress; }
        public void SetAddress(Address addrees) { this.addrees = addrees; }
        public void SetPhoneNumber(string PhoneNumber) { this.PhoneNumber = PhoneNumber; }
        public void SetStoreNumber(string StoreNumber) { this.StoreNumber = StoreNumber; }
        public void SetPassword(string Password) { this.Password = Password; }
        public void SetSellerID(string ID) { this.SellerID = ID; }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////Get Functions//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GetName() { return this.Name; }
        public string GetEmailAddress() { return this.EmailAddress; }
        public Address GetAddress() { return this.addrees; }
        public string GetPhoneNumber() { return this.PhoneNumber; }
        public string GetStoreNumber() { return this.StoreNumber; }
        public string GetPassword() { return this.Password; }
        public string GetSellerId() { return this.SellerID; }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////Check the Data Enterd By the User///////////////////////////////////////////////
        ////////////////////////////When the User Sign Up For The First Time//////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////Seller Name////////////////////////////////////////////////////////
        public void GenerateName(string Name)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd name contains any nmubers
                for (int i = 0; i < Name.Length; i++)
                {
                    string x = Convert.ToString(Name[i]);
                    if (x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
                       || x == Convert.ToString("3") || x == Convert.ToString("4") || x == Convert.ToString("5")
                       || x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8")
                       || x == Convert.ToString("9"))
                    {
                        condition = false;
                    }
                }

                //check if enterd name contains any special charachters
                if (Name.ToLower().Contains('~') || Name.ToLower().Contains('!') || Name.ToLower().Contains('@') || Name.ToLower().Contains('#')
                    || Name.ToLower().Contains('$') || Name.ToLower().Contains('^') || Name.ToLower().Contains('&') || Name.ToLower().Contains('*')
                    || Name.ToLower().Contains('(') || Name.ToLower().Contains(')') || Name.ToLower().Contains('_') || Name.ToLower().Contains('-')
                    || Name.ToLower().Contains('=') || Name.ToLower().Contains('+') || Name.ToLower().Contains('{') || Name.ToLower().Contains('[')
                    || Name.ToLower().Contains(']') || Name.ToLower().Contains('}') || Name.ToLower().Contains(';') || Name.ToLower().Contains(';')
                    || Name.ToLower().Contains('\"') || Name.ToLower().Contains('\'') || Name.ToLower().Contains('<') || Name.ToLower().Contains(',')
                    || Name.ToLower().Contains('.') || Name.ToLower().Contains('<') || Name.ToLower().Contains('/') || Name.ToLower().Contains('?')
                    || Name.ToLower().Contains('\\') || Name.ToLower().Contains('|'))
                {
                    condition = false;
                }

                if (condition == false)
                {
                    Console.WriteLine("The Name You Enterd Does Not Meet The Requirements");
                    Console.WriteLine("To Enter Anthor Name Enter (1)");
                    Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                    string x = Console.ReadLine();

                    if (x == "1")
                    {
                        int choice = Convert.ToInt32(x);
                        Console.WriteLine("Enter Full Name:");
                        Name = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                        Console.WriteLine("Are You Sure You Want To Exit?Answer By(Y:N)");
                        string Answer = Console.ReadLine();

                        if (Answer == "Y" || Answer == "y")
                        { GlobalFun.Welcoming(); }

                        else
                        {
                            Console.WriteLine("Enter Full Name:");
                            Name = Console.ReadLine();
                        }
                    }
                }
            }
            this.Name = Name;
        }

        ///////////////////////////////////////////////Seller Email Address///////////////////////////////////////////////
        public void GenerateEmailAddress(string EmailAddress)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;
                //check if the email is valid
                string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
                condition = Regex.IsMatch(EmailAddress, regex, RegexOptions.IgnoreCase);
                if (condition == false)
                {
                    Console.WriteLine("The Email You Enterd Is Not A Vaild Email");
                    Console.WriteLine("To Enter Anthor Email Enter (1)");
                    Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                    string x = Console.ReadLine();

                    if (x == "1")
                    {
                        int choice = Convert.ToInt32(x);
                        Console.WriteLine("Enter Email Address:");
                        EmailAddress = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                        Console.WriteLine("Are You Sure You Want To Exit? Answer By(Y:N)");
                        string Answer = Console.ReadLine();

                        if (Answer == "Y" || Answer == "y")
                        { GlobalFun.Welcoming(); }

                        else
                        {
                            Console.WriteLine("Enter Email Address:");
                            EmailAddress = Console.ReadLine();
                        }
                    }
                }
            }
            this.EmailAddress = EmailAddress;
        }


        ////////////////////////////////////////////////Seller Address/////////////////////////////////////////////////////////////
        public void GenerateAddress(string Country, string City, String Street, String ApartmentN)
        {
            addrees = new Address();
            ////Check Country
            bool condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd Country contains any nmubers
                for (int i = 0; i < Country.Length; i++)
                {
                    string x = Convert.ToString(Country[i]);
                    if (x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
                        || x == Convert.ToString("3") || x == Convert.ToString("4") || x == Convert.ToString("5")
                        || x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8")
                        || x == Convert.ToString("9"))
                    {
                        condition = false;
                    }

                }

                //check if enterd Country contains any Spaces 
                if (Country.ToLower().Contains(" ")) { condition = false; }

                //check if enterd Country contains any special charachters
                if (Country.ToLower().Contains('~') || Country.ToLower().Contains('!') || Country.ToLower().Contains('@') || Country.ToLower().Contains('#') ||
                       Country.ToLower().Contains('$') || Country.ToLower().Contains('^')
                    || Country.ToLower().Contains('&') || Country.ToLower().Contains('*') || Country.ToLower().Contains('(') || Country.ToLower().Contains(')')
                    || Country.ToLower().Contains('_') || Country.ToLower().Contains('-') || Country.ToLower().Contains('=') || Country.ToLower().Contains('+')
                    || Country.ToLower().Contains('{') || Country.ToLower().Contains('[') || Country.ToLower().Contains(']') || Country.ToLower().Contains('}')
                    || Country.ToLower().Contains(';') || Country.ToLower().Contains(';') || Country.ToLower().Contains('\"') || Country.ToLower().Contains('\'')
                    || Country.ToLower().Contains('<') || Country.ToLower().Contains(',') || Country.ToLower().Contains('.') || Country.ToLower().Contains('<')
                    || Country.ToLower().Contains('/') || Country.ToLower().Contains('?') || Country.ToLower().Contains('\\') || Country.ToLower().Contains('|'))
                {
                    condition = false;
                }

                if (condition == false)
                {
                    Console.WriteLine("The Country You Enterd Does Not Meet The Requirements");
                    Console.WriteLine("To Enter Anthor Country Enter (1)");
                    Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                    string x = Console.ReadLine();
                    if (x == "1")
                    {
                        int choice = Convert.ToInt32(x);
                        Console.WriteLine("Enter Country:");
                        Country = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                        Console.WriteLine("Are You Sure You Want To Exit?Answer By(Y:N)");
                        string Answer = Console.ReadLine();
                        if (Answer == "Y" || Answer == "y")
                        { GlobalFun.Welcoming(); }
                        else
                        {

                            Console.WriteLine("Enter Country:");
                            Country = Console.ReadLine();
                        }
                    }
                }
            }
            this.addrees.SetCountry(Country);

            ////Check City:
            condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd City contains any nmubers
                for (int i = 0; i < City.Length; i++)
                {
                    string x = Convert.ToString(City[i]);
                    if (x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
                        || x == Convert.ToString("3") || x == Convert.ToString("4") || x == Convert.ToString("5")
                       || x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8") || x == Convert.ToString("9"))
                    {
                        condition = false;
                    }

                }

                //check if enterd City contains any Spaces 
                if (City.ToLower().Contains(" ")) { condition = false; }

                //check if enterd City contains any special charachters
                if (City.ToLower().Contains('~') || City.ToLower().Contains('!') || City.ToLower().Contains('@') || City.ToLower().Contains('#') || City.ToLower().Contains('$') || City.ToLower().Contains('^')
                    || City.ToLower().Contains('&') || City.ToLower().Contains('*') || City.ToLower().Contains('(') || City.ToLower().Contains(')')
                    || City.ToLower().Contains('_') || City.ToLower().Contains('-') || City.ToLower().Contains('=') || City.ToLower().Contains('+')
                    || City.ToLower().Contains('{') || City.ToLower().Contains('[') || City.ToLower().Contains(']') || City.ToLower().Contains('}')
                    || City.ToLower().Contains(';') || City.ToLower().Contains(';') || City.ToLower().Contains('\"') || City.ToLower().Contains('\'')
                    || City.ToLower().Contains('<') || City.ToLower().Contains(',') || City.ToLower().Contains('.') || City.ToLower().Contains('<')
                    || City.ToLower().Contains('/') || City.ToLower().Contains('?') || City.ToLower().Contains('\\') || City.ToLower().Contains('|'))
                {
                    condition = false;
                }

                if (condition == false)
                {
                    Console.WriteLine("The City You Enterd Does Not Meet The Requirements");
                    Console.WriteLine("To Enter Anthor City Enter (1)");
                    Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                    string x = Console.ReadLine();
                    if (x == "1")
                    {
                        int choice = Convert.ToInt32(x);
                        Console.WriteLine("Enter City:");
                        City = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                        Console.WriteLine("Are You Sure You Want To Exit?Answer By(Y:N)");
                        string Answer = Console.ReadLine();
                        if (Answer == "Y" || Answer == "y")
                        { GlobalFun.Welcoming(); }
                        else
                        {

                            Console.WriteLine("Enter City:");
                            City = Console.ReadLine();
                        }
                    }
                }
            }
            this.addrees.SetCity(City);

            ////Check Street:
            condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd Street contains any nmubers
                for (int i = 0; i < Street.Length; i++)
                {
                    string x = Convert.ToString(Street[i]);
                    if (x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
                        || x == Convert.ToString("3") || x == Convert.ToString("4") || x == Convert.ToString("5")
                       || x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8") || x == Convert.ToString("9"))
                    {
                        condition = false;
                    }

                }

                //check if enterd Street contains any Spaces 
                if (Street.ToLower().Contains(" ")) { condition = false; }

                //check if enterd City contains any special charachters
                if (Street.ToLower().Contains('~') || Street.ToLower().Contains('!') || Street.ToLower().Contains('@') || Street.ToLower().Contains('#') || Street.ToLower().Contains('$') || Street.ToLower().Contains('^')
                    || Street.ToLower().Contains('&') || Street.ToLower().Contains('*') || Street.ToLower().Contains('(') || Street.ToLower().Contains(')')
                    || Street.ToLower().Contains('_') || Street.ToLower().Contains('-') || Street.ToLower().Contains('=') || Street.ToLower().Contains('+')
                    || Street.ToLower().Contains('{') || Street.ToLower().Contains('[') || Street.ToLower().Contains(']') || Street.ToLower().Contains('}')
                    || Street.ToLower().Contains(';') || Street.ToLower().Contains(';') || Street.ToLower().Contains('\"') || Street.ToLower().Contains('\'')
                    || Street.ToLower().Contains('<') || Street.ToLower().Contains(',') || Street.ToLower().Contains('.') || Street.ToLower().Contains('<')
                    || Street.ToLower().Contains('/') || Street.ToLower().Contains('?') || Street.ToLower().Contains('\\') || Street.ToLower().Contains('|'))
                {
                    condition = false;
                }

                if (condition == false)
                {
                    Console.WriteLine("The Street You Enterd Does Not Meet The Requirements");
                    Console.WriteLine("To Enter Anthor Street Enter (1)");
                    Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                    string x = Console.ReadLine();
                    if (x == "1")
                    {
                        int choice = Convert.ToInt32(x);
                        Console.WriteLine("Enter Street:");
                        Street = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                        Console.WriteLine("Are You Sure You Want To Exit?Answer By(Y:N)");
                        string Answer = Console.ReadLine();
                        if (Answer == "Y" || Answer == "y")
                        { GlobalFun.Welcoming(); }
                        else
                        {

                            Console.WriteLine("Enter Street:");
                            Street = Console.ReadLine();
                        }
                    }
                }
            }
            this.addrees.SetStreet(Street);

            //Check Apartment Number
            condition = false;
            while (condition == false)
            {
                condition = true;
                //check if the Apartment Number is number & Does not Contains any space or letter or special charachters
                for (int i = 0; i < ApartmentN.Length; i++)
                {
                    string x = Convert.ToString(ApartmentN[i]);
                    if (x != Convert.ToString("0") && x != Convert.ToString("1") && x != Convert.ToString("2")
                    && x != Convert.ToString("3") && x != Convert.ToString("4") && x != Convert.ToString("5")
                    && x != Convert.ToString("6") && x != Convert.ToString("7") && x != Convert.ToString("8")
                    && x != Convert.ToString("9")) { condition = false; }

                }

                if (condition == false)
                {
                    Console.WriteLine("The Apartment Number You Enterd Is Not valid");
                    Console.WriteLine("To Enter Anthor Apartment Number Enter (1)");
                    Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                    string x = Console.ReadLine();
                    if (x == "1")
                    {
                        int choice = Convert.ToInt32(x);
                        Console.WriteLine("Enter Apartment Number:");
                        ApartmentN = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                        Console.WriteLine("Are You Sure You Want To Exit?Answer By(Y:N)");
                        string Answer = Console.ReadLine();
                        if (Answer == "Y" || Answer == "y")
                        { GlobalFun.Welcoming(); }
                        else
                        {

                            Console.WriteLine("Enter Apartment Number:");
                            ApartmentN = Console.ReadLine();
                        }
                    }
                }
            }
            this.addrees.SetApartment(ApartmentN);
        }


        ///////////////////////////////////////////////////////Seller PhoneNumber////////////////////////////////////////////////////
        public void GeneratePhoneNumber(string PhoneNumber)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;

                //check if the phone number is 10 Numbers:
                if (PhoneNumber.Length != 10)
                { condition = false; }

                //check if the phone number start with 0:
                if (PhoneNumber.Length == 10)
                {
                    if (Convert.ToString(PhoneNumber[0]) != Convert.ToString("0"))
                    { condition = false; }

                    //check if the second phone number is 7:
                    if (Convert.ToString(PhoneNumber[1]) != Convert.ToString("7"))
                    { condition = false; }

                    //check if the third phone number is 7 or 8 or 9:
                    if (Convert.ToString(PhoneNumber[2]) != Convert.ToString("7")
                     && Convert.ToString(PhoneNumber[2]) != Convert.ToString("8")
                     && Convert.ToString(PhoneNumber[2]) != Convert.ToString("9"))
                    { condition = false; }



                    //check if the rest of the phone number are numbers:
                    for (int i = 3; i < PhoneNumber.Length; i++)
                    {
                        string x = Convert.ToString(PhoneNumber[i]);
                        if (x != Convert.ToString("0") && x != Convert.ToString("1") && x != Convert.ToString("2")
                        && x != Convert.ToString("3") && x != Convert.ToString("4") && x != Convert.ToString("5")
                        && x != Convert.ToString("6") && x != Convert.ToString("7") && x != Convert.ToString("8")
                        && x != Convert.ToString("9"))
                        { condition = false; }

                    }
                }

                if (condition == false)
                {
                    Console.WriteLine("The Phone Number You Enterd Is Not valid");
                    Console.WriteLine("To Enter Anthor Phone Number Enter (1)");
                    Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                    string x = Console.ReadLine();
                    if (x == "1")
                    {
                        int choice = Convert.ToInt32(x);
                        Console.WriteLine("Enter Phone Number:");
                        PhoneNumber = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                        Console.WriteLine("Are You Sure You Want To Exit? Answer By(Y:N)");
                        string Answer = Console.ReadLine();
                        if (Answer == "Y" || Answer == "y")
                        { GlobalFun.Welcoming(); }

                        else
                        {
                            Console.WriteLine("Enter Phone Number:");
                            PhoneNumber = Console.ReadLine();
                        }
                    }
                }
            }
            this.PhoneNumber = PhoneNumber;

        }


        ////////////////////////////////////////////////Seller Store Number//////////////////////////////////////////////////////
        public void GenerateStoreNumber(string StoreNumber)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;
                //check if the store number is number:
                for (int i = 0; i < StoreNumber.Length; i++)
                {
                    string x = Convert.ToString(StoreNumber[i]);
                    if (x != Convert.ToString("0") && x != Convert.ToString("1") && x != Convert.ToString("2")
                    && x != Convert.ToString("3") && x != Convert.ToString("4") && x != Convert.ToString("5")
                    && x != Convert.ToString("6") && x != Convert.ToString("7") && x != Convert.ToString("8")
                    && x != Convert.ToString("9"))
                    { condition = false; }

                }

                if (condition == false)
                {
                    Console.WriteLine("The Store Number You Enterd Is Not valid");
                    Console.WriteLine("To Enter Anthor Store Number Enter (1)");
                    Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                    string x = Console.ReadLine();
                    if (x == "1")
                    {
                        int choice = Convert.ToInt32(x);
                        Console.WriteLine("Enter Store Number:");
                        StoreNumber = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                        Console.WriteLine("Are You Sure You Want To Exit?Answer By(Y:N)");
                        string Answer = Console.ReadLine();
                        if (Answer == "Y" || Answer == "y")
                        { GlobalFun.Welcoming(); }

                        else
                        {
                            Console.WriteLine("Enter Store Number:");
                            StoreNumber = Console.ReadLine();
                        }
                    }
                }
            }
            this.StoreNumber = StoreNumber;
        }


        /////////////////////////////////////////////////////Seller Password/////////////////////////////////////////////////////////////
        public void GeneratePassword(string Password, string ConfirmSPassword)
        {
            bool condition = false;

            //confirm password:
            while (condition == false)
            {
                condition = true;
                if (Password != ConfirmSPassword)
                { condition = false; }

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

            while (condition == false)
            {
                condition = true;

                //Check if password 8 charchters:
                if (Password.Length < 8)
                { condition = false; }

                //Check if password contains one special charachter at least
                if (!(Password.ToLower().Contains('~') || Password.ToLower().Contains('!') || Password.ToLower().Contains('@')
                   || Password.ToLower().Contains('#') || Password.ToLower().Contains('$') || Password.ToLower().Contains('^')
                   || Password.ToLower().Contains('&') || Password.ToLower().Contains('*') || Password.ToLower().Contains('(')
                   || Password.ToLower().Contains(')') || Password.ToLower().Contains('_') || Password.ToLower().Contains('-')
                   || Password.ToLower().Contains('=') || Password.ToLower().Contains('+') || Password.ToLower().Contains('{')
                   || Password.ToLower().Contains('[') || Password.ToLower().Contains(']') || Password.ToLower().Contains('}')
                   || Password.ToLower().Contains(';') || Password.ToLower().Contains(';') || Password.ToLower().Contains('\"')
                   || Password.ToLower().Contains('\'') || Password.ToLower().Contains('>') || Password.ToLower().Contains(',')
                   || Password.ToLower().Contains('.') || Password.ToLower().Contains('<') || Password.ToLower().Contains('/')
                   || Password.ToLower().Contains('?') || Password.ToLower().Contains('\\') || Password.ToLower().Contains('|')))
                {
                    condition = false;
                }


                //Check if password contains one capital Letter at least & one small Letter at least
                if (Password.ToLower().Contains(" "))
                { condition = false; }

                for (int i = 0; i < Password.Length; i++)
                {
                    if (Char.IsUpper(Password[i]))
                    { break; }

                    else if (i == Password.Length - 1)
                    { condition = false; }
                }

                for (int i = 0; i < Password.Length; i++)
                {
                    if (Char.IsLower(Password[i]))
                    { break; }
                    else if (i == Password.Length - 1)
                    { condition = false; }
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

                    //confirm password:
                    while (confirm == false)
                    {
                        confirm = true;
                        if (Password != ConfirmSPassword)
                        { confirm = false; }

                        if (condition == false)
                        {
                            Console.WriteLine("The Password You Enterd Does Not Meet The Requirements");
                            Console.WriteLine("To Enter Anthor Password Enter (1)");
                            Console.WriteLine("To Exit This Page Enter Any Chratecter Other Than 1");
                            string x = Console.ReadLine();

                            if (x == "1")
                            {
                                int choice = Convert.ToInt32(x);
                                Console.WriteLine("Enter Password:");
                                Password = Console.ReadLine();
                            }

                            else
                            {
                                Console.WriteLine("(Any Data You Enterd Will Be Lost)");
                                Console.WriteLine("Are You Sure You Want To Exit?Answer By(Y:N)");
                                string Answer = Console.ReadLine();

                                if (Answer == "Y" || Answer == "y")
                                { GlobalFun.Welcoming(); }

                                else
                                {
                                    Console.WriteLine("Enter Password:");
                                    Password = Console.ReadLine();
                                }
                            }
                        }
                    }
                }
            }
            this.Password = Password;
        }


        /////////////////////////////////////////////////////////////Seller ID/////////////////////////////////////////////////////////
        public void GenerateSellerID()
        {
            counter++;
            this.SellerID = Convert.ToString(counter);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////Functions On Seller/////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////Sign Up///////////////////////////////////////////////////////////////
        public void SignUpSeller()
        {
            Console.WriteLine("\nFill The Following To Create Your New Account As A Seller.\n");

            //Seller Name:
            string SName;
            Console.WriteLine("Full Name(Make Sure It Does Not Contains Any Numbers or Special Charachters):");
            SName = Console.ReadLine();
            this.GenerateName(SName);
            Console.WriteLine("\n");

            //Seller Address:
            Console.WriteLine("Address\n");
            //Country:
            Console.WriteLine("Country (Make Sure It Does Not Contains Any Numbers Or Special Charaters):");
            string SCountry;
            SCountry = Console.ReadLine();
            Console.WriteLine("\n");
            //City:
            Console.WriteLine("City (Make Sure It Does Not Contains Any Numbers Or Special Charaters):");
            string SCity;
            SCity = Console.ReadLine();
            Console.WriteLine("\n");
            //Street:
            Console.WriteLine("Street (Make Sure It Does Not Contains Any Numbers Or Special Charaters):");
            string SStreet;
            SStreet = Console.ReadLine();
            Console.WriteLine("\n");
            //Apartment Number:
            Console.WriteLine("Apartment Number (Make Sure It Does Not Contains Any Letters Or Special Charaters Or Spaces):");
            string SApartmentN;
            SApartmentN = Console.ReadLine();
            Console.WriteLine("\n");
            this.GenerateAddress(SCountry, SCity, SStreet, SApartmentN);

            //Seller Email Address:
            string SEmailAddress;
            Console.WriteLine("Email Address(Make Sure Its A Vaild Email Ex:xxx@xxx.com):");
            SEmailAddress = Console.ReadLine();
            Console.WriteLine("\n");
            this.GenerateEmailAddress(SEmailAddress);

            //Seller Phone Number:
            string SPhoneNumber;
            Console.WriteLine("PhoneNumber(Make Sure It Does Not Contains Any Letters or Special Charachters & Valid Ex:07(7|8|9)*******):");
            SPhoneNumber = Console.ReadLine();
            Console.WriteLine("\n");
            this.GeneratePhoneNumber(SPhoneNumber);

            //Seller StoreNumber: 
            string SStoreNumber;
            Console.WriteLine("StoreNumber(Make Sure It Does Not Contains Any Letters or Special Charachters):");
            SStoreNumber = Console.ReadLine();
            Console.WriteLine("\n");
            this.GenerateStoreNumber(SStoreNumber);

            //Seller Password:
            string SPassword;
            Console.WriteLine("Password(Make Sure It is Not Less Than 8 Charachters\nAnd Contains One UpperCase & One LowerCase & one Special Charachters At Least):");
            SPassword = Console.ReadLine();
            string ConfirmSPassword;
            Console.WriteLine("Confirm Password:");
            ConfirmSPassword = Console.ReadLine();
            Console.WriteLine("\n");
            this.GeneratePassword(SPassword, ConfirmSPassword);

            //Check if the seller already exist & if the user is new Give uniqe ID then save to file:
            this.CheckSeller();
        }



        ///////////////////////////////////////////Check If Seller Exist/////////////////////////////////////////////////////////
        ////////////////////////////////////////When New Seller Sign Up/////////////////////////////////////////////////////////
        public void CheckSeller()
        {
            //Exist or not:
            FileStream FS;
            if (File.Exists(ProgramFilesFolder + "/SellerData.txt"))
            { FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read); }

            else
            {
                Directory.CreateDirectory(ProgramFilesFolder);
                FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Create, FileAccess.ReadWrite);
            }

            BinaryFormatter BF = new BinaryFormatter();
            Seller[] arr = new Seller[1000000];
            int i = 0;

            //if the file is empty write without checking
            if (FS.Length != 0)
            {
                //read objects & save to array
                while (FS.Position < FS.Length)
                {
                    arr[i] = (Seller)BF.Deserialize(FS);
                    i++;
                }

                //check if any of the objects in the array eqauls the new object
                for (int j = 0; j < i; j++)
                {
                    if (arr[j].GetName() == this.GetName()
                        && arr[j].GetPhoneNumber() == this.GetPhoneNumber()
                        && arr[j].GetEmailAddress() == this.GetEmailAddress())
                    {
                        Console.WriteLine("The User Already Exist, Please Try to Log In Instead of Sign Up");
                        FS.Close();
                        GlobalFun.Welcoming();
                    }
                }

                //if its new user save it to file
                FS.Close();
                this.GenerateSellerID();
                this.SaveToFile();
                Console.WriteLine("User Account Created Successfully As A Seller");
                Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
                string Answer = Console.ReadLine();

                if (Answer == "Y" || Answer == "y")
                { this.LogInSeller(); }

                else
                { GlobalFun.Welcoming(); }
            }

            else
            {
                //if the file is empty then user is new (save it)
                FS.Close();
                this.GenerateSellerID();
                this.SaveToFile();
                Console.WriteLine("User Account Created Successfully As A Seller");
                Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
                string Answer = Console.ReadLine();

                if (Answer == "Y" || Answer == "y")
                { this.LogInSeller(); }

                else
                { GlobalFun.Welcoming(); }
            }
        }
        /////////////////////////////////////////Save Seller Account To SellerData File//////////////////////////////////////////////////
        //////////////////////////////////When New Seller Account Pass The Checkup Test/////////////////////////////////////////////////
        public void SaveToFile()
        {

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Data"))
            { Directory.CreateDirectory(ProgramFilesFolder); }
            FileStream FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Append, FileAccess.Write);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Serialize(FS, this);
            FS.Close();

        }



        //////////////////////////////////////////////////Log In //////////////////////////////////////////////////////////////////
        public void LogInSeller()
        {
            string email;
            string Password;
            Console.WriteLine("\nEnter Your Email:");
            email = Console.ReadLine();
            Console.WriteLine("Enter Your Password:");
            Password = Console.ReadLine();
            Seller S = new Seller();

            this.FindAccount(email, Password, ref S);

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
                Console.WriteLine("\nEnter your choice:");
                string x = Console.ReadLine();
                if (x == "1" || x == "2" || x == "3" || x == "4" || x == "5" || x == "6" || x == "7")
                { choice = Convert.ToInt16(x); }//To Avoid Exception Of Converting Non Convertable Type To Int
                else { choice = 8; }
                Console.WriteLine("\n");
                switch (choice)
                {
                    case 1:
                        //Add New Listing
                        Listings L = new Listings();
                        Console.WriteLine("Enter Listing Name:");
                        string Name = Console.ReadLine();
                        Console.WriteLine("\n");
                        L.SetNameOfListing(Name);
                        Console.WriteLine("Enter Listing Description:");
                        string Description = Console.ReadLine();
                        Console.WriteLine("\n");
                        L.SetDescription(Description);
                        Console.WriteLine("Enter Listing Price:");
                        double Price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\n");
                        L.SetPrice(Price);
                        Console.WriteLine("Enter Listing Number Of Items In Listing:");
                        int NumOfItmes = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n");
                        L.SetNumberOfItems(NumOfItmes);
                        S.AddListings(ref L, ref S);

                        break;

                    case 2:
                        Console.WriteLine("Enter Listing Name:");
                        string Name2 = Console.ReadLine();
                        this.DeleteListings(Name2);

                        break;

                    case 3:
                        Console.WriteLine("What Would You Like To Change?");
                        Console.WriteLine("1-Name");
                        Console.WriteLine("2-Descreption");
                        Console.WriteLine("3-Price");
                        Console.WriteLine("4-Number Of Items");
                        string X = Console.ReadLine();
                        Console.WriteLine("\n");
                        int choice2;
                        if (X == "1" || X == "2" || X == "3" || X == "4") { choice2 = Convert.ToInt32(X); }
                        else
                        {
                            Console.WriteLine("Choice Not Valid");
                            choice2 = 0;
                            goto case 3;
                        }
                        switch (choice2) {
                            case 1:

                                Console.WriteLine("Enter Listing Name You Want to Edit:");
                                string Name3 = Console.ReadLine();
                                Console.WriteLine("Enter Listing New Name:");
                                string Name4 = Console.ReadLine();
                                this.Change_Name_For_Existing_Listing(Name3, Name4); break;

                            case 2:
                                Console.WriteLine("Enter Listing Name You Want to Edit:");
                                string Name5 = Console.ReadLine();
                                Console.WriteLine("Enter Listing New Descreption:");
                                string Descreption = Console.ReadLine();
                                this.Change_Description_For_Existing_Listing(Name5, Descreption);
                                break;
                            case 3:
                                Console.WriteLine("Enter Listing Name You Want to Edit:");
                                string Name6 = Console.ReadLine();
                                Console.WriteLine("Enter Listing New Price:");
                                double Price2 = Convert.ToDouble(Console.ReadLine());
                                this.Change_Price_For_Existing_Listing(Name6, Price2);
                                break;
                            case 4:
                                Console.WriteLine("Enter Listing Name You Want to Edit:");
                                string Name7 = Console.ReadLine();
                                Console.WriteLine("Enter Listing New Number Of Items:");
                                int Number = Convert.ToInt32(Console.ReadLine());
                                this.Change_NumOfItems_For_Existing_Listing(Name7, Number);
                                break;
                            default:
                                Console.WriteLine("Invalid Choice, please try agian...");
                                break;
                        }
                        break;
                    case 4:
                        this.ViewAllListings(S);
                        break;

                    case 5:
                        this.ViewSoldListings(S);                   
                        break;

                    case 6:
                        this.ChangeSellerAccountInformation(ref s);                   
                        break;

                    case 7:
                        GlobalFun.Welcoming();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice, please try agian...");
                        break;
                }
            }
            while (choice != 7);

        }



        //////////////////////////////////////////////////Search If The Account Trying To Log In Exist////////////////////////////////////////   
        public void FindAccount(string email, string Password, ref Seller S)
        {
            //Exist or not:
            FileStream FS;

            if (!(File.Exists(ProgramFilesFolder + "/SellerData.txt")))
            {
                Console.WriteLine("The Email Or Password is Wrong, Please Try Again\n");
                GlobalFun.Welcoming();
            }

            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();

            Seller[] arr = new Seller[1000000];
            int i = 0;

            if (FS.Length != 0)
            {
                //read objects & save to array
                while (FS.Position < FS.Length)
                {
                    arr[i] = (Seller)BF.Deserialize(FS);
                    i++;
                }
                bool found = false;
                //check if any of the objects in the array eqauls the object
                for (int j = 0; j < i; j++)
                {
                    if (arr[j].GetPassword() == Password
                        && arr[j].GetEmailAddress() == email)
                    {
                        found = true;
                        Console.WriteLine("Logged In Successfuly\n");
                        S.SetName(arr[j].GetName());
                        S.SetEmailAddress(arr[j].GetEmailAddress());
                        S.SetAddress(arr[j].GetAddress());
                        S.SetPassword(arr[j].GetPassword());
                        S.SetPhoneNumber(arr[j].GetPhoneNumber());
                        S.SetSellerID(arr[j].GetSellerId());
                        S.SetStoreNumber(arr[j].GetStoreNumber());
                        FS.Close();
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("The Email Or Password is Wrong, Please Try Again\n");
                    GlobalFun.Welcoming();
                }
            }

            else
            {
                Console.WriteLine("The Email Or Password is Wrong, Please Try Again\n");
                GlobalFun.Welcoming();
            }

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////Functions Seller Can Do When Log In Pass Successfully///////////////////////////////////



        ////////////////////////////////////////////////////Add Listings//////////////////////////////////////////////////////////
        public void AddListings(ref Listings L, ref Seller S)
        {
            FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Seller[] arr = new Seller[1000000];
            int i = 0;


            //read objects & save to array
            while (FS.Position < FS.Length)
            {
                arr[i] = (Seller)BF.Deserialize(FS);
                i++;
            }

            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            {
                if (arr[j].GetName() == S.GetName()
                    && arr[j].GetPhoneNumber() == S.GetPhoneNumber()
                    && arr[j].GetEmailAddress() == S.GetEmailAddress())
                {
                    S = arr[j];
                }
            }
            FS.Close();
            bool x = false;
            if (S.listings != null)
            {
                for (int k = 0; k < S.listings.Count; k++)
                {
                    if (S.listings[k] == L)
                    {
                        x = true;
                        string a;
                        Console.WriteLine("Listing Alredy Exist\nWould You Like to Edit Number Of Items In It?(Y:N)");
                        a = Console.ReadLine();
                        if (a == "Y" || a == "y")
                        {
                            Console.WriteLine("Please Enter The New Value Of Items");
                            int value = Convert.ToInt32(Console.ReadLine());
                            S.Change_NumOfItems_For_Existing_Listing(S.listings[k].GetNameOfListing(), value);
                        }
                    }
                }
            }

            if (x == false)
            {

                S.listings.Add(L);
                S.EditFile(S);
                Console.WriteLine("Added Successefully\n");
            }
        }


        ///////////////////////////////////////Function To Edit Data File After Any Change//////////////////////////////////////////////////
        public void EditFile(Seller S)
        {
            FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Seller[] arr = new Seller[1000000];
            int i = 0;


            //read objects & save to array
            while (FS.Position < FS.Length)
            {
                arr[i] = (Seller)BF.Deserialize(FS);
                i++;
            }

            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            {
                if (arr[j].GetName() == S.GetName()
                    && arr[j].GetPhoneNumber() == S.GetPhoneNumber()
                    && arr[j].GetEmailAddress() == S.GetEmailAddress())
                {
                    arr[j] = new Seller();
                    arr[j] = S;
                }
            }
            FS.Close();

            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Create, FileAccess.ReadWrite);
            for (int k = 0; k < i; k++) { BF.Serialize(FS, arr[k]); }


            FS.Close();

        }



        /////////////////////////////////////////////////////////Delete Listing////////////////////////////////////////////////////////
        public void DeleteListings(string name)
        {
            bool x = false;
            Seller S = new Seller();
            FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Seller[] arr = new Seller[1000000];
            int i = 0;


            //read objects & save to array
            while (FS.Position < FS.Length)
            {
                arr[i] = (Seller)BF.Deserialize(FS);
                i++;
            }

            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            {
                for (int z = 0; z < arr[j].listings.Count; z++) {
                    if (arr[j].listings[z].GetNameOfListing() == name && arr[j].listings != null)
                    {
                        x = true;
                        S = arr[j];
                        S.listings.RemoveAt(z);
                        FS.Close();
                        S.EditFile(S);
                        Console.WriteLine("Listing Deleted Successfully\n");
                    } }
                if (arr[j].listings == null) { Console.WriteLine("Cant Delete"); Console.WriteLine("The Listing Does Not Exist\n"); }
            }


            if (x == false)
            { Console.WriteLine("Cant Delete"); Console.WriteLine("The Listing Is not In The Seller Data To Delete\n"); }


        }




        /////////////////////////////////////Fun Change Price For Existing Listing///////////////////////////////////////////////////
        public void Change_Price_For_Existing_Listing(string name, double Price)
        {
            bool x = false;
            Seller S = new Seller();
            FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Seller[] arr = new Seller[1000000];
            int i = 0;


            //read objects & save to array
            while (FS.Position < FS.Length)
            {
                arr[i] = (Seller)BF.Deserialize(FS);
                i++;
            }

            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            {
                for (int z = 0; z < arr[j].listings.Count; z++) {
                    if (arr[j].listings[z].GetNameOfListing() == name && arr[j].listings != null)
                    {
                        x = true;
                        S = arr[j];
                        S.listings[z].SetPrice(Price);
                        FS.Close();
                        S.EditFile(S);
                        Console.WriteLine("Listing Edited Price Successfully\n");
                    } }
                if (arr[j].listings == null) { Console.WriteLine("Cant Edit Price"); Console.WriteLine("The Listing Does Not Exist\n"); }
            }


            if (x == false)
            { Console.WriteLine("Cant Edit Price"); Console.WriteLine("The Listing Is not In The Seller Data To Edit\n"); }
        }



        ////////////////////////////////////Fun Change Name For Existing Listing///////////////////////////////////////////////
        public void Change_Name_For_Existing_Listing(string oldname, string newname)
        {
            bool x = false;
            Seller S = new Seller();
            FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Seller[] arr = new Seller[1000000];
            int i = 0;


            //read objects & save to array
            while (FS.Position < FS.Length)
            {
                arr[i] = (Seller)BF.Deserialize(FS);
                i++;
            }

            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            { for (int z = 0; z < arr[j].listings.Count; z++)
                {
                    if (arr[j].listings[z].GetNameOfListing() == oldname && arr[j].listings != null)
                    {
                        x = true;
                        S = arr[j];
                        S.listings[z].SetNameOfListing(newname);
                        FS.Close();
                        S.EditFile(S);
                        Console.WriteLine("Listing Name Edited Successfully\n");

                    }

                }
                if (arr[j].listings == null) { Console.WriteLine("Cant Edit Name"); Console.WriteLine("The Listing Does Not Exist\n"); }
            }


            if (x == false)
            { Console.WriteLine("Cant Edit Name"); Console.WriteLine("The Listing Is not In The Seller Data To Edit\n"); }
        }



        //////////////////////////////////Fun Change Description For Existing Listing////////////////////////////////////////////////////
        public void Change_Description_For_Existing_Listing(string name, string Description)
        {
            bool x = false;
            Seller S = new Seller();
            FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Seller[] arr = new Seller[1000000];
            int i = 0;


            //read objects & save to array
            while (FS.Position < FS.Length)
            {
                arr[i] = (Seller)BF.Deserialize(FS);
                i++;
            }

            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            {
                for (int z = 0; z < arr[j].listings.Count; z++) {
                    if (arr[j].listings[z].GetNameOfListing() == name && arr[j].listings != null)
                    {
                        x = true;
                        S = arr[j];
                        S.listings[z].SetDescription(Description);
                        FS.Close();
                        S.EditFile(S);
                        Console.WriteLine("Listing Description Edited Successfully\n");
                    } }
                if (arr[j].listings == null) { Console.WriteLine("Cant Edit Description"); Console.WriteLine("The Listing Does Not Exist\n"); }
            }


            if (x == false)
            { Console.WriteLine("Cant Edit Description"); Console.WriteLine("The Listing Is not In The Seller Data To Edit\n"); }
        }




        //////////////////////////////////Fun Change Number Of Item For Existing Listing////////////////////////////////////////////////
        public void Change_NumOfItems_For_Existing_Listing(string name, int NumOfItems)
        {
            bool x = false;
            Seller S = new Seller();
            FileStream FS;
            FS = new FileStream("/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Seller[] arr = new Seller[1000000];
            int i = 0;


            //read objects & save to array
            while (FS.Position < FS.Length)
            {
                arr[i] = (Seller)BF.Deserialize(FS);
                i++;
            }

            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            {
                for (int z = 0; z < arr[j].listings.Count; z++) {
                    if (arr[j].listings[z].GetNameOfListing() == name && arr[j].listings != null)
                    {
                        x = true;
                        S = arr[j];
                        S.listings[z].SetNumberOfItems(NumOfItems);
                        FS.Close();
                        S.EditFile(S);
                        Console.WriteLine("Listing Number Of Item Edited Successfully\n");
                    } }
                if (arr[j].listings == null) { Console.WriteLine("Cant Edit Number Of Item"); Console.WriteLine("The Listing Does Not Exist\n"); }
            }


            if (x == false)
            { Console.WriteLine("Cant Edit Number Of Item"); Console.WriteLine("The Listing Is not In The Seller Data To Edit\n"); }
        }



        ////////////////////////////////////////////////////////Fun View All Listings/////////////////////////////////////////////////
        public void ViewAllListings(Seller S)
        {
            FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            //read objects & save to array
            Seller[] arr = new Seller[1000000];
            int i = 0;
            while (FS.Position < FS.Length)
            {
                arr[i] = (Seller)BF.Deserialize(FS);
                i++;
            }
            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            {
                if (arr[j].GetName() == S.GetName()
                    && arr[j].GetPhoneNumber() == S.GetPhoneNumber()
                    && arr[j].GetEmailAddress() == S.GetEmailAddress())
                {
                    S = arr[j];
                }
            }
            FS.Close();

            if (S.listings.Count != 0)
            {
                for (int J = 0; J < S.listings.Count; J++)
                {

                    S.listings[J].Print();
                    Console.WriteLine("\n");
                }
            }
            else
            { Console.WriteLine("The Listings Is Empty\n"); }
        }


        ///////////////////////////////////////////////View Sold Listings////////////////////////////////////////////////////
        public void ViewSoldListings(Seller S) 
        {
            FileStream FS;
            bool found = false;
            if (File.Exists(ProgramFilesFolder + "/SoldListings.txt"))
            { FS = new FileStream(ProgramFilesFolder + "/SoldListings.txt", FileMode.Open, FileAccess.Read);
                BinaryFormatter BF = new BinaryFormatter();
                //read objects & save to array
                Seller[] arr = new Seller[1000000];
                int i = 0;
                while (FS.Position < FS.Length)
                {
                    arr[i] = (Seller)BF.Deserialize(FS);
                    i++;
                }
                //check if any of the objects in the array eqauls the Edited object then Replace it
                for (int j = 0; j < i; j++)
                {
                    if (arr[j].GetName() == S.GetName()
                        && arr[j].GetStoreNumber() == S.GetStoreNumber())
                    {
                        S = arr[j];
                        found = true;
                    }
                }
                if (found == false) { Console.WriteLine("No Sold Listings to Show\n"); }
                FS.Close();

                if (S.listings.Count != 0)
                {
                    for (int J = 0; J < S.listings.Count; J++)
                    {

                        S.listings[J].Print();
                        Console.WriteLine("\n");
                    }
                }
            }
            else {
                Console.WriteLine("No Sold Listings to Show\n");
            }

        }
        ///////////////////////////////////////////////Change account information////////////////////////////////////////////////////


        public void ChangeSellerPhoneNumber()
        {
          /*FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();*/
            Console.WriteLine("Enter the new Phone Number: ");
            string newnumber = Console.ReadLine();
            this.GeneratePhoneNumber(newnumber);
          //FS.close()
        }
        public void ChangeSellerPassword()
        {
          /*FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();*/
            Console.WriteLine("Enter the new Password: ");
            string newpass = Console.ReadLine();
            Console.WriteLine("Confirm the new Password: ");
            string Confirmnewpass = Console.ReadLine();
            this.GeneratePassword(newpass, Confirmnewpass);
          //FS.close()
        }
        public void ChangeSellerEmailAddress()
        {
          /*FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();*/
            Console.WriteLine("Enter the new Email Address: ");
            string newEmailAddress = Console.ReadLine();
            this.GenerateEmailAddress(newEmailAddress);
          //FS.close()
        }
        public void ChangeSellerStoreName()
        {
          /*FileStream FS;
            FS = new FileStream(ProgramFilesFolder + "/SellerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();*/
            Console.WriteLine("Enter the new Store Name: ");
            string newStoreName = Console.ReadLine();
            this.GenerateName(newStoreName);
          //FS.close()
        }

        public void ChangeSellerAccountInformation(ref Seller s)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;
                Console.WriteLine("What Do you want to change? Enter (1) to change phone number," +
                "Enter (2) to change password,Enter (3) to change email address, Enter (4) to change the store name.");
                string b = Console.ReadLine();
                if (b == "1")
                {
                    ChangeSellerPhoneNumber();
                }
                if (b == "2")
                {
                    ChangeSellerPassword();
                }
                if (b == "3")
                {
                    ChangeSellerEmailAddress();
                }
                if (b == "4")
                {
                    ChangeSellerStoreName();
                }
                else
                {
                    condition = false;
                }

            }
            condition = false;
            //need to add the update to files

        }

    }
}
