using System;
using System.Windows;
using System.Windows.Controls;
using ModelLayer;

namespace WpfApp1
{
   /// <summary>
   /// Interaction logic for CardsControl.xaml
   /// </summary>
   public partial class CardsControl : UserControl
   {

      //public CardsControl()
      //{
      //   InitializeComponent();
      //}

      public CardsControl(/*Card[] cards*/)
      {
         InitializeComponent();
         this.innerWindow = new System.Windows.Window();
         this.innerWindow.Title = "Game Board";
      }

      public CardsViewModel Cards
      {
         get { return (CardsViewModel)GetValue(CardsProperty); }
         set
         {
            SetValue(CardsProperty, value);
            SetImagesList(value);
         }
      }

      private void SetImagesList(CardsViewModel value)
      {
        //ImagesList.ItemsSource = value.Model;
         //foreach (var card in Cards)
         //{
         //   ImagesList.Items.Add(new ListViewItem()
         //   {
         //      Content = card.ImageName
         //   });
         //}
      }

      // Using a DependencyProperty as the backing store for CaCards.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty CardsProperty =
          DependencyProperty.Register(nameof(Cards), typeof(CardsViewModel), typeof(CardsControl)/*, new PropertyMetadata(0)*/);



      internal bool? ShowDialog()
      {
         return innerWindow.ShowDialog();
      }
      private System.Windows.Window innerWindow;
   }
}
