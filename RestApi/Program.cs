﻿using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Forge Client Id: ");
            var clientId = Console.ReadLine();

            Console.Write("Forge Client Secret: ");
            var clientSecret = Console.ReadLine();

            // Create Request
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri("https://developer.api.autodesk.com/authentication/v1/authenticate");
            httpRequest.Content = new FormUrlEncodedContent(new Dictionary<string,string>() {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "grant_type", "client_credentials" },
                { "scope", "data:read" },
            });

            // Send Request
            using(var client = new HttpClient())
            {
                using (var reply = client.SendAsync(httpRequest).Result)
                {
                    using (HttpContent content = reply.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;
                        Console.WriteLine(json);
                        var key = Console.ReadKey();
                    }
                }
            }
        }
    }
}
