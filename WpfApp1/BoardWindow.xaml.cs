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
   /// Interaction logic for BoardWindow.xaml
   /// </summary>
   public partial class BoardWindow : Window
   {

      public Card[] Cards { get; set; }
      public BoardWindow()
      {
         InitializeComponent();
      }

      public BoardWindow(ModelLayer.Card[] cards)
      {
         InitializeComponent();
         this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
         double occupiedScreenWidth = 0.8;
         double occupiedScreenHeight = 0.8;
         this.Width = SystemParameters.PrimaryScreenWidth * occupiedScreenWidth;
         this.Height = SystemParameters.PrimaryScreenHeight * occupiedScreenHeight;
         ImagesCollectionName.ItemsSource = cards;
         //InitializeComponent();
         //this.Title = "Game Board";
         //if (ImagesControlName == null)
         //{
         //   ImagesControlName = new CardsControl();
         //}
         //ImagesControlName.Cards = new CardsViewModel(cards);
      }
   }
}
