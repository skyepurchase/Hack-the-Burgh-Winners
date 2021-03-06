using System;
using System.Collections.Generic;
using System.IO;

namespace Hack_the_Burgh_competition
{
    class Market
    {
        private Dictionary<string, Stock> stocks = new Dictionary<string, Stock>();
        private string[] stockTypes = { "Tech", "Oil", "Entertainment", "Travel", "Gold" };  // Hard code 5 types

        public Market()
        { 
            for (int i = 0; i < 5; i++)
            {
                this.stocks.Add(stockTypes[i], new Stock(stockTypes[i]));  // Hard code creating 5 types
            }
        }

        public int buyStock(string type, string date, int number)
        {
            return this.stocks[type].buyStock(date, number);
        }

        public int sellStock(string type, string date, int number)
        {
            return this.stocks[type].sellStock(date, number);
        }

        public void newStock(string type)
        {
            stocks.Add(type, new Stock(type));
        }
        public void GetDays(string type, string startDate, int days)
        {
            this.stocks[type].GetDays(startDate, days);
        }

        public void GetMonth(string type, string startDate, int months)
        {
            this.stocks[type].GetWeeks(startDate, months);
        }
    }

    class Stock
    {
        private List<string> timeStamp = new List<string>();
        private Dictionary<string, string> price = new Dictionary<string, string>();

        public Stock(string type)
        {
            string[] csvLines = File.ReadAllLines($"stockdata{type}.csv");

            for (int i = 0; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(',');
                timeStamp.Add(rowData[0]);
                price.Add(rowData[0], rowData[1]);
            }
        }
        public void GetDays(string startDate, int days)
        {
            int index = timeStamp.IndexOf(startDate);
            string points = "";

            for (int i = 0; i < days && i < timeStamp.Count; i++)
            {
                string date = timeStamp[index + i];
                points += date + ',' + price[date] + '\n';
            }

            File.WriteAllText("GraphData.txt", points);
        }

        public void GetWeeks(string startDate, int weeks)
        {
            int index = timeStamp.IndexOf(startDate);
            string points = "";

            for (int i = 0; i < weeks && i < timeStamp.Count; i++)
            {
                string date = timeStamp[index + i];
                points += date + ',' + price[date] + '\n';
            }

            File.WriteAllText("GraphData.txt", points);
        }

        public int buyStock(string date, int number)
        {
            int cost = int.Parse(price[date]);
            return cost * number;
        }

        public int sellStock(string date, int number)
        {
            int profit = int.Parse(price[date]);
            return profit * number;
        }
    }
}
