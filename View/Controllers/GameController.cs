using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View.Game;
using View.Interfaces;
using View.Rendering;

namespace View.Controllers
{
    public class GameController
    {
        private Player[] bots;
        private Player player;
        private Deck deck;
        private Thread[] botThreads;
        private IForm view;
        private object keyUpdate;
        private Graphic g;
        private Random rand;

        public GameController(IForm view, int wh, int ht)
        {
            this.view = view;
            player = new Player();
            player.TypePlayer = TypePlayer.Player;
            bots = new Player[3];
            for (int i = 0; i < bots.Length; i++)
            {
                bots[i] = new Player();
            }
            bots[0].TypePlayer = TypePlayer.Dealer;
            botThreads = new Thread[3];
            UpdateThreads();
            keyUpdate = new object();
            g = new Graphic(wh, ht);
            rand = new Random();
        }

        public void NewGame()
        {
            Join();
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
            UpdateThreads();
            DefaultCards(bots, player);
            for (int i = 0; i < botThreads.Length; i++)
            {
                botThreads[i].Start();
            }

        }
        private void UpdateThreads()
        {
            for (int i = 0; i < botThreads.Length; i++)
            {
                int j = i; //magic
                botThreads[i] = new Thread(delegate() { BotTurn(bots[j]); });
                botThreads[i].IsBackground = true;
            }
        }
        private void DefaultCards(Player[] bots, Player pl)
        {
            view.EnabledButton = false;
            for (int i = 0; i < bots.Length; i++)
            {
                GiveCard(bots[i]);
                GiveCard(bots[i]);
            }
            GiveCard(pl);
            GiveCard(pl);
            view.EnabledButton = true;
        }
        private void BotTurn(Player bot)
        {
            while (bot.Hand.Point < 17)
            {
                Thread.Sleep(rand.Next(500,2500)); // бот думает
                GiveCard(bot);
            }
        }
        private void GiveCard(Player pl)
        {
            pl.Hand.AddCard(deck.TakeCard());
            Thread.Sleep(100); // задержка выдачи карт
            lock (keyUpdate)
            {
                view.UpdatePic(g.Draw(bots, player));
            }
        }

        private void Join()
        {
            for (int i = 0; i < botThreads.Length; i++)
            {
                if (botThreads[i].IsAlive)
                {
                    botThreads[i].Join();
                }
            }
        }

        public void TakeCard()
        {
            GiveCard(player);
            if (player.Hand.Point > 21)
            {
                Enough();
            }
        }

        public void Enough()
        {
            view.EnabledButton = false;
            Join();
            EndGame();
        }
        private void EndGame()
        {
            view.UpdatePic(g.ShowCards(bots, player));
        }
    }
}
