﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModelLayer;

namespace WpfApp1
{
   /// <summary>
   /// Логика взаимодействия для MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {

      private Card[] cards;
      
      public MainWindow()
      {
         InitializeComponent();
      }

      public MainWindow(Card[] cards)
      {
         InitializeComponent();
         this.cards = cards;
      }

      private void SinglePlayerButtonClick(object sender, RoutedEventArgs e)
      {
         //var win2 = new CardsControl(cards);
         var win2 = new BoardWindow(cards);
         win2.ShowDialog();
         this.Close();
      }
   }
}
