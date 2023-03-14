using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using House4U.Models;
using System.Net.Http.Json;


namespace Properties
{
    public class Program
    {
        static HttpClient client { get; set; }

        static void Main(string[] args) 
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5148/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            GetAllProperties().Wait();
            GetAProperty(1).Wait();
            GetAllEmails().Wait();
        }

        private static async Task GetAllEmails()
        {
            Console.WriteLine("");
            Console.WriteLine("***GetAllEmails***");
            Console.WriteLine("");

            HttpResponseMessage msg = await client.GetAsync("AllEmails");

            if (msg.IsSuccessStatusCode)
            {
                IEnumerable<String> mails = await msg.Content.ReadFromJsonAsync<IEnumerable<String>>();
                foreach (string m in mails)
                {
                    Console.WriteLine(m);
                }
            }
            else
            {
                Console.WriteLine("GetAllEmails - Error: " + msg.StatusCode + msg.ReasonPhrase);
            }
        }

        private static async Task GetAProperty(int v)
        {
            Console.WriteLine("");
            Console.WriteLine("***GetAProperty***");
            Console.WriteLine("");

            HttpResponseMessage msg = await client.GetAsync("api/Property/0");

            if (msg.IsSuccessStatusCode)
            {
                Property prop = await msg.Content.ReadFromJsonAsync<Property>();
                Console.WriteLine(prop);

            }
            else
            {
                Console.WriteLine("GetAProperty - Error: " + msg.StatusCode + msg.ReasonPhrase);
            }
        }

        private static async Task GetAllProperties()
        {
            Console.WriteLine("");
            Console.WriteLine("***GetAllProperties***");
            Console.WriteLine("");

            HttpResponseMessage msg = await client.GetAsync("api/Property");

            if (msg.IsSuccessStatusCode)
            {
                IEnumerable<Property> props = await msg.Content.ReadFromJsonAsync<IEnumerable<Property>>();
                foreach (Property p in props)
                {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Console.WriteLine("Default Get - Error: "+msg.StatusCode+msg.ReasonPhrase);
            }

        }
    }
}