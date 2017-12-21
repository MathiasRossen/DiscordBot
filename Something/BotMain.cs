using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordBot
{
    class BotMain
    {
        DiscordSocketClient client;
        CommandHelper commandHelper;

        public async Task Run()
        {
            client = new DiscordSocketClient();
            client.Log += Log;

            commandHelper = new CommandHelper(client);
            await commandHelper.InstallCommandsAsync();

            string token = ConfigurationManager.AppSettings.Get("DiscordToken");
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
    }
}
