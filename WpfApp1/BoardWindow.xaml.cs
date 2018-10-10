using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
   public partial class BoardWindow : Window, INotifyPropertyChanged
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

      private void ImageButton_Click(object sender, RoutedEventArgs e)
      {
         var contxt = (sender as Button)?.Content;
         var data = (contxt as Image)?.DataContext;
         var card = (data as Card);
         if (card != null) card.Inverted = true;
         //(contxt as Image).BeginInit();
         SetImage(contxt as Image);

         //data.Inverted = true
         //this.MyImageSource = new BitmapImage(...); //you change source of the Image
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

         //Image img = new Image();
         //img.Source = bi;
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
