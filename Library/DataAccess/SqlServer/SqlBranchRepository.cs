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
            throw new NotImplementedException();
        }

        public List<FilialEntity> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
            }
            return new List<FilialEntity>();
        }

        public void Insert(FilialEntity insert)
        {
            throw new NotImplementedException();
        }

        public void Update(FilialEntity Update)
        {
            throw new NotImplementedException();
        }
    }
}
