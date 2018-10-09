using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using ModelLayer;
using WpfApp1;


namespace MemoryGameBL
{
   public class Game
   {
      public Card[] Board;

      public void InitGame()
      {
         var board = new BoardFactory();
         Board = board.InitBoard();
      }

      public Card[] GetData()
      {
         return new BoardFactory().InitBoard();
      }

      public void Start()
      {
        
      }
   }
}