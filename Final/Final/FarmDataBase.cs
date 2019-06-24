using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Final
{
    class FarmDataBase
    {
        //connection string
        private static string _conn =
            "Provider=Microsoft.ACE.OLEDB.16.0; Data Source=C:\\Users\\Public\\FarmInfomation.accdb; Persist Security Info=False";

        private static OleDbConnection _fConnection;
        private static void OpenDataBase()
        {
            {
                //open data base connection 
                _fConnection = new OleDbConnection(_conn);
                _fConnection.Open();
            }
        }

        public static void Disconnect()
        {
            //close the connection 
            _fConnection.Close();
        }
        public static void ReadAnimal(Dictionary<int, FarmAnimal> allAnimals)
        {
            //call methods to read database into dictionary 
            OpenDataBase();
            ReadToCow(allAnimals);
            ReadToDog(allAnimals);
            ReadToGoat(allAnimals);
            ReadToSheep(allAnimals);
            ReadCommodity();
        }
        private static void ReadToCow(Dictionary<int, FarmAnimal>allAnimals)
        {
            //get all cows
            string _q = "Select * From Cows";
            //read all cows 
            OleDbCommand cmd = new OleDbCommand(_q, _fConnection);
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                //add them into dictionary 
                while (reader != null && reader.Read())
                {
                    FarmAnimal fa = new Cow(Convert.ToInt32(reader[0]), Convert.ToDouble(reader[1]), Convert.ToDouble(reader[2]), Convert.ToDouble(reader[3]), Convert.ToInt32(reader[4]), Convert.ToString(reader[5]), Convert.ToDouble(reader[6]), Convert.ToBoolean(reader[7]));
                    allAnimals.Add(Convert.ToInt32(reader[0]), fa);
                }
            }
        }
        private static void ReadToGoat(Dictionary<int, FarmAnimal> allAnimals)
        {
            //get all the goats
            string _q = "Select * From Goats";
            OleDbCommand cmd = new OleDbCommand(_q, _fConnection);
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                //read into dictionary
                while (reader != null && reader.Read())
                {
                   FarmAnimal af = new Goat(Convert.ToInt32(reader[0]), Convert.ToDouble(reader[1]), Convert.ToDouble(reader[2]), Convert.ToDouble(reader[3]), Convert.ToInt32(reader[4]), Convert.ToString(reader[5]), Convert.ToDouble(reader[6]));
                    allAnimals.Add(Convert.ToInt32(reader[0]), af);
                }
            }
        }
        private static void ReadToDog(Dictionary<int, FarmAnimal> allAnimals)
        {
            //read all dogs
            string _q = "Select * From Dogs";
            OleDbCommand cmd = new OleDbCommand(_q, _fConnection);
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader != null && reader.Read())
                {
                    //add into dictionary 
                    FarmAnimal af = new Dog(Convert.ToInt32(reader[0]), Convert.ToDouble(reader[1]), Convert.ToInt32(reader[5]), Convert.ToDouble(reader[2]), Convert.ToInt32(reader[3]), Convert.ToString(reader[4]));
                    allAnimals.Add(Convert.ToInt32(reader[0]), af);
                }
            }
        }
        private static void ReadToSheep(Dictionary<int, FarmAnimal> allAnimals)
        {
            //read all sheeps 
            string _q = "Select * From Sheep";
            OleDbCommand cmd = new OleDbCommand(_q, _fConnection);
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                //add to dictionary
                while (reader != null && reader.Read())
                {
                    FarmAnimal af = new Sheep(Convert.ToInt32(reader[0]), Convert.ToDouble(reader[1]), Convert.ToInt32(reader[2]), Convert.ToDouble(reader[3]), Convert.ToInt32(reader[4]), Convert.ToString(reader[5]), Convert.ToDouble(reader[6]));
                    allAnimals.Add(Convert.ToInt32(reader[0]), af);
                }
            }
        }
        private static void ReadCommodity()
        {
            //select cost table 
            string _q = "Select * From Commodity_Price";
            OleDbCommand cmd = new OleDbCommand(_q, _fConnection);
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                //in-case over write the values use counter to control 
                int order = 0;
                while (reader != null && reader.Read())
                {

                    switch (order)
                    {
                        case 0:
                            {
                                Prices.GoatMilkPrice = Convert.ToDouble(reader[1]);
                                order++;
                                break;
                            }

                        case 1:
                            {
                                Prices.SheepWoolPrice = Convert.ToDouble(reader[1]);
                                order++;
                                break;
                            }

                        case 2:
                            {
                                Prices.WaterPrice = Convert.ToDouble(reader[1]);
                                order++;
                                break;
                            }

                        case 3:
                            {
                                Prices.TaxPerKg = Convert.ToDouble(reader[1]);
                                order++;
                                break;
                            }

                        case 4:
                            {
                                Prices.JerseyTaxPerKg = Convert.ToDouble(reader[1]);
                                order++;
                                break;
                            }

                        case 5:
                            {
                                Prices.CowMilkPrice = Convert.ToDouble(reader[1]);
                                order++;
                                break;

                            }
                    }
                }

            }

        }
    }
}
