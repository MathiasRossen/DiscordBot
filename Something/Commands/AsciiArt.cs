using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.IO;

namespace DiscordBot.Commands
{
    class AsciiArt : ModuleBase<SocketCommandContext>
    {
        List<string> asciiCollection;

        public AsciiArt()
        {
            asciiCollection = new List<string>();
            BuildCollection();
        }

        [Command("ascii")]
        public async Task AsciiAsync()
        {
            Random rand = new Random();
            await ReplyAsync(asciiCollection[rand.Next(asciiCollection.Count)]);
        }

        private void BuildCollection()
        {
            foreach (string file in Directory.GetFiles("../../Files/Ascii"))
            {
                asciiCollection.Add(GetArtFromFile(file));
            }
        }

        private string GetArtFromFile(string file)
        {
            string asciiBuilder = "```\n";
            using (StreamReader sr = new StreamReader(file))
            {
                asciiBuilder += sr.ReadToEnd();
            }
            asciiBuilder += "\n```";

            return asciiBuilder;
        }
    }
}
