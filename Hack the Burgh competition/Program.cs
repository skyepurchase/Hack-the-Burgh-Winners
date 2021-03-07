using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hack_the_Burgh_competition
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class Model
    {
        private Database db;
        private Portfolio portfolio = null;
        public Model()
        {
            this.db = new Database();
        }

        public DataTable MakeQuery(string startDate, string mode)
        {
            Dictionary<string, string> data = null;

            if (this.portfolio == null)
            {
                return null;
            }

            switch (mode)
            {
                case "days":
                    data = db.getConsecutiveDays(this.portfolio.getType(), startDate, 10);
                    break;
                case "months":
                    data = db.getConsecutiveMonths(this.portfolio.getType(), startDate, 12);
                    break;
                case "years":
                    data = db.getConsecutiveYears(this.portfolio.getType(), startDate, 10);
                    break;
                default:
                    break;
            }

            if (data != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("X_Value", typeof(double));
                dt.Columns.Add("Y1_Value", typeof(double));
                dt.Columns.Add("Y2_Value", typeof(double));

                foreach (string x in data.Keys)
                {
                    string[] ypoints = data[x].Split(',');
                    dt.Rows.Add(x, ypoints[0], ypoints[1]);
                }

                return dt;
            }
            return null;
        }

        public void newChallenge(string name, string goal, string type, float money, string date)
        {
            float price = db.price(type, date);
            this.portfolio = new Portfolio(name, goal, type, money, date, price);
        }

        public bool buy(int amount)
        {
            if (this.portfolio == null)
            {
                return false;
            }

            float price = db.price(this.portfolio.getType(), this.portfolio.getCurrentDate());

            if (price > this.portfolio.getMoney())
            {
                return false;
            }

            this.db.buy(this.portfolio.getType(), this.portfolio.getCurrentDate(), amount);
            this.portfolio.buy(price, amount);
            return true;
        }

        public bool sell(int amount)
        {
            if (this.portfolio == null)
            {
                return false;
            }

            if (this.portfolio.getQuantity() > amount)
            {
                return false;
            }

            float profit = this.db.sell(this.portfolio.getType(), this.portfolio.getCurrentDate(), amount);
            this.portfolio.sell(profit, amount);
            return true;
        }

        public bool timeStep(string type, int amount)
        {
            if (this.portfolio == null)
            {
                return false;
            }

            string[] stringDate = this.portfolio.getCurrentDate().Split('-');
            int year = int.Parse(stringDate[0]);
            int month = int.Parse(stringDate[1]);
            int day = int.Parse(stringDate[2]);
            DateTime date = new DateTime(year, month, day);

            switch (type)
            {
                case "days":
                    date.AddDays(amount);
                    break;
                case "months":
                    date.AddMonths(amount);
                    break;
                case "years":
                    date.AddYears(amount);
                    break;
                default:
                    return false;
            }

            string dateRepr = date.Year.ToString() + '-' + date.Month.ToString() + '-' + date.Day.ToString();
            this.portfolio.update(dateRepr, this.db.price(this.portfolio.getType(), dateRepr));

            return true;
        }

        public string getDate()
        {
            return this.portfolio.getCurrentDate();
        }
    }

    class Portfolio
    {
        private string name;
        private string date;
        private string goal;
        private string stock;
        private int quantity;
        private float price;
        private float money;
        private float profit;
        public Portfolio(string name, string goal, string type, float money, string date, float price)
        {
            this.name = name;
            this.date = date;
            this.goal = goal;
            this.stock = type;
            this.quantity = 0;
            this.price = 0;
            this.money = money;
            this.profit = 0;
            update(date);
        }

        public void update(string date, float price)
        {
            this.price = price;
            update(date);
        }

        private void update(string date)
        {
            this.date = date;
            string display = $"Challenge name: {this.name}\n\nPresent Date: {date}\n\nGoal: {this.goal}\n\nCurrently owned stock quantity: {this.quantity}\n\nCurrent stock price: {this.price}\n\nAvailable money: £{this.money}\n\nTotal profit: £{this.profit}";
            File.WriteAllText(@"Player information\Portfolio.txt", display);
        }

        public void buy(float price, int amount)
        {
            this.money -= price * amount;
            this.profit -= price * amount;
            this.price = price;
            this.quantity += amount;
            update(this.date);
        }

        public void sell(float profit, int amount)
        {
            this.money += profit;
            this.profit += profit;
            this.quantity -= amount;
            update(this.date);
        }

        public string getType()
        {
            return this.stock;
        }

        public string getCurrentDate()
        {
            return this.date;
        }

        public float getMoney()
        {
            return this.money;
        }

        public float getQuantity()
        {
            return this.quantity;
        }
    }
}
