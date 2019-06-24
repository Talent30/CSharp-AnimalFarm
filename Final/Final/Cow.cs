using System;

namespace Final
{
    class Cow:FarmAnimal
    {
        //cow inheritance from farm animal class
        public Cow(int id, double amountOfWater, double dailyCost, double weight, int age, string color, double amountOfMilk, bool isJersey) : base(id, amountOfWater, dailyCost, weight, age, color)
        {
            //cow will have amount of milk 
            //cow might be a jersey 
            AmountOfMilk = amountOfMilk;
            IsJersey = isJersey;
        }
        public double AmountOfMilk { get; set; }
        public bool IsJersey { get; set; }
        
        public override string DisplayInfo()
        {
            string info =
                $"Type: Cow\r\n ID:{Convert.ToString(Id)}\r\n Amount Of Water: {Convert.ToString(AmountOfMilk)}\r\n Daily Cost: {Convert.ToString(DailyCost)}\r\n Weight: {Convert.ToString(Weight)}\r\n Age: {Convert.ToString(Age)}\r\n Color: {Color}\r\n Amount Of Milk: {Convert.ToString(AmountOfMilk)}\r\n Is Jersey: {Convert.ToString(IsJersey)}";
            return info;
        }

        public override double TaxPerYear()
        {
            double tax;
            //if it is a jersey 
            if (IsJersey)
            {
                //extra tax
                tax = Prices.JerseyTaxPerKg + Prices.TaxPerKg * Weight;
            }
            else
            {
                //normal tax 
                tax = Prices.TaxPerKg * Weight;
            }

            return tax;
        }

        //get profitability 
        public override double Profitability()
        {
            //profit from the milk, cost from tax and normal cost 
            double prof = AmountOfMilk * Prices.CowMilkPrice - TaxPerYear() / 365 - TotalCostPerDay();
            return prof;
        }


    }
}
