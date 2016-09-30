using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace KolkoKrzyzyk
{
    public partial class FormMain : Form
    {
        Point point = new Point(); //used to show OverlayClicable
        int scoreX = 0; //player points
        int scoreO = 0;
        int[,] tabBoard = new int[5, 5]; //game board
        //self-explainatory
        enum GameStates { InProgress, WinX, WinO, Draw };
        enum CurrentTurn { TurnX, TurnO };
        enum Place { Nothing, X, O }
        GameStates gameState = GameStates.InProgress;
        CurrentTurn currentTurn = CurrentTurn.TurnX;

        public FormMain()
        {
            InitializeComponent();
            InitializeBoard();
            ListBoard();
            UpdatePanels(tabBoard);
            gameState = CheckIfSomebodyWon();
            Debug.WriteLine(CheckIfSomebodyWon());
            NewTurn();
        }

        /// <summary>
        /// Make game board clear
        /// </summary>
        private void InitializeBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabBoard[i, j] = (int)Place.Nothing;
                }
            }
            UpdatePanels(tabBoard);
        }

        /// <summary>
        /// Writes tabBoard to console for debugging reasons
        /// </summary>
        private void ListBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Debug.Write((int)tabBoard[i, j] + " ");
                }
                Debug.WriteLine("");
            }
        }

        /// <summary>
        /// Redraw game data on panels
        /// Panels are named panel0 - panel24
        /// </summary>
        /// <param name="tab"></param>
        private void UpdatePanels(int[,] tab)
        {
            int i = 0;
            int j = -1;
            foreach (Control c in flowLayoutPanelBoard.Controls)
            {
                if (c is Panel)
                {
                    if (c.Name.Contains("panel"))
                    {
                        j++;
                        if (j == 5)
                        {
                            i++;
                            j = 0;
                        }
                        if (i == 5) return;
                        if (tab[i, j] == (int)Place.O) ((Control)c).BackgroundImage = KolkoKrzyzyk.Properties.Resources.O;
                        if (tab[i, j] == (int)Place.X) ((Control)c).BackgroundImage = KolkoKrzyzyk.Properties.Resources.X;
                        if (tab[i, j] == (int)Place.Nothing) ((Control)c).BackgroundImage = null;
                    }
                }
            }
        }

        /// <summary>
        /// Method that prepares a new turn
        /// </summary>
        private void NewTurn()
        {
            gameState = CheckIfSomebodyWon();
            Debug.WriteLine(CheckIfSomebodyWon());
            switch (gameState)
            {
                case GameStates.InProgress:
                    break;
                case GameStates.WinX:
                    MessageBox.Show("Player X won!");
                    scoreX++;
                    labelPointsX.Text = scoreX.ToString();
                    NewGame();
                    break;
                case GameStates.WinO:
                    MessageBox.Show("Player O won!");
                    scoreO++;
                    labelPointsO.Text = scoreO.ToString();
                    NewGame();
                    break;
                case GameStates.Draw:
                    MessageBox.Show("Game draw!");
                    NewGame();
                    break;
                default:
                    break;
            }
            if (currentTurn == CurrentTurn.TurnX)
            {
                currentTurn = CurrentTurn.TurnO;
                labelMoveWho.Text = "O";
            }
            else if (currentTurn == CurrentTurn.TurnO)
            {
                currentTurn = CurrentTurn.TurnX;
                labelMoveWho.Text = "X";
            }
            ListBoard();
            UpdatePanels(tabBoard);
        }

        /// <summary>
        /// Method that restarts the game
        /// </summary>
        private void NewGame()
        {
            InitializeBoard();
            gameState = GameStates.InProgress;
            NewTurn();
        }

        /// <summary>
        /// Method that checks if somebody already won and whether program should start a new game or not
        /// </summary>
        /// <returns></returns>
        private GameStates CheckIfSomebodyWon()
        {
            int sumXrow = 0; int sumXcolumn = 0;
            int sumOrow = 0; int sumOcolumn = 0;
            int sumXdiag1 = 0; int sumOdiag1 = 0;
            int sumXdiag2 = 0; int sumOdiag2 = 0;
            int draw = 0;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    //a bit intricated
                    //diagonal1
                    if (tabBoard[i, i] == (int)Place.X) sumXdiag1++;
                    if (tabBoard[i, i] == (int)Place.O) sumOdiag1++;
                    if (i == 4) { if (sumXdiag1 < 5) sumXdiag1 = 0; else return GameStates.WinX; }
                    if (i == 4) { if (sumOdiag1 < 5) sumOdiag1 = 0; else return GameStates.WinO; }
                    //diagonal2
                    if (tabBoard[4 - i, i] == (int)Place.X) sumXdiag2++;
                    if (tabBoard[4 - i, i] == (int)Place.O) sumOdiag2++;
                    if (i == 4) { if (sumXdiag2 < 5) sumXdiag2 = 0; else return GameStates.WinX; }
                    if (i == 4) { if (sumOdiag2 < 5) sumOdiag2 = 0; else return GameStates.WinO; }
                    //rows
                    if (tabBoard[j, i] == (int)Place.X) sumXrow++;
                    if (tabBoard[j, i] == (int)Place.O) sumOrow++;
                    if (i == 4) { if (sumXrow < 5) sumXrow = 0; else return GameStates.WinX; }
                    if (i == 4) { if (sumOrow < 5) sumOrow = 0; else return GameStates.WinO; }
                    //columns
                    if (tabBoard[i, j] == (int)Place.X) sumXcolumn++;
                    if (tabBoard[i, j] == (int)Place.O) sumOcolumn++;
                    if (i == 4) { if (sumXcolumn < 5) sumXcolumn = 0; else return GameStates.WinX; }
                    if (i == 4) { if (sumOcolumn < 5) sumOcolumn = 0; else return GameStates.WinO; }
                    //draw
                    if (tabBoard[i, j] != 0) draw++;
                    if (i == 4 && j == 4 && draw == 25) return GameStates.Draw;
                }
            }
            return GameStates.InProgress;
        }

        /// <summary>
        /// As users clicks the panelBoard, this method calculates which field on the board corresponds to the clicked point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flowLayoutPanelBoard_MouseClick(object sender, MouseEventArgs e)
        {
            point = e.Location;
            //MessageBox.Show(e.Location.ToString());
            int[] tableWhere = new int[2]; //-which field on board?
            for (int i = 1; i < 6; i++)
            {
                if (point.X > (flowLayoutPanelBoard.Size.Width / 5) * (i - 1))
                {
                    tableWhere[0] = i;
                    Debug.WriteLine(tableWhere[0]);
                    Debug.WriteLine("(flowLayoutPanelBoard.Size.Width / 5) * i-1 = " + (flowLayoutPanelBoard.Size.Width / 5) * (i - 1));
                }
                if (point.Y > (flowLayoutPanelBoard.Size.Height / 5) * (i - 1))
                {
                    tableWhere[1] = i;
                    Debug.WriteLine(tableWhere[1]);
                    Debug.WriteLine("(flowLayoutPanelBoard.Size.Height / 5) * i-1 = " + (flowLayoutPanelBoard.Size.Height / 5) * (i - 1));
                }
                Debug.WriteLine(tableWhere[0] + "," + tableWhere[1]);
            }
            //perform move but don't waste one if field is already taken
            if (currentTurn == CurrentTurn.TurnX)
                if (tabBoard[tableWhere[1] - 1, tableWhere[0] - 1] == 0)
                {
                    tabBoard[tableWhere[1] - 1, tableWhere[0] - 1] = (int)Place.X;
                    NewTurn();
                }
            if (currentTurn == CurrentTurn.TurnO)
                if (tabBoard[tableWhere[1] - 1, tableWhere[0] - 1] == 0)
                {
                    tabBoard[tableWhere[1] - 1, tableWhere[0] - 1] = (int)Place.O;
                    NewTurn();
                }
            UpdatePanels(tabBoard);

        }
    }
}
