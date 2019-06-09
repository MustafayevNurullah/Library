using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstraction
{
   public interface IUnitOfWork
    {
        void SaveChanges();
        IUserRepository UserRepository { get; }
        IBranchRepository BranchRepository { get; }
        IBookRepository BookRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IRentRepository RentRepository { get; }
        ISaleRepository SaleRepository { get; }
        IWorkerRepository WorkerRepository { get; }
    }
}
