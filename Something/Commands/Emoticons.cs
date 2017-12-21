using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Commands
{
    class Emoticons : ModuleBase<SocketCommandContext>
    {
        [Command("flip")]
        public async Task FlipAsync()
        {
            await ReplyAsync("(╯°□°)╯︵ ┻━┻");
        }

        [Command("unflip")]
        public async Task UnFlipAsync()
        {
            await ReplyAsync("┬─┬﻿ ノ( ゜-゜ノ)");
        }

        [Command("shrug")]
        public async Task ShrugAsync()
        {
            await ReplyAsync("¯\\_(ツ)_/¯");
        }

        [Command("donger")]
        public async Task DongerAsync()
        {
            await ReplyAsync("( ͡° ͜ʖ ͡°)");
        }
    }
}
