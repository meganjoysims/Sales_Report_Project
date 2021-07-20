using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Report_Project
{
    class Menu
    {

        public void MainMenu()
        {
            Console.WriteLine("Sales Report");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("");
            Console.WriteLine("1.Data Entry");
            Console.WriteLine("2.Reports");
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
            Console.WriteLine("Information required to add data to sales report:");
            Console.WriteLine("Sale ID, Product Name, Quantity Sold, Price");
            Console.WriteLine("");
            
            //Console.WriteLine("Sale ID:");
            //string saleID = Console.ReadLine();

            Console.WriteLine("Product Name:");
            string prodName = Console.ReadLine();

            Console.WriteLine("Quantity sold:");
            string quantity = Console.ReadLine();

            Console.WriteLine("Price:");
            string price = Console.ReadLine();

            Console.Read();
            functions sales = new functions();
            sales.addData(prodName, quantity, price);
        }

        public void ReportsMenu()
        {

            Console.WriteLine("");
            Console.WriteLine("Select option for which report to view:");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1:Products sold by year");
            Console.WriteLine("2:Products sold by month in year");
            Console.WriteLine("3:Total sales by year");
            Console.WriteLine("4:Total sales by month in year");
            int ch2 = Int32.Parse(Console.ReadLine());
        }

    }
}
