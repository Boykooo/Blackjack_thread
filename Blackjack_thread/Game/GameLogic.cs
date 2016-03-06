using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Game
{
    public class GameLogic
    {
        private Player[] bots;
        private Player player;
        private Deck deck;
        public GameLogic()
        {
            bots = new Player[3];
            for (int i = 0; i < bots.Length; i++)
            {
                bots[i] = new Player();
            }
            bots[0].TypePlayer = TypePlayer.Dealer;
        }
        public void NewGame()
        {
            deck = new Deck();
            ClearHandPlayers(bots);
            ClearHandPlayers(player);

        }

        private void ClearHandPlayers(params Player[] players)
        {
            foreach (var item in players)
            {
                item.Hand = new Hand();
                item.Hand.ClearPoint();
                item.Money = 1000;
            }
        }
    }
}
