using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ZopaHomework
{
    public class LendersList
    {
        public List<Lender> Lenders { get; private set; }

        public LendersList(List<Lender> lenders)
        {
            Lenders = lenders;
        }

        public double TotalMoneyAvailable() => Lenders.Select(l => l.Founds).Sum();

        public static LendersList LoadFromCsvFile(string csvFileName)
        {
            var lenders = new List<Lender>();
            var lines = File.ReadAllLines(csvFileName);

            foreach (var line in lines.Skip(1))
            {
                var record = line.Split(',');
                var lender = new Lender(
                    record[0],                  // Name
                    double.Parse(record[1]),    // Rate
                    double.Parse(record[2]));   // Founds Available
                lenders.Add(lender);
            }

            return new LendersList(lenders);
        }
    }
}
