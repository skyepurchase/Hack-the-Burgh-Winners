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
        Model model = new Model();
        public Form1()
        {
            InitializeComponent();
        }

        // Utility functions
        private void ChangePanel(Panel old, Panel next)
        {
            // makes current panel invisible and changes to a new one
            old.Visible = false;
            next.Visible = true;
            next.BringToFront();
            listPanel.Add(next);

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
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (listPanel.Count > 1)  // if not in starting page
            {
                Panel curr = listPanel[listPanel.Count - 1];  // make current page invisible and remove it from list
                curr.Visible = false;
                listPanel.RemoveAt(listPanel.Count - 1);

                Panel prev = listPanel[listPanel.Count - 1];  // move to last page in list
                prev.Visible = true;
            }
        }

        private string makeTwoDigit(int i)
        {
            string rv;
            if (i < 10)
            {
                rv = String.Concat('0', char.Parse(i.ToString()));
            }
            else
            {
                rv = i.ToString();
            }
            return rv;
        }

        
        // Main menu page
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

        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(pnlMenu);
        }

        // Start page
        private void button1_Click(object sender, EventArgs e)
        {
            ChangePanel(panel2, pnlTraining);
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

        // Training page
        private void btnIntroduction_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlTraining, pnlInformation);

            lblInfoTitle.Text = btnIntroduction.Text;
            lblInfo.Text = readfile("Training information", "Introduction.txt");
        }

        private void btnFinancialInstruments_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlTraining, pnlInformation);

            lblInfoTitle.Text = btnFinancialInstruments.Text;
            lblInfo.Text = readfile("Training information", "Financial Instruments.txt");
        }

        private void btnCompoundInterest_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlTraining, pnlInformation);

            lblInfoTitle.Text = btnCompoundInterest.Text;
            lblInfo.Text = readfile("Training information", "Compound Interest.txt");
        }

        private void btnAssetManagement_Click(object sender, EventArgs e)
        {
            ChangePanel(pnlTraining, pnlInformation);

            lblInfoTitle.Text = btnCompoundInterest.Text;
            lblInfo.Text = readfile("Training information", "Asset Management.txt");
        }

        private void pnlInformation_VisibleChanged(object sender, EventArgs e)
        {

        }

        
        // Challenges page buttons
        private void btnChallenge1_Click(object sender, EventArgs e)
        {
            model.newChallenge("Challenge 1", "10", "Tech", 1000f, "2014-01-02");
            ChangePanel(pnlChallenges, pnlChallenge1);
            lblChallengeStats.Text = readfile("Player information", "Portfolio.txt");
        }

        private void btnChallenge2_Click(object sender, EventArgs e)
        {
            model.newChallenge("Challenge 2", "100", "Gold", 1000f, "2014-02-02");
            ChangePanel(pnlChallenges, pnlChallenge1);
        }

        private void btnChallenge3_Click(object sender, EventArgs e)
        {
            model.newChallenge("Challenge 3", "1000", "Travel", 1000f, "2014-03-02");
            ChangePanel(pnlChallenges, pnlChallenge1);
        }

        private void btnChallenge4_Click(object sender, EventArgs e)
        {
            model.newChallenge("Challenge 4", "2000", "Oil", 1000f, "2014-04-02");
            ChangePanel(pnlChallenges, pnlChallenge1);
        }

        private void btnChallenge5_Click(object sender, EventArgs e)
        {
            model.newChallenge("Challenge 5", "10000", "Entertainment", 1000f, "2014-05-02");
            ChangePanel(pnlChallenges, pnlChallenge1);
        }

        private void pnlChallenge1_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlChallenge1.Visible)
            {
                lblChallengeStats.Text = readfile("Player information", "Portfolio.txt");
                cbViewingMode.SelectedItem = cbViewingMode.Items[0];
                cbYear.SelectedItem = cbYear.Items[0];
                cbDate.SelectedItem = cbDate.Items[0];
                cbMonth.SelectedItem = cbMonth.Items[0];
            }
        }

        // functionality related to challenges
        private void btnBuy_Click(object sender, EventArgs e)
        {
            model.buy(Int32.Parse(txtQuantity.Text));
            lblChallengeStats.Text = readfile("Player information", "Portfolio.txt");
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            model.sell(Int32.Parse(txtQuantity.Text));
            lblChallengeStats.Text = readfile("Player information", "Portfolio.txt");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string mode = cbViewingMode.SelectedItem.ToString();
            string[] date = new string[] { 
                cbYear.SelectedItem.ToString(),
                cbMonth.SelectedItem.ToString(),
                cbDate.SelectedItem.ToString()
            };

            DataTable dt = model.MakeQuery(String.Join("-", date), mode);

            chart1.DataSource = dt;
            chart1.Series["Open"].XValueMember = "X_Value";
            chart1.Series["Close"].XValueMember = "X_Value";
            chart1.Series["Open"].YValueMembers = "Y1_Value";
            chart1.Series["Close"].YValueMembers = "Y2_Value";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
        }        
        
        private void btnTimeSkip_Click(object sender, EventArgs e)
        {
            model.timeStep(cbTimeUnits.SelectedItem.ToString() ,Int32.Parse(txtTimeVal.Text));
            lblChallengeStats.Text = readfile("Player information", "Portfolio.txt");
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


        // Makes sure that they can't select dates beyond their 'present' date
        private void cbViewingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbViewingMode.SelectedItem.ToString() == "Years")
            {
                cbYear.Enabled = true;
                cbMonth.Enabled = false;
                cbDate.Enabled = false;
            }

            if (cbViewingMode.SelectedItem.ToString() == "Months")
            {
                cbYear.Enabled = true;
                cbMonth.Enabled = false;
                cbDate.Enabled = false;
            }

            if (cbViewingMode.SelectedItem.ToString() == "Days")
            {
                cbYear.Enabled = true;
                cbMonth.Enabled = true;
                cbDate.Enabled = true;
            }

            string date = model.getDate();
            string yr = date.Split('-')[0];
            string lastyr = cbYear.Items[cbYear.Items.Count - 1].ToString();
            while (Int32.Parse(yr) > Int32.Parse(lastyr))
            {
                cbYear.Items.Add(Int32.Parse(lastyr) + 1);
                lastyr = cbYear.Items[cbYear.Items.Count - 1].ToString();
            }

        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = model.getDate();

            string curYear = date.Split('-')[0];
            string curMonth = date.Split('-')[1];
            string selectedYear = cbYear.SelectedItem.ToString();
            List<string> months = new List<string>(new String[] {"January", "February", "March", "April", "May", "June", "July",
                "August", "September", "October", "November", "December" });

            if (Int32.Parse(selectedYear) < Int32.Parse(curYear))
            {
                foreach (string month in months)
                {
                    if (!cbMonth.Items.Contains(month)) cbMonth.Items.Add(month);
                }
            }

            else
            {
                foreach (string month in months)
                {
                    if (months.IndexOf(curMonth) < months.IndexOf(month) && cbMonth.Items.Contains(month)) cbMonth.Items.Remove(month);
                }
            }
            
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = model.getDate();

            string curYear = date.Split('-')[0];
            string curMonth = date.Split('-')[1];
            string curDate = date.Split('-')[2];
            string selectedYear = cbYear.SelectedItem.ToString();
            string selectedMonth = cbMonth.SelectedItem.ToString();
            List<string> months = new List<string>(new String[] {"January", "February", "March", "April", "May", "June", "July",
                "August", "September", "October", "November", "December" });

            if (Int32.Parse(selectedYear) < Int32.Parse(curYear) || (Int32.Parse(selectedYear) == Int32.Parse(curYear) && months.IndexOf(selectedMonth) < months.IndexOf(curMonth)))
            {
                for (int i = 1; i <= 31; i++)
                {
                    string item = makeTwoDigit(i);
                    if (!cbDate.Items.Contains(item)) 
                    {
                        cbDate.Items.Add(item);
                    }
                }
            }
            
            else 
            {
                for (int i = 1; i <= 31; i++)
                {
                    string item = makeTwoDigit(i);
                    if (Int32.Parse(curDate) >= i && !cbDate.Items.Contains(item)) 
                    {
                        cbDate.Items.Add(item);
                    }
                    else if (Int32.Parse(curDate) < i && cbDate.Items.Contains(item)) cbDate.Items.Remove(item);
                }
            }
        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /*
        Tasks:
        Link the training datas to the text files provided by karthik
        Create a time skip button
        Make the drop down lists show values using the current date
        */

    }
}
