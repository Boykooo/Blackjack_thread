using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Exceptions;

namespace View.Game
{
    /// <summary>
    /// Класс колоды
    /// </summary>
    public class Deck
    {
        private Stack<Card> currentDeck;
        private Card[] mainDeck;

        public Deck()
        {
            mainDeck = new Card[52];
            currentDeck = new Stack<Card>();
            FillMainDeck();
            RandomDeck();
        }
        /// <summary>
        /// Перемешивает колоду
        /// </summary>
        public void RandomDeck()
        {
            Random r = new Random();
            for (int i = mainDeck.Length - 1; i > 0; i--)
            {
                int j = r.Next(i);
                var t = mainDeck[i];
                mainDeck[i] = mainDeck[j];
                mainDeck[j] = t;
            }
            for (int i = 0; i < mainDeck.Length; i++)
            {
                currentDeck.Push(mainDeck[i]);
            }
        }

        /// <summary>
        /// Заполнение основной колоды
        /// </summary>
        private void FillMainDeck()
        {
            Lear[] lear = new Lear[] { Lear.Club, Lear.Diamond, Lear.Heart, Lear.Spade };

            for (int i = 0, j = 0; i < 52; i += 13, j++)
            {
                AddLearToDeck(i, lear[j]);
            }
        }
        /// <summary>
        /// Добавление колоду карт определенного индекса и определенной масти
        /// </summary>
        /// <param name="start"> Индекс добавления карт </param>
        /// <param name="lear"> Масть карт </param>
        private void AddLearToDeck(int start, Lear lear)
        {
            try
            {
                for (int i = start, j = 2; i < start + 9; i++, j++)
                {
                    mainDeck[i] = new Card(lear, j.ToString(), j, Image.FromFile(@"Images\Cards\" + lear.ToString() + j.ToString() + ".jpg"));
                }

                AddCardWithPicture(lear, start + 9, "Jack");
                AddCardWithPicture(lear, start + 10, "Dame");
                AddCardWithPicture(lear, start + 11, "King");
                mainDeck[start + 12] = new Card(lear, "Ace", 11, Image.FromFile(@"Images\Cards\" + lear.ToString() + "Ace.jpg"));
            }
            catch
            {
                throw new DataLoadException();
            }
        }
        /// <summary>
        /// Добавление карт с картинками в основную колоду
        /// </summary>
        /// <param name="lear"> Масть карт </param>
        /// <param name="i"> Индекс добавления карт </param>
        /// <param name="name"> Имя карты </param>
        private void AddCardWithPicture(Lear lear, int i, string name)
        {
            mainDeck[i] = new Card(lear, name, 10, Image.FromFile(@"Images\Cards\" + lear.ToString() + name + ".jpg"));
        }
        /// <summary>
        /// Возвращает карту из текущей колоды
        /// </summary>
        /// <returns> Карта </returns>
        public Card TakeCard()
        {
            return currentDeck.Pop();
        }
    }
}
