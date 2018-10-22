using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ModelLayer;

namespace WpfApp1
{
   /// <summary>
   /// Interaction logic for BoardWindow.xaml
   /// </summary>
   public partial class BoardWindow : Window, INotifyPropertyChanged
   {

      public Card[] Cards { get; set; }
      public BoardWindow()
      {
         InitializeComponent();
      }

      public BoardWindow(Card[] cards)
      {
         InitializeComponent();
         this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
         double occupiedScreenWidth = 0.8;
         double occupiedScreenHeight = 0.8;
         this.Width = SystemParameters.PrimaryScreenWidth * occupiedScreenWidth;
         this.Height = SystemParameters.PrimaryScreenHeight * occupiedScreenHeight;
         //ImagesCollectionName.ItemsSource = cards;
         this.DataContext = cards;
      }

      private void ImageButton_Click(object sender, RoutedEventArgs e)
      {
         var contxt = (sender as Button)?.Content;
         var data = (contxt as Image)?.DataContext;
         var card = (data as Card);
         if (card == null) return;
         var cardsList = new List<Card>();
         foreach (var currentCard in ImagesCollectionName.ItemsSource)
         {
            cardsList.Add(currentCard as Card);
         }
         var tempCard = cardsList.FirstOrDefault(c => c.ImageName.Equals(card.ImageName) 
                                          && c.CardType.Equals(card.CardType));
         if (tempCard.Inverted == true) return;
         SingleMove.SetCard(tempCard);
         tempCard.Inverted = true;
         tempCard.RefreshImgValue();
         System.Threading.Thread.Sleep(30);
         if (SingleMove.TwoCardsSet)
         {
               cardsList.Where(c => c.ImageName == SingleMove.FirstCard.ImageName || c.ImageName == SingleMove.SecondCard.ImageName)
                        .ToList()
                        .ForEach(c => 
                        {
                           c.Inverted = SingleMove.FirstEqualsSecond();
                           c.RefreshImgValue();
                        });
               SingleMove.Clear();
         }
      }

      private void SetImage(Image image)
      {
         if (image == null)
            return;
         var card = image.DataContext as Card;
         image.BeginInit();
         image.Source = Base64StringToBitmap(card.ImgValue);
         image.EndInit();
      }

      public static ImageSource Base64StringToBitmap(string base64String)
      {
         byte[] binaryData = Convert.FromBase64String(base64String);

         BitmapImage bi = new BitmapImage();
         bi.BeginInit();
         bi.StreamSource = new MemoryStream(binaryData);
         bi.EndInit();
         return bi;
      }

      public event PropertyChangedEventHandler PropertyChanged;

      private void OnPropertyChanged(string propertyName)
      {
         var handler = PropertyChanged;
         if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
