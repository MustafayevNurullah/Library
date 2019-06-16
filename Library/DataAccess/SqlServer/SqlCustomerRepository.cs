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
    public class SqlCustomerRepository : ICustomerRepository
    {

        public string ConnectionString { get => SqlContex.ConnectionString; }

        public SqlContex SqlContex;
        public SqlCustomerRepository(SqlContex sqlContex)
        {
            SqlContex = sqlContex;
        }




        public void Delete(CustomerEntity delete)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                string cmd = $"Delete From Customers Where Customers.Id={delete.Id}";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<CustomerEntity> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = "Select * From Customers";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<CustomerEntity> customers = new List<CustomerEntity>();
                    while (sqlDataReader.Read())
                    {
                        CustomerEntity customerEntity = new CustomerEntity();
                        customerEntity.Id = Convert.ToInt32(sqlDataReader[nameof(customerEntity.Id)]);
                        customerEntity.Name = Convert.ToString(sqlDataReader[nameof(customerEntity.Name)]);
                        customerEntity.Surname = Convert.ToString(sqlDataReader[nameof(customerEntity.Surname)]);
                        customerEntity.Phone = Convert.ToString(sqlDataReader[nameof(customerEntity.Phone)]);
                        customerEntity.Data = Convert.ToString(sqlDataReader[nameof(customerEntity.Data)]);
                        customers.Add(customerEntity);
                    }
                    return customers;
                }
            }
        }
        public void Insert(CustomerEntity insert)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = @"Insert into Customers(Name,Surname,Phone,Data)" +
                $"Values('{insert.Name}','{insert.Surname}','{insert.Phone}','{insert.Data}')";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", insert.Name);
                    sqlCommand.Parameters.AddWithValue("@Surname", insert.Surname);
                    sqlCommand.Parameters.AddWithValue("@Phone", insert.Phone);
                    sqlCommand.Parameters.AddWithValue("@Data", insert.Data);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Update(CustomerEntity Update)
        {
            string cmd = $"UPDATE Customers " +
                  $"SET Name = @Name,Surname = @Surname,Phone=@Phone,Data=@Data WHERE Customers.Id = @Id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.Parameters.AddWithValue("@Name", Update.Name);
                    command.Parameters.AddWithValue("@Surname", Update.Surname);
                    command.Parameters.AddWithValue("@Phone", Update.Phone);
                    command.Parameters.AddWithValue("@Data", Update.Data);
                    command.Parameters.AddWithValue("@Id", Update.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public CustomerEntity GetCustomer(int Id)
        {
            string cmd;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                cmd = $"Select Name From Customers Where Customers.Id={Id}";
                CustomerEntity customerEntity = new CustomerEntity();
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        customerEntity.Name = Convert.ToString(sqlDataReader[nameof(customerEntity.Name)]);
                        //   filialEntity.Id = Convert.ToInt32(sqlDataReader[nameof(filialEntity.Id)]);
                        // filialEntity.Address = Convert.ToString(sqlDataReader[nameof(filialEntity.Address)]);
                    }
                }
                return customerEntity;
            }
        }
    }
}
