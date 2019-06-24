using System;

namespace Final
{
    class Dog:FarmAnimal
    {
        //dog inheritance from farmAnimal
        public Dog(int id, double amountOfWater, double dailyCost, double weight, int age, string color) : base(id, amountOfWater, dailyCost, weight, age, color)
        {
        }

        //return dog data 
        public override string DisplayInfo()
        {
            string info =
                $"Type: Dog\r\n ID: {Convert.ToString(Id)}\r\n Amount Of Water: {Convert.ToString(AmountOfWater)}\r\n Weight: {Convert.ToString(Weight)}\r\n Age: {Convert.ToString(Age)}\r\n Color: {Color}\r\n Daily Cost: {Convert.ToString(DailyCost)}";
            return info;
        }

        //get profitability, dog does not make any profit
        public override double Profitability()
        {
            double profit = 0 - TotalCostPerDay();
            return profit;
        }
    }
}
