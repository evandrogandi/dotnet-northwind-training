using System.Collections.Generic;
using GAtec.Northwind.Domain.Model;
using GAtec.Northwind.Domain.Repository;
using System.Data;
using System.Data.SqlClient;
using Gatec.Northwind.Util;


namespace GAtec.Northwind.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        Category category = null;
        public void Add(Category item)
        {

            using (var con = new SqlConnection(NorthwindSetting.ConnectionString))
            {

                con.Open();

                using (var cmd = new SqlCommand("insert into Categories (CategoryName, Description) values (@name, @description)", con))
                {

                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("description", SqlDbType.NText).Value = item.Description;

                    cmd.ExecuteNonQuery();
                }

            }

            //throw new System.NotImplementedException();
        }

        public void Update(Category item)
        {
            using (var con = new SqlConnection(NorthwindSetting.ConnectionString))
            {

                con.Open();

                using (var cmd = new SqlCommand("update Categories set CategoryName = @name, Description= @description where id = @id", con))
                {

                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("description", SqlDbType.NText).Value = item.Description;
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = item.Id;

                    cmd.ExecuteNonQuery();
                }

            }
        }


        public void Delete(object id)
        {
            using (var con = new SqlConnection(NorthwindSetting.ConnectionString))
            {

                con.Open();

                using (var cmd = new SqlCommand("delete Categories where id = @id", con))
                {

                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public Category Get(object id)
        {

            using (var con = new SqlConnection(NorthwindSetting.ConnectionString))
            {

                con.Open();

                using (var cmd = new SqlCommand("select * from Categories where id = @id", con))
                {

                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = new Category();

                            category.Id = (int)reader["CategoryId"];
                            category.Name = reader.GetString(1);
                            category.Description = reader.GetString(reader.GetOrdinal("Description"));
                        }
                    }

                }
                return category;
            }
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();

            using (var con = new SqlConnection(NorthwindSetting.ConnectionString))
            {

                con.Open();

                using (var cmd = new SqlCommand("select * from Categories order by Categoryid", con))                {
                                       

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            category = new Category();

                            category.Id = (int)reader["CategoryId"];
                            category.Name = reader.GetString(1);
                            category.Description = reader.GetString(reader.GetOrdinal("Description"));

                            categories.Add(category);
                        }
                    }

                }
               
            }
            return categories;
        }

        public bool ExistsName(string name, int id = 0)
        {
            var result = false;
            using (var con = new SqlConnection(NorthwindSetting.ConnectionString))
            {

                con.Open();

                using (var cmd = new SqlCommand("select * from categories where upper(CategoryName) = @name and Categoryid <> @id", con))
                {

                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = name.ToUpper();
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    result = (int) cmd.ExecuteScalar() > 0;
                }

            }
            return result;
        }
    }
}