namespace Bomberman
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelHint = new System.Windows.Forms.Label();
            this.buttonDrawMap = new System.Windows.Forms.Button();
            this.textBoxCursorPosition = new System.Windows.Forms.TextBox();
            this.buttonSpawnPlayers = new System.Windows.Forms.Button();
            this.buttonClearExplosions = new System.Windows.Forms.Button();
            this.groupBoxPlayer1 = new System.Windows.Forms.GroupBox();
            this.labelPlayer1SpeedAmount = new System.Windows.Forms.Label();
            this.labelPlayer1MaxBombAmount = new System.Windows.Forms.Label();
            this.labelPlayer1ExplosionPowerAmount = new System.Windows.Forms.Label();
            this.labelPlayer1Speed = new System.Windows.Forms.Label();
            this.labelPlayer1MaxBomb = new System.Windows.Forms.Label();
            this.labelPlayer1ExplosionPower = new System.Windows.Forms.Label();
            this.labelPlayer1HpAmount = new System.Windows.Forms.Label();
            this.labelPlayer1Hp = new System.Windows.Forms.Label();
            this.groupBoxPlayer2 = new System.Windows.Forms.GroupBox();
            this.labelPlayer2SpeedAmount = new System.Windows.Forms.Label();
            this.labelPlayer2MaxBombAmount = new System.Windows.Forms.Label();
            this.labelPlayer2ExplosionPowerAmount = new System.Windows.Forms.Label();
            this.labelPlayer2Speed = new System.Windows.Forms.Label();
            this.labelPlayer2MaxBomb = new System.Windows.Forms.Label();
            this.labelPlayer2ExplosionPower = new System.Windows.Forms.Label();
            this.labelPlayer2HpAmount = new System.Windows.Forms.Label();
            this.labelPlayer2Hp = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelDebug = new System.Windows.Forms.Panel();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelGame.SuspendLayout();
            this.groupBoxPlayer1.SuspendLayout();
            this.groupBoxPlayer2.SuspendLayout();
            this.panelDebug.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelGame.Controls.Add(this.labelHint);
            this.panelGame.Location = new System.Drawing.Point(10, 10);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1000, 800);
            this.panelGame.TabIndex = 0;
            this.panelGame.Visible = false;
            this.panelGame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseMove);
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHint.Location = new System.Drawing.Point(66, 227);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(870, 46);
            this.labelHint.TabIndex = 0;
            this.labelHint.Text = "ZAMKNIJ OKNO I WYPRÓBUJ NOWĄ MAPĘ";
            this.labelHint.Visible = false;
            // 
            // buttonDrawMap
            // 
            this.buttonDrawMap.Location = new System.Drawing.Point(3, 32);
            this.buttonDrawMap.Name = "buttonDrawMap";
            this.buttonDrawMap.Size = new System.Drawing.Size(123, 23);
            this.buttonDrawMap.TabIndex = 1;
            this.buttonDrawMap.Text = "Create Map";
            this.buttonDrawMap.UseVisualStyleBackColor = true;
            this.buttonDrawMap.Click += new System.EventHandler(this.buttonDrawMap_Click);
            // 
            // textBoxCursorPosition
            // 
            this.textBoxCursorPosition.Enabled = false;
            this.textBoxCursorPosition.Location = new System.Drawing.Point(3, 119);
            this.textBoxCursorPosition.Name = "textBoxCursorPosition";
            this.textBoxCursorPosition.Size = new System.Drawing.Size(123, 22);
            this.textBoxCursorPosition.TabIndex = 2;
            // 
            // buttonSpawnPlayers
            // 
            this.buttonSpawnPlayers.Location = new System.Drawing.Point(3, 61);
            this.buttonSpawnPlayers.Name = "buttonSpawnPlayers";
            this.buttonSpawnPlayers.Size = new System.Drawing.Size(123, 23);
            this.buttonSpawnPlayers.TabIndex = 3;
            this.buttonSpawnPlayers.Text = "Spawn Players";
            this.buttonSpawnPlayers.UseVisualStyleBackColor = true;
            this.buttonSpawnPlayers.Click += new System.EventHandler(this.buttonSpawnPlayers_Click);
            // 
            // buttonClearExplosions
            // 
            this.buttonClearExplosions.Location = new System.Drawing.Point(3, 90);
            this.buttonClearExplosions.Name = "buttonClearExplosions";
            this.buttonClearExplosions.Size = new System.Drawing.Size(123, 23);
            this.buttonClearExplosions.TabIndex = 4;
            this.buttonClearExplosions.Text = "Clear Explosions";
            this.buttonClearExplosions.UseVisualStyleBackColor = true;
            this.buttonClearExplosions.Click += new System.EventHandler(this.buttonClearExplosions_Click);
            // 
            // groupBoxPlayer1
            // 
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1SpeedAmount);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1MaxBombAmount);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1ExplosionPowerAmount);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1Speed);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1MaxBomb);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1ExplosionPower);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1HpAmount);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1Hp);
            this.groupBoxPlayer1.Location = new System.Drawing.Point(3, 3);
            this.groupBoxPlayer1.Name = "groupBoxPlayer1";
            this.groupBoxPlayer1.Size = new System.Drawing.Size(159, 200);
            this.groupBoxPlayer1.TabIndex = 5;
            this.groupBoxPlayer1.TabStop = false;
            this.groupBoxPlayer1.Text = "Player 1";
            // 
            // labelPlayer1SpeedAmount
            // 
            this.labelPlayer1SpeedAmount.AutoSize = true;
            this.labelPlayer1SpeedAmount.Location = new System.Drawing.Point(133, 69);
            this.labelPlayer1SpeedAmount.Name = "labelPlayer1SpeedAmount";
            this.labelPlayer1SpeedAmount.Size = new System.Drawing.Size(20, 17);
            this.labelPlayer1SpeedAmount.TabIndex = 8;
            this.labelPlayer1SpeedAmount.Text = "...";
            // 
            // labelPlayer1MaxBombAmount
            // 
            this.labelPlayer1MaxBombAmount.AutoSize = true;
            this.labelPlayer1MaxBombAmount.Location = new System.Drawing.Point(133, 52);
            this.labelPlayer1MaxBombAmount.Name = "labelPlayer1MaxBombAmount";
            this.labelPlayer1MaxBombAmount.Size = new System.Drawing.Size(20, 17);
            this.labelPlayer1MaxBombAmount.TabIndex = 7;
            this.labelPlayer1MaxBombAmount.Text = "...";
            // 
            // labelPlayer1ExplosionPowerAmount
            // 
            this.labelPlayer1ExplosionPowerAmount.AutoSize = true;
            this.labelPlayer1ExplosionPowerAmount.Location = new System.Drawing.Point(133, 35);
            this.labelPlayer1ExplosionPowerAmount.Name = "labelPlayer1ExplosionPowerAmount";
            this.labelPlayer1ExplosionPowerAmount.Size = new System.Drawing.Size(20, 17);
            this.labelPlayer1ExplosionPowerAmount.TabIndex = 6;
            this.labelPlayer1ExplosionPowerAmount.Text = "...";
            // 
            // labelPlayer1Speed
            // 
            this.labelPlayer1Speed.AutoSize = true;
            this.labelPlayer1Speed.Location = new System.Drawing.Point(6, 69);
            this.labelPlayer1Speed.Name = "labelPlayer1Speed";
            this.labelPlayer1Speed.Size = new System.Drawing.Size(72, 17);
            this.labelPlayer1Speed.TabIndex = 4;
            this.labelPlayer1Speed.Text = "Szybkość:";
            // 
            // labelPlayer1MaxBomb
            // 
            this.labelPlayer1MaxBomb.AutoSize = true;
            this.labelPlayer1MaxBomb.Location = new System.Drawing.Point(6, 52);
            this.labelPlayer1MaxBomb.Name = "labelPlayer1MaxBomb";
            this.labelPlayer1MaxBomb.Size = new System.Drawing.Size(80, 17);
            this.labelPlayer1MaxBomb.TabIndex = 3;
            this.labelPlayer1MaxBomb.Text = "Max. bomb:";
            // 
            // labelPlayer1ExplosionPower
            // 
            this.labelPlayer1ExplosionPower.AutoSize = true;
            this.labelPlayer1ExplosionPower.Location = new System.Drawing.Point(6, 35);
            this.labelPlayer1ExplosionPower.Name = "labelPlayer1ExplosionPower";
            this.labelPlayer1ExplosionPower.Size = new System.Drawing.Size(93, 17);
            this.labelPlayer1ExplosionPower.TabIndex = 2;
            this.labelPlayer1ExplosionPower.Text = "Siła eksplozji:";
            // 
            // labelPlayer1HpAmount
            // 
            this.labelPlayer1HpAmount.AutoSize = true;
            this.labelPlayer1HpAmount.Location = new System.Drawing.Point(133, 18);
            this.labelPlayer1HpAmount.Name = "labelPlayer1HpAmount";
            this.labelPlayer1HpAmount.Size = new System.Drawing.Size(20, 17);
            this.labelPlayer1HpAmount.TabIndex = 1;
            this.labelPlayer1HpAmount.Text = "...";
            // 
            // labelPlayer1Hp
            // 
            this.labelPlayer1Hp.AutoSize = true;
            this.labelPlayer1Hp.Location = new System.Drawing.Point(6, 18);
            this.labelPlayer1Hp.Name = "labelPlayer1Hp";
            this.labelPlayer1Hp.Size = new System.Drawing.Size(30, 17);
            this.labelPlayer1Hp.TabIndex = 0;
            this.labelPlayer1Hp.Text = "Hp:";
            // 
            // groupBoxPlayer2
            // 
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2SpeedAmount);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2MaxBombAmount);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2ExplosionPowerAmount);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2Speed);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2MaxBomb);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2ExplosionPower);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2HpAmount);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2Hp);
            this.groupBoxPlayer2.Location = new System.Drawing.Point(3, 209);
            this.groupBoxPlayer2.Name = "groupBoxPlayer2";
            this.groupBoxPlayer2.Size = new System.Drawing.Size(159, 200);
            this.groupBoxPlayer2.TabIndex = 6;
            this.groupBoxPlayer2.TabStop = false;
            this.groupBoxPlayer2.Text = "Player2";
            // 
            // labelPlayer2SpeedAmount
            // 
            this.labelPlayer2SpeedAmount.AutoSize = true;
            this.labelPlayer2SpeedAmount.Location = new System.Drawing.Point(133, 69);
            this.labelPlayer2SpeedAmount.Name = "labelPlayer2SpeedAmount";
            this.labelPlayer2SpeedAmount.Size = new System.Drawing.Size(20, 17);
            this.labelPlayer2SpeedAmount.TabIndex = 14;
            this.labelPlayer2SpeedAmount.Text = "...";
            // 
            // labelPlayer2MaxBombAmount
            // 
            this.labelPlayer2MaxBombAmount.AutoSize = true;
            this.labelPlayer2MaxBombAmount.Location = new System.Drawing.Point(133, 52);
            this.labelPlayer2MaxBombAmount.Name = "labelPlayer2MaxBombAmount";
            this.labelPlayer2MaxBombAmount.Size = new System.Drawing.Size(20, 17);
            this.labelPlayer2MaxBombAmount.TabIndex = 13;
            this.labelPlayer2MaxBombAmount.Text = "...";
            // 
            // labelPlayer2ExplosionPowerAmount
            // 
            this.labelPlayer2ExplosionPowerAmount.AutoSize = true;
            this.labelPlayer2ExplosionPowerAmount.Location = new System.Drawing.Point(133, 35);
            this.labelPlayer2ExplosionPowerAmount.Name = "labelPlayer2ExplosionPowerAmount";
            this.labelPlayer2ExplosionPowerAmount.Size = new System.Drawing.Size(20, 17);
            this.labelPlayer2ExplosionPowerAmount.TabIndex = 12;
            this.labelPlayer2ExplosionPowerAmount.Text = "...";
            // 
            // labelPlayer2Speed
            // 
            this.labelPlayer2Speed.AutoSize = true;
            this.labelPlayer2Speed.Location = new System.Drawing.Point(6, 69);
            this.labelPlayer2Speed.Name = "labelPlayer2Speed";
            this.labelPlayer2Speed.Size = new System.Drawing.Size(72, 17);
            this.labelPlayer2Speed.TabIndex = 11;
            this.labelPlayer2Speed.Text = "Szybkość:";
            // 
            // labelPlayer2MaxBomb
            // 
            this.labelPlayer2MaxBomb.AutoSize = true;
            this.labelPlayer2MaxBomb.Location = new System.Drawing.Point(6, 52);
            this.labelPlayer2MaxBomb.Name = "labelPlayer2MaxBomb";
            this.labelPlayer2MaxBomb.Size = new System.Drawing.Size(80, 17);
            this.labelPlayer2MaxBomb.TabIndex = 10;
            this.labelPlayer2MaxBomb.Text = "Max. bomb:";
            // 
            // labelPlayer2ExplosionPower
            // 
            this.labelPlayer2ExplosionPower.AutoSize = true;
            this.labelPlayer2ExplosionPower.Location = new System.Drawing.Point(6, 35);
            this.labelPlayer2ExplosionPower.Name = "labelPlayer2ExplosionPower";
            this.labelPlayer2ExplosionPower.Size = new System.Drawing.Size(93, 17);
            this.labelPlayer2ExplosionPower.TabIndex = 9;
            this.labelPlayer2ExplosionPower.Text = "Siła eksplozji:";
            // 
            // labelPlayer2HpAmount
            // 
            this.labelPlayer2HpAmount.AutoSize = true;
            this.labelPlayer2HpAmount.Location = new System.Drawing.Point(133, 18);
            this.labelPlayer2HpAmount.Name = "labelPlayer2HpAmount";
            this.labelPlayer2HpAmount.Size = new System.Drawing.Size(20, 17);
            this.labelPlayer2HpAmount.TabIndex = 3;
            this.labelPlayer2HpAmount.Text = "...";
            // 
            // labelPlayer2Hp
            // 
            this.labelPlayer2Hp.AutoSize = true;
            this.labelPlayer2Hp.Location = new System.Drawing.Point(6, 18);
            this.labelPlayer2Hp.Name = "labelPlayer2Hp";
            this.labelPlayer2Hp.Size = new System.Drawing.Size(30, 17);
            this.labelPlayer2Hp.TabIndex = 2;
            this.labelPlayer2Hp.Text = "Hp:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(3, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(123, 23);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start Game";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelDebug
            // 
            this.panelDebug.Controls.Add(this.buttonStart);
            this.panelDebug.Controls.Add(this.buttonDrawMap);
            this.panelDebug.Controls.Add(this.textBoxCursorPosition);
            this.panelDebug.Controls.Add(this.buttonClearExplosions);
            this.panelDebug.Controls.Add(this.buttonSpawnPlayers);
            this.panelDebug.Location = new System.Drawing.Point(1017, 508);
            this.panelDebug.Name = "panelDebug";
            this.panelDebug.Size = new System.Drawing.Size(129, 146);
            this.panelDebug.TabIndex = 0;
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.groupBoxPlayer1);
            this.panelStats.Controls.Add(this.groupBoxPlayer2);
            this.panelStats.Location = new System.Drawing.Point(1017, 10);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(190, 492);
            this.panelStats.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 833);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelDebug);
            this.Controls.Add(this.panelGame);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.groupBoxPlayer1.ResumeLayout(false);
            this.groupBoxPlayer1.PerformLayout();
            this.groupBoxPlayer2.ResumeLayout(false);
            this.groupBoxPlayer2.PerformLayout();
            this.panelDebug.ResumeLayout(false);
            this.panelDebug.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Button buttonDrawMap;
        private System.Windows.Forms.TextBox textBoxCursorPosition;
        private System.Windows.Forms.Button buttonSpawnPlayers;
        private System.Windows.Forms.Button buttonClearExplosions;
        private System.Windows.Forms.GroupBox groupBoxPlayer1;
        private System.Windows.Forms.Label labelPlayer1HpAmount;
        private System.Windows.Forms.Label labelPlayer1Hp;
        private System.Windows.Forms.GroupBox groupBoxPlayer2;
        private System.Windows.Forms.Label labelPlayer2HpAmount;
        private System.Windows.Forms.Label labelPlayer2Hp;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panelDebug;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.Label labelPlayer1SpeedAmount;
        private System.Windows.Forms.Label labelPlayer1MaxBombAmount;
        private System.Windows.Forms.Label labelPlayer1ExplosionPowerAmount;
        private System.Windows.Forms.Label labelPlayer1Speed;
        private System.Windows.Forms.Label labelPlayer1MaxBomb;
        private System.Windows.Forms.Label labelPlayer1ExplosionPower;
        private System.Windows.Forms.Label labelPlayer2SpeedAmount;
        private System.Windows.Forms.Label labelPlayer2MaxBombAmount;
        private System.Windows.Forms.Label labelPlayer2ExplosionPowerAmount;
        private System.Windows.Forms.Label labelPlayer2Speed;
        private System.Windows.Forms.Label labelPlayer2MaxBomb;
        private System.Windows.Forms.Label labelPlayer2ExplosionPower;
    }
}

