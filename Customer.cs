using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Online_Shoping_Site
{
    [Serializable]
    class Customer
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////// Atributes /////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string Name;
        string EmailAddress;
        string PhoneNumber;
        string Password;
        string CustomerId;
        Address ShippingAddress;
        Payment PaymentInformation;
        List<Listings> listings;
        public static int counter = 0;
        public static Dictionary<string, object> data = new Dictionary<string, object>();
        public static string ProgramFilesFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Data";


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////Set Functions//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetName(string Name) { this.Name = Name; }
        public void SetEmailAddress(string EmailAddress) { this.EmailAddress = EmailAddress; }
        public void SetPhoneNumber(string PhoneNumber) { this.PhoneNumber = PhoneNumber; }
        public void SetPassword(string Password) { this.Password = Password; }
        public void SetCustomerID(string ID) { this.CustomerId = ID; }
        public void SetShippingAddress(Address ShippingAddress) { this.ShippingAddress = ShippingAddress; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////Get Functions//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public string GetName() { return this.Name; }
        public string GetEmailAddress() { return this.EmailAddress; }
        public string GetPhoneNumber() { return this.PhoneNumber; }
        public string GetPassword() { return this.Password; }
        public string GetCustomerId() { return this.CustomerId; }
        public Address GetShippingAddress() { return this.ShippingAddress; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////Check the Data Enterd By the User///////////////////////////////////////////////
        ////////////////////////////When the User Sign Up For The First Time//////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////(Generate Name: Letters only, No Numbers, No Special Charachters)/////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////(Generate Email Address)//////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////(Generate Phone Number)////////////////////////////////////////////
        //////(10 Numbers, start with 0, second number is 7, third number 7/8/9, the rest are numbers)///////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////(Generate Password)/////////////////////////////////////////////
        //////////////(Confirm Password, 8 charchters, special charchter, capital & small letters)///////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////(Generate Customer ID)////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public void GenerateCustomerID()
        {
            counter++;
            this.CustomerId = Convert.ToString(counter);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////(Generate Shipping Address: Country, City, Street, Apartment)//////////////////
        ////////////////////////////(No number, No space, No special charachters)/////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public void GenerateShippingAddress(string Country, string City, String Street, String ApartmentN)
        {
            ShippingAddress = new Address();

            ////Check Country:
            bool condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd Country contains any nmubers:
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

                //check if enterd Country contains any Spaces: 
                if (Country.ToLower().Contains(" "))
                { condition = false; }

                //check if enterd Country contains any special charachters:
                if (Country.ToLower().Contains('~') || Country.ToLower().Contains('!') || Country.ToLower().Contains('@')
                    || Country.ToLower().Contains('#') || Country.ToLower().Contains('$') || Country.ToLower().Contains('^')
                    || Country.ToLower().Contains('&') || Country.ToLower().Contains('*') || Country.ToLower().Contains('(')
                    || Country.ToLower().Contains(')') || Country.ToLower().Contains('_') || Country.ToLower().Contains('-')
                    || Country.ToLower().Contains('=') || Country.ToLower().Contains('+') || Country.ToLower().Contains('{')
                    || Country.ToLower().Contains('[') || Country.ToLower().Contains(']') || Country.ToLower().Contains('}')
                    || Country.ToLower().Contains(';') || Country.ToLower().Contains(';') || Country.ToLower().Contains('\"')
                    || Country.ToLower().Contains('\'') || Country.ToLower().Contains('<') || Country.ToLower().Contains(',')
                    || Country.ToLower().Contains('.') || Country.ToLower().Contains('<') || Country.ToLower().Contains('/')
                    || Country.ToLower().Contains('?') || Country.ToLower().Contains('\\') || Country.ToLower().Contains('|'))
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
                        Console.WriteLine("Are You Sure You Want To Exit? Answer By(Y:N)");
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
            this.ShippingAddress.SetCountry(Country);

            ////Check City:
            condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd City contains any nmubers:
                for (int i = 0; i < City.Length; i++)
                {
                    string x = Convert.ToString(City[i]);
                    if (x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
                        || x == Convert.ToString("3") || x == Convert.ToString("4") || x == Convert.ToString("5")
                        || x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8")
                        || x == Convert.ToString("9"))
                    {
                        condition = false;
                    }

                }

                //check if enterd City contains any Spaces: 
                if (City.ToLower().Contains(" "))
                { condition = false; }

                //check if enterd City contains any special charachters:
                if (City.ToLower().Contains('~') || City.ToLower().Contains('!') || City.ToLower().Contains('@') || City.ToLower().Contains('#')
                    || City.ToLower().Contains('$') || City.ToLower().Contains('^') || City.ToLower().Contains('&') || City.ToLower().Contains('*')
                    || City.ToLower().Contains('(') || City.ToLower().Contains(')') || City.ToLower().Contains('_') || City.ToLower().Contains('-')
                    || City.ToLower().Contains('=') || City.ToLower().Contains('+') || City.ToLower().Contains('{') || City.ToLower().Contains('[')
                    || City.ToLower().Contains(']') || City.ToLower().Contains('}') || City.ToLower().Contains(';') || City.ToLower().Contains(';')
                    || City.ToLower().Contains('\"') || City.ToLower().Contains('\'') || City.ToLower().Contains('<') || City.ToLower().Contains(',')
                    || City.ToLower().Contains('.') || City.ToLower().Contains('<') || City.ToLower().Contains('/') || City.ToLower().Contains('?')
                    || City.ToLower().Contains('\\') || City.ToLower().Contains('|'))
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
            this.ShippingAddress.SetCity(City);

            ////Check Street:
            condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd Street contains any nmubers:
                for (int i = 0; i < Street.Length; i++)
                {
                    string x = Convert.ToString(Street[i]);
                    if (x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
                       || x == Convert.ToString("3") || x == Convert.ToString("4") || x == Convert.ToString("5")
                       || x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8")
                       || x == Convert.ToString("9"))
                    {
                        condition = false;
                    }

                }

                //check if enterd Street contains any Spaces: 
                if (Street.ToLower().Contains(" "))
                { condition = false; }

                //check if enterd City contains any special charachters:
                if (Street.ToLower().Contains('~') || Street.ToLower().Contains('!') || Street.ToLower().Contains('@') || Street.ToLower().Contains('#')
                    || Street.ToLower().Contains('$') || Street.ToLower().Contains('^') || Street.ToLower().Contains('&') || Street.ToLower().Contains('*')
                    || Street.ToLower().Contains('(') || Street.ToLower().Contains(')') || Street.ToLower().Contains('_') || Street.ToLower().Contains('-')
                    || Street.ToLower().Contains('=') || Street.ToLower().Contains('+') || Street.ToLower().Contains('{') || Street.ToLower().Contains('[')
                    || Street.ToLower().Contains(']') || Street.ToLower().Contains('}') || Street.ToLower().Contains(';') || Street.ToLower().Contains(';')
                    || Street.ToLower().Contains('\"') || Street.ToLower().Contains('\'') || Street.ToLower().Contains('<') || Street.ToLower().Contains(',')
                    || Street.ToLower().Contains('.') || Street.ToLower().Contains('<') || Street.ToLower().Contains('/') || Street.ToLower().Contains('?')
                    || Street.ToLower().Contains('\\') || Street.ToLower().Contains('|'))
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
            this.ShippingAddress.SetStreet(Street);

            ////Check Apatrment:
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
                     && x != Convert.ToString("9"))
                    { condition = false; }

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
                        Console.WriteLine("Are You Sure You Want To Exit? Answer By(Y:N)");
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
            this.ShippingAddress.SetApartment(ApartmentN);
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////Functions On Customer////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////(Sign Up  Function)///////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SignUpCustomer()
        {
            Console.WriteLine("Fill The Following To Create Your New Account As A Customer.");

            //Customer Name:
            string CName;
            Console.WriteLine("Full Name(Make Sure It Does Not Contains Any Numbers or Special Charachters):");
            CName = Console.ReadLine();
            this.GenerateName(CName);
            Console.WriteLine("\n");

            //Customer Email Address:
            string CEmailAddress;
            Console.WriteLine("Email Address(Make Sure Its A Vaild Email Ex:xxx@xxx.com):");
            CEmailAddress = Console.ReadLine();
            Console.WriteLine("\n");
            this.GenerateEmailAddress(CEmailAddress);

            //Customer Phone Number:
            string CPhoneNumber;
            Console.WriteLine("PhoneNumber(Make Sure It Does Not Contains Any Letters or Special Charachters & Valid Ex:07(7|8|9)*******):");
            CPhoneNumber = Console.ReadLine();
            Console.WriteLine("\n");
            this.GeneratePhoneNumber(CPhoneNumber);

            //Customer Password:
            string CPassword;
            Console.WriteLine("Password(Make Sure It is Not Less Than 8 Charachters\nAnd Contains One UpperCase & One LowerCase & one Special Charachters At Least):");
            CPassword = Console.ReadLine();
            string ConfirmCPassword;
            Console.WriteLine("Confirm Password:");
            ConfirmCPassword = Console.ReadLine();
            Console.WriteLine("\n");
            this.GeneratePassword(CPassword, ConfirmCPassword);

            //Customer Address:
            Console.WriteLine("Address\n");
            //Country:
            Console.WriteLine("Country (Make Sure It Does Not Contains Spaces or Any Numbers Or Special Charaters):");
            string CCountry;
            CCountry = Console.ReadLine();
            Console.WriteLine("\n");
            //City:
            Console.WriteLine("City (Make Sure It Does Not Contains Spaces or Any Numbers Or Special Charaters):");
            string CCity;
            CCity = Console.ReadLine();
            Console.WriteLine("\n");
            //Street:
            Console.WriteLine("Street (Make Sure It Does Not Contains Spaces or Any Numbers Or Special Charaters):");
            string CStreet;
            CStreet = Console.ReadLine();
            Console.WriteLine("\n");
            //Apartment Number:
            Console.WriteLine("Apartment Number (Make Sure It Does Not Contains Spaces Any Letters Or Special Charaters Or Spaces):");
            string CApartmentN;
            CApartmentN = Console.ReadLine();
            Console.WriteLine("\n");
            this.GenerateShippingAddress(CCountry, CCity, CStreet, CApartmentN);

            //Check if the customer already exist & if the user is new Give uniqe ID then save to file:
            this.CheckCustomer();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////Check If Seller Exist/////////////////////////////////////////////////////////
        ////////////////////////////////////////When New Seller Sign Up/////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CheckCustomer()
        {
            //Exist or not:
            FileStream FC;
            if (File.Exists(ProgramFilesFolder + "/CustomerData.txt"))
            { FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Open, FileAccess.Read); }

            else
            {
                Directory.CreateDirectory(ProgramFilesFolder);
                FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Create, FileAccess.ReadWrite);
            }

            BinaryFormatter BF = new BinaryFormatter();
            Customer[] arr = new Customer[1000000];
            int i = 0;

            //if the file is empty write without checking
            if (FC.Length != 0)
            {
                //read objects & save to array
                while (FC.Position < FC.Length)
                {
                    arr[i] = (Customer)BF.Deserialize(FC);
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
                        FC.Close();
                        GlobalFun.Welcoming();
                    }
                }

                //if its new user save it to file
                FC.Close();
                this.GenerateCustomerID();
                this.SaveToFile();
                Console.WriteLine("User Account Created Successfully As A Customer");
                Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
                string Answer = Console.ReadLine();

                if (Answer == "Y" || Answer == "y")
                { this.LogInCustomer(); }

                else
                { GlobalFun.Welcoming(); }
            }

            else
            {
                //if the file is empty then user is new (save it)
                FC.Close();
                this.GenerateCustomerID();
                this.SaveToFile();
                Console.WriteLine("User Account Created Successfully As A Customer");
                Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
                string Answer = Console.ReadLine();

                if (Answer == "Y" || Answer == "y")
                { this.LogInCustomer(); }

                else
                { GlobalFun.Welcoming(); }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////Save Customer Account To CustomerData File///////////////////////////////////////
        //////////////////////////////////When New Customer Account Pass The Checkup Test////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SaveToFile()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Data"))
            { Directory.CreateDirectory(ProgramFilesFolder); }
            FileStream FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Append, FileAccess.Write);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Serialize(FC, this);
            FC.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////( Serch If The Account Trying To Log In Exist )///////////////////////////////   
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void FindAccount(string email, string Password, ref Customer C)
        {
            //Exist or not:
            FileStream FC;
            if (!(File.Exists(ProgramFilesFolder + "/CustomerData.txt")))
            {
                Console.WriteLine("The Email Or Password is Wrong, Please Try Again");
                GlobalFun.Welcoming();
            }

            FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();

            Customer[] arr = new Customer[1000000];
            int i = 0;

            if (FC.Length != 0)
            {
                //read objects & save to array
                while (FC.Position < FC.Length)
                {
                    arr[i] = (Customer)BF.Deserialize(FC);
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
                        C.SetName(arr[j].GetName());
                        C.SetEmailAddress(arr[j].GetEmailAddress());
                        C.SetShippingAddress(arr[j].GetShippingAddress());
                        C.SetPassword(arr[j].GetPassword());
                        C.SetPhoneNumber(arr[j].GetPhoneNumber());
                        C.SetCustomerID(arr[j].GetCustomerId());
                        FC.Close();
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////( Function To Edit Data File After Any Change )/////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void EditFile(Customer C)
        {
            FileStream FC;
            FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();
            Customer[] arr = new Customer[1000000];
            int i = 0;


            //read objects & save to array
            while (FC.Position < FC.Length)
            {
                arr[i] = (Customer)BF.Deserialize(FC);
                i++;
            }

            //check if any of the objects in the array eqauls the Edited object then Replace it
            for (int j = 0; j < i; j++)
            {
                if (arr[j].GetName() == C.GetName()
                    && arr[j].GetPhoneNumber() == C.GetPhoneNumber()
                    && arr[j].GetEmailAddress() == C.GetEmailAddress())
                {
                    arr[j] = new Customer();
                    arr[j] = C;
                }
            }
            FC.Close();

            FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Create, FileAccess.ReadWrite);
            for (int k = 0; k < i; k++) { BF.Serialize(FC, arr[k]); }


            FC.Close();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////( Log In )////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void LogInCustomer()
        {
            string email;
            string Password;
            Console.WriteLine("Enter Your Email:");
            email = Console.ReadLine();
            Console.WriteLine("Enter Your Password:");
            Password = Console.ReadLine();
            Customer C = new Customer();
            this.FindAccount(email, Password, ref C);

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
                Console.Write("\nEnter your choice:");
                choice = Convert.ToInt16(Console.ReadLine());
                string x = Console.ReadLine();

                //To Avoid Exception Of Converting Non Convertable Type To Int
                if (x == "1" || x == "2" || x == "3" || x == "4" || x == "5" || x == "6" || x == "7")
                { choice = Convert.ToInt16(x); }
                else 
                { choice = 8; }

                Console.WriteLine("\n");
                switch (choice)
                {
                    case 1:
                        this.ViewAllAvailableListings();
                        break;

                    case 2:
                        Console.WriteLine("Enter Name of listing whose contents you want to view:");
                        string Name = Console.ReadLine();
                        C.ViewChosenListingInformation(Name);
                        break;

                    case 3:
                        //AddListingToCart();
                        break;

                    case 4:
                        //ViewEditAddedListingsToCart();
                        Console.WriteLine("View Added listings to cart: ");

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
                        GlobalFun.Welcoming();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice, please try agian...");
                        break;
                }
            }
            while (choice != 8);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////( Functions Seller Can Do When Log In Pass Successfully )////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////( View all available listings )///////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewAllAvailableListings()
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

            FS.Close();

            Seller S = new Seller();
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////( View Chosen Listing Information )///////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewChosenListingInformation(string Name)
        {
            //Check emty or not:
            if (this.listings != null)
            {
                for (int i = 0; i < this.listings.Count; i++)
                {
                    if (this.listings[i].GetNameOfListing() == Name)
                    {
                        // this.listings[i].Print();
                    }
                }
            }

            else
            { Console.WriteLine("The Listings Is Empty"); }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////( Add Listing To Cart )////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddListingToCart()
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////( View/Edit Added Listings To Cart )//////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewEditAddedListingsToCart()
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////( Checkout Listings )/////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CheckoutListings()
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////( Change Account Information )////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeCustomerPhoneNumber()
        {
          /*FileStream FC;
            FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();*/
            Console.WriteLine("Enter the new Phone Number: ");
            string newnumber = Console.ReadLine();
            this.GeneratePhoneNumber(newnumber);
          //FC.close();
        }
        public void ChangeCustomerPassword()
        {
          /*FileStream FC;
            FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();*/
            Console.WriteLine("Enter the new Password: ");
            string newpass = Console.ReadLine();
            Console.WriteLine("Confirm the new Password: ");
            string Confirmnewpass = Console.ReadLine();
            this.GeneratePassword(newpass, Confirmnewpass);
          //FC.close();
        }
        public void ChangeCustomerEmailAddress()
        {
          /*FileStream FC;
            FC = new FileStream(ProgramFilesFolder + "/CustomerData.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter BF = new BinaryFormatter();*/
            Console.WriteLine("Enter the new Email Address: ");
            string newEmailAddress = Console.ReadLine();
            this.GenerateEmailAddress(newEmailAddress);
          //FC.close();
        }

        public void ChangeCustomerAccountInformation(ref Customer c)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;
                Console.WriteLine("What Do you want to change? Enter (1) to change phone number," +
                "Enter (2) to change password,Enter (3) to change email address");
                string b = Console.ReadLine();
                if (b == "1")
                {
                    ChangeCustomerPhoneNumber();
                }
                if (b == "2")
                {
                    ChangeCustomerPassword();
                }
                if (b == "3")
                {
                    ChangeCustomerEmailAddress();
                }
                else
                {
                    condition = false;
                }

            }
            condition = false;
            //need to add the update to files

        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////( Search For Listing )////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SearchForListing()
        {

        }

    }
}