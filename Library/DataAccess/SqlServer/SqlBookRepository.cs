using Library.Domain.Abstraction;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.SqlServer
{
    public class SqlBookRepository : IBookRepository
    {
        public void Delete(BookEntity delete)
        {
            throw new NotImplementedException();
        }

        public List<BookEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(BookEntity insert)
        {
            throw new NotImplementedException();
        }

        public void Update(BookEntity Update)
        {
            throw new NotImplementedException();
        }
    }
}
