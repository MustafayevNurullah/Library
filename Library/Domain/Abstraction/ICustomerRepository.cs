﻿using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstraction
{
   public interface ICustomerRepository:IRepository<CustomerEntity>
    {
        CustomerEntity GetCustomer(int Id);
    }
}
