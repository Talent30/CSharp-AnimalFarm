using System;

namespace Final
{
    class Goat:FarmAnimal
    {
        public Goat(int id, double amountOfWater, double dailyCost, double weight, int age, string color, double amountOfMilk) : base(id, amountOfWater, dailyCost, weight, age, color)
        {
            AmountOfMilk = amountOfMilk;
        }
        public double AmountOfMilk { get; set; }

        public override string DisplayInfo()
        {
            string info =
                $"Type: Goat\r\n ID: {Convert.ToString(Id)}\r\n Amount Of Water: {Convert.ToString(AmountOfWater)}\r\n Daily Cost: {Convert.ToString(DailyCost)}\r\n Weight: {Convert.ToString(Weight)}\r\n Age: {Convert.ToString(Age)}\r\n Color: {Color}\r\n Amount Of Milk{Convert.ToString(AmountOfMilk)}";
            return info;
        }

        //goat profitability will be milk amount and price subtract by cost and tax
        public override double Profitability()
        {
            double prof = AmountOfMilk * Prices.GoatMilkPrice - TaxPerYear() / 365 - TotalCostPerDay();
            return prof;
        }


    }
}
