using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BracketDemo
{
    public partial class Form1 : Form
    {
        private Bracket mainBracket{get; set;}
        private string FilePath { get; set; }
        private int[][] NameLocs { get; set; }
        private int MaxWins{get; set;}
        private Label[][] rounds{get; set;}

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBracket = new Bracket();
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "Text Files (*.txt) | *.txt";
            load.ShowDialog();
            if (load.FileName != "")
            {
                StreamReader sr = new StreamReader(load.FileName);

                StringBuilder sb = new StringBuilder(sr.ReadToEnd());
                sr.Close();

                string[] lines;
                List<Team> teams = new List<Team>();
                try
                {
                    //parse the file
                    lines = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] line = lines[i].Split(',');
                        string name = line[0];
                        int seed = Int32.Parse(line[1]);
                        int wins = Int32.Parse(line[2]);
                        teams.Add(new Team(name, seed, wins));
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid text format.", "We done goofed");
                    return;
                }
                mainBracket = new Bracket(teams);
                saveToolStripMenuItem.Enabled = true;
                FilePath = load.FileName;
                bool successfulRead = false;
                switch (lines.Length)
                {
                    case 4: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\4_team_bracket.png"; sr = new StreamReader(Environment.CurrentDirectory + "\\4_locations.txt"); break;
                    default:
                        {
                            pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\32_team_bracket.png";
                            sr = new StreamReader(Environment.CurrentDirectory + "\\32_locations.txt");
                            break;
                        }
                }

                successfulRead = true;
                if (successfulRead)
                {
                    //all positions are stored in def files
                    string positionPath;

                    int numberOfTeams = mainBracket.Teams.Count;

                    switch (numberOfTeams)
                    {
                        case 4: positionPath = Environment.CurrentDirectory + "\\4_locations.txt"; break;
                        case 8: positionPath = Environment.CurrentDirectory + "\\8_locations.txt"; break;
                        case 16: positionPath = Environment.CurrentDirectory + "\\16_locations.txt"; break;
                        case 32: positionPath = Environment.CurrentDirectory + "\\32_locations.txt"; break;
                        default: MessageBox.Show("Error loading locations.", "Uh - oh!"); return;
                    }

                    //parse the def file
                    sr = new StreamReader(positionPath);
                    sb = new StringBuilder(sr.ReadToEnd());
                    string[] posLines = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    NameLocs = new int[posLines.Length][];
                    for (int i = 0; i < posLines.Length; i++)
                    {
                        try
                        {
                            string[] halfLine = posLines[i].Split(':');
                            string[] coords = halfLine[1].Split(',');
                            if (i < NameLocs.Length)
                            {
                                NameLocs[i] = new int[] { Int32.Parse(coords[0]) + 100, Int32.Parse(coords[1]) + 25 };
                            }
                        }
                        catch { }
                    }



                    sb = new StringBuilder(sr.ReadToEnd());
                    lines = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    MaxWins = (int)Math.Log(numberOfTeams, 2);

                    rounds = new Label[MaxWins + 1][];

                    //DEMO EXCLUSIVE CODE
                    rounds[0] = new Label[8];
                    rounds[0][0] = label0;
                    rounds[0][1] = label1;
                    rounds[0][2] = label2;
                    rounds[0][3] = label3;
                    rounds[0][4] = label4;
                    rounds[0][5] = label5;
                    rounds[0][6] = label6;
                    rounds[0][7] = label7;

                    rounds[1] = new Label[4];
                    rounds[1][0] = label8;
                    rounds[1][1] = label9;
                    rounds[1][2] = label10;
                    rounds[1][3] = label11;

                    rounds[2] = new Label[2];
                    rounds[2][0] = label12;
                    rounds[2][1] = label13;

                    rounds[3] = new Label[1];
                    rounds[3][0] = label14;







                    for (int i = 0; i < mainBracket.Teams.Count; i++)
                    {
                        try
                        {
                            string[] halfLines = lines[i].Split(':');
                            string[] coords = halfLines[1].Split(',');
                            NameLocs[i] = new int[] { Int32.Parse(coords[0]) + pictureBox1.Location.X, Int32.Parse(coords[1]) + pictureBox1.Location.Y };
                        }
                        catch { }
                    }
                    string[] names = new string[mainBracket.Teams.Count];
                    for (int i = 0; i < mainBracket.Teams.Count; i++)
                    {
                        names[i] = mainBracket.Teams.ElementAt(i).Name;
                    }

                    //load the appropriate bracket image based on number of teams
                    switch (numberOfTeams)
                    {
                        case 4: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\4_team_bracket.png"; break;
                        case 8: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\8_team_bracket.png"; break;
                        case 16: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\16_team_bracket.png"; break;
                        case 32: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\32_team_bracket.png"; break;
                        default: MessageBox.Show("Error loading bracket.", "Uh - oh!"); return;
                    }
                }
                else
                {
                    MessageBox.Show("Read error");
                    return;
                }

                mainBracket = new Bracket(teams);
                saveToolStripMenuItem.Enabled = true;
                FilePath = load.FileName;




                int count = 0;
                int matchNum = 1;
                foreach (Team t in mainBracket.Teams)
                {
                    if (count % 2 == 0)
                    {
                        matchBox.Items.Add("Match " + matchNum);
                        matchNum++;
                    }
                    count++;
                }

                

                pictureBox1.Visible = true;
                matchBox.Visible = true;
                TopWin.Visible = true;
                BottomWin.Visible = true;
                groupBox1.Visible = true;
                groupBox1.BringToFront();
                pictureBox1.SendToBack();
                ResetBracket();
            }
        }
        

            private void ResetBracket()
            {
                for (int i = 0; i < rounds[0].Length; i++ )
                {
                    rounds[0][i].Text = mainBracket.Teams.ElementAt(i).Name;
                    rounds[0][i].Visible = true;
                }

                foreach (Team t in mainBracket.Teams)
                {
                    int TeamPosition = mainBracket.Teams.IndexOf(t);
                    if (t.Wins > 0)
                    {


                        switch (TeamPosition)
                        {
                            case 0:
                                {
                                    rounds[1][0].Text = t.Name;
                                    rounds[1][0].Visible = true;
                                    break;
                                }
                            case 1:
                                {
                                    rounds[1][0].Text = t.Name;
                                    rounds[1][0].Visible = true;
                                    break;
                                }
                            case 2:
                                {
                                    rounds[1][1].Text = t.Name;
                                    rounds[1][1].Visible = true;
                                    break;
                                }
                            case 3:
                                {
                                    rounds[1][1].Text = t.Name;
                                    rounds[1][1].Visible = true;
                                    break;
                                }
                            case 4:
                                {
                                    rounds[1][2].Text = t.Name;
                                    rounds[1][2].Visible = true;
                                    break;
                                }
                            case 5:
                                {
                                    rounds[1][2].Text = t.Name;
                                    rounds[1][2].Visible = true;
                                    break;
                                }
                            case 6:
                                {
                                    rounds[1][3].Text = t.Name;
                                    rounds[1][3].Visible = true;
                                    break;
                                }
                            case 7:
                                {
                                    rounds[1][3].Text = t.Name;
                                    rounds[1][3].Visible = true;
                                    break;
                                }
                            default: MessageBox.Show("Someting Terrible Has Happened"); break;
                        }
                        if (t.Wins > 1)
                        {

                            switch (TeamPosition)
                            {
                                case 0:
                                    {
                                        rounds[2][0].Text = t.Name;
                                        rounds[2][0].Visible = true;
                                        break;
                                    }
                                case 1:
                                    {
                                        rounds[2][0].Text = t.Name;
                                        rounds[2][0].Visible = true;
                                        break;
                                    }
                                case 2:
                                    {
                                        rounds[2][0].Text = t.Name;
                                        rounds[2][0].Visible = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        rounds[2][0].Text = t.Name;
                                        rounds[2][0].Visible = true;
                                        break;
                                    }
                                case 4:
                                    {
                                        rounds[2][1].Text = t.Name;
                                        rounds[2][1].Visible = true;
                                        break;
                                    }
                                case 5:
                                    {
                                        rounds[2][1].Text = t.Name;
                                        rounds[2][1].Visible = true;
                                        break;
                                    }
                                case 6:
                                    {
                                        rounds[2][1].Text = t.Name;
                                        rounds[2][1].Visible = true;
                                        break;
                                    }
                                case 7:
                                    {
                                        rounds[2][1].Text = t.Name;
                                        rounds[2][1].Visible = true;
                                        break;
                                    }
                                default: MessageBox.Show("Someting Terrible Has Happened"); break;
                            }
                        }
                        if (t.Wins > 2)
                        {

                            switch (TeamPosition)
                            {
                                case 0:
                                    {
                                        rounds[3][0].Text = t.Name;
                                        rounds[3][0].Visible = true;
                                        break;
                                    }
                                case 1:
                                    {
                                        rounds[3][0].Text = t.Name;
                                        rounds[3][0].Visible = true;
                                        break;
                                    }
                                case 2:
                                    {
                                        rounds[3][0].Text = t.Name;
                                        rounds[3][0].Visible = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        rounds[3][0].Text = t.Name;
                                        rounds[3][0].Visible = true;
                                        break;
                                    }
                                case 4:
                                    {
                                        rounds[3][0].Text = t.Name;
                                        rounds[3][0].Visible = true;
                                        break;
                                    }
                                case 5:
                                    {
                                        rounds[3][0].Text = t.Name;
                                        rounds[3][0].Visible = true;
                                        break;
                                    }
                                case 6:
                                    {
                                        rounds[3][0].Text = t.Name;
                                        rounds[3][0].Visible = true;
                                        break;
                                    }
                                case 7:
                                    {
                                        rounds[3][0].Text = t.Name;
                                        rounds[3][0].Visible = true;
                                        break;
                                    }
                                default: MessageBox.Show("Someting Terrible Has Happened"); break;
                            }
                        }
                    }
                }
            }
        }
    }

