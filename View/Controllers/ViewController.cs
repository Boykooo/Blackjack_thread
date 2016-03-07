using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Controller;
using View.Interfaces;
using GraphicDLL;

namespace View.Controllers
{
    public class ViewController
    {
        private GameController game;
        private IForm view;
        private Graphic g;
        public ViewController(int wh, int ht)
        {
            g = new Graphic(wh, ht);
            game = new GameController();
            game.NewGame();
            view.Update(g.Draw());
        }

        public void NewGame()
        {
            game.NewGame();
        }

        public void TakeCard()
        {

            
        }

        public void Enough()
        {

        }

    }
}
