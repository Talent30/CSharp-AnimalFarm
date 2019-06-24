namespace Final
{
    public abstract class FarmAnimal
    {
        //all animals in the farm have id, amount of water, daily cost, weight, age, and color
        protected FarmAnimal(int id, double amountOfWater, double dailyCost, double weight, int age, string color)
        {
            Id = id;
            AmountOfWater = amountOfWater;
            DailyCost = dailyCost;
            Weight = weight;
            Age = age;
            Color = color;
        }

        public int Id { get; set; }
        public double AmountOfWater { get; set; }
        public double DailyCost { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }

        //every animal need to display their information
        public abstract string DisplayInfo();
        //every animal needs to pay tax base on their weight
        public virtual double TaxPerYear()
        {
            double tax = Prices.TaxPerKg * Weight;
            return tax;
        }
        //every animal has a cost, daily cost and water cost
        public virtual double TotalCostPerDay()
        {
            double cost = DailyCost + AmountOfWater * Prices.WaterPrice;

            return cost;
        }
        //every animal will have profitability
        public abstract double Profitability();

    }
}
