using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using DiscordBot.Commands;

namespace DiscordBot
{
    class CommandHelper
    {
        CommandService commands;
        DiscordSocketClient client;
        IServiceProvider services;

        public CommandHelper(DiscordSocketClient client)
        {
            commands = new CommandService();
            this.client = client;

            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();

            // Manually add commands below
            commands.AddModuleAsync<Cat>();
            commands.AddModuleAsync<AsciiArt>();
            commands.AddModuleAsync<Emoticons>();
        }

        public async Task InstallCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            SocketUserMessage message = messageParam as SocketUserMessage;
            if (message == null)
                return;

            int argPos = 0;

            if (!(message.HasCharPrefix('!', ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos)))
                return;

            SocketCommandContext context = new SocketCommandContext(client, message);

            IResult result = await commands.ExecuteAsync(context, argPos, services);
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }
    }
}
