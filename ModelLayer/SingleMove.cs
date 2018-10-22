using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
   public class SingleMove
   {
      public static Card FirstCard;
      public static Card SecondCard;
      public static bool TwoCardsSet;


      public static void SetCard(Card card)
      {
         if (FirstCard == null)
         {
            FirstCard = card;
            return;
         }
         if (SecondCard == null)
         {
            SecondCard = card;
            TwoCardsSet = true;
         }
      }

      public static bool FirstEqualsSecond()
      {
         return FirstCard.ImageName == SecondCard.ImageName;
      }

      public static void Clear()
      {
         FirstCard = null;
         SecondCard = null;
         TwoCardsSet = false;
      }
   }
}
