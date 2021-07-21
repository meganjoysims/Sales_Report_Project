
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sales_Report_Project
{
    class functions
    {
        MySqlConnection con;
        MySqlCommand cmd;

        public functions()
        {
            string connectionstring = "server=localhost;user=root;password=root;database=sales";
            con = new MySqlConnection(connectionstring);
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        public void addData(string prodName, string quantity, string price)
        {
            
            cmd.CommandText = $"select max(substr(SaleID,1,3)+1) from sales_report";
            MySqlDataReader data = cmd.ExecuteReader();
            data.Read();
            string newSaleID = "00" + data[0];


            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            data.Close();
            cmd.CommandText = $"insert into sales_report values({newSaleID}, '{prodName}', {quantity}, {price}, '{currentDate}')";
            cmd.ExecuteNonQuery();

            data.Close();
        }

        public void prodByYear()
        {
            Console.WriteLine("See products sold by year");
            Console.WriteLine("Select year: (YYYY) ");
            string YrSelected = Console.ReadLine();

            string sqlSelect = $"select * from sales_report where substr(SaleDate, 1,4)='{YrSelected}'";
            showData(sqlSelect);
            Console.ReadLine();


        }

        public void prodByMonthYear()
        {
            Console.WriteLine("See products sold by month in year");
            Console.WriteLine("Select month: (MM)");
            string MthSelected = Console.ReadLine();
            Console.WriteLine("Select year: (YYYY)");
            string YrSelected = Console.ReadLine();

            string sqlSelect = $"select * from sales_report where substr(SaleDate, 6,2)='{MthSelected}' && substr(SaleDate, 1,4)='{YrSelected}'";
            showData(sqlSelect);
            Console.ReadLine();

        }

        public void totalSalesYear()
        {
            Console.WriteLine("See total sales by year");
            Console.WriteLine("Select year: (YYYY) ");
            string YrSelected = Console.ReadLine();

            string sqlSelect = $"select count(*) from sales_report where substr(SaleDate, 1,4)='{YrSelected}'";
            showData2(sqlSelect);
            Console.ReadLine();


        }

        public void totalSalesMonthYear()
        {
            Console.WriteLine("See total sales by month in year");
            Console.WriteLine("Select month: (MM)");
            string MthSelected = Console.ReadLine();
            Console.WriteLine("Select year: (YYYY)");
            string YrSelected = Console.ReadLine();

            string sqlSelect = $"select count(*) from sales_report where substr(SaleDate, 6, 2)='{MthSelected}' && substr(SaleDate, 1,4)='{YrSelected}'";
            showData2(sqlSelect);
            Console.ReadLine();

        }

        private void showData(string sqlSelect)
        {

            cmd.CommandText = sqlSelect;
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine($"{data[0]}, {data[1]}, {data[2]}, {data[3]}, {data[4]}");
            }
            Console.Read();
        }

        private void showData2(string sqlSelect)
        {

            cmd.CommandText = sqlSelect;
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Console.WriteLine(data[0] + " Sales made");
            }
            Console.Read();
        }
    }
}
