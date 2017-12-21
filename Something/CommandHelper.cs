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
            commandCollection = new List<ICommand>();
            commandCollection.Add(new RandomCat());
        }

        public RandomCat GetRandomCatCommand()
        {
            return commandCollection.Find(x => x.Name == "cat") as RandomCat;
        }
    }
}
