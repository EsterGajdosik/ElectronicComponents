using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ElectronicComponents.Pages.Stock
{
    public class IndexModel : PageModel
    {
        public List<StockInfo> listStocks = new List<StockInfo>();
        public void OnGet(string searchString)
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ElectronicComponents;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM stock";
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        sql += $" WHERE name LIKE '%{searchString}%'";
                    }

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StockInfo stockInfo = new StockInfo();
                                stockInfo.id = "" + reader.GetInt32(0);
                                stockInfo.name = reader.GetString(1);
                                stockInfo.manufacturer = reader.GetString(2);
                                stockInfo.price = reader.GetString(3);
                                stockInfo.address = reader.GetString(4);
                                stockInfo.created_at = reader.GetDateTime(5).ToString();

                                listStocks.Add(stockInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class StockInfo
    {
        public string id;
        public string name;
        public string manufacturer;
        public string price;
        public string address;
        public string created_at;
    }
}
