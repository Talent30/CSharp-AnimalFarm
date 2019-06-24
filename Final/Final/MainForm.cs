using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Final
{
    public partial class MainForm : Form
    {
        //create dictionary 
        Dictionary<int, FarmAnimal> allAnimals = new Dictionary<int, FarmAnimal>();
        public MainForm()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //this button is for search the age 
            textBox1.Clear();
            //convert user input
            if (int.TryParse(textBox2.Text, out int id))
            {
                //search from dictionary
                Display(id, allAnimals);
            }
            else
            {
                MessageBox.Show(@"Please input a correct id");
            }
        }

        private void Display(int id, Dictionary<int, FarmAnimal> allAnimals)
        {
            try
            {
                //if there is not the id in the dictionary
                FarmAnimal fa = allAnimals[id];
                textBox1.AppendText(fa.DisplayInfo());
            }
            catch (Exception)
            {//display error 
                MessageBox.Show(@"The id is not present in the dictionary, please connect to the database or check your id");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //be sure user connect to the database first
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to the database");
                return;
            }
            //get total profitability 
            double total = FarmReport.Prof(allAnimals);
            textBox1.Clear();
            textBox1.AppendText("Total profitability per day: " + total.ToString("P"));

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //be sure user connect to the databse
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to the database");
                return;
            }
            //get total tax per month 
            textBox1.Clear();
            textBox1.AppendText("Tax per month is: " + FarmReport.TotalTaxPerMonth(allAnimals).ToString("C"));
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //connect to databse before functioning 
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to the database");
                return;
            }
            textBox1.Clear();
            //get cow milk amount
            double cowMilk = FarmReport.CowMilkAmount(allAnimals);
            //get goat milk amount
            double goatMilk = FarmReport.GoatMilkAmount(allAnimals);
            //total
            double total = goatMilk + cowMilk;
            string a =
                $"Cow milk amount is: {cowMilk}\r\nGoat milk amount is: {goatMilk}\r\nTotal milk amount is:{total}";
            textBox1.AppendText(a);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //connect to database
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to the database");
                return;
            }

            textBox1.Clear();
            //get average age 
            textBox1.AppendText("The Average age of animals in the farm: " + FarmReport.AverageAge(allAnimals).ToString("F1"));
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //connect to the database
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to the database");
                return;
            }
            textBox1.Clear();
            //cow and goat profit compare goat profit
            string a =
                $"Average goats and cows profitability:{FarmReport.AverageGoatCowProf(allAnimals):F}\r\nAverage sheep profitability: {FarmReport.AverageSheepProf(allAnimals):F}";
            textBox1.AppendText(a);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //connect to the database
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to the database");
                return;
            }
            textBox1.Clear();
            //get total cost
            double totalCost = FarmReport.TotalCost(allAnimals);
            //get dog cost
            double dogCost = FarmReport.DogCost(allAnimals);
            //get percentage
            double percentage = dogCost / totalCost;
            textBox1.AppendText("Total Cost: " + totalCost.ToString("F") + "\r\n" + "Dog Cost: " + dogCost.ToString("C") + "\r\n" + "Ratio: " + percentage.ToString("P"));
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to the database");
                return;
            }
            //new thread for file dialog and write file
            ThreadStart threadStart1 = OpenFileDialog;
            Thread t1 = new Thread(threadStart1);

            t1.TrySetApartmentState(ApartmentState.STA);
            //start thread
            t1.Start();

        }
        private void OpenFileDialog()
        {

            
            //open file dialog
            saveFileDialog1 = new SaveFileDialog { Filter = @"Text Files | *.txt" };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //create a variable store the file path 
                //check if the path is valid 
                string filepath = saveFileDialog1.FileName;
                if (!string.IsNullOrEmpty(filepath))
                {
                    //after check start write file 
                    Write(filepath);
                }
            }

        }
        private void Write(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //star writing
            //ger sorted array
            FarmAnimal[] animals = FarmReport.SortArray(allAnimals);
                //write array to file, profitability should from high to low
            for (int i = animals.Length - 1; i >= 0; i--)
            {
                //skip dog
                if (animals[i].GetType() == typeof(Dog))
                {
                }
                else
                {
                    sw.WriteLine("ID: " + animals[i].Id + "  Profitability: " +
                                 animals[i].Profitability().ToString("F"));
                }
            }

            //clean buffer
            sw.Flush();
            //close stream 
            sw.Close();
            fs.Close();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connection to the database");
                return;
            }
            textBox1.Clear();
            //number of red animals 
            int redCount = FarmReport.RedColorCount(allAnimals);
            //number of all the animals
            int totalCount = allAnimals.Count;
            //get ratio
            double ratio = redCount / (double)totalCount;
            textBox1.AppendText("Total number of animal: " + totalCount + "\r\n" + "Number of red color animal: " + redCount + "\r\n" + "Red color ratio is: " + ratio.ToString("P"));
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connection to the database");
                return;
            }
            textBox1.Clear();
            //get jersey tax
            double jerseyTax = FarmReport.JerseyTax(allAnimals);
            textBox1.AppendText("Total tax paid for Jersey Cows is: " + jerseyTax.ToString("C"));
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            //connect to database
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to database");
                return;
            }
            //get total animal count
            double totalAnimal = allAnimals.Count;
            //convert user input age
            if (int.TryParse(textBox3.Text, out int inputAge))
            {
                //get number of animals above the age
                int aboveCount = FarmReport.Age(inputAge, allAnimals);
                textBox1.Clear();
                double ratio = aboveCount / totalAnimal;
                textBox1.AppendText("Number age is above: " + aboveCount + "\r\n" + "Number of all animals: " +
                                    totalAnimal + "\r\n" + "Age above " + inputAge + " ratio: " + ratio.ToString("P"));
            }
            else
            {
                //if convert fail 
                MessageBox.Show(@"Please input a correct age");
            }

        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (connectToolStripMenuItem.Enabled)
            {
                MessageBox.Show(@"Please connect to database");
                return;
            }
            //get jersey tax
            double profit = FarmReport.ProfitJersey(allAnimals);
            textBox1.Clear();
            textBox1.AppendText("Total Jersey profitability is: " + profit.ToString("c"));

        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //after click connect to the database
            FarmDataBase.ReadAnimal(allAnimals);
            //after connect should not connect anymore
            connectToolStripMenuItem.Enabled = false;
            //allow user to click disconnect
            disconnectToolStripMenuItem.Enabled = true;
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //click disconnect connect button should be enable 
            connectToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
            //disconnect database 
            FarmDataBase.Disconnect();
            //clear dictionary
            allAnimals.Clear();
        }
    }
}
