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
    class Customer
    {
        string Name;
        string EmailAddress;
        string PhoneNumber;
        string Password;
        string CustomerId;
        Address ShippingAddress;
        Payment PaymentInformation;
        public static int counter = 0;



        //Listings listings;
        //Fun1 (Set Name: Letters only, No Nubers, No Special Charachters): 
        public void SetName(string Name)
        {
            bool condition = false;
            while (condition == false)
            {
                condition = true;

                //check if enterd name contains any nmubers
                for (int i = 0; i < Name.Length; i++)
                {
                    string x = Convert.ToString(Name[i]);
                    if (   x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
                       ||  x == Convert.ToString("3") || x == Convert.ToString("4") || x == Convert.ToString("5")
                       ||  x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8") 
                       ||  x == Convert.ToString("9"))
                    {
                        condition = false;
                    }
                }

                //check if enterd name contains any special charachters
                if  (  Name.ToLower().Contains('~') || Name.ToLower().Contains('!') || Name.ToLower().Contains('@') || Name.ToLower().Contains('#') 
                    || Name.ToLower().Contains('$') || Name.ToLower().Contains('^') || Name.ToLower().Contains('&') || Name.ToLower().Contains('*') 
                    || Name.ToLower().Contains('(') || Name.ToLower().Contains(')') || Name.ToLower().Contains('_') || Name.ToLower().Contains('-') 
                    || Name.ToLower().Contains('=') || Name.ToLower().Contains('+') || Name.ToLower().Contains('{') || Name.ToLower().Contains('[') 
                    || Name.ToLower().Contains(']') || Name.ToLower().Contains('}') || Name.ToLower().Contains(';') || Name.ToLower().Contains(';') 
                    || Name.ToLower().Contains('\"')|| Name.ToLower().Contains('\'')|| Name.ToLower().Contains('<') || Name.ToLower().Contains(',') 
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

        //Fun2 (Set Email Address: Email is valid):
        public void SetEmailAddress(string EmailAddress)
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

        //Fun3 (Set Phone Number: 10 Numbers, start with 0, second number is 7, third number 7/8/9, the reset are numbers):
        public void SetPhoneNumber(string PhoneNumber)
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

        //Fun4 (Set Password: Password Confirm, 8 charchters, special charchter, capital & small letters): 
        public void SetPassword(string Password, string ConfirmSPassword)
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

        //Fun5 (Set Customer ID):
        public void SetCustomerID()
        {
            counter++;
            this.CustomerId = Convert.ToString(counter);
        }

        //Fun6 (set Shipping Address: Country, City, Street, Apartment):
        //Country: No number, No space, No special charachters.
        //City: No number, No space, No special charachters.
        //Street: No number, No space, No special charachters.
        //Apartment: No number, No space, No special charachters.
        public void SetShippingAddress(string Country, string City, String Street, String ApartmentN)
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
                    if (   x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
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
                if (   Country.ToLower().Contains('~') || Country.ToLower().Contains('!') || Country.ToLower().Contains('@') 
                    || Country.ToLower().Contains('#') || Country.ToLower().Contains('$') || Country.ToLower().Contains('^')
                    || Country.ToLower().Contains('&') || Country.ToLower().Contains('*') || Country.ToLower().Contains('(') 
                    || Country.ToLower().Contains(')') || Country.ToLower().Contains('_') || Country.ToLower().Contains('-') 
                    || Country.ToLower().Contains('=') || Country.ToLower().Contains('+') || Country.ToLower().Contains('{') 
                    || Country.ToLower().Contains('[') || Country.ToLower().Contains(']') || Country.ToLower().Contains('}')
                    || Country.ToLower().Contains(';') || Country.ToLower().Contains(';') || Country.ToLower().Contains('\"') 
                    || Country.ToLower().Contains('\'')|| Country.ToLower().Contains('<') || Country.ToLower().Contains(',') 
                    || Country.ToLower().Contains('.') || Country.ToLower().Contains('<') || Country.ToLower().Contains('/') 
                    || Country.ToLower().Contains('?') || Country.ToLower().Contains('\\')|| Country.ToLower().Contains('|'))
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
                    if (   x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
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
                if (   City.ToLower().Contains('~') || City.ToLower().Contains('!')  || City.ToLower().Contains('@') || City.ToLower().Contains('#') 
                    || City.ToLower().Contains('$') || City.ToLower().Contains('^')  || City.ToLower().Contains('&') || City.ToLower().Contains('*') 
                    || City.ToLower().Contains('(') || City.ToLower().Contains(')')  || City.ToLower().Contains('_') || City.ToLower().Contains('-') 
                    || City.ToLower().Contains('=') || City.ToLower().Contains('+')  || City.ToLower().Contains('{') || City.ToLower().Contains('[') 
                    || City.ToLower().Contains(']') || City.ToLower().Contains('}')  || City.ToLower().Contains(';') || City.ToLower().Contains(';') 
                    || City.ToLower().Contains('\"') || City.ToLower().Contains('\'')|| City.ToLower().Contains('<') || City.ToLower().Contains(',') 
                    || City.ToLower().Contains('.') || City.ToLower().Contains('<')  || City.ToLower().Contains('/') || City.ToLower().Contains('?') 
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
                    if (  x == Convert.ToString("0") || x == Convert.ToString("1") || x == Convert.ToString("2")
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
                if (   Street.ToLower().Contains('~') || Street.ToLower().Contains('!')  || Street.ToLower().Contains('@') || Street.ToLower().Contains('#') 
                    || Street.ToLower().Contains('$') || Street.ToLower().Contains('^')  || Street.ToLower().Contains('&') || Street.ToLower().Contains('*') 
                    || Street.ToLower().Contains('(') || Street.ToLower().Contains(')')  || Street.ToLower().Contains('_') || Street.ToLower().Contains('-') 
                    || Street.ToLower().Contains('=') || Street.ToLower().Contains('+')  || Street.ToLower().Contains('{') || Street.ToLower().Contains('[') 
                    || Street.ToLower().Contains(']') || Street.ToLower().Contains('}')  || Street.ToLower().Contains(';') || Street.ToLower().Contains(';') 
                    || Street.ToLower().Contains('\"') || Street.ToLower().Contains('\'')|| Street.ToLower().Contains('<') || Street.ToLower().Contains(',') 
                    || Street.ToLower().Contains('.') || Street.ToLower().Contains('<')  || Street.ToLower().Contains('/') || Street.ToLower().Contains('?') 
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

        //Fun8:
        public string GetName()
        { return Name; }

        //Fun9:
        public string GetEmailAddress()
        { return EmailAddress; }

        //Fun10:
        public string GetPhoneNumber()
        { return PhoneNumber; }

        //Fun11 (Check Seller: Exist or not, empty or not, save object, equality):
        public void CheckCustomer()
        {
            //Exist or not:
            FileStream FC;
            if (File.Exists("CustomerData.txt"))
            { FC = new FileStream("CustomerData.txt", FileMode.Open, FileAccess.Read); }

            else
            { FC = new FileStream("CustomerData.txt", FileMode.Create, FileAccess.ReadWrite); }

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
                this.SetCustomerID();
                this.SaveToFile();
                Console.WriteLine("User Account Created Successfully As A Customer");
                Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
                string Answer = Console.ReadLine();

                if (Answer == "Y")
                { this.LogInCustomer(); }

                else
                { GlobalFun.Welcoming(); }
            }

            else
            {
                //if the file is empty then user is new (save it)
                FC.Close();
                this.SetCustomerID();
                this.SaveToFile();
                Console.WriteLine("User Account Created Successfully As A Customer");
                Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
                string Answer = Console.ReadLine();

                if (Answer == "Y")
                { this.LogInCustomer(); }

                else
                { GlobalFun.Welcoming(); }
            }
        }

        //Fun12 (Seve To File):
        public void SaveToFile()
        {
            FileStream FC = new FileStream("CustomerData.txt", FileMode.Append, FileAccess.Write);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Serialize(FC, this);
            FC.Close();
        }

        //Fun13 (Sign Up Customer):
        public void SignUpCustomer()
        {
            Console.WriteLine("Fill The Following To Create Your New Account As A Customer.");

            //Customer Name:
            string CName;
            Console.WriteLine("Full Name(Make Sure It Does Not Contains Any Numbers or Special Charachters):");
            CName = Console.ReadLine();
            this.SetName(CName);

            //Customer Email Address:
            string CEmailAddress;
            Console.WriteLine("Email Address(Make Sure Its A Vaild Email Ex:xxx@xxx.com):");
            CEmailAddress = Console.ReadLine();
            this.SetEmailAddress(CEmailAddress);

            //Customer Phone Number:
            string CPhoneNumber;
            Console.WriteLine("PhoneNumber(Make Sure It Does Not Contains Any Letters or Special Charachters & Valid Ex:07(7|8|9)*******):");
            CPhoneNumber = Console.ReadLine();
            this.SetPhoneNumber(CPhoneNumber);

         
            //Customer Password:
            string CPassword;
            Console.WriteLine("Password(Make Sure It is Not Less Than 8 Charachters\nAnd Contains One UpperCase & One LowerCase & one Special Charachters At Least):");
            CPassword = Console.ReadLine();
            string ConfirmCPassword;
            Console.WriteLine("Confirm Password:");
            ConfirmCPassword = Console.ReadLine();
            this.SetPassword(CPassword, ConfirmCPassword);

            //Customer Address:
            Console.WriteLine("Address");
            Console.WriteLine("Country (Make Sure It Does Not Contains Spaces or Any Numbers Or Special Charaters):");
            string CCountry;
            CCountry = Console.ReadLine();
            Console.WriteLine("City (Make Sure It Does Not Contains Spaces or Any Numbers Or Special Charaters):");
            string CCity;
            CCity = Console.ReadLine();
            Console.WriteLine("Street (Make Sure It Does Not Contains Spaces or Any Numbers Or Special Charaters):");
            string CStreet;
            CStreet = Console.ReadLine();
            Console.WriteLine("Apartment Number (Make Sure It Does Not Contains Spaces Any Letters Or Special Charaters Or Spaces):");
            string CApartmentN;
            CApartmentN = Console.ReadLine();
            this.SetShippingAddress(CCountry, CCity, CStreet, CApartmentN);

            //Check if the customer already exist & if the user is new Give uniqe ID then save to file:
            this.CheckCustomer();

        }

        //Fun14: 
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
}
