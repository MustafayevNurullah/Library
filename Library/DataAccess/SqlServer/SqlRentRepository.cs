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
    public class SqlRentRepository : IRentRepository
    {

        public string ConnectionString { get => SqlContex.ConnectionString; }
        public SqlContex SqlContex;
        public SqlRentRepository(SqlContex sqlContex)
        {
            SqlContex = sqlContex;
        }
        public void Delete(RentEntity delete)
        {
            throw new NotImplementedException();
        }
        public List<RentEntity> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = "Select * From RentBooks";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<RentEntity> rentbooks = new List<RentEntity>();

                    while (sqlDataReader.Read())
                    {
                        RentEntity rententity = new RentEntity();
                        rententity.Id = Convert.ToInt32(sqlDataReader[nameof(rententity.Id)]);
                        rententity.BookId = Convert.ToInt32(sqlDataReader[nameof(rententity.BookId)]);
                        rententity.UserId = Convert.ToInt32(sqlDataReader[nameof(rententity.UserId)]);
                        rententity.CustomerId = Convert.ToInt32(sqlDataReader[nameof(rententity.CustomerId)]);
                        rententity.DailyRentPrice = Convert.ToDouble(sqlDataReader[nameof(rententity.DailyRentPrice)]);
                        rententity.Deadline = Convert.ToDateTime(sqlDataReader[nameof(rententity.Deadline)]);
                        rententity.RealDate = Convert.ToDateTime(sqlDataReader[nameof(rententity.RealDate)]);
                        rententity.RentDate = Convert.ToDateTime(sqlDataReader[nameof(rententity.RentDate)]);

                        rententity.Book = new BookEntity();
                        rententity.Book = App.Db.BookRepository.GetBook(rententity.BookId);
                        rententity.Customer = new CustomerEntity();
                        rententity.Customer = App.Db.CustomerRepository.GetCustomer(rententity.CustomerId);
                        rententity.User = new UserEntity();
                        rententity.User = App.Db.UserRepository.GetUser(rententity.UserId);
                        rentbooks.Add(rententity);
                    }
                    return rentbooks;
                }
            }
        }

        public void Insert(RentEntity insert)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = @"Insert into RentBooks(CustomerId,BookId,DailyRentPrice,Deadline,RealDate,RentDate,UserId)" +
                $"Values('{insert.CustomerId}','{insert.BookId}','{insert.DailyRentPrice}','{insert.Deadline}','{insert.RealDate}','{insert.RentDate}','{insert.UserId}')";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@CustomerId", insert.CustomerId);
                    sqlCommand.Parameters.AddWithValue("@BookId", insert.BookId);
                    sqlCommand.Parameters.AddWithValue("@DailyRentPrice", insert.DailyRentPrice);
                    sqlCommand.Parameters.AddWithValue("@Deadline", insert.Deadline);
                    sqlCommand.Parameters.AddWithValue("@RealDate", insert.RealDate);
                    sqlCommand.Parameters.AddWithValue("@RentDate", insert.RentDate);
                    sqlCommand.Parameters.AddWithValue("@UserId", insert.UserId);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public void Update(RentEntity Update)
        {
            throw new NotImplementedException();
        }
    }
}
