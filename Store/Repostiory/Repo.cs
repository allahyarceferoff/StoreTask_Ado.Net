using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;
using System.Configuration;
using Store.Views.UserControls;
using System.Windows;

namespace Store.Repostiory
{
    public class Repo
    {
        string cs = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

        public Repo()
        {

        }

        public async Task GetAllProduct(ObservableCollection<Product> _products)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                var query = "SELECT * FROM Products";

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;


                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Product product = new Product
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Quantity = int.Parse(reader[2].ToString()),
                            Price = decimal.Parse(reader[3].ToString()),
                            CategoryId = int.Parse(reader[4].ToString()),
                            ImagePath = reader[5].ToString(),
                        };
                        _products.Add(product);
                    }
                }
            }
        }

        public async Task GetAllCategories(ObservableCollection<Category> _categories)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                var query = "SELECT * FROM Categories";

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;


                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Category category = new Category
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                        };
                        _categories.Add(category);
                    }
                }
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                SqlTransaction sqlTransaction = null;

                var query = "DELETE FROM Products WHERE Id=@id";

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;

                sqlTransaction = conn.BeginTransaction();


                command.Transaction = sqlTransaction;

                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@id";
                parameterName.SqlDbType = SqlDbType.Int;
                parameterName.Value = id;

                command.Parameters.Add(parameterName);

                try
                {
                    await command.ExecuteNonQueryAsync();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                    sqlTransaction.Rollback();
                }
            }
        }

        public async void Insert(string name, decimal price, int quantity,Category category)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                string query = $@" INSERT INTO Products([CategoryId],[Name],[Price],[Quantity])
                                VALUES(@categoryId,@name,@price,@quantity)";

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;

                var paramCategoryId = new SqlParameter();
                paramCategoryId.ParameterName = "@categoryId";
                paramCategoryId.SqlDbType = SqlDbType.Int;
                paramCategoryId.Value = category.Id;

                var paramName = new SqlParameter();
                paramName.ParameterName = "@name";
                paramName.SqlDbType = SqlDbType.NVarChar;
                paramName.Value = name;

                var paramPrice = new SqlParameter();
                paramPrice.ParameterName = "@price";
                paramPrice.SqlDbType = SqlDbType.Money;
                paramPrice.Value = price;

                var paramQuantity = new SqlParameter();
                paramQuantity.ParameterName = "@quantity";
                paramQuantity.SqlDbType = SqlDbType.Int;
                paramQuantity.Value = quantity;

                command.Parameters.Add(paramCategoryId);
                command.Parameters.Add(paramName);
                command.Parameters.Add(paramPrice);
                command.Parameters.Add(paramQuantity);

                using (var reader = await command.ExecuteReaderAsync())
                {

                }
            }
        }
    }
}
