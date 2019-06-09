using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstraction
{
  public interface IRepository<T>
    {

        List<T> GetAll();
        void Insert(T insert);
        void Delete(T delete);
        void Update(T Update);
    }
}
