﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MemoryGame.Factory
{
    public class Card
    {
        public readonly string ImageValue;
        public readonly string ImageName;

        public Card(string imageName, string imageValue)
        {
            ImageName = imageName;
            ImageValue = imageValue;
        }

        public static Card InitCard(int index)
        {
            string dir = @"C:\Users\aleks\source\repos\MemoryGame\MemoryGame\Content\Images";
            string filename = Path.Combine(dir, $"image{index}.jpg");
            Bitmap bitmap = (Bitmap)Image.FromFile(filename);
            byte[] imageAsByteArr = bitmap.ToByteArray(ImageFormat.Bmp);
            var base64 = Convert.ToBase64String(imageAsByteArr);
            var imageSrc = $"data:image/gif;base64,{base64}";
            return new Card($"image{index}", imageSrc);
        }
    }
}