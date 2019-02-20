using System;
using System.Security.Cryptography;
using System.Text;

namespace Md5HashProofOfWork
{
    class Program
    {
        private const int MIN = 0;
        private const int MAX = 10;

        static void Main(string[] args)
        {
            while(true)
            {
                string source = String.Empty;
                while (true)
                {
                    Console.Write("Enter a string to hash (or type exit): ");
                    source = Console.ReadLine();
                    if (!String.IsNullOrEmpty(source))
                    {
                        break;
                    }
                }
                if (source == "exit")
                {
                    return;
                }
                int numberOfZeros = MIN;
                while(true)
                {
                    Console.Write($"How many zeros ({MIN} - {MAX}, or exit): ");
                    string numberOfZerosString = Console.ReadLine();
                    try
                    {
                        if (numberOfZerosString == "exit")
                        {
                            return;
                        }
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
                        string toHash = source;
                        if (seed > 0)
                        {
                            toHash += seed;
                        }
                        string hash = GetMd5Hash(md5Hash, toHash);
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
                            Console.WriteLine($"Seed: {seed}");
                            Console.WriteLine($"String: {toHash}");
                            Console.WriteLine(hash);
                            Console.WriteLine($"Trys: {trys}");
                            break;
                        }
                        seed++;
                    }
                }
            }
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
