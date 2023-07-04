using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.ServerTty
{
    internal class Program
    {
        private static bool end = false;
        static void Main(string[] args)
        {
            /*
                Terminal server consists of:
                    Parser -> parses custom implemented language
                    Server -> does networking and stuff
                    Controller -> glues everything together
                    Handler -> Does handling of clients
                    Interface -> Sets up modular User Interface
                    Broker -> Data Base broker
                    Domain -> sets up templates of all Classes that can be used

                Main Loop -> Read -> Parser -> Controller -> Execute Command[Interface:Server:Handler:Broker:Domain]
            */
            Controller.Instance.terminal.Banner(50);
            while (!end){ Controller.Instance.parser.Parse(Controller.Instance.terminal.ReadLn()); }
        }
    }
}
