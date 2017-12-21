using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Commands;

namespace DiscordBot
{
    class CommandHelper
    {
        List<ICommand> commandCollection;

        public CommandHelper()
        {
            commandCollection = new List<ICommand>
            {
                new RandomCat(),
                new AsciiArt()
            };
        }

        public RandomCat GetRandomCatCommand()
        {
            return commandCollection.Find(x => x.Name == "cat") as RandomCat;
        }

        public AsciiArt GetAsciiArtCommand()
        {
            return commandCollection.Find(x => x.Name == "asciiArt") as AsciiArt;
        }
    }
}
