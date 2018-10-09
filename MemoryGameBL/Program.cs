using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1;

namespace MemoryGameBL
{
   class Program
   {
      [STAThread]
      static void Main(string[] args)
      {
         var cards = new Game().GetData();
         //StartWindow win = new StartWindow(cards);
         //win.Show();
         var application = new System.Windows.Application();
         application.Run(new StartWindow(cards));
      }
   }
}
