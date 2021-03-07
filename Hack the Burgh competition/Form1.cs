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
        List<Panel> listPanel = new List<Panel>(); // stores previous pages
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
            listPanel.Add(next);

        }
        private void btnStats_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlMenu, pnlInformation);

            lblInfoTitle.Text = btnStats.Text;
            lblInfo.Text = readfile("Player information", "Portfolio.txt");

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
            if (listPanel.Count > 1)
            {
                Panel curr = listPanel[listPanel.Count - 1];
                curr.Visible = false;
                listPanel.RemoveAt(listPanel.Count - 1);

                Panel prev = listPanel[listPanel.Count - 1];
                prev.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(pnlMenu);
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

        private void btnChallenges_Click(object sender, EventArgs e)
        {
            ChangePanel(panel2, pnlChallenges);
            List<string> challengeNames = getChallengesNames();
            string currChallenge = getCurrentChallenge();
            List<Button> buttons = getChallengeButtons();

            // if no challenge started, only enable the first one
            if (currChallenge == "None")
            {
                foreach (Button button in buttons) button.Enabled = false;
                buttons[0].Enabled = true;
            }
            // if a challenge started, enable that challenge and all the previous ones
            else
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (i <= challengeNames.IndexOf(currChallenge))
                    {
                        buttons[i].Enabled = true;
                    }
                    else
                    {
                        buttons[i].Enabled = false;
                    }
                }
            }
        }

        private List<Button> getChallengeButtons()
        {
            // get list of challenge buttons in the correct order
            List<Button> buttons = new List<Button>();
            buttons.Add(btnChallenge1);
            buttons.Add(btnChallenge2);
            buttons.Add(btnChallenge3);
            buttons.Add(btnChallenge4);
            buttons.Add(btnChallenge5);
            return buttons;
        }
        
        private string getCurrentChallenge()
        {
            // uses portfolio to see what challenge they are currently working in - could be 'None'
            string[] portfolio = readfile("Player information", "Portfolio.txt").Split('\n');
            string name = "Challenge name not found";
            foreach (string item in portfolio)
            {
                if (item.Contains("Challenge name"))
                {
                    name = item.Split(':')[1].Trim();
                }
            }
            return name;
        }

        private List<string> getChallengesNames()
        {
            // gets names of the different challenges using the text used in the challenge buttons
            List<string> challengeNames = new List<string>();
            challengeNames.Add(btnChallenge1.Text);
            challengeNames.Add(btnChallenge2.Text);
            challengeNames.Add(btnChallenge3.Text);
            challengeNames.Add(btnChallenge4.Text);
            challengeNames.Add(btnChallenge5.Text);
            return challengeNames;
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

        private void LoadData()
        {
            //if (makeQuery("challenge", "yyyy-dd-mm", "Viewing mode") == "success")
            //{
                // file path
                string cwd = Directory.GetCurrentDirectory();
                // moves cwd back 2 spaces (to access the folder where the files are kept)
                List<string> filedir = cwd.Split('\\').ToList();
                filedir.RemoveRange(filedir.Count - 2, 2);
                string path = String.Join("\\", filedir.ToArray()) + '\\' + "Data" + '\\' + "Queried Data.txt";


                DataTable dt = new DataTable();
                dt.Columns.Add("X_Value", typeof(double));
                dt.Columns.Add("Y_Value", typeof(double));

                StreamReader sr = new StreamReader(@path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] strarr = line.Split(',');
                    dt.Rows.Add(strarr[0], strarr[1]);
                }
                chart1.DataSource = dt;
                chart1.Series["Series1"].XValueMember = "X_Value";
                chart1.Series["Series1"].YValueMembers = "Y_Value";
                //chart1.Series["Series1"].ChartType = SeriesChartType.Line;
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
                if (sr != null) sr.Close();
            //}
            
        }
        
        private void btnChallenge1_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlChallenges, pnlChallenge1);
            lblChallengeStats.Text = readfile("Player information", "Portfolio.txt");
        }

        private void btnChallenge2_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlChallenges, pnlChallenge1);
        }

        private void btnChallenge3_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlChallenges, pnlChallenge1);
        }

        private void btnChallenge4_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlChallenges, pnlChallenge1);
        }

        private void btnChallenge5_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlChallenges, pnlChallenge1);
        }

        private void pnlChallenge1_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlChallenge1.Visible)
            {
                lblChallengeStats.Text = readfile("Player information", "Portfolio.txt");
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                if (txtQuantity.Text == "Enter amount you want to buy / sell")
                {
                    txtQuantity.Text = "";
                    Font font = new Font(new FontFamily("Arial"), 8.0f, FontStyle.Italic);
                    txtQuantity.Font = font;
                    txtQuantity.ForeColor = Color.Black;

                }
                txtQuantity.Text += e.KeyChar;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtQuantity.Text.Length > 0 && txtQuantity.Text != "Enter amount you want to buy / sell")
                {
                    List<char> txt = txtQuantity.Text.ToList();
                    txt.RemoveAt(txt.Count - 1);
                    txtQuantity.Text = String.Join("", txt);
                }
                if (txtQuantity.TextLength == 0)
                {
                    Font font = new Font(new FontFamily("Microsoft Sans Serif"), 8.0f, FontStyle.Regular);
                    txtQuantity.Font = font;
                    txtQuantity.ForeColor = Color.Gray;
                    txtQuantity.Text = "Enter amount you want to buy / sell";
                }
            }
            txtQuantity.SelectionStart = txtQuantity.Text.Length;
            txtQuantity.SelectionLength = 0;
            e.Handled = true;
        }

        private void txtQuantity_MouseClick(object sender, MouseEventArgs e)
        {
            txtQuantity.SelectionStart = txtQuantity.Text.Length;
            txtQuantity.SelectionLength = 0;
        }

        private void txtTimeVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                if (txtTimeVal.Text == "Enter value")
                {
                    txtTimeVal.Text = "";
                    Font font = new Font(new FontFamily("Arial"), 8.0f, FontStyle.Italic);
                    txtTimeVal.Font = font;
                    txtTimeVal.ForeColor = Color.Black;

                }
                txtTimeVal.Text += e.KeyChar;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtTimeVal.Text.Length > 0 && txtTimeVal.Text != "Enter value")
                {
                    List<char> txt = txtTimeVal.Text.ToList();
                    txt.RemoveAt(txt.Count - 1);
                    txtTimeVal.Text = String.Join("", txt);
                }
                if (txtTimeVal.TextLength == 0)
                {
                    Font font = new Font(new FontFamily("Microsoft Sans Serif"), 8.0f, FontStyle.Regular);
                    txtTimeVal.Font = font;
                    txtTimeVal.ForeColor = Color.Gray;
                    txtTimeVal.Text = "Enter value";
                }
            }
            txtTimeVal.SelectionStart = txtTimeVal.Text.Length;
            txtTimeVal.SelectionLength = 0;
            e.Handled = true;
        }

        private void txtTimeVal_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimeVal.SelectionStart = txtQuantity.Text.Length;
            txtTimeVal.SelectionLength = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbViewingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbViewingMode.SelectedItem.ToString() == "Year view")
            {
                cbYear.Enabled = true;
                cbMonth.Enabled = false;
                cbDate.Enabled = false;
            }

            if (cbViewingMode.SelectedItem.ToString() == "Month view")
            {
                cbYear.Enabled = true;
                cbMonth.Enabled = false;
                cbDate.Enabled = false;
            }

            if (cbViewingMode.SelectedItem.ToString() == "Day view")
            {
                cbYear.Enabled = true;
                cbMonth.Enabled = true;
                cbDate.Enabled = true;
            }

        }

        /*
        Tasks:

        */

    }
}
