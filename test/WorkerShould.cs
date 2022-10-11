using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReports.Test
{
    public class WorkerShould
    {
        private Worker _worker;

        [Fact]
        public void PrintFirstLineEN()
        {
            _worker = new Worker("EN");
            Assert.Equal("Insert expense",_worker.PrintFirstLine() );
        }

        [Fact]
        public void PrintFirstLineES()
        {
            _worker = new Worker("ES");
            Assert.Equal("Inserte gastos", _worker.PrintFirstLine());
        }

        [Theory]
        [InlineData("","Insert expense")]
        [InlineData("EN", "Insert expense")]
        [InlineData("ES", "Inserte gastos")]
        public void PrintFirstLineImprove(string iso, string expected)
        {
            _worker = new Worker(iso);
            Assert.Equal(expected, _worker.PrintFirstLine());
        }

    }

}
