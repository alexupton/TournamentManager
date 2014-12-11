namespace BracketsAndVenues
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MatchBox = new System.Windows.Forms.ComboBox();
            this.EditLabel = new System.Windows.Forms.Label();
            this.Team1Label = new System.Windows.Forms.Label();
            this.Team1Win = new System.Windows.Forms.Button();
            this.Team2Label = new System.Windows.Forms.Label();
            this.Team2Win = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(144, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(880, 800);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MatchBox
            // 
            this.MatchBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MatchBox.FormattingEnabled = true;
            this.MatchBox.Location = new System.Drawing.Point(884, 74);
            this.MatchBox.Name = "MatchBox";
            this.MatchBox.Size = new System.Drawing.Size(121, 21);
            this.MatchBox.TabIndex = 4;
            this.MatchBox.Visible = false;
            this.MatchBox.SelectedIndexChanged += new System.EventHandler(this.MatchBox_SelectedIndexChanged);
            // 
            // EditLabel
            // 
            this.EditLabel.AutoSize = true;
            this.EditLabel.Location = new System.Drawing.Point(820, 77);
            this.EditLabel.Name = "EditLabel";
            this.EditLabel.Size = new System.Drawing.Size(58, 13);
            this.EditLabel.TabIndex = 5;
            this.EditLabel.Text = "Edit Match";
            this.EditLabel.Visible = false;
            this.EditLabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // Team1Label
            // 
            this.Team1Label.AutoSize = true;
            this.Team1Label.Location = new System.Drawing.Point(1021, 53);
            this.Team1Label.Name = "Team1Label";
            this.Team1Label.Size = new System.Drawing.Size(43, 13);
            this.Team1Label.TabIndex = 6;
            this.Team1Label.Text = "Team 1";
            this.Team1Label.Visible = false;
            this.Team1Label.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // Team1Win
            // 
            this.Team1Win.Enabled = false;
            this.Team1Win.Location = new System.Drawing.Point(1070, 48);
            this.Team1Win.Name = "Team1Win";
            this.Team1Win.Size = new System.Drawing.Size(75, 23);
            this.Team1Win.TabIndex = 7;
            this.Team1Win.Text = "Win";
            this.Team1Win.UseVisualStyleBackColor = true;
            this.Team1Win.Visible = false;
            this.Team1Win.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Team2Label
            // 
            this.Team2Label.AutoSize = true;
            this.Team2Label.Location = new System.Drawing.Point(1021, 101);
            this.Team2Label.Name = "Team2Label";
            this.Team2Label.Size = new System.Drawing.Size(43, 13);
            this.Team2Label.TabIndex = 8;
            this.Team2Label.Text = "Team 2";
            this.Team2Label.Visible = false;
            // 
            // Team2Win
            // 
            this.Team2Win.Enabled = false;
            this.Team2Win.Location = new System.Drawing.Point(1070, 96);
            this.Team2Win.Name = "Team2Win";
            this.Team2Win.Size = new System.Drawing.Size(75, 23);
            this.Team2Win.TabIndex = 9;
            this.Team2Win.Text = "Win";
            this.Team2Win.UseVisualStyleBackColor = true;
            this.Team2Win.Visible = false;
            this.Team2Win.Click += new System.EventHandler(this.Team2Win_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.Team2Win);
            this.Controls.Add(this.Team2Label);
            this.Controls.Add(this.Team1Win);
            this.Controls.Add(this.Team1Label);
            this.Controls.Add(this.EditLabel);
            this.Controls.Add(this.MatchBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Bracket Manager v0.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GenerateLabels(int[][] coordinates, string[] teamNames)
        {
            //delete any existing names
            if(names != null)
            {
                for(int i = 0; i < names.Length; i++)
                {
                    this.Controls.Remove(names[i]);
                }
            }
            //add new labels

            int roundSize = mainBracket.teams.Count * 2;
            for (int i = 0; i < rounds.Length; i++)
            {
                rounds[i] = new System.Windows.Forms.Label[roundSize / 2 ];
                roundSize /= 2;
            }

            for (int i = 0; i < rounds.Length; i++ )
            {
                for(int j = 0; j < rounds[i].Length; j++)
                {
                    rounds[i][j] = new System.Windows.Forms.Label();
                    rounds[i][j].AutoSize = true;
                    rounds[i][j].Location = new System.Drawing.Point(coordinates[j][0], coordinates[j][1]);
                    rounds[i][j].Name = "Label " + i.ToString();
                    rounds[i][j].Size = new System.Drawing.Size(35, 13);
                    rounds[i][j].TabIndex = i + 4;
                    if (j < teamNames.Length && i == 0)
                    {
                        rounds[i][j].Text = teamNames[j];
                    }
                    else
                    {
                        rounds[i][j].Text = "AssAssAss";
                    }
                }
            }
            for (int i = 0; i < rounds.Length; i++)
            {
                for (int j = 0; j < rounds[i].Length; j++)
                {
                    this.Controls.Add(rounds[i][j]);
                    rounds[i][j].BringToFront();
                }
            }
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label[] names;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox MatchBox;
        private System.Windows.Forms.Label EditLabel;
        private System.Windows.Forms.Label Team1Label;
        private System.Windows.Forms.Button Team1Win;
        private System.Windows.Forms.Label Team2Label;
        private System.Windows.Forms.Button Team2Win;
    }
}

