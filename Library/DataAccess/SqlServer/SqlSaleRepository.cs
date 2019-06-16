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
    public class SqlSaleRepository : ISaleRepository
    {

        public string ConnectionString { get => SqlContex.ConnectionString; }

        public SqlContex SqlContex;
        public SqlSaleRepository(SqlContex sqlContex)
        {
            SqlContex = sqlContex;
        }
        public void Delete(BuyEntity delete)
        {
            throw new NotImplementedException();
        }
        public List<BuyEntity> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = "Select * From SaleBooks";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<BuyEntity> salebooks = new List<BuyEntity>();

                    while (sqlDataReader.Read())
                    {
                        BuyEntity saleentity = new BuyEntity();
                        saleentity.Id = Convert.ToInt32(sqlDataReader[nameof(saleentity.Id)]);
                        saleentity.BookId = Convert.ToInt32(sqlDataReader[nameof(saleentity.BookId)]);
                        saleentity.UserId = Convert.ToInt32(sqlDataReader[nameof(saleentity.UserId)]);
                        saleentity.CustomerId = Convert.ToInt32(sqlDataReader[nameof(saleentity.CustomerId)]);
                        saleentity.Date = Convert.ToDateTime(sqlDataReader[nameof(saleentity.Date)]);
                        saleentity.Note = Convert.ToString(sqlDataReader[nameof(saleentity.Note)]);
                        saleentity.SalePrice = Convert.ToDouble(sqlDataReader[nameof(saleentity.SalePrice)]);
                        
                        saleentity.Book = new BookEntity();
                        saleentity.Book = App.Db.BookRepository.GetBook(saleentity.BookId);
                        saleentity.Customer = new CustomerEntity();
                        saleentity.Customer = App.Db.CustomerRepository.GetCustomer(saleentity.CustomerId);
                        saleentity.User = new UserEntity();
                        saleentity.User = App.Db.UserRepository.GetUser(saleentity.UserId);
                        salebooks.Add(saleentity);
                    }
                    return salebooks;
                }
            }
        }

        public void Insert(BuyEntity insert)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = @"Insert into SaleBooks(BookId,CustomerId,Date,Note,SalePrice,UserId)" +
                $"Values('{insert.BookId}','{insert.CustomerId}','{insert.Date}','{insert.Note}','{insert.SalePrice}','{insert.UserId}')";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@BookId", insert.BookId);
                    sqlCommand.Parameters.AddWithValue("@CustomerId", insert.CustomerId);
                    sqlCommand.Parameters.AddWithValue("@Date", insert.Date);
                    sqlCommand.Parameters.AddWithValue("@Note", insert.Note);
                    sqlCommand.Parameters.AddWithValue("@SalePrice", insert.SalePrice);
                    sqlCommand.Parameters.AddWithValue("@UserId", insert.UserId);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Update(BuyEntity Update)
        {
            throw new NotImplementedException();
        }
    }
}
