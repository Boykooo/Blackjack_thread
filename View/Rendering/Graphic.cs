using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;

namespace View.Rendering
{
    public class Graphic
    {
        private Bitmap mainBT;
        private Graphics g;
        private Image background;
        private Point[] startPointBots;
        private Point startPointPlayer;
        public Graphic(int wh, int ht)
        {
            mainBT = new Bitmap(wh, ht);
            g = Graphics.FromImage(mainBT);
            startPointBots = new Point[] {
                new Point(410,55),
                new Point(210, 200),
                new Point(600, 200),
            };
            startPointPlayer = new Point(410, 435);
        }
        public Bitmap Draw(Player[] bots, Player pl)
        {
            g.Clear(Color.White);
            g.DrawImage(background, new Point(0, 0));
            for (int i = 0; i < bots.Length; i++)
            {
                DrawCard(bots[i], startPointBots[i]);
            }

            for (int j = 0, shift = 0; j < pl.Hand.cards.Count; j++, shift += 25)
            {
                DrawCard(pl, startPointPlayer);
            }   
            return mainBT;
        }
        private void DrawCard(Player pl, Point start)
        {
            for (int j = 0, shift = 0; j < pl.Hand.cards.Count; j++, shift += 25)
            {
                g.DrawImage(pl.Hand.cards[j].Picture, new Point(start.X + shift, start.Y));
            }
        }

    }
}
