using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Media.Imaging;
using MemoryGame;
using Image = System.Drawing.Image;

namespace ModelLayer
{
   public class Card : INotifyPropertyChanged
   {
      //public readonly string ImgSource;
      //public readonly string ImageName;

      private string _imgSource;

      private string _imgValue;

      public string ImgValue
      {
         get { return _imgValue; }
         set
         {
            SetImageValue(value);
            OnPropertyChanged("ImgValue");
         }
      }

      private void SetImageValue(string value)
      {
         switch (Inverted)
         {
            case (true): _imgValue = _imgSource;
               break;
            case (false): _imgValue = Card.GetBackSideImage();
               break;
         }
      }

      public string ImageName { get; set; }

      private bool _inverted;

      public bool Inverted
      {
         get { return _inverted;}
         set
         {
            _inverted = value;
            if (_inverted == true)
            {
               ImgValue = _imgSource;
            }
            OnPropertyChanged("Inverted");
         }
      }

      private static string backSideImageSrc;


      public static string GetBackSideImage()
      {
         if (backSideImageSrc != null)
         {
            return backSideImageSrc;
         }
         string dir = GetImagePath(@"..\..\..\ModelLayer\Images\cardBackSideImage");
         string filename = Path.Combine(dir, $"Triplicate_back2.jpg");
         var bitmap = (Bitmap)System.Drawing.Image.FromFile(filename);
         byte[] imageAsByteArr = bitmap.ToByteArray(ImageFormat.Bmp);
         backSideImageSrc = Convert.ToBase64String(imageAsByteArr);
         return backSideImageSrc;
      }

      public Card(string imageName, string imgSource)
      {
         ImageName = imageName;
         _imgSource = imgSource;
         Inverted = false;
      }

      // private Image ConvertToImage(string imgSource)
      // {
      //    Image image;
      //    if (imgSource != null)
      //    {
      //       var imageBytes = System.Convert.FromBase64String(imgSource);
      //       using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
      //       {
      //          image = Image.FromStream(ms, true);
      //          return image;
      //       }
      //    }

      //    if (Image != null)
      //    {
      //    Bitmap bmp;
      //    using (var ms = new MemoryStream())
      //    {
      //       bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
      //       ms.Position = 0;

      //       var bi = new BitmapImage();
      //       bi.BeginInit();
      //       bi.CacheOption = BitmapCacheOption.OnLoad;
      //       bi.StreamSource = ms;
      //       bi.EndInit();
      //    }
      //   }

      //    image.Source = bi;
      //}

      public static Card InitCard(int index)
      {
         string dir = GetImagePath(@"..\..\..\ModelLayer\Images");
         string filename = Path.Combine(dir, $"image{index}.jpg");
         var bitmap = (Bitmap)System.Drawing.Image.FromFile(filename);
         byte[] imageAsByteArr = bitmap.ToByteArray(ImageFormat.Bmp);
         var base64 = Convert.ToBase64String(imageAsByteArr);
         // var imageSrc = $"data:image/gif;base64,{base64}";
         var imageSrc = base64;
         return new Card($"image{index}", imageSrc);
      }

      private static string GetImagePath(string relativePath)
      {
         var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
         var iconPath = Path.Combine(outPutDirectory, relativePath);
         return new Uri(iconPath).LocalPath;
      }


      public override string ToString()
      {
         return ImageName;
      }

      public event PropertyChangedEventHandler PropertyChanged;

      private void OnPropertyChanged(string propertyName)
      {
         var handler = PropertyChanged;
         if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}