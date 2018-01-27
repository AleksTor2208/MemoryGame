using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace MemoryGame.Factory
{
    public class BoardFactory
    {
        public const int ImageQuantity = 14;
        private static Random rnd;

        public Card[] InitBoard()
        {
            var board = new Card[ImageQuantity];
            for (int i = 0; i < ImageQuantity; i++)
            {
                var card = Card.InitCard(i);
                board[i] = card;
            }
            return DuplicateAndRandomize(board);
        }

        private Card[] DuplicateAndRandomize(Card[] board)
        {
            var endBoardLength = board.Length * 2;
            var endBoard = Duplicate(board);
            var endBoardRndIndexes = SetIndexesRandomly(endBoardLength);
            endBoard = Randomize(endBoard, endBoardRndIndexes);
            return endBoard;
        }

        private Card[] Randomize(Card[] endBoard, int[] endBoardRndIndexes)
        {
            var randomizeDict = new Dictionary<int, Card>();
            for (int i = 0; i < endBoard.Length; i++)
            {
                randomizeDict[endBoardRndIndexes[i]] = endBoard[i]; 
            }
            var randomizeDictKeys = new List<int> ( randomizeDict.Keys );
            randomizeDictKeys.Sort();
            var endList = new Card[endBoard.Length];
            for (int i = 0; i < endBoard.Length; i++)
            {
                endList[i] = randomizeDict[randomizeDictKeys[i]];
            }
            return endList;
        }

        private Card[] Duplicate(Card[] board)
        {
            var endBoard = new List<Card>();
            const int CopiesQuantity = 2;
            for (int i = 0; i < CopiesQuantity; i++)
            {
                foreach (var card in board)
                {
                    endBoard.Add(card);
                }
            }
            return endBoard.ToArray();
        }

        private int[] SetIndexesRandomly(int BoardLength)
        {
            var indexes = Enumerable.Range(0, BoardLength).ToArray();
            for (int i = 0; i < BoardLength; i++)
            {
                var randomIndex = GetRandom().Next(0, BoardLength);
                var temp = indexes[i];
                indexes[i] = indexes[randomIndex];
                indexes[randomIndex] = temp;
            }

            //indexes.ToList().Shuffle();
            return indexes;
        }

        private void SetCardToEndBoard(Card card, Card[] endBoard)
        {
            

        }

        private Random GetRandom()
        {
            if (rnd == null) return new Random(Guid.NewGuid().GetHashCode());
            return rnd;
        }


    }
}