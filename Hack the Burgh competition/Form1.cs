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

namespace Hack_the_Burgh_competition
{
    public partial class Form1 : Form
    {
        List<Panel> listpanel = new List<Panel>(); // stores previous pages
        public Form1()
        {
            InitializeComponent();
        }

        private void ChangePanel(Panel old, Panel next)
        {
            // makes current panel invisible and changes to a new one
            old.Visible = false;
            next.Visible = true;
            next.BringToFront();
            listpanel.Add(next);

        }
        private void btnStats_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlMenu, pnlInformation);

            lblInfoTitle.Text = btnStats.Text;
            lblInfo.Text = readfile("Player information", "Stats.txt");

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlMenu, panel2);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlMenu, pnlSettings);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (listpanel.Count > 1)
            {
                Panel curr = listpanel[listpanel.Count - 1];
                curr.Visible = false;
                listpanel.RemoveAt(listpanel.Count - 1);

                Panel prev = listpanel[listpanel.Count - 1];
                prev.Visible = true;
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listpanel.Add(pnlMenu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePanel(panel2, pnlTraining);
        }

        private void btnTerminologies_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlTraining, pnlInformation);

            lblInfoTitle.Text = btnTerminologies.Text;
            lblInfo.Text = readfile("Training information", "Sample.txt");
        }

        private void btnConcept1_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlTraining, pnlInformation);

            lblInfoTitle.Text = btnConcept1.Text;
            lblInfo.Text = readfile("Training information", "Concept 1.txt");
        }

        private void btnConcept2_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlTraining, pnlInformation);

            lblInfoTitle.Text = btnConcept2.Text;
            lblInfo.Text = readfile("Training information", "Concept 2.txt");
        }

        private string readfile(string dirName, string fileName)
        {
            // reads the file of the given name, which will contain information for the chosen topic

            string cwd = Directory.GetCurrentDirectory();
            // moves cwd back 2 spaces (to access the folder where the files are kept)
            List<string> filedir = cwd.Split('\\').ToList();
            filedir.RemoveRange(filedir.Count - 2, 2);
            string path = String.Join("\\", filedir.ToArray()) + '\\' + dirName + '\\' + fileName;

            string information = "";
            if (!File.Exists(@path))
            {
                information = "Couldn't find file at: " + path;
            }
            else
            {
                information = File.ReadAllText(@path);
            }
            return information;
        } ///

        private void pnlInformation_VisibleChanged(object sender, EventArgs e)
        {

        }

    }
}
