using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game
{
    /// <summary>
    /// Класс руки
    /// </summary>
    public class Hand
    {
        public List<Card> cards { get; private set; }
        public int Point
        {
            get
            {
                int x = 0;
                foreach (Card i in cards)
                {
                    x += i.Cost;
                }
                return x;
            }
            private set { }
        }

        public Hand()
        {
            Point = 0;
            cards = new List<Card>();
        }
        /// <summary>
        /// Добавить карту в руку
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public void ClearPoint()
        {
            Point = 0;
        }
    }
}
