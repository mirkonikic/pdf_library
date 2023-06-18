using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Server
{
    public class CommandParser
    {
        // Commands cmd;
        // mislim da treba napraviti singleton i u njega ubaciti operaciju koja treba da se izvrsi
        // command parser samo postavi vrednost u promenljivu, kasnije se proveri i izvrsi?

        public enum Commands 
        {
            help,
            start,
            stop,
            whois,      
            time,
            ban,
            kick,
            nothing
        }

        public CommandParser() 
        {
        
        }

        public string Parse(string input) 
        {
            // split input and check which operation it belongs to
            // set Commands to that operation and forward those two arguments to Execute(Commands cmd, string inp);
            Commands cmd = Commands.nothing;
            switch(input.Split(' ')[0]) 
            {
                case "/help":
                    cmd = Commands.help;
                    break;
                case "/start":
                    cmd = Commands.start;
                    break;
                case "/stop":
                    cmd = Commands.stop;
                    break;
                default:
                    cmd = Commands.nothing;
                    break;
            }
            return Execute(cmd);
        }

        public string Execute(Commands c) 
        {
            return "default";
        }
    }
}
