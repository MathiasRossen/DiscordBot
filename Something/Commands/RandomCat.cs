using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DiscordBot.Commands
{
    class RandomCat : ICommand
    {
        HttpClient client;

        public string Name { get; private set; }

        public RandomCat(string name)
        {
            Name = name;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://random.cat:80/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public RandomCat()
            : this("cat")
        {
        }

        public async Task<string> GetRandomCat()
        {
            string catUrl = "Meow";

            HttpResponseMessage response = await client.GetAsync("meow.php");
            if (response.IsSuccessStatusCode)
                catUrl = await response.Content.ReadAsStringAsync();

            return catUrl.Substring(9, catUrl.Length - 11).Replace("\\", string.Empty);
        }
    }
}
