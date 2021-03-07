using System;
using System.Collections.Generic;
using System.IO;

namespace Hack_the_Burgh_competition
{
    class Database
    {
        private Dictionary<string, Dictionary<DateTime, string>> closeStocks = new Dictionary<string, Dictionary<DateTime, string>>();
        private Dictionary<string, Dictionary<DateTime, string>> openStocks = new Dictionary<string, Dictionary<DateTime, string>>(); // Don't worry about these I understand them
        private string[] stockTypes = { "Tech", "Oil", "Entertainment", "Travel", "Gold" };  // Hard code 5 types

        public Database()
        {
            foreach (string type in stockTypes)
            {
                string[] csvLinesClose = File.ReadAllLines($"closestockdata{type}.csv");
                string[] csvLinesOpen = File.ReadAllLines($"openstockdata{type}.csv");  // This is just the format of my python data collection files

                for (int i = 1; i < csvLinesClose.Length; i++)
                {
                    string[] rowData = csvLinesClose[i].Split(','); // Get the date and price from .csv

                    string[] stringDate = rowData[0].Split('-');
                    int year = int.Parse(stringDate[0]);
                    int day = int.Parse(stringDate[2]);
                    int month = int.Parse(stringDate[1]);
                    DateTime date = new DateTime(year, month, day);  // Incorrectly convert to DateTime (but I know it works so who cares)

                    if (!closeStocks.ContainsKey(type)) {
                        closeStocks.Add(type, new Dictionary<DateTime, string>());
                    }
                    closeStocks[type].Add(date, rowData[1]);  // For this specific stock add the price related to this date
                }
                for (int i = 1; i < csvLinesOpen.Length; i++)
                {
                    string[] rowData = csvLinesOpen[i].Split(','); // Same as above but the other file

                    string[] stringDate = rowData[0].Split('-');
                    int year = int.Parse(stringDate[0]);
                    int day = int.Parse(stringDate[2]);
                    int month = int.Parse(stringDate[1]);
                    DateTime date = new DateTime(year, month, day);

                    if (!openStocks.ContainsKey(type)) {
                        openStocks.Add(type, new Dictionary<DateTime, string>());
                    }
                    openStocks[type].Add(date, rowData[1]);
                }
            }
        }

        public Dictionary<string, string> getConsecutiveDays(string type, string startDate, int days)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            int day = int.Parse(stringDate[2]);
            int month = int.Parse(stringDate[1]);
            DateTime date = new DateTime(year, month, day); // Again convert to Datetime

            Dictionary<string, string> result = new Dictionary<string, string>();  // The link between dates and prices

            for (int i = 0; i < days; i++)
            {
                date = date.AddDays(1); // Get the next day

                string key = date.Year.ToString() + '-' + date.Day.ToString() + '-' + date.Month.ToString(); // This is just for visual purposes

                if (this.openStocks[type].ContainsKey(date) && this.closeStocks[type].ContainsKey(date)) // Only add if both open and closed have a value
                {
                    result[key] = this.openStocks[type][date] + ',' + this.closeStocks[type][date];  // IMPORTANT: still need to put a comma between date and these values
                                                                                                     // ALSO: need a comma after these values, VJ will probably explain
                } 
            }

            return result;
        }

        public Dictionary<string, string> getConsecutiveMonths(string type, string startDate, int months)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            int month = int.Parse(stringDate[1]);
            DateTime date = new DateTime(year, month, 1);// Same as above really
            date = date.AddMonths(1);
            date = date.AddDays(-1);  // except we don't care about days so take end of the month by going to next month then back

            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i < months; i++)
            {
                date = date.AddMonths(1); // Get next calendar month

                DateTime openDate = date.AddMonths(-1).AddDays(1); // Get the start of the month

                string key = date.Year.ToString() + '-' + date.Month.ToString(); // Don't care about days

                if (this.openStocks[type].ContainsKey(openDate) && this.closeStocks[type].ContainsKey(date))
                {
                    result[key] = this.openStocks[type][openDate] + ',' + this.closeStocks[type][date]; // Same as above but with months not days
                }
            }

            return result;
        }

        public Dictionary<string, string> getConsecutiveYears(string type, string startDate, int days)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            DateTime date = new DateTime(year, 1, 1);
            date = date.AddMonths(1);
            date = date.AddDays(-1); // Same as above but for years

            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i < days; i++)
            {
                date = date.AddYears(1);
                DateTime openDate = date.AddYears(-1).AddDays(1);
                string key = date.Year.ToString();
                if (this.openStocks[type].ContainsKey(openDate) && this.closeStocks[type].ContainsKey(date))
                {
                    result[key] = this.openStocks[type][openDate] + ',' + this.closeStocks[type][date]; // Same as above but with years not months
                }
            }

            return result;
        }

        public float price(string type, string startDate) // To be used to judge whether a stock can actually be bought with funds
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            int day = int.Parse(stringDate[2]);
            int month = int.Parse(stringDate[1]);
            DateTime date = new DateTime(year, month, day); // Usual datetime stuff

            return float.Parse(this.closeStocks[type][date]); // Prices are floats the value in £
        }

        public void buy(string type, string startDate, int number)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            int day = int.Parse(stringDate[2]);
            int month = int.Parse(stringDate[1]);
            DateTime date = new DateTime(year, month, day); // This is getting boring to comment this block should probably create a function might do that tomorrow

            float currPrice = float.Parse(this.closeStocks[type][date]);
            // Assume say 1000 people investing in the stock
            float newPrice = currPrice * (1000 + number) / 1000;  

            this.closeStocks[type][date] = newPrice.ToString(); // Edit the value of the stock
        }

        public float sell(string type, string startDate, int number)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            int day = int.Parse(stringDate[2]);
            int month = int.Parse(stringDate[1]);
            DateTime date = new DateTime(year, month, day);  // Whelp last one

            float currPrice = float.Parse(this.closeStocks[type][date]);
            // Assume say 1000 people investing in the stock
            float newPrice = currPrice * (1000 - number) / 1000;

            this.closeStocks[type][date] = newPrice.ToString(); // Edit the value of the stock

            return currPrice * number; // Ignoring the fact that this might not actually be viable. That's a problem for actual development
        }

        public void update()
        {
            // I don't know if this is necessary
            // I automatically update when I method is called
        }
    }
}
