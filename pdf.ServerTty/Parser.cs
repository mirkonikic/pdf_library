using pdf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pdf.ServerTty
{

    public class Parser
    {
        // Commands cmd;
        // mislim da treba napraviti singleton i u njega ubaciti operaciju koja treba da se izvrsi
        // command parser samo postavi vrednost u promenljivu, kasnije se proveri i izvrsi?

        // finish full parser here

        public enum Commands { add, ban, echo, env, help, info, kick, list, msg, nothing, quit, start, stop, time, visual }
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
                case "add":
                    cmd = Commands.add;
                    break;
                case "ban":
                    cmd = Commands.ban;
                    break;
                case "echo":
                    cmd = Commands.echo;
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
                case "quit":
                    cmd = Commands.quit;
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
                //case Commands.ban: ban(s); break;
                case Commands.add: add(s); break;
                case Commands.echo: echo(s); break;
                //case Commands.env: env(s); break;
                case Commands.help: help(s); break;
                //case Commands.info: info(s); break;
                //case Commands.kick: kick(s); break;
                case Commands.list: list(s); break;
                //case Commands.msg: msg(s); break;
                //case Commands.nothing: nothing(s); break;
                case Commands.quit: quit(s); break;
                case Commands.start: start(s); break;
                case Commands.stop: stop(s); break;
                //case Commands.time: time(s); break;
                case Commands.visual: visual(s); break;
                default: break;
            }
        }

        public void add(string s) 
        {
            // create book or user
            string[] argv = s.Split(' ');
            switch (argv[1])
            {
                case "object":
                    if (argv[2] == "user")
                    {
                        Book b = new Book();

                        // get user parameters
                        // usrnm name lastname address email
                        Controller.Instance.terminal.sPrintLn("---------- BOOK CREATING PROCESS STARTED ----------");
                        
                        // not implemented since i dont know how to interract with AutorID or ZanrID..
                        //  ideja: implement ReadAuthors -> sPrintLn: choose one of the following authors or 0 to insert your own
                        //  ideja: insert first and last name for the author -> we dont have anyone named like that please insert him into the database
                        //          or we found these authors, please type in the number of the author or 0 to insert your own



                        Controller.Instance.terminal.vPrintLn($"BOOK CREATING PROCESS NOT IMPLEMENTED YET");

                        Controller.Instance.terminal.sPrintLn("---------- BOOK CREATING PROCESS ENDED__ ----------");
                        Controller.Instance.terminal.sPrintLn("");
                    }
                    else if (argv[2] == "book")
                    {
                        User u = new User();

                        // get user parameters
                        // usrnm name lastname address email
                        Controller.Instance.terminal.sPrintLn("---------- BOOK CREATING PROCESS STARTED ----------");
                        Controller.Instance.terminal.sPrintLn("");
                        Controller.Instance.terminal.sPrintLn("    Type in the username:");
                        u.UserName = Controller.Instance.terminal.ReadLn();
                        Controller.Instance.terminal.sPrintLn("    Type in the password:");
                        u.Password = Controller.Instance.terminal.ReadLn();
                        Controller.Instance.terminal.sPrintLn("    Type in the first name:");
                        u.Name = Controller.Instance.terminal.ReadLn();
                        Controller.Instance.terminal.sPrintLn("    Type in the last name:");
                        u.LastName = Controller.Instance.terminal.ReadLn();
                        Controller.Instance.terminal.sPrintLn("    Type in the email:");
                        u.Email = Controller.Instance.terminal.ReadLn();
                        Controller.Instance.terminal.sPrintLn("    Type in the address:");
                        u.Address = Controller.Instance.terminal.ReadLn();


                        bool us = Controller.Instance.broker.NapraviKorisnika(u);
                        Controller.Instance.terminal.vPrintLn($"book process creating finished well: {us}");
                        Controller.Instance.terminal.sPrintLn("---------- BOOK CREATING PROCESS ENDED__ ----------");
                        Controller.Instance.terminal.sPrintLn("");
                    }
                    else
                        Controller.Instance.terminal.ePrintLn("that object doesnt exist!");
                    break;
                default: break;
            }

        }
        public void ban(string s) { }
        public void echo(string s) 
        {

        }
        public void quit(string s) 
        {
            Environment.Exit(1);
        }
        public void env(string s) { }
        public void help(string s)
        { /*
                
                PdfLib v0.1 -> server
                    Server commands: ban, echo, quit, env, help, kick, list, msg, nothing, start, stop, time, visual
                    * use help with any of them to find out more about each one
            
            */

            // based on number of args, you can create help {COMMAND} or help {COMMAND} <option>

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
        public void list(string s) 
        {
            string[] argv = s.Split(' ');

            // list OBJECT[to_list] OPTION[about_object]
            /*
                list user [OPTION]      -> ClientHandlerList
                list object [OPTION]    -> broker.*

            eg.
                list user -a
                list user -u MIRKO
                list user -i 9
                list object -a
                list object Book -a
                list object Book -u
                list object Book -i 9 
            */

            // implement more options in list

            if(argv.Length < 2)
                return;

            switch (argv[1]) 
            { 
                case "user":
                    foreach (var i in Controller.Instance.clients) { Controller.Instance.terminal.vPrintLn($"{i.user.UserName} {i.user.Name} {i.user.LastName} {i.user.Email} {i.user.Address} isdeleted:{i.user.isDeleted} admin:{i.user.isAdmin}"); }
                    break;
                case "object":
                    if (argv[2] == "user")
                    {
                        List<User> ul = Controller.Instance.broker.UcitajKorisnike();
                        Controller.Instance.terminal.sPrintLn($"In database there is {ul.Count} {argv[2]} objects");
                        foreach (var i in ul) { Controller.Instance.terminal.vPrintLn($"{i.UserName} {i.Name} {i.LastName} {i.Email} {i.Address} isdeleted:{i.isDeleted} admin:{i.isAdmin}"); }
                    }
                    else if (argv[2] == "book")
                    {
                        // ispisi broj ili imena ili neku spec kolonu ili ime:adresa
                        List<Book> bl = Controller.Instance.broker.UcitajKnjige();
                        Controller.Instance.terminal.sPrintLn($"In database there is {bl.Count} {argv[2]} objects");
                        foreach (var i in bl) { Controller.Instance.terminal.vPrintLn($"{i.ImeKnjige} {i.BrStrana} {i.FormatKnjige.Name} {i.DatPublished}"); }
                    }
                    else
                        Controller.Instance.terminal.ePrintLn("that object doesnt exist!");
                    break;
                default: break; 
            }

            // foreach (var i in argv) { Controller.Instance.terminal.sPrintLn(i); }
        }

        private void swtich(string v)
        {
            throw new NotImplementedException();
        }

        public void msg(string s) { }
        public void nothing(string s) { }
        public void start(string s) 
        {
            int port = 9999;
            if (s.Split(' ').Length == 2)
            {
                try
                {
                    port = int.Parse(s.Split(' ')[1]);

                }
                catch(Exception ex)
                {
                    port = 9999;
                }
            }

            Controller.Instance.server.Start("127.0.0.1", port);
            Thread nit = new Thread(Controller.Instance.server.HandleClients); 
            nit.Start();
        }
        public void stop(string s) { Controller.Instance.server.Stop(); }
        public void time(string s) { }
        public void visual(string s) 
        {
            if (s.Split().Length != 2)
            {
                Controller.Instance.terminal.ePrintLn("visual: wrong format of command");
                Controller.Instance.terminal.vPrintLn($"input: {s}, should have been visual on or visual off");
                return;
            }

            if (s.Split()[1] == "on")
            {
                Controller.Instance.terminal.setDebug(true);
                Controller.Instance.terminal.sPrintLn("visual mode ON");
            }
            else if (s.Split()[1] == "off")
            {
                Controller.Instance.terminal.setDebug(false);
                Controller.Instance.terminal.sPrintLn("visual mode OFF");
            }
            else 
            {
                Controller.Instance.terminal.ePrintLn($"visual: that option doesnt exist! {s.Split()[1]}");            
            }
        }
    }
}
