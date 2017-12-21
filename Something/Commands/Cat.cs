using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DiscordBot.Commands
{
    class Cat : ModuleBase<SocketCommandContext>
    {
        HttpClient client;

        public Cat()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://random.cat:80/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Command("cat")]
        public async Task CatAsync()
        {
            string catUrl = "Meow";

            HttpResponseMessage response = await client.GetAsync("meow.php");
            if (response.IsSuccessStatusCode)
                catUrl = await response.Content.ReadAsStringAsync();

            await ReplyAsync(catUrl.Substring(9, catUrl.Length - 11).Replace("\\", string.Empty));
        }
    }
}
