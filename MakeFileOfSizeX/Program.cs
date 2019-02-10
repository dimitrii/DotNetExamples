using System;
using System.IO;

namespace MakeFileOfSizeX
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many megabytes? (1000 max): ");
            var sizeInMbString = Console.ReadLine();

            int sizeInMb = Convert.ToInt32(sizeInMbString);

            if (sizeInMb > 1000 || sizeInMb < 0)
            {
                return;
            }
            var fileName = Guid.NewGuid().ToString() + ".dat";
            byte[] data = new byte[sizeInMb * 1024 * 1024];
            Random rng = new Random();
            rng.NextBytes(data);
            File.WriteAllBytes(fileName, data);

            Console.WriteLine("Saved: " + fileName);
        }
    }
}
