using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiscordBot.Commands
{
    class AsciiArt : ICommand
    {
        List<string> asciiCollection;

        public string Name { get; private set; }

        public AsciiArt()
            : this("asciiArt")
        {
        }

        public AsciiArt(string name)
        {
            Name = name;
            asciiCollection = new List<string>();
            BuildCollection();
        }

        public string GetAsciiArt()
        {
            Random rand = new Random();
            return asciiCollection[rand.Next(asciiCollection.Count)];
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
