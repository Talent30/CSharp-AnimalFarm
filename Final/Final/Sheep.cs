using System;

namespace Final
{
    class Sheep :FarmAnimal
    {
        public Sheep(int id, double amountOfWater, double dailyCost, double weight, int age, string color, double amountOfWool) : base(id, amountOfWater, dailyCost, weight, age, color)
        {
            AmountOfWool = amountOfWool;
        }
        public double AmountOfWool { get; set; }

        public override string DisplayInfo()
        {
            string info =
                $"Type: Sheep\r\n ID: {Convert.ToString(Id)}\r\n AmountOfWater: {Convert.ToString(AmountOfWater)}\r\n Daily Cost: {Convert.ToString(DailyCost)}\r\n Weight: {Convert.ToString(Weight)}\r\n Age: {Convert.ToString(Age)}\r\n Color: {Color}\r\n Amount Of Wood: {Convert.ToString(AmountOfWool)}\r\n";
            return info;
        }
        //profitability base on wool price
        public override double Profitability()
        {
            double prof = (AmountOfWool * Prices.SheepWoolPrice) - (TaxPerYear() / 365) - TotalCostPerDay();
            return prof;
        }

    }
}
