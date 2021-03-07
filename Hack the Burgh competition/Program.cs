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
        private Portfolio portfolio;
        public Model()
        {
            this.db = new Database();
            this.portfolio = new Portfolio();
        }

        public DataTable MakeQuery(string type, string startDate, string mode)
        {
            Dictionary<string, string> data = null;

            switch (mode)
            {
                case "days":
                    data = db.getConsecutiveDays(type, startDate, 10);
                    break;
                case "months":
                    data = db.getConsecutiveMonths(type, startDate, 12);
                    break;
                case "years":
                    data = db.getConsecutiveYears(type, startDate, 10);
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

                string points = "";

                foreach (string x in data.Keys)
                {
                    string[] ypoints = data[x].Split(',');
                    dt.Rows.Add(x, ypoints[0], ypoints[1]);
                }

                return dt;
            }
            return null;
        }
    }

    class Portfolio
    {

    }
}
