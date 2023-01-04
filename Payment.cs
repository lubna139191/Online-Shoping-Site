using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shoping_Site
{
    [Serializable]
    class Payment
    {
        string CardNumber;
        String PinCode;
        string BillingAddress;

//Set Functions:
        public void SetCardNumber(string CardNumber)
        { this.CardNumber = CardNumber; }

        public void SetPinCode(string PinCode)
        { this.PinCode = PinCode; }

        public void SetBillingAddress(string BillingAddress)
        { this.BillingAddress = BillingAddress; }

//Get Functions:
        public string GetCardNumber()
        { return this.CardNumber; }

        public string GetPinCode()
        { return this.PinCode; }

        public string GetBillingAddress()
        { return this.BillingAddress; }

        
    }
}
