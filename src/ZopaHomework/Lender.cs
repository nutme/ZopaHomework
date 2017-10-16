namespace ZopaHomework
{
    public class Lender
    {
        public Lender(string name, double rate, double foundsAvailable)
        {
            Name = name;
            Rate = rate;
            FoundsAvailable = foundsAvailable;
        }

        public string Name { get; private set; }
        public double Rate { get; private set; }
        public double FoundsAvailable { get; private set; }
    }
}
