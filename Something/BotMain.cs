using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordBot.Commands;

namespace DiscordBot
{
    class BotMain
    {
        DiscordSocketClient client;
        CommandHelper commandHelper;

        public BotMain()
        {
            commandHelper = new CommandHelper();
        }

        public async Task Run()
        {
            client = new DiscordSocketClient();
            client.Log += Log;
            client.MessageReceived += HandleMessages;

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

        private async Task HandleMessages(SocketMessage message)
        {
            switch (message.Content.ToLower())
            {
                case "!ping":
                    await message.Channel.TriggerTypingAsync();
                    await message.Channel.SendMessageAsync("Pong");
                    break;

                case "!cat":
                    await message.Channel.TriggerTypingAsync();
                    await message.Channel.SendMessageAsync(await commandHelper.GetRandomCatCommand().GetRandomCat());
                    break;

                case "!ascii":
                    await message.Channel.TriggerTypingAsync();
                    await message.Channel.SendMessageAsync(commandHelper.GetAsciiArtCommand().GetAsciiArt());
                    break;
            }
        }
    }
}
