using System;
using System.Collections.Generic;
using System.IO;

namespace Hack_the_Burgh_competition
{
    class Database
    {
        private Dictionary<string, Dictionary<DateTime, string>> closeStocks = new Dictionary<string, Dictionary<DateTime, string>>();
        private Dictionary<string, Dictionary<DateTime, string>> openStocks = new Dictionary<string, Dictionary<DateTime, string>>();
        private string[] stockTypes = { "Tech", "Oil", "Entertainment", "Travel", "Gold" };  // Hard code 5 types

        public Database()
        {
            foreach (string type in stockTypes)
            {
                string[] csvLinesClose = File.ReadAllLines($"closestockdata{type}.csv");
                string[] csvLinesOpen = File.ReadAllLines($"openstockdata{type}.csv");

                for (int i = 0; i < csvLinesClose.Length; i++)
                {
                    string[] rowData = csvLinesClose[i].Split(',');
                    string[] stringDate = rowData[0].Split('-');
                    int year = int.Parse(stringDate[0]);
                    int day = int.Parse(stringDate[1]);
                    int month = int.Parse(stringDate[2]);
                    DateTime date = new DateTime(year, month, day);
                    closeStocks[type].Add(date, rowData[1]);
                }
                for (int i = 0; i < csvLinesOpen.Length; i++)
                {
                    string[] rowData = csvLinesOpen[i].Split(',');
                    string[] stringDate = rowData[0].Split('-');
                    int year = int.Parse(stringDate[0]);
                    int day = int.Parse(stringDate[1]);
                    int month = int.Parse(stringDate[2]);
                    DateTime date = new DateTime(year, month, day);
                    openStocks[type].Add(date, rowData[1]);
                }
            }
        }

        public Dictionary<string, string> GetConsecutiveDays(string type, string startDate, int days)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            int day = int.Parse(stringDate[1]);
            int month = int.Parse(stringDate[2]);
            DateTime date = new DateTime(year, month, day);

            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i < days; i++)
            {
                date = date.AddDays(1);
                string key = date.Year.ToString() + '-' + date.Day.ToString() + '-' + date.Month.ToString();
                if (this.openStocks[type].ContainsKey(date) && this.closeStocks[type].ContainsKey(date))
                {
                    result[key] = this.openStocks[type][date] + ',' + this.closeStocks[type][date];
                } 
            }

            return result;
        }

        public Dictionary<string, string> GetConsecutiveMonths(string type, string startDate, int months)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            int month = int.Parse(stringDate[2]);
            DateTime date = new DateTime(year, month, 1);

            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i < months; i++)
            {
                date = date.AddMonths(1);
                DateTime openDate = date.AddDays(-1);
                string key = date.Year.ToString() + '-' + date.Month.ToString();
                if (this.openStocks[type].ContainsKey(openDate) && this.closeStocks[type].ContainsKey(date))
                {
                    result[key] = this.openStocks[type][openDate] + ',' + this.closeStocks[type][date];
                }
            }

            return result;
        }

        public Dictionary<string, string> GetConsecutiveYears(string type, string startDate, int days)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            DateTime date = new DateTime(year, 1, 1);

            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i < days; i++)
            {
                date = date.AddYears(1);
                DateTime openDate = date.AddDays(-1);
                string key = date.Year.ToString();
                if (this.openStocks[type].ContainsKey(openDate) && this.closeStocks[type].ContainsKey(date))
                {
                    result[key] = this.openStocks[type][openDate] + ',' + this.closeStocks[type][date];
                }
            }

            return result;
        }
    }
}
