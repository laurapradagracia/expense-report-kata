using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseReports;

namespace ExpenseReports
{
    public class Worker
    {
      private string _iso;
      public Worker()
        {
            _iso = "ES";
        }
        public Worker(string iso)
        {
            _iso = iso;
        }
        public string PrintFirstLine()
        {
            if (_iso == "ES")
            {
                return ("Inserte gastos");
            }
            return ("Insert expense");
        }
    }
}
