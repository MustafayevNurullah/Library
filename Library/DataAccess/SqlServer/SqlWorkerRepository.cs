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
    public class SqlWorkerRepository : IWorkerRepository
    {


        public string ConnectionString { get => SqlContex.ConnectionString; }

        public SqlContex SqlContex;
        public SqlWorkerRepository(SqlContex sqlContex)
        {
            SqlContex = sqlContex;
        }


        public void Delete(WorkerEntity delete)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                string cmd = $"Delete From Workers Where Workers.Id={delete.Id}";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, Connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<WorkerEntity> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = "Select * From Workers";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<WorkerEntity> workers = new List<WorkerEntity>();

                    while (sqlDataReader.Read())
                    {
                        WorkerEntity workersentity = new WorkerEntity();
                        workersentity.Id = Convert.ToInt32(sqlDataReader[nameof(workersentity.Id)]);
                        workersentity.Name = Convert.ToString(sqlDataReader[nameof(workersentity.Name)]);
                        workersentity.Surname = Convert.ToString(sqlDataReader[nameof(workersentity.Surname)]);
                        workersentity.Phone = Convert.ToString(sqlDataReader[nameof(workersentity.Phone)]);
                        workersentity.Salary = Convert.ToDouble(sqlDataReader[nameof(workersentity.Salary)]);
                        workersentity.BranchId = Convert.ToInt32(sqlDataReader[nameof(workersentity.BranchId)]);
                        workersentity.Filial = new FilialEntity();
                        workersentity.Filial = App.Db.BranchRepository.GetBranch(workersentity.BranchId);
                        workers.Add(workersentity);
                    }
                    return workers;
                }
            }
        }

        public void Insert(WorkerEntity insert)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmd = @"Insert into Workers(Name,Phone,Salary,Surname,BranchId)" +
                $"Values('{insert.Name}','{insert.Phone}','{insert.Salary}','{insert.Surname}','{insert.BranchId}')";
                using (SqlCommand sqlCommand = new SqlCommand(cmd, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@Author", insert.Phone);
                    sqlCommand.Parameters.AddWithValue("@Name", insert.Name);
                    sqlCommand.Parameters.AddWithValue("@BranchId", insert.BranchId);
                    sqlCommand.Parameters.AddWithValue("@Count", insert.Salary);
                    sqlCommand.Parameters.AddWithValue("@BuyPrice", insert.Surname);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Update(WorkerEntity Update)
        {
            string cmd = $"UPDATE Workers " +
                  $"SET Name = @Name,Surname = @Surname,BranchId=@BranchId,Salary=@Salary,Phone=@Phone WHERE Workers.Id = @Id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    command.Parameters.AddWithValue("@Id", Update.Id);
                    command.Parameters.AddWithValue("@Name", Update.Name);
                    command.Parameters.AddWithValue("@Surname", Update.Surname);
                    command.Parameters.AddWithValue("@Salary", Update.Salary);
                    command.Parameters.AddWithValue("@Phone", Update.Phone);
                    command.Parameters.AddWithValue("@BranchId", Update.BranchId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
