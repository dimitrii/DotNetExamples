using System;
using System.Security.Cryptography;
using System.Text;

namespace Md5HashProofOfWork
{
    class Program
    {
        private const int MIN = 1;
        private const int MAX = 4;

        static void Main(string[] args)
        {
            Console.Write("Create a seed: ");
            string source = Console.ReadLine();

            int numberOfZeros = MIN;

            while(true)
            {
                Console.Write($"How many zeros ({MIN} - {MAX}): ");
                string numberOfZerosString = Console.ReadLine();
                try
                {
                    numberOfZeros = Convert.ToInt32(numberOfZerosString);
                    if (numberOfZeros >= MIN && numberOfZeros <= MAX)
                    {
                        break;   
                    }
                }
                catch 
                {

                }
            }
            
            int seed = 0;
            int trys = 0;
            using (MD5 md5Hash = MD5.Create())
            {
                while (true)
                {
                    trys++;
                
                    string hash = GetMd5Hash(md5Hash, source + seed++);
                    Console.WriteLine(hash);

                    int isZeroCheck = 0;
                    for(int i = 0; i < numberOfZeros; i++)
                    {
                        if(hash[hash.Length - 1 - i] == '0')
                        {
                            isZeroCheck++;
                        }
                    }
                    if (numberOfZeros == isZeroCheck)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"Trys: {trys}");
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
