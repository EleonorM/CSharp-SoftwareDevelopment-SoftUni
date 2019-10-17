namespace _4._Copy_Binary_File
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var reader = new FileStream(Path.Combine("picture", "copyMe.png"), FileMode.Create))
            {
                Byte[] imgByte = new byte[reader.Length];
                reader.Write(imgByte, 0, imgByte.Length);
            }
        }
    }
}
