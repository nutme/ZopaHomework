namespace ZopaHomework
{
    public class Lender
    {
        public Lender(string name, double rate, double foundsAvailable)
        {
            // need ID of some sort as well for data integrity
            Name = name;
            Rate = rate;
            Founds = foundsAvailable;
        }

        public string Name { get; private set; }
        public double Rate { get; private set; }
        public double Founds { get; private set; }
    }
}
