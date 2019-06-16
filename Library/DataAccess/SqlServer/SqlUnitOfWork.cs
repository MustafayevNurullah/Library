using Library.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        public string ConnectionString { get; set; }
        SqlContex SqlContex;
        public SqlUnitOfWork(string ConnectionString)
        {

            this.ConnectionString = ConnectionString;
            SqlContex = new SqlContex(this);
        }


        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
        public IUserRepository UserRepository =>  new SqlUserRepository(SqlContex);

        public IBranchRepository BranchRepository =>  new SqlBranchRepository(SqlContex);

        public IBookRepository BookRepository => new SqlBookRepository(SqlContex);

        public ICustomerRepository CustomerRepository =>  new SqlCustomerRepository(SqlContex);

        public IRentRepository RentRepository =>  new SqlRentRepository(SqlContex);

        public ISaleRepository SaleRepository =>  new SqlSaleRepository(SqlContex);

        public IWorkerRepository WorkerRepository =>  new SqlWorkerRepository(SqlContex);
    }
}
