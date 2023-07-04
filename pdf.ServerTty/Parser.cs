using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public enum Commands { ban, echo, quit, env, help, info, kick, list, msg, nothing, start, stop, time, visual }
        public enum Tokens { command, option, numeric, alphabet, alphanumeric, semicolon, colon, pipe, equal, two_exclamation_marks, env_var }

        public Parser() { }

        #region cmd_lang_implementation
        // Simple Language For Command Parsing On Server Side -> SLFCPOSS
        // da bih olaksao sebi, svaki token je odvojen space-om -> help env ; echo mirko $n
        public void Run(string input) 
        {
            Executor(SemanticAnalyzer(SyntaxAnalyzer(Lexer(input))));
        }

        // Lexical Analysis -> separate text by spaces, than sort each element with regex into list of tokens, return the list to Parser
        private Tokens[] Lexer(string input) 
        { return null; }

        // Syntax Analysis -> create a parse tree here and pass it to Semantic Analyzer
        private Tokens[] SyntaxAnalyzer(Tokens[] tokens)
        { return null; }

        // Semantic Analysis -> type checking etc.
        private Tokens[] SemanticAnalyzer(Tokens[] tokens) 
        { return null; }

        // Code Generation -> Interpret the AST, no need to generate code here
        private void Executor(Tokens[] tokens)
        {  }
        #endregion

        // Current simple parser
        public void Parse(string input)
        {
            // split input and check which operation it belongs to
            // set Commands to that operation and forward those two arguments to Execute(Commands cmd, string inp);

            // ban, echo, quit, env, help, kick, list, msg, nothing, start, stop, time, visual
            Commands cmd = Commands.nothing;
            switch (input.Split(' ')[0])
            {
                case "ban":
                    cmd = Commands.ban;
                    break;
                case "echo":
                    cmd = Commands.echo;
                    break;
                case "quit":
                    cmd = Commands.quit;
                    break;
                case "env":
                    cmd = Commands.env;
                    break;
                case "help":
                    cmd = Commands.help;
                    break;
                case "info":
                    cmd = Commands.info;
                    break;
                case "kick":
                    cmd = Commands.kick;
                    break;
                case "list":
                    cmd = Commands.list;
                    break;
                case "msg":
                    cmd = Commands.msg;
                    break;
                case "nothing":
                    cmd = Commands.nothing;
                    break;
                case "start":
                    cmd = Commands.start;
                    break;
                case "stop":
                    cmd = Commands.stop;
                    break;
                case "time":
                    cmd = Commands.time;
                    break;
                case "visual":
                    cmd = Commands.visual;
                    break;
                default:
                    cmd = Commands.nothing;
                    break;
            }
            Execute(cmd, input);
        }

        public void Execute(Commands c, string s)
        {
            if (Controller.Instance.server.isNull() == true && (c != Commands.start && c != Commands.help && c != Commands.help && c != Commands.visual && c != Commands.quit))
            {
                Controller.Instance.terminal.PrintLn("Server is not running!");
                return;
            }
            switch (c)
            {
                case Commands.ban: ban(s); break;
                case Commands.echo: echo(s); break;
                case Commands.quit: quit(s); break;
                case Commands.env: env(s); break;
                case Commands.help: help(s); break;
                case Commands.info: info(s); break;
                case Commands.kick: kick(s); break;
                case Commands.list: list(s); break;
                case Commands.msg: msg(s); break;
                case Commands.nothing: nothing(s); break;
                case Commands.start: start(s); break;
                case Commands.stop: stop(s); break;
                case Commands.time: time(s); break;
                case Commands.visual: visual(s); break;
                default: break;
            }
        }

        public void ban(string s) { }
        public void echo(string s) { }
        public void quit(string s) { }
        public void env(string s) { }
        public void help(string s)
        { /*
                
                PdfLib v0.1 -> server
                    Server commands: ban, echo, quit, env, help, kick, list, msg, nothing, start, stop, time, visual
                    * use help with any of them to find out more about each one
            
            */
            Controller.Instance.terminal.tPrintLn("", 10);
            Controller.Instance.terminal.tPrintLn("\tPdfLib v0.1 -> server", 10);
            Controller.Instance.terminal.tPrintLn("\t\tServer commands: ban, echo, quit, env, help, kick, list, msg, nothing, start, stop, time, visual", 10);
            Controller.Instance.terminal.tPrintLn("\t\t* commands are used like: CMD <TARGET> [-OPTION]", 10);
            Controller.Instance.terminal.tPrintLn("\t\t* use help with any of them to find out more about each one", 10);
            Controller.Instance.terminal.tPrintLn("", 10);
            Controller.Instance.terminal.tPrintLn("-----------------------------------------------------------------", 10);
        }
        public void info(string s) { }
        public void kick(string s) { }
        public void list(string s) { }
        public void msg(string s) { }
        public void nothing(string s) { }
        public void start(string s) 
        {
            Controller.Instance.server.Start("127.0.0.1", 9999); }
        public void stop(string s) { Controller.Instance.server.Stop(); }
        public void time(string s) { }
        public void visual(string s) { }

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
    }
}
