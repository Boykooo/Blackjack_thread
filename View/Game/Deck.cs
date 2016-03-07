using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Exceptions;

namespace View.Game
{
    public class Deck
    {
        private Stack<Card> currentDeck;
        private Card[] mainDeck;

        public Deck()
        {
            mainDeck = new Card[52];
            FillMainDeck();
            RandomDeck();
        }
        private void RandomDeck()
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

        private void FillMainDeck()
        {
            Lear[] lear = new Lear[] { Lear.Club, Lear.Diamond, Lear.Heart, Lear.Spade };

            for (int i = 0, j = 1; i < 52; i += 13, j++)
            {
                AddLearToDeck(i, lear[j]);
            }
        }
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
        private void AddCardWithPicture(Lear lear, int i, string name)
        {
            mainDeck[i] = new Card(lear, name, 10, Image.FromFile(@"Images\Cards\" + lear.ToString() + name + ".jpg"));
        }

        public Card TakeCard()
        {
            if (currentDeck.Count != 0)
            {
                return currentDeck.Pop();
            }

            throw new Exception("Закончилась колода"); // ???
        }
    }
}
