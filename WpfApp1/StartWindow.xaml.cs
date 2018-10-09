using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ModelLayer;

namespace WpfApp1
{
   /// <summary>
   /// Interaction logic for StartWindow.xaml
   /// </summary>
   public partial class StartWindow : Window
   {
     
      private Card[] cards;

      public StartWindow()
      {
         //InitializeComponent();
      }

      public StartWindow(Card[] cards)
      {
         InitializeComponent();
         this.cards = cards;
      }

      private void SinglePlayerButtonClick(object sender, RoutedEventArgs e)
      {
         //var win2 = new CardsControl(cards);
         var win2 = new BoardWindow(cards);
         this.Close();
         win2.ShowDialog();
         
      }
   }
}
