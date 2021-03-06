﻿using System;
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
    /// <summary>
    /// Контроллер игры
    /// </summary>
    public class GameController : IGame
    {
        private Player[] bots;
        private Player player;
        private Deck deck;
        private Thread[] botThreads;
        private IForm view;
        private object keyUpdate;
        private Render render;
        private Random rand;

        public GameController(IForm view, int wh, int ht)
        {
            rand = new Random();
            this.view = view;
            render = new Render(wh, ht);
            view.UpdatePic(render.GetBackground());
            player = new Player();
            player.TypePlayer = TypePlayer.Player;
            player.Name = "Player";
            InitBots();
            botThreads = new Thread[3];
            keyUpdate = new object();
        }
        /// <summary>
        /// Создание ботов
        /// </summary>
        private void InitBots()
        {
            bots = new Player[3];
            string[] names = new string[] { "Bob", "John", "Nancey", "Nicole", "Bettany", "Mark", "Justin", "Karl", "Andrew", "Rita", "Tayler" };
            for (int i = 0; i < bots.Length; i++)
            {
                bots[i] = new Player();
                bots[i].Name = names[rand.Next(0, names.Length)];
            }
            bots[0].Name = "Казино";
            bots[0].TypePlayer = TypePlayer.Dealer;
        }
        /// <summary>
        /// Новая игра
        /// </summary>
        public void NewGame()
        {
            deck = new Deck();
            Turn();
        }
        /// <summary>
        /// Имитация ставок ботов
        /// </summary>
        private void BetBots()
        {
            for (int i = 0; i < bots.Length; i++)
            {
                bots[i].Bet = rand.Next(10, bots[i].Money / 2);
            }
        }
        /// <summary>
        /// Очистка рук всех игроков
        /// </summary>
        /// <param name="bots"> Массив ботов </param>
        /// <param name="pl"> Класс игрока-человека </param>
        private void ClearHand(Player[] bots, Player pl)
        {
            for (int i = 0; i < bots.Length; i++)
            {
                bots[i].Hand = new Hand();
            }
            pl.Hand = new Hand();
        }
        /// <summary>
        /// Начало новой партии
        /// </summary>
        private void Turn()
        {
            ClearHand(bots, player);
            player.Bet = view.GetBet(player.Money);
            BetBots();
            //UpdateThreads();
            DefaultCards(bots, player);
            view.UpdatePoints(player.Hand.Point);
            StartBots();
        }
        /// <summary>
        /// Запуск ботов
        /// </summary>
        private void StartBots()
        {
            for (int i = 0; i < botThreads.Length; i++)
            {
                int j = i; //magic
                botThreads[i] = new Thread(delegate() { BotTurn(bots[j]); });
                botThreads[i].IsBackground = true;
                botThreads[i].Start();
            }
        }
        /// <summary>
        /// Раздача карт в начале партии
        /// </summary>
        /// <param name="bots" >Массив ботов </param>
        /// <param name="pl"> Класс игрока-человека </param>
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
        /// <summary>
        /// Имитация логики ботов 
        /// </summary>
        /// <param name="bot"></param>
        private void BotTurn(Player bot)
        {
            while (bot.Hand.Point < 17)
            {
                Thread.Sleep(rand.Next(500, 2500)); // бот думает
                GiveCard(bot);
            }
        }
        /// <summary>
        /// Выдача карты игроку
        /// </summary>
        /// <param name="pl">Класс игрока</param>
        private void GiveCard(Player pl)
        {
            pl.Hand.AddCard(deck.TakeCard());
            Thread.Sleep(100); // задержка выдачи карт
            lock (keyUpdate)
            {
                view.UpdatePic(render.Draw(bots, player));
            }
        }
        /// <summary>
        /// Ожидание завершения потоков ботов
        /// </summary>
        private void JoinBots()
        {
            for (int i = 0; i < botThreads.Length; i++)
            {
                if (botThreads[i].IsAlive)
                {
                    botThreads[i].Join();
                    Thread.Sleep(500);
                }
            }
        }
        /// <summary>
        /// Конец партии, определение победителя
        /// </summary>
        private void EndOfGame()
        {
            view.UpdatePic(render.ShowCards(bots, player));

            int indexWinner = WinnerOfBots();
            if (player.Hand.Point <= 21 && player.Hand.Point > bots[indexWinner].Hand.Point)
            {
                player.Money += player.Bet;
                view.Winner(player.Name);
                PickUpBetBots(null);
            }
            else
            {
                player.Money -= player.Bet;
                view.Winner(bots[indexWinner].Name);
                PickUpBetBots(indexWinner);
                if (player.Money == 0)
                {
                    view.UpdateMoney(0);
                    view.GameOver();
                    return;
                }
            }

            //Новая партия
            deck.RandomDeck();
            view.UpdateMoney(player.Money);
            Turn();
        }
        /// <summary>
        /// Вычисление средcтв ботов
        /// </summary>
        /// <param name="winnerBot">индекс бота-победителя или при отсутствии победителя - null </param>
        private void PickUpBetBots(int? winnerBot)
        {
            for (int i = 0; i < bots.Length; i++)
            {
                bots[i].Money -= bots[i].Bet;
            }

            if (winnerBot != null)
            {
                int i = (int)winnerBot;
                bots[i].Money += 2 * bots[i].Bet;
            }
        }
        /// <summary>
        /// Определение победителя среди ботов
        /// </summary>
        /// <returns></returns>
        private int WinnerOfBots()
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < bots.Length; i++)
            {
                if (bots[i].Hand.Point <= 21 && bots[i].Hand.Point > max)
                {
                    max = bots[i].Hand.Point;
                    index = i;
                }
            }
            return index;
        }

        public void TakeCard()
        {
            GiveCard(player);
            view.UpdatePoints(player.Hand.Point);
            if (player.Hand.Point > 21)
            {
                Enough();
            }
        }
        public void Enough()
        {
            view.EnabledButton = false;
            JoinBots();
            EndOfGame();
        }

    }
}
