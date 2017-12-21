using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    class AsciiArt : ICommand
    {
        List<string> asciiCollection;

        public string Name { get; private set; }

        public AsciiArt()
            :this("asciiArt")
        {
        }

        public AsciiArt(string name)
        {
            Name = name;
            asciiCollection = new List<string>();

            asciiCollection.Add(@"```
             ---,_,----
            /    .     \
           /     |      \
          (      @@      )
          /   _/----\_   \
         /   '/      \`   \    
        /    /   .    \    \     
       /    /|        |\    \
       /   / |        | \   \
      /   /`_/_      _\_'\   \
     /  '/  (  . )( .  )  \  `\
     <_ ' `--`___'`___'--' ` _>
    /  '     @ @/ =\@ @     `  \
   /  /      @@(  , )@@      \  \
  /  /       @@| o o|@@       \  \
 ' /          @@@@@@@@          \ `
```");
        }

        public string GetAsciiArt()
        {
            Random rand = new Random();
            return asciiCollection[rand.Next(asciiCollection.Count)];
        }
    }
}
