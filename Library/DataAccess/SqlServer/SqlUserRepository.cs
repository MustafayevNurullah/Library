using Library.Domain.Abstraction;
using Library.Entity;
using Library.Hash;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.SqlServer
{
    public class SqlUserRepository : IUserRepository
    {
        public string ConnectionString { get => SqlContex.ConnectionString; }
        public SqlContex SqlContex;
        public SqlUserRepository(SqlContex sqlContex)
        {
            SqlContex = sqlContex;
        }


        public void Delete(UserEntity delete)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                string cmd = $"Delete From Users Where Users.Id={delete.Id}";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<UserEntity> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = "Select * From Users";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<UserEntity> users = new List<UserEntity>();

                    while (sqlDataReader.Read())
                    {
                        UserEntity userEntity = new UserEntity();
                        userEntity.Id = Convert.ToInt32(sqlDataReader[nameof(userEntity.Id)]);
                        userEntity.Username = Convert.ToString(sqlDataReader[nameof(userEntity.Username)]);
                        userEntity.Password =  Convert.ToString(sqlDataReader[nameof(userEntity.Password)]);
                        userEntity.CanCreateBook = Convert.ToBoolean(sqlDataReader[nameof(userEntity.CanCreateBook)]);
                        userEntity.CanCreateBranch = Convert.ToBoolean(sqlDataReader[nameof(userEntity.CanCreateBranch)]);
                        userEntity.CanCreateCustomer = Convert.ToBoolean(sqlDataReader[nameof(userEntity.CanCreateCustomer)]);
                        userEntity.CanCreateUser = Convert.ToBoolean(sqlDataReader[nameof(userEntity.CanCreateUser)]);
                        userEntity.CanRent = Convert.ToBoolean(sqlDataReader[nameof(userEntity.CanRent)]);
                        userEntity.Presently = Convert.ToBoolean(sqlDataReader[nameof(userEntity.Presently)]);
                      
                        users.Add(userEntity);
                    }
                    return users;
                }
            }
        }

        public void Insert(UserEntity insert)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = @"Insert into Users(Presently,CanCreateBook,CanCreateBranch,CanCreateCustomer,CanCreateUser,CanRent,Password,Username)" +
                $"Values('{insert.Presently}','{insert.CanCreateBook}','{insert.CanCreateBranch}','{insert.CanCreateCustomer}','{insert.CanCreateUser}','{insert.CanRent}','{insert.Password}','{insert.Username}')";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                    insert.Presently = false;
                    sqlCommand.Parameters.AddWithValue("@CanCreateBook", insert.CanCreateBook);
                    sqlCommand.Parameters.AddWithValue("@CanCreateBranch", insert.CanCreateBranch);
                    sqlCommand.Parameters.AddWithValue("@CanCreateCustomer", insert.CanCreateCustomer);
                    sqlCommand.Parameters.AddWithValue("@CanCreateUser", insert.CanCreateUser);
                    sqlCommand.Parameters.AddWithValue("@CanRent", insert.CanRent);
                    sqlCommand.Parameters.AddWithValue("@Password", insert.Password);
                    sqlCommand.Parameters.AddWithValue("@Username", insert.Username);
                    sqlCommand.Parameters.AddWithValue("@Presently", insert.Presently);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Update(UserEntity Update)
        {
            string cmd = $"UPDATE Users " +
                $"SET Username = @Username,Password = @Password,CanCreateBook= @CanCreateBook,CanCreateBranch=@CanCreateBranch,CanCreateCustomer=@CanCreateCustomer,CanCreateUser=@CanCreateUser,CanRent=@CanRent,Presently=@Presently  WHERE Users.Id = @Id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.Parameters.AddWithValue("@Id", Update.Id);

                    command.Parameters.AddWithValue("@Username", Update.Username);
                    command.Parameters.AddWithValue("@Password", Update.Password);

                    command.Parameters.AddWithValue("@CanCreateBook", Update.CanCreateBook);
                    command.Parameters.AddWithValue("@CanCreateBranch", Update.CanCreateBranch);
                    command.Parameters.AddWithValue("@CanCreateCustomer", Update.CanCreateCustomer);

                    command.Parameters.AddWithValue("@CanCreateUser", Update.CanCreateUser);
                    command.Parameters.AddWithValue("@CanRent", Update.CanRent);
                    command.Parameters.AddWithValue("@Presently", Update.Presently);
                    command.ExecuteNonQuery();
                }
            }
        }

        public UserEntity GetUser(int Id)
        {
            string cmd;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                cmd = $"Select Username From Users Where Users.Id={Id}";
                UserEntity userEntity = new UserEntity();
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        userEntity.Username = Convert.ToString(sqlDataReader[nameof(userEntity.Username)]);
                        //   filialEntity.Id = Convert.ToInt32(sqlDataReader[nameof(filialEntity.Id)]);
                        // filialEntity.Address = Convert.ToString(sqlDataReader[nameof(filialEntity.Address)]);
                    }
                }
                return userEntity;
            }
        }

        public UserEntity GetUserPresenly()
        {
            string cmd;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                cmd = $"Select Username,Id From Users Where Users.Presently={1}";
                UserEntity userEntity = new UserEntity();
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        userEntity.Username = Convert.ToString(sqlDataReader[nameof(userEntity.Username)]);
                        userEntity.Id = Convert.ToInt32(sqlDataReader[nameof(userEntity.Id)]);
                        // filialEntity.Address = Convert.ToString(sqlDataReader[nameof(filialEntity.Address)]);
                    }
                }
                return userEntity;
            }
        }
    }
}
