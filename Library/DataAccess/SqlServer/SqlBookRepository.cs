using Library.Domain.Abstraction;
using Library.Entity;
using Library.ViewModel;
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
        BookViewModel BookViewModel;
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
                string cmd = "Select * From Books ";
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
                        BookEntity.BranchId =  Convert.ToInt32(sqlDataReader[nameof(BookEntity.BranchId)]);
                        BookEntity.BuyPrice = Convert.ToDouble(sqlDataReader[nameof(BookEntity.BuyPrice)]);
                        BookEntity.SalePrice = Convert.ToDouble(sqlDataReader[nameof(BookEntity.SalePrice)]);

                        BookEntity.Branch = new FilialEntity();
                        BookEntity.Branch = App.Db.BranchRepository.GetBranch(BookEntity.BranchId);

                       // BookEntity.BranchName = App.Db.BranchRepository.GetBranch(BookEntity.BranchId);
                       
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
                string cmd = @"Insert into Books(Name,Author,Count,BranchId,BuyPrice,SalePrice)" +
                $"Values('{insert.Name}','{insert.Author}','{insert.Count}','{insert.BranchId}','{insert.BuyPrice}','{insert.SalePrice}')";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@Author", insert.Author);
                    sqlCommand.Parameters.AddWithValue("@Name", insert.Name);
                    sqlCommand.Parameters.AddWithValue("@BranchId", insert.BranchId);
                    sqlCommand.Parameters.AddWithValue("@Count", insert.Count);
                    sqlCommand.Parameters.AddWithValue("@BuyPrice", insert.BuyPrice);
                    sqlCommand.Parameters.AddWithValue("@SalePrice", insert.SalePrice);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public void Update(BookEntity Update)
        {
            string cmd = $"UPDATE Books " +
                 $"SET Name = @Name,Author = @Author,BranchId=@BranchId,Count=@Count,BuyPrice=@BuyPrice,SalePrice=@SalePrice WHERE Books.Id = @Id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.Parameters.AddWithValue("@Id", Update.Id);
                    command.Parameters.AddWithValue("@Name", Update.Name);
                    command.Parameters.AddWithValue("@Author", Update.Author);
                    command.Parameters.AddWithValue("@BranchId", Update.BranchId);
                    command.Parameters.AddWithValue("@Count", Update.Count);
                    command.Parameters.AddWithValue("@BuyPrice", Update.BuyPrice);
                    command.Parameters.AddWithValue("@SalePrice", Update.SalePrice);
                    command.ExecuteNonQuery();
                }
            }
        }

        public BookEntity GetBook(int Id)
        {
            string cmd;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                cmd = $"Select Name,SalePrice From Books Where Books.Id={Id}";
                BookEntity bookEntity = new BookEntity();
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        bookEntity.Name = Convert.ToString(sqlDataReader[nameof(bookEntity.Name)]);
                        bookEntity.SalePrice = Convert.ToDouble(sqlDataReader[nameof(bookEntity.SalePrice)]);
                        //   filialEntity.Id = Convert.ToInt32(sqlDataReader[nameof(filialEntity.Id)]);
                        // filialEntity.Address = Convert.ToString(sqlDataReader[nameof(filialEntity.Address)]);
                    }
                }
                return bookEntity;
            }
        }
    }
}
