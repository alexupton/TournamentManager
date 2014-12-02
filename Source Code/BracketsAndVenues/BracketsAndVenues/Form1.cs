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
        public Form1()
        {
            InitializeComponent();
            mainBracket = new Bracket();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "Text Files (*.txt) | *.txt";
            load.ShowDialog();
            StreamReader sr = new StreamReader(load.FileName);

            StringBuilder sb = new StringBuilder(sr.ReadToEnd());
            sr.Close();

            string[] lines = sb.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            List<Team> teams = new List<Team>();
            for(int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(',');
                string name = line[0];
                int seed = Int32.Parse(line[1]);
                int wins = Int32.Parse(line[2]);
                teams.Add(new Team(name, seed, wins));
            }
            mainBracket = new Bracket(teams);
            saveToolStripMenuItem.Enabled = true;
            FilePath = load.FileName;


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilePath == "")
            {
                Save(false);
            }
            else
                Save(true);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainBracket.IsDirty == false)
            {
                this.Close();
            }
            else
            {
                
               DialogResult saveOption = MessageBox.Show("Do you want to save first?,", "Exit", MessageBoxButtons.YesNo);
               if (saveOption == DialogResult.Yes)
               {
                   if (FilePath != "")
                       Save(false);
                   else
                       Save(true);
               }
               else
               {
                   this.Close();
               }
                
            }
        }

        private void Save(bool saveAs)
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
                try
                {
                    File.WriteAllText(FilePath, sb.ToString());
                }
                catch
                {
                    MessageBox.Show("File cannot be overwritten because it is in use by another process");
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(true);
        }
    }
}
