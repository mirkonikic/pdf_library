using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf.Server
{
    public class CommandParser
    {
        public CommandParser() 
        {
        
        }

        public void Parse(string input) 
        {
            switch(input) 
            {
                case "/help":
                    break;
                case "":
                    break;
                default:
                    break;
            }
        }
    }
}
