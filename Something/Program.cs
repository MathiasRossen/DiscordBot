using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            BotMain bot = new BotMain();
            bot.Run().GetAwaiter().GetResult();
        }
    }
}