using Library.Domain.Abstraction;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.SqlServer
{
    public class SqlBookRepository : IBookRepository
    {
        public string ConnectionString { get => SqlContex.ConnectionString; }

        public SqlContex SqlContex;
        public SqlBookRepository(SqlContex sqlContex)
        {
            SqlContex = sqlContex;
        }




        public void Delete(BookEntity delete)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                string cmd = $"Delete From Books Where Branchs.Id={delete.Id}";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<BookEntity> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = "Select * From Books";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<BookEntity> books = new List<BookEntity>();

                    while (sqlDataReader.Read())
                    {
                        BookEntity BookEntity = new BookEntity();
                        BookEntity.Id = Convert.ToInt32(sqlDataReader[nameof(BookEntity.Id)]);
                        BookEntity.Name = Convert.ToString(sqlDataReader[nameof(BookEntity.Name)]);
                        BookEntity.Author = Convert.ToString(sqlDataReader[nameof(BookEntity.Author)]);
                        BookEntity.Count = Convert.ToInt32(sqlDataReader[nameof(BookEntity.Count)]);
                        BookEntity.BranchName = Convert.ToString(sqlDataReader[nameof(BookEntity.BranchName)]);
                        BookEntity.BuyPrice = Convert.ToDouble(sqlDataReader[nameof(BookEntity.BuyPrice)]);
                        BookEntity.SalePrice = Convert.ToDouble(sqlDataReader[nameof(BookEntity.SalePrice)]);
                        books.Add(BookEntity);
                    }
                    return books;
                }
            }
        }

        public void Insert(BookEntity insert)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = @"Insert into Books(Name,Author,Count,BranchName,BuyPrice,SalePrice)" +
                $"Values('{insert.Name}','{insert.Author}','{insert.Count},'{insert.BranchName},'{insert.BuyPrice}','{insert.SalePrice}')";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", insert.Name);
                    sqlCommand.Parameters.AddWithValue("@Author", insert.Author);
                    sqlCommand.Parameters.AddWithValue("@Count", insert.Count);
                    sqlCommand.Parameters.AddWithValue("@BranchName", insert.BranchName);
                    sqlCommand.Parameters.AddWithValue("@BuyPrice", insert.BuyPrice);
                    sqlCommand.Parameters.AddWithValue("@SalePrice", insert.SalePrice);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public void Update(BookEntity Update)
        {
            string cmd = $"UPDATE Branchs " +
                 $"SET Name = @Name,Address = @Address WHERE Branchs.Id = @Id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.Parameters.AddWithValue("@Name", Update.Name);
                    command.Parameters.AddWithValue("@Id", Update.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
