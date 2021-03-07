using System;
using System.Collections.Generic;
using System.IO;

namespace Hack_the_Burgh_competition
{
    class Database
    {
        private Dictionary<string, Dictionary<string, string>> closeStocks = new Dictionary<string, Dictionary<string, string>>();
        private Dictionary<string, Dictionary<string, string>> openStocks = new Dictionary<string, Dictionary<string, string>>(); // Don't worry about these I understand them
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

                    if (!closeStocks.ContainsKey(type)) {
                        closeStocks.Add(type, new Dictionary<string, string>());
                    }
                    closeStocks[type].Add(rowData[0], rowData[1]);  // For this specific stock add the price related to this date
                }
                for (int i = 1; i < csvLinesOpen.Length; i++)
                {
                    string[] rowData = csvLinesOpen[i].Split(','); // Same as above but the other file

                    if (!openStocks.ContainsKey(type)) {
                        openStocks.Add(type, new Dictionary<string, string>());
                    }
                    openStocks[type].Add(rowData[0], rowData[1]);
                }
            }
        }

        public Dictionary<string, string> getConsecutiveDays(string type, string startDate, int days)
        {
            DateTime date = this.ParseDate(startDate);

            Dictionary<string, string> result = new Dictionary<string, string>();  // The link between dates and prices

            for (int i = 0; i < days; i++)
            {
                date = date.AddDays(1); // Get the next day
                string stringDate = date.Year.ToString() + '-' + date.Month.ToString().PadLeft(2, '0') + '-' + date.Day.ToString().PadLeft(2, '0');

                string key = date.Day.ToString(); // This is just for visual purposes

                if (this.openStocks[type].ContainsKey(stringDate) && this.closeStocks[type].ContainsKey(stringDate)) // Only add if both open and closed have a value
                {
                    result.Add(key, this.openStocks[type][stringDate] + ',' + this.closeStocks[type][stringDate]);  // IMPORTANT: still need to put a comma between date and these values
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
                string stringClose = date.Year.ToString() + '-' + date.Month.ToString().PadLeft(2, '0') + '-' + date.Day.ToString().PadLeft(2, '0');

                DateTime openDate = date.AddMonths(-1).AddDays(1); // Get the start of the month
                string stringOpen = openDate.Year.ToString() + '-' + openDate.Month.ToString().PadLeft(2, '0') + '-' + openDate.Day.ToString().PadLeft(2, '0');

                string key = date.Month.ToString(); // Don't care about days

                if (this.openStocks[type].ContainsKey(stringOpen) && this.closeStocks[type].ContainsKey(stringClose))
                {
                    result.Add(key, this.openStocks[type][stringOpen] + ',' + this.closeStocks[type][stringClose]); // Same as above but with months not days
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
                string stringClose = date.Year.ToString() + '-' + date.Month.ToString().PadLeft(2, '0') + '-' + date.Day.ToString().PadLeft(2, '0');

                DateTime openDate = date.AddYears(-1).AddDays(1);
                string stringOpen = openDate.Year.ToString() + '-' + openDate.Month.ToString().PadLeft(2, '0') + '-' + openDate.Day.ToString().PadLeft(2, '0');

                string key = date.Year.ToString();
                if (this.openStocks[type].ContainsKey(stringOpen) && this.closeStocks[type].ContainsKey(stringClose))
                {
                    result.Add(key, this.openStocks[type][stringOpen] + ',' + this.closeStocks[type][stringClose]); // Same as above but with years not months
                }
            }

            return result;
        }

        public float price(string type, string startDate) // To be used to judge whether a stock can actually be bought with funds
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            DateTime date = new DateTime(year, 1, 1);
            string key = date.Year.ToString() + '-' + date.Month.ToString().PadLeft(2, '0') + '-' + date.Day.ToString().PadLeft(2, '0');

            if (this.closeStocks[type].ContainsKey(key))
            {
                return float.Parse(this.closeStocks[type][key]); // Prices are floats the value in £
            }
            else
            {
                return 0f;
            }
        }

        public bool buy(string type, string startDate, int number)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            DateTime date = new DateTime(year, 1, 1);
            string key = date.Year.ToString() + '-' + date.Month.ToString().PadLeft(2, '0') + '-' + date.Day.ToString().PadLeft(2, '0');

            if (this.closeStocks[type].ContainsKey(key))
            {
                float currPrice = float.Parse(this.closeStocks[type][key]);
                // Assume say 1000 people investing in the stock
                float newPrice = currPrice * (1000 + number) / 1000;

                this.closeStocks[type][key] = newPrice.ToString(); // Edit the value of the stock
                return true;
            }
            else
            {
                return false;
            }
        }

        public float sell(string type, string startDate, int number)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            DateTime date = new DateTime(year, 1, 1);
            string key = date.Year.ToString() + '-' + date.Month.ToString().PadLeft(2, '0') + '-' + date.Day.ToString().PadLeft(2, '0');

            if (this.closeStocks[type].ContainsKey(key))
            {
                float currPrice = float.Parse(this.closeStocks[type][key]);
                // Assume say 1000 people investing in the stock
                float newPrice = currPrice * (1000 - number) / 1000;

                this.closeStocks[type][key] = newPrice.ToString(); // Edit the value of the stock

                return currPrice * number; // Ignoring the fact that this might not actually be viable. That's a problem for actual development
            }
            else
            {
                return 0f;
            }
        }

        public DateTime ParseDate(string repr)
        {
            string[] stringDate = repr.Split('-');
            int year = int.Parse(stringDate[0]);
            int month = int.Parse(stringDate[1]);
            int day = int.Parse(stringDate[2]);
            return new DateTime(year, month, day); // Sperate function to make a dateTime in a way I'm comfortable with, will eventually switch to built in
        }
    }
}
