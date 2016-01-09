namespace Culminating
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameNewGameBeginner = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameNewGameIntermediate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameNewGameExpert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGameExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.picClock = new System.Windows.Forms.PictureBox();
            this.lblSecondsElapsed = new System.Windows.Forms.Label();
            this.picPeanut = new System.Windows.Forms.PictureBox();
            this.lblPeanutsLeft = new System.Windows.Forms.Label();
            this.mnuGameHighscores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPeanut)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGame,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(454, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuGame
            // 
            this.mnuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGameNewGame,
            this.mnuGameHighscores,
            this.toolStripMenuItem1,
            this.mnuGameExit});
            this.mnuGame.Name = "mnuGame";
            this.mnuGame.Size = new System.Drawing.Size(46, 20);
            this.mnuGame.Text = "Game";
            // 
            // mnuGameNewGame
            // 
            this.mnuGameNewGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGameNewGameBeginner,
            this.mnuGameNewGameIntermediate,
            this.mnuGameNewGameExpert});
            this.mnuGameNewGame.Name = "mnuGameNewGame";
            this.mnuGameNewGame.Size = new System.Drawing.Size(152, 22);
            this.mnuGameNewGame.Text = "New Game";
            // 
            // mnuGameNewGameBeginner
            // 
            this.mnuGameNewGameBeginner.Name = "mnuGameNewGameBeginner";
            this.mnuGameNewGameBeginner.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mnuGameNewGameBeginner.Size = new System.Drawing.Size(183, 22);
            this.mnuGameNewGameBeginner.Text = "Beginner";
            this.mnuGameNewGameBeginner.Click += new System.EventHandler(this.mnuGameNewGameBeginner_Click);
            // 
            // mnuGameNewGameIntermediate
            // 
            this.mnuGameNewGameIntermediate.Name = "mnuGameNewGameIntermediate";
            this.mnuGameNewGameIntermediate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuGameNewGameIntermediate.Size = new System.Drawing.Size(183, 22);
            this.mnuGameNewGameIntermediate.Text = "Intermediate";
            this.mnuGameNewGameIntermediate.Click += new System.EventHandler(this.mnuGameNewGameIntermediate_Click);
            // 
            // mnuGameNewGameExpert
            // 
            this.mnuGameNewGameExpert.Name = "mnuGameNewGameExpert";
            this.mnuGameNewGameExpert.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuGameNewGameExpert.Size = new System.Drawing.Size(183, 22);
            this.mnuGameNewGameExpert.Text = "Expert";
            this.mnuGameNewGameExpert.Click += new System.EventHandler(this.mnuGameNewGameExpert_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuGameExit
            // 
            this.mnuGameExit.Name = "mnuGameExit";
            this.mnuGameExit.Size = new System.Drawing.Size(152, 22);
            this.mnuGameExit.Text = "Exit";
            this.mnuGameExit.Click += new System.EventHandler(this.mnuGameExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // picClock
            // 
            this.picClock.BackColor = System.Drawing.Color.Transparent;
            this.picClock.Image = global::Culminating.Properties.Resources.GameClock;
            this.picClock.Location = new System.Drawing.Point(50, 36);
            this.picClock.Name = "picClock";
            this.picClock.Size = new System.Drawing.Size(26, 26);
            this.picClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClock.TabIndex = 1;
            this.picClock.TabStop = false;
            // 
            // lblSecondsElapsed
            // 
            this.lblSecondsElapsed.BackColor = System.Drawing.Color.Black;
            this.lblSecondsElapsed.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondsElapsed.ForeColor = System.Drawing.Color.White;
            this.lblSecondsElapsed.Location = new System.Drawing.Point(82, 41);
            this.lblSecondsElapsed.Name = "lblSecondsElapsed";
            this.lblSecondsElapsed.Size = new System.Drawing.Size(62, 18);
            this.lblSecondsElapsed.TabIndex = 2;
            this.lblSecondsElapsed.Text = "0";
            this.lblSecondsElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picPeanut
            // 
            this.picPeanut.BackColor = System.Drawing.Color.Transparent;
            this.picPeanut.Image = global::Culminating.Properties.Resources.GamePeanut;
            this.picPeanut.Location = new System.Drawing.Point(172, 36);
            this.picPeanut.Name = "picPeanut";
            this.picPeanut.Size = new System.Drawing.Size(26, 26);
            this.picPeanut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPeanut.TabIndex = 3;
            this.picPeanut.TabStop = false;
            // 
            // lblPeanutsLeft
            // 
            this.lblPeanutsLeft.BackColor = System.Drawing.Color.Black;
            this.lblPeanutsLeft.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeanutsLeft.ForeColor = System.Drawing.Color.White;
            this.lblPeanutsLeft.Location = new System.Drawing.Point(204, 41);
            this.lblPeanutsLeft.Name = "lblPeanutsLeft";
            this.lblPeanutsLeft.Size = new System.Drawing.Size(62, 18);
            this.lblPeanutsLeft.TabIndex = 4;
            this.lblPeanutsLeft.Text = "0";
            this.lblPeanutsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mnuGameHighscores
            // 
            this.mnuGameHighscores.Name = "mnuGameHighscores";
            this.mnuGameHighscores.Size = new System.Drawing.Size(152, 22);
            this.mnuGameHighscores.Text = "Highscores...";
            this.mnuGameHighscores.Click += new System.EventHandler(this.mnuGameHighscores_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Culminating.Properties.Resources.VioletBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(454, 451);
            this.Controls.Add(this.lblPeanutsLeft);
            this.Controls.Add(this.picPeanut);
            this.Controls.Add(this.lblSecondsElapsed);
            this.Controls.Add(this.picClock);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chocolate Sweeper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPeanut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuGame;
        private System.Windows.Forms.ToolStripMenuItem mnuGameNewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuGameExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuGameNewGameBeginner;
        private System.Windows.Forms.ToolStripMenuItem mnuGameNewGameIntermediate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox picClock;
        private System.Windows.Forms.Label lblSecondsElapsed;
        private System.Windows.Forms.PictureBox picPeanut;
        private System.Windows.Forms.Label lblPeanutsLeft;
        private System.Windows.Forms.ToolStripMenuItem mnuGameNewGameExpert;
        private System.Windows.Forms.ToolStripMenuItem mnuGameHighscores;
    }
}

