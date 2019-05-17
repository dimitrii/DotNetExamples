using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

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
                Prop2 = "property 2",
                ParentModel = new Model()
                {
                    Prop1 = "parentProp1",
                    Prop2 = "parentProp2",
                    ParentModel = new Model()
                    {
                        Prop1 = "parentParentProp1",
                        Prop2 = "parentParentProp2"
                    }
                }
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

            // Turn Json string to XmlDocument
            Dictionary<string,dynamic> obj;
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(modelJsonString)))
            {
                try
                {
                    var reader = JsonReaderWriterFactory.CreateJsonReader(ms, new XmlDictionaryReaderQuotas());
                    while (reader.Read())
                    {
                        var value = reader.ReadContentAsString();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            
        }
    }
}
