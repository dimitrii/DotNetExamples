using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Object
            var model = new Model()
            {
                Prop1 = "proeprty 1",
                Prop2 = "property 2"                
            };

            // Turn Object to JSON string
            var modelJsonString = String.Empty;
            using (var ms = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(Model));
                serializer.WriteObject(ms, model);
                ms.Position = 0;
                using (var sr = new StreamReader(ms))
                {
                    modelJsonString = sr.ReadToEnd();
                }
            }
            Console.WriteLine(modelJsonString);

            // Turn Json string to object
            Model modelFromJsonString;
            using(var ms = new MemoryStream(Encoding.UTF8.GetBytes(modelJsonString)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Model));
                try
                {
                    modelFromJsonString = (Model)serializer.ReadObject(ms);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            Console.WriteLine($"Prop1: {modelFromJsonString.Prop1}");
            Console.WriteLine($"Prop2: {modelFromJsonString.Prop2}");
        }
    }
}
