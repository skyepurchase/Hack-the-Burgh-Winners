using System;
using System.Collections.Generic;
using System.IO;

namespace Hack_the_Burgh_competition
{
    class Database
    {
        private Dictionary<string, Dictionary<string, string>> stocks = new Dictionary<string, Dictionary<string, string>>();
        private string[] stockTypes = { "Tech", "Oil", "Entertainment", "Travel", "Gold" };  // Hard code 5 types

        public Database()
        {
            foreach (string type in stockTypes)
            {
                string[] csvLines = File.ReadAllLines($"stockdata{type}.csv");

                for (int i = 0; i < csvLines.Length; i++)
                {
                    string[] rowData = csvLines[i].Split(',');
                    stocks[type].Add(rowData[0], rowData[1]);
                }
            }
        }

        /*public int buyStock(string type, string date, int number)
        {
            return this.stocks[type].buyStock(date, number);
        }

        public int sellStock(string type, string date, int number)
        {
            return this.stocks[type].sellStock(date, number);
        }*/

        public Dictionary<string, string> GetOpenConsecutiveDays(string type, string startDate, int days)
        {
            string[] stringDate = startDate.Split('-');
            int year = int.Parse(stringDate[0]);
            int day = int.Parse(stringDate[1]);
            int month = int.Parse(stringDate[2]);
            DateTime date = new DateTime(year, month, day);

            Dictionary<string, string> result = new Dictionary<string, string>();

            return result;
        }
    }
}
