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
        public IUserRepository UserRepository => throw new NotImplementedException();

        public IBranchRepository BranchRepository =>  new SqlBranchRepository(SqlContex);

        public IBookRepository BookRepository => new SqlBookRepository(SqlContex);

        public ICustomerRepository CustomerRepository => throw new NotImplementedException();

        public IRentRepository RentRepository => throw new NotImplementedException();

        public ISaleRepository SaleRepository => throw new NotImplementedException();

        public IWorkerRepository WorkerRepository => throw new NotImplementedException();
    }
}
