using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shoping_Site
{
    [Serializable]
    class Address
    {
        string country;
        string city;
        string street;
        string apartmentN;

        //Set:
        public void SetCountry(string country) 
        { this.country = country; }
        public void SetCity(string city) 
        { this.city = city; }
        public void SetStreet(string street) 
        { this.street = street; }
        public void SetApartment(string apartmentN) 
        { this.apartmentN = apartmentN; }

        //Get:
        public string GetCountry() 
        {return this.country; }
        public string GetCity() 
        { return this.city; }
        public string GetStreet() 
        { return this.street; }
        public string GetApartmentN() 
        { return this.apartmentN; }
    }
}
