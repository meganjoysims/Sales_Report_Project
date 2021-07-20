
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
            //connects to Nationwide database in MySql
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
            cmd.CommandText = $"insert into sales_report values('{newSaleID}', '{prodName}', '{quantity}', '{price}', '{currentDate}')";
            cmd.ExecuteNonQuery();

            Console.ReadLine();
            data.Close();
        }

    }
}
