using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Linq;

namespace Online_Shoping_Site
{
    class Files
    {
        public static void CreateFiles() {
            FileStream SD = new FileStream("SellerData.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter SDformatter = new BinaryFormatter();

            FileStream CD = new FileStream("CustomerData.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter CDformatter = new BinaryFormatter();
        }
    }
}
