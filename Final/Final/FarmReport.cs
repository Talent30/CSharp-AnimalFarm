using System;
using System.Collections.Generic;
using System.Linq;

namespace Final
{
    class FarmReport
    {
        /// <summary>
        /// This method will calculate the total profitability 
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double Prof(Dictionary<int, FarmAnimal> allAnimals)
        {
            double profit = 0;
            //for each animal get profit and sum up them 
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                profit += fa.Profitability();
            }
            return profit;
        }
        /// <summary>
        /// Get tax per year from each animal divide by 12
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double TotalTaxPerMonth(Dictionary<int, FarmAnimal> allAnimals)
        {
            double totalTax = 0;
            //for each animal get yearly tax
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //tax does not include dog
                if (fa.GetType()!= typeof(Dog))
                {
                    totalTax += fa.TaxPerYear();
                }
                
            }
            //become monthly
            return totalTax / 12;
        }
        /// <summary>
        /// Get total cow milk amount
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double CowMilkAmount(Dictionary<int, FarmAnimal> allAnimals)
        {
            double milk = 0;
            //for each animal in the dictionary
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //if the animal is cow
                if (fa.GetType() == typeof(Cow))
                {
                    //cast to cow
                    Cow faCow = (Cow)fa;
                    //get amount of milk
                    milk += faCow.AmountOfMilk;
                }
            }

            return milk;
        }
        /// <summary>
        /// Get total goat milk amount
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double GoatMilkAmount(Dictionary<int, FarmAnimal> allAnimals)
        {
            double milk = 0;
            //for each animal in the dictionary
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //if the animal is goat 
                if (fa.GetType() == typeof(Goat))
                {
                    //cast to goat
                    Goat faGoat = (Goat)fa;
                    //get amount of milk
                    milk += faGoat.AmountOfMilk;
                }
            }

            return milk;
        }
        /// <summary>
        /// Get animal average age exclude dog
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double AverageAge(Dictionary<int, FarmAnimal> allAnimals)
        {
            int counter = 0;
            double totalAge = 0;
            //for each animal in the dictionary
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //if is a dog
                if (fa.GetType() == typeof(Dog))
                {
                    //do nothing 
                }
                else
                {
                    //else sum age, counter increase
                    totalAge += fa.Age;
                    counter++;
                }

            }
            //get average
            double average = totalAge / counter;

            return average;
        }
        /// <summary>
        /// Cow and goat average profitability
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double AverageGoatCowProf(Dictionary<int, FarmAnimal> allAnimals)
        {
            double goatCow = 0;
            int counter = 0;
            //for each animal in the dictionary
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //if the animal is a goat
                if (fa.GetType() == typeof(Goat))
                {
                    //cast as a goat
                    Goat faGoat = (Goat)fa;
                    //get profit 
                    goatCow += faGoat.Profitability();
                    //increase counter
                    counter++;
                }
                //if the animal is a cow
                else if (fa.GetType() == typeof(Cow))
                {
                    //cast as a cow
                    Cow faCow = (Cow)fa;
                    //get profit
                    goatCow += faCow.Profitability();
                    //increase counter
                    counter++;
                }
            }
            //get average profit
            double averageProfit = goatCow / counter;

            return averageProfit;
        }
        /// <summary>
        /// get average sheep profitability
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double AverageSheepProf(Dictionary<int, FarmAnimal> allAnimals)
        {
            double sheep = 0;
            int counter = 0;

            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //if is sheep
                if (fa.GetType() == typeof(Sheep))
                {
                    //cast as a sheep
                    Sheep faSheep = (Sheep)fa;
                    //get profitability 
                    sheep += faSheep.Profitability();
                    //increase counter 
                    counter++;
                }
            }
            //get average
            double averageProfit = sheep / counter;
            return averageProfit;
        }
        /// <summary>
        /// Get total cost of all anmials 
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double TotalCost(Dictionary<int, FarmAnimal> allAnimals)
        {
            double totalCost = 0;
            //for each animal get cost sum up
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                totalCost += fa.TotalCostPerDay();
            }

            return totalCost;
        }
        /// <summary>
        /// get total dog cost
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double DogCost(Dictionary<int, FarmAnimal> allAnimals)
        {
            double dogCost = 0;
            
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //for each dog sum up the cost 
                if (fa.GetType() == typeof(Dog))
                {
                    Dog faDog = (Dog)fa;
                    dogCost += faDog.TotalCostPerDay();

                }
            }

            return dogCost;
        }
        /// <summary>
        /// convert the dictionary into an array then do quick sort 
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static FarmAnimal[] SortArray(Dictionary<int, FarmAnimal> allAnimals)
        {
            //convert to array
            FarmAnimal[] animals = allAnimals.Values.ToArray();
            //quick sort
            QuickSort(animals, 0, animals.Length - 1);
            return animals;
        }

        private static void QuickSort(FarmAnimal[] animals, int low, int high)
        {
            if (low < high)
            {
                //pivot is the middle one 
                FarmAnimal middle = animals[(low + high) / 2];
                int i = low - 1;
                int j = high + 1;
                while (true)
                {
                    //left side animal profitability is smaller than the pivot animal 
                    while (animals[++i].Profitability() < middle.Profitability()) ;
                    //right side is bigger 
                    while (animals[--j].Profitability() > middle.Profitability()) ;
                    if (i >= j) break;//condition to break
                    //otherwise swap two animals
                    Swap(animals, i, j);
                }
                //left and right side do same process 
                QuickSort(animals, low, i - 1);
                QuickSort(animals, j + 1, high);
            }

        }

        private static void Swap(FarmAnimal[] fa, int i, int j)
        {
            //swap animals in the array
            FarmAnimal temp = fa[i];
            fa[i] = fa[j];
            fa[j] = temp;
        }
        /// <summary>
        /// count red color animal 
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static int RedColorCount(Dictionary<int, FarmAnimal> allAnimals)
        {
            int counter = 0;
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //if color is red increase counter
                if (fa.Color.Equals("Red", StringComparison.OrdinalIgnoreCase))
                {
                    counter++;
                }
            }

            return counter;
        }
        /// <summary>
        /// Input age return the number of animals age is above user input
        /// </summary>
        /// <param name="age"></param>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static int Age(int age, Dictionary<int, FarmAnimal> allAnimals)
        {
            int counter = 0;
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //if above input age 
                if (fa.Age > age)
                {
                    //increase
                    counter++;
                }
            }

            return counter;
        }
        /// <summary>
        /// Get jersey cow total tax
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double JerseyTax(Dictionary<int, FarmAnimal> allAnimals)
        {
            double totalTax = 0;
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //check if it is a cow 
                if (fa.GetType() == typeof(Cow))
                {
                    Cow faCow = (Cow)fa;
                    //check if it is a jersey cow
                    if (faCow.IsJersey)
                    {
                        totalTax += faCow.TaxPerYear();
                    }
                }
            }

            return totalTax;
        }

        /// <summary>
        /// get all jersey cow profit
        /// </summary>
        /// <param name="allAnimals"></param>
        /// <returns></returns>
        public static double ProfitJersey(Dictionary<int, FarmAnimal> allAnimals)
        {
            double totalProfit = 0;
            foreach (FarmAnimal fa in allAnimals.Values)
            {
                //check if it is a cow 
                if (fa.GetType() == typeof(Cow))
                {
                    Cow faCow = (Cow) fa;
                    //check if it is a jersey cow 
                    if (faCow.IsJersey)
                    {
                        totalProfit += faCow.Profitability();
                    }
                }
            }
            return totalProfit;
        }
    }
}
