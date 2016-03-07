using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;

namespace View.Controllers
{
    public class GameController
    {
        private Player[] bots;
        private Player player;
        private Deck deck;
        public GameController()
        {
            player = new Player();
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
            foreach (var player in players)
            {
                player.Hand = new Hand();
                player.Money = 1000;
            }
        }


    }
}
