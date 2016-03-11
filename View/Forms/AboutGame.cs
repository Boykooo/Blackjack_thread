using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Forms
{
    partial class AboutGame : Form
    {
        public AboutGame()
        {
            InitializeComponent();
            this.Text = String.Format("О программе {0}", AssemblyTitle);
            this.labelProductName.Text = "BlackJack";
            this.labelVersion.Text = String.Format("Версия 1.0");
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void AboutGame_Load(object sender, EventArgs e)
        {
            textBoxDescription.Text = "Цель игры Цель игры в блэкджек заключается в том, чтобы набрать двадцать одно очко или же количество очков, максимально приближенное к этой сумме, но не больше ее. Если игрок набирает больше двадцати одного очка, он сразу же проигрывает. В остальных случаях ценность его карт сравнивается с ценностью карт дилера и определяется победитель. Карта достоинством десять очков и туз, полученные с раздачи, называются блэкджеком. Это единственная комбинация карт в игре, имеющая название и она превосходит по силе любые другие карты.Достоинство картКарты от двойки до десятки имеют достоинство, совпадающее с их номиналом. Достоинство валета, дамы и короля равно десяти очкам. Туз может давать одно или одиннадцать очков. Этот выбор делается в пользу игрока.Например, если на боксе туз и четверка, объявляется, что у игрока пять или пятнадцать очков. Если ему придет шестерка, он получит двадцать одно очко (в некоторых казино в такой ситуации игра автоматически переходит на следующий бокс, а в некоторых объявляется одиннадцать или двадцать одно и игрок сам делает выбор, брать ли еще карту). Однако, если он получит семерку, будет считаться, что у него двенадцать очков, но не двадцать два.Количество игрокоКоличество игроков ограничивается количеством боксов (полей для ставок) на игровом столе. В традиционном варианте их семь. Однако это не означает, что игроки могут делать совместные ставки на один бокс. Главное, чтобы их сумма не превышала максимальный размер ставок, разрешенный для этого стола.Количество ставокВо многих казино запрещено играть на один бокс, поэтому игрок должен делать не менее двух ставок. Максимальное количество ставок для одного игрока определяется каждым казино, однако обычно оно ограничивается лишь количеством боксов на столе.Ход игры Дилер тщательно перемешивает все колоды, отделяет часть карт (от пятой до третьей) с помощью специальной пластиковой карты и вставляет их все в «башмак». В процессе игры он достает из него карты по одной и раздает их игрокам и себе. Вышедшие из игры карты помещаются в специальный отбойник и находятся там, пока из «башмака» не выйдет пластиковая карта. Раздача, в течение которой это произошло, объявляется последней и по ее окончанию все карты снова перемешиваются.Подготовив карты к игре, дилер предлагает игрокам сделать ставки, после чего прекращает их прием и начинает раздавать карты. В базовом варианте игры он раздает всем игрокам и себе по две карты Одну из своих карт он открывает. В нашей стране получил распространение вариант правил, по которым дилер раздает себе лишь одну открытую карту, а остальные набирает себе после всех игроков. Если на каком-то боксе образуется блэкджек, а открытая карта дилера исключает возможность такой же комбинации у него (то есть, это карта от двойки до девятки), он сразу оплачивает блэкджек и забирает карты в отбойник. Если у дилера открыт туз или карта достоинством в десять очков, блэкджек не оплачивается до тех пор, пока не придет время сравнивать комбинации. Если у крупье открыт туз, по правилам некоторых казино он предлагает игроку, у которого блэкджек, так называемые «равные деньги». Это означает, что он сразу оплачивает блэкджек 1:1 и забирает карты.Игроки, оценивая силу своих карт и принимая во внимание достоинство открытой карты крупье, принимают решение, брать ли еще карту или останавливаться на той сумме очков, которая уже есть на боксе. На бокс можно набирать любое количество карт при условии, что сумма очков не превышает двадцати одного. Набор карт происходит строго по очереди. Первый бокс находится по левую руку от дилера. После того, как на всех боксах было принято окончательное решение, дилер вскрывает свою вторую карту, при необходимости добирает карты и сравнивает полученную комбинацию с картами игроков. Дилер берет себе карты строго в соответствии с правилами: он обязан брать еще карту, если у него шестнадцать или меньше очков и останавливаться, если у него семнадцать и больше очков.";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
