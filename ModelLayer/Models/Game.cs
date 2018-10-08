using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ModelLayer
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