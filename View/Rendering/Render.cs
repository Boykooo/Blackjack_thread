using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;

namespace View.Rendering
{
    /// <summary>
    /// Класс отрисовки
    /// </summary>
    public class Render
    {
        private Bitmap mainBT;
        private Image background;
        private Image shirt;
        private Point[] startPointBots;
        private Point startPointPlayer;
        private Graphics g;
        private Font font;

        public Render(int wh, int ht)
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
            font = new Font("Times New Roman", 20);
            
        }
        /// <summary>
        /// Отрисовка всей поверхности
        /// </summary>
        /// <param name="bots"> Массив ботов </param>
        /// <param name="pl"> Класс игрока-человека </param>
        /// <returns>Bitmap-рисунок</returns>
        public Bitmap Draw(Player[] bots, Player pl)
        {
            g.Clear(Color.White);
            g.DrawImage(background, new Point(0, 20));
            for (int i = 0; i < bots.Length; i++)
            {
                g.DrawString(bots[i].Name, font, Brushes.Black, startPointBots[i].X + 10, startPointBots[i].Y - 30);
                DrawCard(bots[i], startPointBots[i]);
            }

            g.DrawString("Игрок", font, Brushes.Black, startPointPlayer.X + 10, startPointPlayer.Y - 30);
            for (int j = 0, shift = 0; j < pl.Hand.cards.Count; j++, shift += 25)
            {
                DrawCard(pl, startPointPlayer);
            }   
            return mainBT;
        }
        /// <summary>
        /// Отрисовка карт игрока
        /// </summary>
        /// <param name="pl"> Класс игрока </param>
        /// <param name="start"> Начальные координаты отрисовки карт </param>
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
        /// <summary>
        /// Отрисовка всей поверхности с перевернутыми картами
        /// </summary>
        /// <param name="bots"></param>
        /// <param name="pl"></param>
        /// <returns></returns>
        public Bitmap ShowCards(Player[] bots, Player pl)
        {
            g.Clear(Color.White);
            g.DrawImage(background, new Point(0, 20));

            for (int i = 0; i < bots.Length; i++)
            {
                for (int j = 0, shift = 0; j < bots[i].Hand.cards.Count; j++, shift += 25)
                {
                    g.DrawImage(bots[i].Hand.cards[j].Picture, new Point(startPointBots[i].X + shift, startPointBots[i].Y));
                }
                g.DrawString(bots[i].Name, font, Brushes.Black, startPointBots[i].X + 10, startPointBots[i].Y - 30);
            }
            g.DrawString("Игрок", font, Brushes.Black, startPointPlayer.X + 10, startPointPlayer.Y - 30);
            for (int j = 0, shift = 0; j < pl.Hand.cards.Count; j++, shift += 25)
            {
                g.DrawImage(pl.Hand.cards[j].Picture, new Point(startPointPlayer.X + shift, startPointPlayer.Y));
            }
            return mainBT;
        }
        /// <summary>
        /// Возвращает фоновый рисунок 
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBackground()
        {
            g.Clear(Color.Black);
            g.DrawImage(background, new Point(0, 20));

            return mainBT;
        }
    }
}
