﻿using System;
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

        string Name;
        Address addrees;
        string EmailAddress;
        string PhoneNumber;
        string StoreNumber;
        string Password;
        string SellerID;

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

        //Fun2:
        public void SetAddress(string Country, string City, String Street, String ApartmentN)
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
                       || x == Convert.ToString("6") || x == Convert.ToString("7") || x == Convert.ToString("8") || x == Convert.ToString("9"))
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

        //Fun3 (Set Email Address: Email is valid):
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

        //Fun4 (Set Phone Number: 10 Numbers, start with 0, second number is 7, third number 7/8/9, the reset are numbers):
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
                         || Convert.ToString(PhoneNumber[2]) != Convert.ToString("8") 
                         || Convert.ToString(PhoneNumber[2]) != Convert.ToString("9")) 
                        { condition = false; }

                        else 
                        { condition = false; }

                        //check if the rest of the phone number are numbers:
                        for (int i = 3; i < PhoneNumber.Length; i++)
                        {
                            string x = Convert.ToString(PhoneNumber[i]);
                            if (x != Convert.ToString("0") && x != Convert.ToString("1") && x != Convert.ToString("2")
                            &&  x != Convert.ToString("3") && x != Convert.ToString("4") && x != Convert.ToString("5")
                            &&  x != Convert.ToString("6") && x != Convert.ToString("7") && x != Convert.ToString("8")
                            &&  x != Convert.ToString("9")) 
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
                        if (Answer == "Y"||Answer == "y")
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

        //Fun5:
        public void SetStoreNumber(string StoreNumber) 
        {
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

        //Fun6 (Set Password: Password Confirm, 8 charchters, special charchter, capital & small letters): 
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
                   || Password.ToLower().Contains('\'')|| Password.ToLower().Contains('>') || Password.ToLower().Contains(',') 
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

        //Fun7:
        public void SetSellerID() 
        {
            counter++;
            this.SellerID = Convert.ToString(counter);
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
        public void CheckSeller() 
        {
            //Exist or not:
            FileStream FS;
            if (File.Exists("SellerData.txt"))
            { FS = new FileStream("SellerData.txt", FileMode.Open, FileAccess.Read); }

            else
            { FS = new FileStream("SellerData.txt", FileMode.Create, FileAccess.ReadWrite); } 

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
                    if (   arr[j].GetName()         == this.GetName() 
                        && arr[j].GetPhoneNumber()  == this.GetPhoneNumber()
                        && arr[j].GetEmailAddress() == this.GetEmailAddress())
                    {
                        Console.WriteLine("The User Already Exist, Please Try to Log In Instead of Sign Up");
                        FS.Close();
                        GlobalFun.Welcoming();
                    } 
                }
                        
                //if its new user save it to file
                            FS.Close();
                            this.SetSellerID();
                            this.SaveToFile();
                            Console.WriteLine("User Account Created Successfully As A Seller");
                            Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
                            string Answer = Console.ReadLine();

                            if (Answer == "Y") 
                            { this.LogInSeller(); }

                            else 
                            { GlobalFun.Welcoming(); }
                }

                else
                { 
                    //if the file is empty then user is new (save it)
                    FS.Close();
                    this.SetSellerID();
                    this.SaveToFile();
                    Console.WriteLine("User Account Created Successfully As A Seller");
                    Console.WriteLine("Do You Want To Log In? Answer by(Y:N):");
                    string Answer = Console.ReadLine();

                    if (Answer == "Y") 
                    { this.LogInSeller(); }

                    else 
                    { GlobalFun.Welcoming(); }
                }
        }

        //Fun12 (Seve To File):
        public void SaveToFile() 
        {
            FileStream FS = new FileStream("SellerData.txt", FileMode.Append, FileAccess.Write);
            BinaryFormatter BF = new BinaryFormatter();
            BF.Serialize(FS, this);
            FS.Close();
        }

        //Fun13 (Sign Up Seller):
        public void SignUpSeller()
        {
            Console.WriteLine("Fill The Following To Create Your New Account As A Seller.");

            //Seller Name:
            string SName;
            Console.WriteLine("Full Name(Make Sure It Does Not Contains Any Numbers or Special Charachters):");
            SName = Console.ReadLine();
            this.SetName(SName);

            //Seller Address:
            Console.WriteLine("Address");
            Console.WriteLine("Country (Make Sure It Does Not Contains Any Numbers Or Special Charaters):");
            string SCountry;
            SCountry = Console.ReadLine();
            Console.WriteLine("City (Make Sure It Does Not Contains Any Numbers Or Special Charaters):");
            string SCity;
            SCity = Console.ReadLine();
            Console.WriteLine("Street (Make Sure It Does Not Contains Any Numbers Or Special Charaters):");
            string SStreet;
            SStreet = Console.ReadLine();
            Console.WriteLine("Apartment Number (Make Sure It Does Not Contains Any Letters Or Special Charaters Or Spaces):");
            string SApartmentN;
            SApartmentN = Console.ReadLine();
            this.SetAddress(SCountry, SCity, SStreet, SApartmentN);

            //Seller Email Address:
            string SEmailAddress;
            Console.WriteLine("Email Address(Make Sure Its A Vaild Email Ex:xxx@xxx.com):");
            SEmailAddress = Console.ReadLine();
            this.SetEmailAddress(SEmailAddress);

            //Seller Phone Number:
            string SPhoneNumber;
            Console.WriteLine("PhoneNumber(Make Sure It Does Not Contains Any Letters or Special Charachters & Valid Ex:07(7|8|9)*******):");
            SPhoneNumber = Console.ReadLine();
            this.SetPhoneNumber(SPhoneNumber);

            //Seller StoreNumber: 
            string SStoreNumber;
            Console.WriteLine("StoreNumber(Make Sure It Does Not Contains Any Letters or Special Charachters):");
            SStoreNumber = Console.ReadLine();
            this.SetStoreNumber(SStoreNumber);

            //Seller Password:
            string SPassword;
            Console.WriteLine("Password(Make Sure It is Not Less Than 8 Charachters\nAnd Contains One UpperCase & One LowerCase & one Special Charachters At Least):");
            SPassword = Console.ReadLine();
            string ConfirmSPassword;
            Console.WriteLine("Confirm Password:");
            ConfirmSPassword = Console.ReadLine();
            this.SetPassword(SPassword, ConfirmSPassword);

            //Check if the seller already exist & if the user is new Give uniqe ID then save to file:
            this.CheckSeller();
        }

        //Fun14:
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
}
