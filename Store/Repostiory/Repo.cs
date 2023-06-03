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

namespace Store.Repostiory
{
    public class Repo
    {
        ObservableCollection<Product> _products = new ObservableCollection<Product>();
        ObservableCollection<Category> _categories = new ObservableCollection<Category>();
        SqlConnection conn;
        string cs = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

        public Repo()
        {
            using (conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                SqlDataReader reader = null;

                string query = "SELECT * FROM Products";
                using (var command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
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

            using (conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();

                SqlDataReader reader = null;

                string query = "SELECT * FROM Categories";
                using (var command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            Id=int.Parse(reader[0].ToString()),
                            Name=reader[1].ToString(),
                        };
                        _categories.Add(category);
                    }
                }
            }
        }

        public ObservableCollection<Product> GetAllProduct()
        {
            return _products;
        }

        public ObservableCollection<Category> GetAllCategories()
        {
            return _categories;
        }

        public void Insert(int id, string firstName, string lastName)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = cs;
                conn.Open();


                string query = $@" INSERT INTO Authors(Id,FirstName,LastName)
                                VALUES(@id,@firstName,@lastName)";

                var paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.SqlDbType = SqlDbType.Int;
                paramId.Value = id;

                var paramName = new SqlParameter();
                paramName.ParameterName = "@firstName";
                paramName.SqlDbType = SqlDbType.NVarChar;
                paramName.Value = firstName;

                var paramSurname = new SqlParameter();
                paramSurname.ParameterName = "@lastName";
                paramSurname.SqlDbType = SqlDbType.NVarChar;
                paramSurname.Value = lastName;

                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.Add(paramId);
                    command.Parameters.Add(paramName);
                    command.Parameters.Add(paramSurname);

                    var result = command.ExecuteNonQuery();
                }
                //Author author = new Author
                //{
                //    Id = id,
                //    FirstName = firstName,
                //    LastName = lastName
                //};
                //_authors.Add(author);
            }
        }
    }
}
