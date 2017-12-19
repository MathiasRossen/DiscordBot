using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Discord;
using Discord.WebSocket;

namespace DiscordBot
{
    class Program
    {
        DiscordSocketClient client;
        HttpClient catClient;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.Log += Log;
            client.MessageReceived += HandleMessages;

            catClient = new HttpClient();
            catClient.BaseAddress = new Uri("http://random.cat:80/");
            catClient.DefaultRequestHeaders.Accept.Clear();
            catClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string token = "";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            // Let's the program run forever just like an infinite loop
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task HandleMessages(SocketMessage message)
        {
            switch (message.Content.ToLower())
            {
                case "!ping":
                    await message.Channel.SendMessageAsync("Pong");
                    break;

                case "!cat":
                    await message.Channel.TriggerTypingAsync();
                    await message.Channel.SendMessageAsync(GetRandomCat().Result);
                    break;
            }
        }

        async Task<string> GetRandomCat()
        {
            string catUrl = "Meow";

            HttpResponseMessage response = await catClient.GetAsync("meow.php");
            if (response.IsSuccessStatusCode)
                catUrl = await response.Content.ReadAsStringAsync();

            return catUrl.Substring(9, catUrl.Length - 11).Replace("\\", string.Empty);
        }
    }
}