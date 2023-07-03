using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.ServerTty
{

    public class Parser
    {
        // Commands cmd;
        // mislim da treba napraviti singleton i u njega ubaciti operaciju koja treba da se izvrsi
        // command parser samo postavi vrednost u promenljivu, kasnije se proveri i izvrsi?

        // finish full parser here

        public enum Commands
        {
            help,
            echo,
            start,
            stop,
            end,
            time,
            whois,
            list,
            kick,
            ban,
            msg,
            nothing
        }

        public Parser()
        {

        }

        public void Parse(string input)
        {
            // split input and check which operation it belongs to
            // set Commands to that operation and forward those two arguments to Execute(Commands cmd, string inp);
            Commands cmd = Commands.nothing;
            switch (input.Split(' ')[0])
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
            Execute(cmd, input);
        }

        public void Execute(Commands c, string s)
        {
            if (Controller.Instance.server.isNull() == null)
            {
                Controller.Instance.terminal.PrintLn("Server is not running!");
                return;
            }
            switch (c)
            {
                case Commands.help: help(); break;
                case Commands.start: start(); break;
                case Commands.stop: stop(); break;
                case Commands.whois: whois(); break;
                case Commands.time: time(); break;
                case Commands.ban: ban(); break;
                case Commands.kick: kick(); break;
                case Commands.nothing: none(s); break;
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
            Controller.Instance.terminal.PrintLn("");
            Controller.Instance.terminal.PrintLn("\tPdfLib v0.1 -> server");
            Controller.Instance.terminal.PrintLn("\t\thelp   -   prints out this message");
            Controller.Instance.terminal.PrintLn("\t\twhois  -   prints out logged in clients with info");
            Controller.Instance.terminal.PrintLn("\t\ttime   -   prints out time statistics");
            Controller.Instance.terminal.PrintLn("\t\tban    -   bans user IP from logging in and deletes account");
            Controller.Instance.terminal.PrintLn("\t\tkick   -   kicks user from the network");
            Controller.Instance.terminal.PrintLn("");
            Controller.Instance.terminal.PrintLn("-----------------------------------------------------------------");
        }
        public void whois()
        {
            Controller.Instance.terminal.PrintLn("");
            Controller.Instance.terminal.PrintLn("WHOIS ONLINE:");
            for (int i = 0; i < Controller.Instance.clients.Count; i++)
            {
                Controller.Instance.terminal.PrintLn (Controller.Instance.clients[i].ToString());
            }
            Controller.Instance.terminal.PrintLn("");
            Controller.Instance.terminal.PrintLn("-----------------------------------------------------------------");
        }
        public void start() { }
        public void stop() { }
        public void time() { }
        public void ban() { }
        public void kick() { }
        public void none(string s)
        {
            Controller.Instance.terminal.PrintLn("");
            Controller.Instance.terminal.PrintLn(s);
        }
    }
}
