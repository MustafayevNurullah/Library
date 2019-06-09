using Library.Domain.Abstraction;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.SqlServer
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        public void Delete(CustomerEntity delete)
        {
            throw new NotImplementedException();
        }

        public List<CustomerEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(CustomerEntity insert)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerEntity Update)
        {
            throw new NotImplementedException();
        }
    }
}
