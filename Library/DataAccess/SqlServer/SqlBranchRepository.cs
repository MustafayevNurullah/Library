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
    public class SqlBranchRepository : IBranchRepository
    {
        public string ConnectionString { get => SqlContex.ConnectionString; }

      public  SqlContex SqlContex;
        public SqlBranchRepository(SqlContex sqlContex)
        {
            SqlContex = sqlContex;
        }
        public void Delete(FilialEntity delete)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                string cmd = $"Delete From Filial Where Filial.Id={delete.Id}";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public List<FilialEntity> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
               string cmd= "Select * From Filial";
                using (SqlCommand sqlCommand=new SqlCommand(cmd,connection))
                {
                   
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<FilialEntity> filials = new List<FilialEntity>();
                    
                    while(sqlDataReader.Read())
                    {
                        FilialEntity filialEntity = new FilialEntity();
                        filialEntity.Id = Convert.ToInt32(sqlDataReader[nameof(filialEntity.Id)]);
                        filialEntity.Name = Convert.ToString(sqlDataReader[nameof(filialEntity.Name)]);
                        filialEntity.Address = Convert.ToString(sqlDataReader[nameof(filialEntity.Address)]);
                        filials.Add(filialEntity);
                    }
                    return filials;
                }
            }
        }
        public void Insert(FilialEntity insert)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = @"Insert into Filial(Name,Address)"+
                $"Values('{insert.Name}','{insert.Address}')";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                        sqlCommand.Parameters.AddWithValue("@Name", insert.Name);
                        sqlCommand.Parameters.AddWithValue("@Address", insert.Address);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public void Update(FilialEntity Update)
        {



        }
    }
}
