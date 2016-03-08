using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View.Game;
using View.Interfaces;

namespace View.Controllers
{
    public class GameController
    {
        private Player[] bots;
        private Player player;
        private Deck deck;
        private Thread[] botThreads;
        private IForm view;
        private object key;

        public GameController(IForm view)
        {
            this.view = view;
            player = new Player();
            bots = new Player[3];
            for (int i = 0; i < bots.Length; i++)
            {
                bots[i] = new Player();
            }
            bots[0].TypePlayer = TypePlayer.Dealer;
            botThreads = new Thread[bots.Length];
            for (int i = 0; i < botThreads.Length; i++)
            {
                botThreads[i] = new Thread(delegate() { BotTurn(bots[i]); });
                botThreads[i].IsBackground = true;
            }
            key = new object();
        }

        public void NewGame()
        {
            deck = new Deck();
            ClearHandPlayers(bots);
            ClearHandPlayers(player);
            Turn();
        }
        private void ClearHandPlayers(params Player[] bots)
        {
            foreach (var player in bots)
            {
                player.Hand = new Hand();
                player.Money = 1000;
            }
        }
        public void Turn()
        {
            DefaultCards(bots);
            DefaultCards(player);
            for (int i = 0; i < botThreads.Length; i++)
            {
                botThreads[i].Start();
            }
        }
        private void DefaultCards(params Player[] pls)
        {
            view.EnabledButton = false;
            for (int i = 0; i < pls.Length; i++)
            {
                pls[i].Hand.AddCard(deck.TakeCard());

                Thread.Sleep(10); // задержка выдачи карт
            }
        }
        private void BotTurn(Player bot)
        {

        }

    }
}
