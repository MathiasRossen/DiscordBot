using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiTest
{
    class Program
    {
        HttpClient client;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        void Run()
        {
            client = new HttpClient();
            RunAsync().GetAwaiter().GetResult();
        }

        async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://random.cat:80/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = await client.GetAsync("meow.php");
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            //Console.WriteLine(response);
            Console.WriteLine(await GetRandomCat());

            Console.ReadLine();
        }

        async Task<string> GetRandomCat()
        {
            string catUrl = "Nothing";
            HttpResponseMessage response = await client.GetAsync("meow.php");
            if (response.IsSuccessStatusCode)
                catUrl = await response.Content.ReadAsStringAsync();

            return catUrl;
        }
    }
}
