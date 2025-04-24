using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Daily_Sales.Models;

namespace HamroDailySales.Data
{
    public class DataBaseObject
    {
        private readonly string _connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=HamroSalesSumanThapa;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public async Task<bool> SaveItem(Sale sale)
        {
            if (sale == null || string.IsNullOrEmpty(sale.ItemType) || string.IsNullOrEmpty(sale.Brand) || string.IsNullOrEmpty(sale.Quantity) || sale.Price <= 0)
            {
                System.IO.File.AppendAllText("error.log", $"{DateTime.Now}: Invalid sale data\n");
                return false;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var query = @"
                        INSERT INTO Sales (ItemType, Brand, Quantity, Price, Remarks, CreatedDate)
                        VALUES (@ItemType, @Brand, @Quantity, @Price, @Remarks, @CreatedDate)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemType", sale.ItemType);
                        command.Parameters.AddWithValue("@Brand", sale.Brand);
                        command.Parameters.AddWithValue("@Quantity", sale.Quantity);
                        command.Parameters.AddWithValue("@Price", sale.Price);
                        command.Parameters.AddWithValue("@Remarks", sale.Remarks ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedDate", sale.CreatedDate);

                        await command.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception err)
            {
                System.IO.File.AppendAllText("error.log", $"{DateTime.Now}: SaveItem error: {err.Message}\n");
                return false;
            }
        }

        public async Task<List<Sale>> TotallSales()
        {
            List<Sale> karobar = new List<Sale>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = "SELECT ItemType, Brand, Quantity, Price, Remarks, CreatedDate FROM Sales";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Sale sale = new Sale
                            {
                                ItemType = reader["ItemType"] as string,
                                Brand = reader["Brand"] as string,
                                Quantity = reader["Quantity"] != DBNull.Value ? reader["Quantity"].ToString() : string.Empty,
                                Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0,
                                Remarks = reader["Remarks"] as string,
                                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.MinValue
                            };
                            karobar.Add(sale);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("error.log", $"{DateTime.Now}: TotallSales error: {ex.Message}\n");
            }
            return karobar;
        }
    }
}