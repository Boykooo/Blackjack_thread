using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Interfaces
{
    /// <summary>
    /// Интерфейс игры
    /// </summary>
    interface IGame
    {
        /// <summary>
        /// Выдать карту игроку
        /// </summary>
        void TakeCard();
        /// <summary>
        /// Закончить партию
        /// </summary>
        void Enough();
        /// <summary>
        /// Начать новую игру
        /// </summary>
        void NewGame();
    }
}
