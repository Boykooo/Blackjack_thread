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
        private Image background;
        private Image shirt;
        private Point[] startPointBots;
        private Point startPointPlayer;
        private Graphics g;

        public Graphic(int wh, int ht)
        {
            mainBT = new Bitmap(wh, ht);
            g = Graphics.FromImage(mainBT);
            startPointBots = new Point[] {
                new Point(410,55),
                new Point(190, 300),
                new Point(620, 300),
            };
            startPointPlayer = new Point(410, 435);
            background = Image.FromFile(@"Images\Background3.jpeg");
            shirt = Image.FromFile(@"Images\Cards\Shirt.jpg");
            
        }
        public Bitmap Draw(Player[] bots, Player pl)
        {
            g.Clear(Color.White);
            g.DrawImage(background, new Point(0, 20));
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
                if (pl.TypePlayer == TypePlayer.Player)
                {
                    g.DrawImage(pl.Hand.cards[j].Picture, new Point(start.X + shift, start.Y));
                }
                else
                {
                    g.DrawImage(shirt, new Point(start.X + shift, start.Y));
                }
            }
        }
        public Bitmap ShowCards(Player[] bots, Player pl) // проверить
        {
            g.Clear(Color.White);
            g.DrawImage(background, new Point(0, 20));

            for (int i = 0; i < bots.Length; i++)
            {
                for (int j = 0, shift = 0; j < bots[i].Hand.cards.Count; j++, shift += 25)
                {
                    g.DrawImage(bots[i].Hand.cards[j].Picture, new Point(startPointBots[i].X + shift, startPointBots[i].Y));
                }
            }
            for (int j = 0, shift = 0; j < pl.Hand.cards.Count; j++, shift += 25)
            {
                g.DrawImage(pl.Hand.cards[j].Picture, new Point(startPointPlayer.X + shift, startPointPlayer.Y));
            }
            return mainBT;
        }

    }
}
