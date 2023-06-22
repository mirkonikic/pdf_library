using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
            whois,      
            time,
            ban,
            kick,
            nothing
        }

        public CommandParser() 
        {
        
        }

        public void Parse(string input) 
        {
            // split input and check which operation it belongs to
            // set Commands to that operation and forward those two arguments to Execute(Commands cmd, string inp);
            Commands cmd = Commands.nothing;
            switch(input.Split(' ')[0]) 
            {
                case "help":
                case "?":
                    cmd = Commands.help;
                    break;
                case "start": break;
                case "stop": break;
                case "whois":
                    cmd = Commands.whois;
                    break;
                case "time":
                    cmd = Commands.time;
                    break;
                case "ban":
                    cmd = Commands.ban;
                    break;
                case "kick":
                    cmd = Commands.kick;
                    break;
                default:
                    cmd = Commands.nothing;
                    break;
            }
            Execute(cmd);
        }

        public void Execute(Commands c)
        {
            if (Controller.Instance.server.serverSocket == null) 
            {
                Controller.Instance.PrintOnTerminal("Server is not running!");
                return;
            }
            switch (c)
            {
                case Commands.help: help(); break;
                //case Commands.start: start(); break;
                //case Commands.stop: stop(); break;
                case Commands.whois: whois(); break;
                case Commands.time: time(); break;
                case Commands.ban: ban(); break;
                case Commands.kick: kick(); break;
                case Commands.nothing: none(); break;
                default: break;
            }
        }

        public void help() 
        {
            /*
                
                PdfLib v0.1 -> server
                    /help   -   prints out this message
                    /start  -   starts the server
                    /stop   -   stops the server
                    /whois  -   prints out logged in clients with info
                    /time   -   prints out time statistics
                    /ban    -   bans user IP from logging in and deletes account
                    /kick   -   kicks user from the network
            
            */
            Controller.Instance.PrintOnTerminal("");
            Controller.Instance.PrintOnTerminal("\tPdfLib v0.1 -> server");
            Controller.Instance.PrintOnTerminal("\t\thelp   -   prints out this message");
            Controller.Instance.PrintOnTerminal("\t\twhois  -   prints out logged in clients with info");
            Controller.Instance.PrintOnTerminal("\t\ttime   -   prints out time statistics");
            Controller.Instance.PrintOnTerminal("\t\tban    -   bans user IP from logging in and deletes account");
            Controller.Instance.PrintOnTerminal("\t\tkick   -   kicks user from the network");
            Controller.Instance.PrintOnTerminal("");
            Controller.Instance.PrintOnTerminal("-----------------------------------------------------------------");
        }
        public void whois() 
        {
            Controller.Instance.PrintOnTerminal("");
            Controller.Instance.PrintOnTerminal("WHOIS ONLINE:");
            for (int i = 0; i < Controller.Instance.clients.Count; i++) 
            {
                Controller.Instance.PrintOnTerminal(Controller.Instance.clients[i].ToString());
            }
            Controller.Instance.PrintOnTerminal("");
            Controller.Instance.PrintOnTerminal("-----------------------------------------------------------------");
        }
        public void time() { }
        public void ban() { }
        public void kick() { }
        public void none() { }

    }
}
