using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Media.Imaging;
using MemoryGame;
using Image = System.Drawing.Image;

namespace ModelLayer
{
    public class Card
    {
        //public readonly string ImageValue;
        //public readonly string ImageName;

       public string ImageValue { get; set; }
       public string ImageName { get; set; }
       public Image Image { get; set; }

      public Card(string imageName, string imageValue)
        {
            ImageName = imageName;
            ImageValue = imageValue;
        }

      // private Image ConvertToImage(string imageValue)
      // {
      //    Image image;
      //    if (imageValue != null)
      //    {
      //       var imageBytes = System.Convert.FromBase64String(imageValue);
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
         var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
         var iconPath = Path.Combine(outPutDirectory, @"..\..\..\ModelLayer\Images");
         string dir = new Uri(iconPath).LocalPath;
         string filename = Path.Combine(dir, $"image{index}.jpg");
         var bitmap = (Bitmap)System.Drawing.Image.FromFile(filename);
         byte[] imageAsByteArr = bitmap.ToByteArray(ImageFormat.Bmp);
         var base64 = Convert.ToBase64String(imageAsByteArr);
        // var imageSrc = $"data:image/gif;base64,{base64}";
         var imageSrc = base64;
         return new Card($"image{index}", imageSrc);
        }

       public override string ToString()
       {
          return ImageName;
       }
    }
}