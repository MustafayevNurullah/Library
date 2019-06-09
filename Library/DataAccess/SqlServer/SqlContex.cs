using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.SqlServer
{
  public  class SqlContex
    {
        public string ConnectionString { get => SqlUnitOfWork.ConnectionString; }
        public SqlUnitOfWork SqlUnitOfWork { get; set; }
        public SqlContex(SqlUnitOfWork sqlUnitOfWork)
        {
            SqlUnitOfWork = sqlUnitOfWork;
        }
    }
}
