﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game
{
    public enum TypePlayer { Bot, Player, Dealer };
    public class Player
    {
        public TypePlayer TypePlayer { get; set; }
        public string Name { get; set; }
        public Hand Hand { get; set; }
        public int Money { get; set; }
        public int Bet { get; set; }
        public Player()
        {
            Hand = new Game.Hand();
            Money = 1000;
        }
    }
}
