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
<<<<<<< HEAD
        private int[][] NameLocs { get; set; }
=======
        private List<int[]> TextPositions { get; set; }
>>>>>>> origin/master
        public Form1()
        {
            InitializeComponent();
            mainBracket = new Bracket();
            TextPositions = new List<int[]>();
        }

        //load in team file. right now it is plain text. this is subject to change
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "Text Files (*.txt) | *.txt";
            load.ShowDialog();
            if (load.FileName != "")
            {
                StreamReader sr = new StreamReader(load.FileName);

                StringBuilder sb = new StringBuilder(sr.ReadToEnd());
                sr.Close();


<<<<<<< HEAD
            List<Team> teams = new List<Team>();
            try
            {
=======
                //parse the file
                string[] lines = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                List<Team> teams = new List<Team>();
>>>>>>> origin/master
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] line = lines[i].Split(',');
                    string name = line[0];
                    int seed = Int32.Parse(line[1]);
                    int wins = Int32.Parse(line[2]);
                    teams.Add(new Team(name, seed, wins));
                }
<<<<<<< HEAD
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
                case 4: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\4_team_bracket.png"; break;
                default:
                    {
                        pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\32_team_bracket.png";
                        sr = new StreamReader(Environment.CurrentDirectory + "\\32_locations.txt");
                        successfulRead = true;
                        break;
                    }
        }
            if (successfulRead)
            {
                NameLocs = new int[mainBracket.teams.Count][];
                sb = new StringBuilder(sr.ReadToEnd());
                lines = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < mainBracket.teams.Count; i++)
                {
                    string[] halfLines = lines[i].Split(':');
                    string[] coords = halfLines[1].Split(',');
                    NameLocs[i] = new int[] { Int32.Parse(coords[0]) + pictureBox1.Location.X, Int32.Parse(coords[1]) + pictureBox1.Location.Y };
                }
                string[] names = new string[mainBracket.teams.Count];
                for(int i = 0; i < names.Length; i++)
                {
                    names[i] = mainBracket.teams.ElementAt(i).Name;
                }
            }
            else
            {
                MessageBox.Show("Read error");
                return;
            }
=======
                mainBracket = new Bracket(teams);
                saveToolStripMenuItem.Enabled = true;
                FilePath = load.FileName;
                int numberOfTeams = lines.Length;

                //load the appropriate bracket image based on number of teams
                switch (numberOfTeams)
                {
                    case 4: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\4_team_bracket.png"; break;
                    case 8: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\8_team_bracket.png"; break;
                    case 16: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\16_team_bracket.png"; break;
                    default: pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\32_team_bracket.png"; break;
                }

                pictureBox1.Refresh();


                //all positions are stored in def files
                string positionPath;

                switch (numberOfTeams)
                {
                    case 4: positionPath = Environment.CurrentDirectory + "\\4_locations.txt"; break;
                    case 8: positionPath = Environment.CurrentDirectory + "\\8_locations.txt"; break;
                    case 16: positionPath = Environment.CurrentDirectory + "\\16_locations.txt"; break;
                    default: positionPath = Environment.CurrentDirectory + "\\32_locations.txt"; break;
                }

                //parse the def file
                sr = new StreamReader(positionPath);
                sb = new StringBuilder(sr.ReadToEnd());
                string[] posLines = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < posLines.Length; i++)
                {
                    string[] halfLine = posLines[i].Split(':');
                    string[] coords = halfLine[1].Split(',');
                    TextPositions.Add(new int[] { Int32.Parse(coords[0]) + 147, Int32.Parse(coords[1]) + 45 });
                }

                //draw names on bracket
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                using (Font myFont = new Font("Arial", 14))
                {
                    for (int i = 0; i < TextPositions.Count; i++)
                    {
                        if (mainBracket.teams.Count > i )
                        {
                            g.DrawString(mainBracket.teams.ElementAt(i).Name, myFont, Brushes.Black, new Point(TextPositions.ElementAt(i)[0], TextPositions.ElementAt(i)[1]));
                        }
                    }
                }
            }

            

            

>>>>>>> origin/master




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


    }
}
