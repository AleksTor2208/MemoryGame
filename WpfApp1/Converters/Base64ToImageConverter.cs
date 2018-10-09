using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfApp1.Converters
{
   [ValueConversion(typeof(Image), typeof(BitmapSource))]
   class Base64ToImageConverter : IValueConverter
   {
      [DllImport("gdi32.dll")]
      [return: MarshalAs(UnmanagedType.Bool)]
      internal static extern bool DeleteObject(IntPtr value);

      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         string base64Value = value?.ToString();
         if (base64Value == null)
         {
            return null;
         }
         Image myImage = ConvertToImage(base64Value);
         var bitmap = new Bitmap(myImage);
         IntPtr bmpPt = bitmap.GetHbitmap();
         BitmapSource bitmapSource =
            System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
               bmpPt,
               IntPtr.Zero,
               Int32Rect.Empty,
               BitmapSizeOptions.FromEmptyOptions());

         //freeze bitmapSource and clear memory to avoid memory leaks
         bitmapSource.Freeze();
         DeleteObject(bmpPt);

         return bitmapSource;
      }

      private Image ConvertToImage(string imageValue)
      {
         Image image;
         if (imageValue != null)
         {
            var imageBytes = System.Convert.FromBase64String(imageValue);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
               image = Image.FromStream(ms, true);
               return image;
            }
         }

         return null;
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return null;
      }
   }
}
