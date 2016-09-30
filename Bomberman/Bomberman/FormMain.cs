using Bomberman.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing; //primarly for Point class
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class FormMain : Form
    {
        public Form formStart = new Form();
        public Bomberman.Map map = new Bomberman.Map(); //field used to store current map
        public Panel panelPlayer1 = new Panel(); //easier playerPanel management than inside player object
        public Panel panelPlayer2 = new Panel(); //easier playerPanel management than inside player object
        public Player player1 = new Player(0, 0, 1);
        public Player player2 = new Player(0, 0, 2);
        public enum direction { Up, Left, Down, Right }; //for future use (bonuses)
        public Timer timerEverybodyAlive; //checks if game should end
        public Timer timerBye = new Timer() { Interval = 1000 }; //animation after game has ended
        public Dictionary<Keys, bool> downState = new Dictionary<Keys, bool>(); //Multi-key input simulation
        public string mapPath;

        public FormMain(string mapPath, Form formStart)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.formStart = formStart;
            this.mapPath = mapPath;
            panelDebug.Hide(); //it's only for debug
            //Set KeyPreview object to true to allow the form to process the key before the control with focus processes it.
            this.KeyPreview = true;
            //anti-flicker tweak
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //Multi-key input simulation
            downState.Add(Keys.W, false);
            downState.Add(Keys.D, false);
            downState.Add(Keys.S, false);
            downState.Add(Keys.A, false);
            downState.Add(Keys.Up, false);
            downState.Add(Keys.Right, false);
            downState.Add(Keys.Down, false);
            downState.Add(Keys.Left, false);
        }

        /// <summary>
        /// Reset downState list
        /// </summary>
        private void InitializeButtonPressed()
        {
            try
            {
                foreach (Keys key in downState.Keys)
                {
                    if (downState[key] == true)
                    {
                        downState[key] = false;
                        InitializeButtonPressed();
                    }
                }
            }
            catch (InvalidOperationException){ Console.WriteLine("downState list in use."); }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); //common stuff
            Timer timerPlayerMove = new Timer() { Interval = 25 }; //timer used to measure and perform player movement
            timerPlayerMove.Tick += TimerPlayerMove_Tick;
            timerPlayerMove.Start();
            timerEverybodyAlive = new Timer() { Interval = 1000 };
            timerEverybodyAlive.Tick += TimerEverybodyAlive_Tick;
            timerEverybodyAlive.Start();

            this.CenterToScreen();
            panelGame.Size = new Size((int)(this.Size.Width * 1), (int)(this.Size.Height * 0.9));
            panelGame.BackColor = Color.Aqua;
            //panelGame.Visible = true;

            DrawMap(mapPath);
            panelStats.Location = new Point(panelGame.Location.X + map.ElementSize*map.Width + panelGame.Margin.Right, panelStats.Location.Y);

            SpawnPlayers();
        }

        /// <summary>
        /// If key is pressed move panelPlayerX each tick.
        /// Also checks if everybody should be alive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerPlayerMove_Tick(object sender, EventArgs e)
        {
            foreach (Keys key in downState.Keys)
            {
                if (downState[key] == true)
                {
                    if (key == Keys.W)
                    {
                        if (CheckMove(player1, "Up"))
                        {
                            MoveUp(player1);
                            player1.LastMoved = Player.direction.Up;
                        }
                    }
                    if (key == Keys.D)
                    {
                        if (CheckMove(player1, "Right"))
                        {
                            MoveRight(player1);
                            player1.LastMoved = Player.direction.Right;
                        }
                            
                    }
                    if (key == Keys.S)
                    {
                        if (CheckMove(player1, "Down"))
                        {
                            MoveDown(player1);
                            player1.LastMoved = Player.direction.Down;
                        }     
                    }
                    if (key == Keys.A)
                    {
                        if (CheckMove(player1, "Left") == true)
                        {
                            MoveLeft(player1);
                            player1.LastMoved = Player.direction.Left;
                        }
                    }
                    //-----------player2--------------
                    if (key == Keys.Up)
                    {
                        if (CheckMove(player2, "Up"))
                            MoveUp(player2);
                    }
                    if (key == Keys.Right)
                    {
                        if (CheckMove(player2, "Right"))
                            MoveRight(player2);
                    }
                    if (key == Keys.Down)
                    {
                        if (CheckMove(player2, "Down"))
                            MoveDown(player2);
                    }
                    if (key == Keys.Left)
                    {
                        if (CheckMove(player2, "Left") == true)
                            MoveLeft(player2);
                    }
                }
            }
        }

        private void TimerEverybodyAlive_Tick(object sender, EventArgs e)
        {
            foreach (MapObject mapObject in map.EveryEntityList)
            {
                if (mapObject is Player)
                {
                    Player player = new Player(mapObject.X, mapObject.Y, 99);
                    player = mapObject as Player;
                    if (player.Hp < 1)
                    {
                        timerEverybodyAlive.Stop();
                        Methods.GameOver(player, this);
                        InitializeButtonPressed();
                        timerEverybodyAlive = null;
                        //this.Close();
                        timerBye.Tick += TimerBye_Tick;
                        timerBye.Start();
                        //labelHint.Location = new Point(panelGame.Size.Width / 2 - labelHint.Size.Width / 2);
                        labelHint.Show();
                        labelHint.BringToFront();
                        return;
                    }
                }
            }
        }

        private void TimerBye_Tick(Object sender, EventArgs e)
        {
            foreach (MapObject bye in map.EveryEntityList)
            {
                if (bye.CorrespondingPanel != null && !(bye is Explosion) && !(bye is Stone) && !(bye is Player))
                {
                    Bomb bomb = new Bomb(bye.X, bye.Y, 0, map, this);
                    return;
                }
            }
            Debug.WriteLine("Disposing timerBye");
            timerBye.Dispose();
        }

        #region Debug
        private void panelGame_MouseMove(object sender, MouseEventArgs e)
        {
            textBoxCursorPosition.Text = e.Location.ToString();
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            textBoxCursorPosition.Text = e.Location.ToString();
        }

        public void ClearExplosions()
        {
            List<MapObject> list = new List<MapObject>();
            list = map.EveryEntityList;
            foreach (MapObject mapObject in list)
            {
                if (mapObject is Explosion)
                {
                    this.Controls.Remove(mapObject.CorrespondingPanel);
                    map.EveryEntityList.Remove(mapObject);
                    ClearExplosions();
                    return;
                }
            }
        }
        #endregion

        #region Moving panels

        /// <summary>
        /// Returns bool whether player can perform move in specified direction
        /// </summary>
        /// <param name="player"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        bool CheckMove(Player player, string direction)
        {
            Panel newPanel = new Panel();
            //newPanel.Location = player.CorrespondingPanel.Location;
            newPanel.Size = player.CorrespondingPanel.Size;
            newPanel.Bounds = player.CorrespondingPanel.Bounds;
            //Debug
            //newPanel.BackColor = Color.Lime;
            newPanel.Visible = false;
            this.Controls.Add(newPanel);
            //Debug
            //newPanel.BringToFront();
            switch (direction)
            {
                default:
                    break;
                case "Up":
                    MoveUp(newPanel, player.Speed);
                    break;
                case "Right":
                    MoveRight(newPanel, player.Speed);
                    break;
                case "Down":
                    MoveDown(newPanel, player.Speed);
                    break;
                case "Left":
                    MoveLeft(newPanel, player.Speed);
                    break;
            }
            foreach (MapObject mapObject in map.EveryEntityList)
            {
                if (mapObject != null) //don't check if null
                {
                    if (mapObject.CorrespondingPanel != null) //don't check if not drawn on the board
                    {
                        if (mapObject != player) //don't check self
                        {
                            if (Methods.DetectCollision(newPanel, mapObject.CorrespondingPanel)) //try to detect collision
                            {
                                if (mapObject.PassThrough == false) //some blocks can be passed through anyways
                                {
                                    if (mapObject is Bomb) //if it's a bomb- prevent being stuck
                                    {
                                        Bomb newBomb = mapObject as Bomb;
                                        if (newBomb.canPassThrough.Contains(player)) //stuck prevention
                                        {
                                            if (!Methods.DetectCollision(newBomb.CorrespondingPanel, player.CorrespondingPanel)) //once player went out, no longer can pass
                                            {
                                                newBomb.canPassThrough.Remove(player);
                                            }
                                            return true; //it's a bomb but player is allowed to pass
                                        }
                                        else return false; //it's a bomb and player is not allowed to pass
                                    }
                                    else //not allowed to pass
                                    {
                                        Debug.WriteLine("Collision detected between " + player.Name  + " and " + mapObject.CorrespondingPanel.Name);
                                        //cleanup
                                        this.Controls.Remove(newPanel);
                                        newPanel = null;
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            this.Controls.Remove(newPanel);
            return true;
        }

        /// <summary>
        /// Move player (offset is get from player.speed)
        /// </summary>
        /// <param name="player"></param>
        private void MoveLeft(Player player)
        {
            Point currentPoint = new Point(player.CorrespondingPanel.Location.X, player.CorrespondingPanel.Location.Y);
            Point newPoint = new Point(currentPoint.X - player.Speed, currentPoint.Y);
            player.CorrespondingPanel.Location = newPoint;
            currentPoint = newPoint;
        }

        /// <summary>
        /// Move panel by specified offset
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="offset"></param>
        private void MoveLeft(Panel panel, int offset)
        {
            Point currentPoint = new Point(panel.Location.X, panel.Location.Y);
            Point newPoint = new Point(currentPoint.X - offset, currentPoint.Y);
            panel.Location = newPoint;
            currentPoint = newPoint;
        }

        private void MoveDown(Player player)
        {
            Point currentPoint = new Point(player.CorrespondingPanel.Location.X, player.CorrespondingPanel.Location.Y);
            Point newPoint = new Point(currentPoint.X, currentPoint.Y + player.Speed);
            player.CorrespondingPanel.Location = newPoint;
            currentPoint = newPoint;
        }

        private void MoveDown(Panel panel, int offset)
        {
            Point currentPoint = new Point(panel.Location.X, panel.Location.Y);
            Point newPoint = new Point(currentPoint.X, currentPoint.Y + offset);
            panel.Location = newPoint;
            currentPoint = newPoint;
        }

        private void MoveRight(Player player)
        {
            Point currentPoint = new Point(player.CorrespondingPanel.Location.X, player.CorrespondingPanel.Location.Y);
            Point newPoint = new Point(currentPoint.X + player.Speed, currentPoint.Y);
            player.CorrespondingPanel.Location = newPoint;
            currentPoint = newPoint;
        }

        private void MoveRight(Panel panel, int offset)
        {
            Point currentPoint = new Point(panel.Location.X, panel.Location.Y);
            Point newPoint = new Point(currentPoint.X + offset, currentPoint.Y);
            panel.Location = newPoint;
            currentPoint = newPoint;
        }

        private void MoveUp(Player player)
        {
            Point currentPoint = new Point(player.CorrespondingPanel.Location.X, player.CorrespondingPanel.Location.Y);
            Point newPoint = new Point(currentPoint.X, currentPoint.Y - player.Speed);
            player.CorrespondingPanel.Location = newPoint;
            currentPoint = newPoint;
        }

        private void MoveUp(Panel panel, int offset)
        {
            Point currentPoint = new Point(panel.Location.X, panel.Location.Y);
            Point newPoint = new Point(currentPoint.X, currentPoint.Y - offset);
            panel.Location = newPoint;
            currentPoint = newPoint;
        }

        #endregion

        #region Controls

        private void buttonDrawMap_Click(object sender, EventArgs e)
        {
            //DrawMap();
        }

        private void DrawMap(string mapPath)
        {
            map = new Map();
            map.CreateMapFromFile(mapPath);
            map.DrawMap(map, map.EntityList, this, panelGame);
            map.EveryEntityList = new List<MapObject>();
            foreach (MapObject mapObject in map.EntityList)
                if (mapObject != null)
                    map.EveryEntityList.Add(mapObject);
        }

        private void buttonSpawnPlayers_Click(object sender, EventArgs e)
        {
            SpawnPlayers();
        }

        /// <summary>
        /// Create players and use DrawPlayer() to draw them.
        /// </summary>
        private void SpawnPlayers()
        {
            for (int i = 0; i < map.EntityList.GetLength(0); i++)
            {
                for (int j = 0; j < map.EntityList.GetLength(1); j++)
                {
                    if (map.EntityList[i, j] is Spawner)
                    {
                        Spawner spawner = map.EntityList[i, j] as Spawner;
                        DrawPlayer(i, j, spawner);
                    }
                }
            }
            //initialize player hp display
            labelPlayer1HpAmount.Text = player1.Hp.ToString();
            labelPlayer2HpAmount.Text = player2.Hp.ToString();
        }

        private void buttonClearExplosions_Click(object sender, EventArgs e)
        {
            ClearExplosions();
        }

        /// <summary>
        /// Draws players.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="spawner"></param>
        private void DrawPlayer(int i, int j, Spawner spawner)
        {
            int index = spawner.whichPlayer;
            string playerName = "player" + index;
            Player newPlayer = new Player(i, j, index);
            newPlayer.Size = map.ElementSize;
            double desiredSize = 0.8;
            newPlayer.CollisionSize = newPlayer.CalculateCollisionSize(desiredSize);
            newPlayer.Size = newPlayer.CollisionSize;
            newPlayer.Form = this;
            newPlayer.Map = map;
            newPlayer.Panel = this.Controls.Find("panelGame", false)[0] as Panel;
            Methods.DrawEntity(newPlayer, playerName, map, this, this.Controls.Find("panelGame", false)[0] as Panel, "Images/" + playerName + ".png", desiredSize);
            if (spawner.whichPlayer == 1)
                player1 = newPlayer;
            if (spawner.whichPlayer == 2)
                player2 = newPlayer;
            newPlayer.UpdateLabels();
        }
        #endregion

        #region Key Response

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            downState[e.KeyData] = true;
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            downState[e.KeyData] = false;
        }

        /// <summary>
        /// Planting Bomb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ' ':
                    player1.PlantBomb(map, this);
                    break;
                case '/':
                    player2.PlantBomb(map, this);
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void buttonStart_Click(object sender, EventArgs e)
        {
            foreach (MapObject mapObject in map.EveryEntityList)
            {
                if (mapObject.CorrespondingPanel != null)
                {
                    this.Controls.Remove(mapObject.CorrespondingPanel);
                }
            }
            map = null;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
