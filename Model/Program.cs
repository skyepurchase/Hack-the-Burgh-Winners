using System;

namespace Model {
    class Model {

        public class Market {
            public const string cash = "Cash";
            public Market() {}
            public void addInvestment(string investment) {}
            public void updateValue(string investment, double value) {} // Can't update value of cash
            public double getValue(string investment) { return 0.0; }
            public bool isInvestment(string investment) { return false; }
        }

        public class Portfolio {
            public Portfolio(Market m) {
                market = m;
            }
            public void transfer(double cash) {}
            private Market market;
            public bool buy(string investment, double quantity) { return false; }
            public void sell(string investment, double quantity) {}
            public double quantity(string investment) { return 0.0; }
            public double value() { return 0.0; }
        }

        static void Main(string[] args) {
            Market market = new Market();
            market.addInvestment("Commodity Future");
            market.updateValue("Commodity Future", 5.0);

            market.addInvestment("Stock");
            market.updateValue("Stock", 5.0);

            market.addInvestment("Bond");
            market.updateValue("Bond", 5.0);

            market.addInvestment("Investment Fund");
            market.updateValue("Investment Fund", 5.0);

            market.addInvestment("Option");
            market.updateValue("Option", 5.0);
        }
    }
}
