using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pdf.ServerTty
{
    public class Terminal
    {
        // terminal properties
        private bool DEBUG = false;
        private string[] terminal_prompt = { "server> ", "root_0> ", "visual> ", "error_>" };  // {response_prompt, user_prompt, debug_prompt}

        //banner encoded to base64
        private string banner = "ICAgX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fXwogIHxfX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19ffAogIHwgX18gICAgIF9fICAgX19fXyAgIF9fXyB8fCAgX19fXyAgICBfX19fICAgICBfICBfXyAgfAogIHx8ICB8X18gfC0tfF98IHx8IHxffCAgIHx8fF98Kip8KnxfX3wrfCt8fF9fX3wgfHwgIHwgfAogIHx8PT18Xl58fC0tfCB8PXx8PXwgfD0qPXx8fCB8fn58fnwgIHw9fD18fCB8IHx+fHw9PXwgfAogIHx8ICB8IyN8fCAgfCB8IHx8IHwgfEpST3x8fC18ICB8IHw9PXwrfCt8fC18LXx+fHxfX3wgfAogIHx8X198X198fF9ffF98X3x8X3xffF9fX3x8fF98X198X3xfX3xffF98fF98X3xffHxfX3xffAogIHx8X19fX19fX19fX19fX19fX19fX19fX198fF9fX19fX19fX19fX19fX19fX19fX19fX19ffAogIHwgX19fX19fX19fX19fX19fX19fX19fICB8fCAgICAgIF9fICAgX18gIF8gIF9fICAgIF8gfAogIHx8PXw9fD18PXw9fD18PXw9fD18PXw9fCBfXy4uXC8gfCAgfF98ICB8fCN8fD09fCAgLyAvfAogIHx8IHwgfCB8IHwgfCB8IHwgfCB8IHwgfC9cIFwgIFx8Kyt8PXwgIHx8IHx8PT18IC8gLyB8CiAgfHxffF98X3xffF98X3xffF98X3xffF8vXy9cXy5fX19cX198X3xfX3x8X3x8X198L18vX198CiAgfF9fX19fX19fX19fX19fX19fX19fIC9cfigpLygpfi8vXCBfX19fX19fX19fX19fX19fX198CiAgfCBfXyAgIF9fICAgIF8gIF8gICAgIFxfICAoXyAuICBfLyBfICAgIF9fXyAgICAgX19fX198CiAgfHx+fnxffC4ufF9ffCB8fCB8XyBfICAgXCAvL1wgLyAgfD18X198fnx+fF9fX3wgfCB8IHwKICB8fC0tfCt8Xl58PT18MXx8MnwgfCB8X18vXCBfXyAvXF9ffCB8PT18eHx4fCt8K3w9fD18PXwKICB8fF9ffF98X198X198X3x8X3xffCAvICBcIFwgIC8gLyAgXF98X198X3xffF98X3xffF98X3wKICB8X19fX19fX19fX19fX19fX18gXy8gICAgXC9cL1wvICAgIFxfIF9fX19fX19fX19fX19fX3wKICB8IF9fX19fICAgXyAgIF9fICB8LyAgICAgIFwuLi8gICAgICBcfCAgX18gICBfXyAgIF9fX3wKICB8fF9fX19ffF98IHxffCMjfF98fCAgIHwgICBcLyBfX3wgICB8fF98PT18X3wrK3xffC18fHwKICB8fF9fX19fX3x8PXwjfC0tfCB8XCAgIFwgICBvICAgIC8gICAvfCB8ICB8fnwgIHwgfCB8fHwKICB8fF9fX19fX3x8X3xffF9ffF98X1wgICBcICBvICAgLyAgIC9ffF98X198X3xfX3xffF98fHwKICB8X19fX19fX19fIF9fX19fX19fX19cX19fXF9fX18vX19fL19fX19fX19fX19fIF9fX19fX3wKICB8X18gICAgXyAgLyAgICBfX19fX19fXyAgICAgX19fX19fICAgICAgICAgICAvfCBfIF8gX3wKICB8XCBcICB8PXwvICAgLy8gICAgL3wgLy8gICAvICAvICAvIHwgICAgICAgIC8gfHwlfCV8JXwKICB8IFwvXCB8Ki8gIC4vL19fX18vLy4vLyAgIC9fXy9fXy8gKF8pICAgICAgLyAgfHw9fD18PXwKX198ICBcL1x8LyAgIC8oX19fX3wvIC8vICAgICAgICAgICAgICAgICAgICAvICAvfHx+fH58fnwKICB8X19fXF8vICAgL19fX19fX19fLy8gICBfX19fX19fXyAgICAgICAgIC8gIC8gfHxffF98X3wKICB8X19fIC8gICAofF9fX19fX19fLyAgIHxcX19fX19fX1wgICAgICAgLyAgL3wgfF9fX19fX3wgICAgICAgICAgIFBERiBMaWIgdjAuMSAKICAgICAgLyAgICAgICAgICAgICAgICAgIFx8X19fX19fX18pICAgICAvICAvIHwgfCAgICAgICAgICAgICAgICAgICAgICAgICBieSBNaXJrbw==";

        public Terminal(Int32 x = 125, Int32 y = 33, bool dbg = false) { Console.SetWindowSize(x, y); setColor(15, 0); DEBUG = dbg; }
        public void Banner(int i) { foreach (var line in (System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(banner)).Split('\n'))) { Console.WriteLine(line); Thread.Sleep(i); } }
        public void PrintLn(string s) => Console.WriteLine(s);
        public void vPrintLn(string s) 
        {
            if (DEBUG == false)
                return;
            setColor(11, 0); Console.Write(terminal_prompt[2]); setColor(15, 0); Console.WriteLine(s); 
        }
        public void sPrintLn(string s)
        { setColor(14, 0); Console.Write(terminal_prompt[0]); setColor(15, 0); Console.WriteLine(s); }
        public void tPrintLn(string s, int i) 
        { Thread.Sleep(i); setColor(14, 0); Console.Write(terminal_prompt[0]); setColor(15, 0); Console.WriteLine(s); }
        public void ePrintLn(string s)
        { setColor(15, 12); Console.Write(terminal_prompt[3]); setColor(15, 0); Console.WriteLine(" " + s); }
        public string ReadLn() 
        { setColor(12, 0); Console.Write(terminal_prompt[1]); setColor(15, 0); return Console.ReadLine(); }
        public void setColor(int fg, int bg)
        { Console.ForegroundColor = (ConsoleColor)fg;  Console.BackgroundColor = (ConsoleColor)bg; }
        public void setDebug(bool dbg) { DEBUG = dbg; }
    }
}
