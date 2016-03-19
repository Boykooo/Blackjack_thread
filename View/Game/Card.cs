using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game
{
    /// <summary>
    /// Перечисление мастей
    /// </summary>
    public enum Lear { Heart, Diamond, Club, Spade };
    /// <summary>
    /// Класс карты
    /// </summary>
    public class Card
    {
        public Lear Lear { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public Image Picture { get; set; }
        public Card(Lear lear, string name, int cost, Image pct)
        {
            Lear = lear;
            Name = name;
            Cost = cost;
            Picture = pct;
        }
    }
}
