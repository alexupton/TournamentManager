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

namespace BracketsAndVenues
{
    public partial class Form1 : Form
    {
        private Bracket mainBracket { get; set; }
        private string FilePath { get; set; }
        private int[][] NameLocs { get; set; }
        private List<int[]> TextPositions { get; set; }
        private Team[] SelectedTeam { get; set; }
        private int MatchIndex { get; set; }
        private int MaxWins { get; set; }
        private Label[][] rounds { get; set; }
        private Label[] thirdPlace { get; set; }
        public Form1()
        {
            InitializeComponent();
            mainBracket = new Bracket();
            TextPositions = new List<int[]>();
            SelectedTeam = new Team[2];
        }

        //load in team file. right now it is plain text. this is subject to change
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
            switch(lines.Length)
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

                int numberOfTeams = mainBracket.teams.Count;

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

                


                    for (int i = 0; i < mainBracket.teams.Count; i++)
                    {
                        try
                        {
                            string[] halfLines = lines[i].Split(':');
                            string[] coords = halfLines[1].Split(',');
                            NameLocs[i] = new int[] { Int32.Parse(coords[0]) + pictureBox1.Location.X, Int32.Parse(coords[1]) + pictureBox1.Location.Y };
                        }
                        catch { }
                    }
                string[] names = new string[mainBracket.teams.Count];
                for(int i = 0; i < mainBracket.teams.Count; i++)
                {
                    names[i] = mainBracket.teams.ElementAt(i).Name;
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
                

                



                

                



                
               

                //set up bracket
                ResetBracket();

                


            }

            

            





        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilePath == "")
            {
                Save(true);
            }
            else
                Save(false);
        }

        //Exit button Clicked
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if any changes have been made, offer to save if they have
            if (mainBracket.IsDirty == false)
            {
                this.Close();
            }
            else
            {
               DialogResult saveOption = MessageBox.Show("Do you want to save first?", "Exit", MessageBoxButtons.YesNoCancel);
               if (saveOption == DialogResult.Yes)
               {
                   if (FilePath != "")
                   {
                       if (!Save(false))
                           this.Close();
                           
                   }
                   else
                   {
                       Save(true);
                       this.Close();
                   }
               }
               else if(saveOption == DialogResult.No)
               {
                   this.Close();
               }
                
            }
        }

        //save function returns true if canceled, false otherwise
        private bool Save(bool saveAs)
        {
            if (mainBracket.teams.Count > 0)
            {
                if (saveAs)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Text File (*.txt) | *.txt";
                    save.ShowDialog();
                    FilePath = save.FileName;
                }

                StringBuilder sb = new StringBuilder();
                foreach (Team t in mainBracket.teams)
                {
                    string line = t.Name + "," + t.Seed.ToString() + "," + t.Wins.ToString();
                    sb.AppendLine(line);
                }
                if(FilePath == "")
                {
                    return true;
                }
                try
                {
                    File.WriteAllText(FilePath, sb.ToString());
                }
                catch
                {
                    MessageBox.Show("File cannot be overwritten because it is in use by another process");
                }
                return false;
            }
            return true;
        }
        //save as option clicked
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //top team wins
        private void button1_Click_1(object sender, EventArgs e)
        {
            Team1Win.Enabled = false;
            Team2Win.Enabled = true;

            //names[MatchIndex * 2].BackColor = Color.LightGreen;
            //names[MatchIndex * 2 + 1].BackColor = Color.PaleVioletRed;

            mainBracket.matchups.ElementAt(MatchIndex)[1].Unwin();
            mainBracket.matchups.ElementAt(MatchIndex)[0].Win();


                ResetBracket();


        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }
        //select match
        private void MatchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Team1Win.Visible = true;
            Team2Win.Visible = true;
            Team1Win.Enabled = true;
            Team2Win.Enabled = true;

            Team1Label.Visible = true;
            Team2Label.Visible = true;

            //if(SelectedTeam != null)
            //{
            //    if (names[MatchIndex * 2].BackColor != Color.LightGreen && names[MatchIndex * 2].BackColor != Color.PaleVioletRed)
            //    {
            //        names[MatchIndex * 2].BackColor = default(Color);
            //        names[MatchIndex * 2 + 1].BackColor = default(Color);
            //    }
            //}

            SelectedTeam = mainBracket.matchups.ElementAt(MatchBox.SelectedIndex);
            MatchIndex = MatchBox.SelectedIndex;

            int nameLabelIndex = MatchBox.SelectedIndex * 2;

            //names[nameLabelIndex].BackColor = Color.Aqua;
            //names[nameLabelIndex + 1].BackColor = Color.Aqua;

            
        }

        //bottom team wins
        private void Team2Win_Click(object sender, EventArgs e)
        {
            Team2Win.Enabled = false;
            Team1Win.Enabled = true;
            //names[MatchIndex * 2 + 1].BackColor = Color.LightGreen;
            //names[MatchIndex * 2].BackColor = Color.PaleVioletRed;
            mainBracket.matchups.ElementAt(MatchIndex)[0].Unwin();
            mainBracket.matchups.ElementAt(MatchIndex)[1].Win();
            mainBracket.IsDirty = true;

            for (int i = 0; i < mainBracket.teams.Count; i++)
            {
                if (mainBracket.teams.ElementAt(i).Name == mainBracket.matchups.ElementAt(MatchIndex)[1].Name)
                {

                    mainBracket.teams.RemoveAt(i);
                    mainBracket.teams.Insert(i, mainBracket.matchups.ElementAt(MatchIndex)[1]);
                }
            }

            ResetBracket();

        }

        private void ResetBracket()
        {

            string[] tNames = new string[mainBracket.teams.Count];
            for (int i = 0; i < mainBracket.teams.Count; i++)
            {
                tNames[i] = mainBracket.teams.ElementAt(i).Name;
            }
            //initial label generation
            this.GenerateLabels(NameLocs, tNames);
            MatchBox.Items.Clear();
            int count = 1;
            foreach (Team[] t in mainBracket.matchups)
            {
                MatchBox.Items.Add("Match " + count);
                count++;
            }

            foreach (Team t in mainBracket.teams)
            {
                for(int i = 1; i <= t.Wins; i++)
                {
                    rounds[i][i / 2].Text = t.Name;
                    rounds[i][i / 2].BringToFront();
                }
            }
            MatchBox.Visible = true;
            MatchBox.Enabled = true;
            EditLabel.Visible = true;
        }

    }
}
