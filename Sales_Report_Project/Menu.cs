using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Report_Project
{
    class Menu
    {
        functions f = new functions();

        public void MainMenu()
        {
            Console.WriteLine("*******Sales Report********");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("");
            Console.WriteLine("1.Add Sales Data");
            Console.WriteLine("2.View Reports");
            Console.WriteLine("3.Exit");
            int ch = Int32.Parse(Console.ReadLine());

            if(ch == 1)
            {
                DataEntryMenu();
            }

            if(ch == 2)
            {
                ReportsMenu();
            }

            if (ch == 3)
            {
                Console.WriteLine("Thank you, goodbye");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
        }

        public void DataEntryMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("********Add Sales Data********");
            Console.WriteLine("Information required to add data to sales report:");
            Console.WriteLine("Sale ID, Product Name, Quantity Sold, Price");
            Console.WriteLine("");

            string choice = "Y";
            while (choice == "Y" || choice == "y")
            {


                Console.WriteLine("Product Name:");
                string prodName = Console.ReadLine();

                Console.WriteLine("Quantity sold:");
                string quantity = Console.ReadLine();

                Console.WriteLine("Price:");
                string price = Console.ReadLine();

                f.addData(prodName, quantity, price);
                
                Console.WriteLine("Data added! Do you want to add more? (Y/N)");
                choice = Console.ReadLine();
            }
        }

        public void ReportsMenu()
        {

            Console.WriteLine("");
            Console.WriteLine("********View Reports********");
            Console.WriteLine("Select option for which report to view:");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1:Products sold by year");
            Console.WriteLine("2:Products sold by month in year");
            Console.WriteLine("3:Total sales by year");
            Console.WriteLine("4:Total sales by month in year");
            Console.WriteLine("5: Back to Main Menu");
            int ch2 = Int32.Parse(Console.ReadLine());

            if (ch2 == 1)
            {
                f.prodByYear();
            }

            if (ch2 == 2)
            {
                f.prodByMonthYear();

            }

            if (ch2 == 3)
            {
                f.totalSalesYear();
            }

            if (ch2 == 4)
            {
                f.totalSalesMonthYear();
            }

            if (ch2 == 5)
            {
                MainMenu();
            }
        }

    }
}
