﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Linq;


namespace Online_Shoping_Site
{
    class Program
    {
//******************************************************************************************************
//Main:
        static void Main(string[] args)
        {
            //File creation: 
            Files.CreateFiles();


            //Welcoming screen:
            GlobalFun.Welcoming();


        }

    }
}





