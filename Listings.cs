using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shoping_Site
{
    [Serializable]
    class Listings
    {
        string NameOfListing;
        string Description;
        double Price;
        int    NumberOfItems;

        //Set:
        public void SetNameOfListing (string NameOfListing)
        { this.NameOfListing = NameOfListing;  }

        public void SetDescription (string Description)
        { this.Description = Description; }

        public void SetPrice(double Price)
        { this.Price = Price; }

        public void SetNumberOfItems(int NumberOfItems)
        { this.NumberOfItems = NumberOfItems; }

        //Get:
        public string GetNameOfListing()
        { return this.NameOfListing; }

        public string GetDescription()
        { return this.Description; }

        public double GetPrice()
        { return this.Price; }

        public int GetNumberOfItems()
        { return this.NumberOfItems; }

        public void Print() 
        {  
         
            Console.WriteLine("Listings Name:" + " " + this.GetNameOfListing());
            Console.WriteLine("Listings Description:" + " " + this.GetDescription());
            Console.WriteLine("Number Of Items:" + " " + this.GetNumberOfItems());
            Console.WriteLine("Price:" + " " + this.GetPrice());
          
        }

    }
}
