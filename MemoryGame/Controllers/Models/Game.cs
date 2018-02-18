using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemoryGame.Factory;

namespace MemoryGame.Models
{
    public class Game
    {
        public Card[] Board;

        public void InitGame()
        {
            var board = new BoardFactory();
            Board = board.InitBoard();
        }
    }
}