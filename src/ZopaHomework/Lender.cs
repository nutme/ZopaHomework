namespace ZopaHomework
{
    public class Lender
    {
        public Lender(string name, double rate, double foundsAvailable)
        {
            Name = name;
            Rate = rate;
            Founds = foundsAvailable;
        }

        public string Name { get; private set; }

        /// <summary>
        /// Rate is supplied as double value like 0.07
        /// Which is equil to 7%
        /// </summary>
        public double Rate { get; private set; }
        public double Founds { get; private set; }
    }
}
