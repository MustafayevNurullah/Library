﻿using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstraction
{
   public interface IUserRepository:IRepository<UserEntity>
    {

        UserEntity GetUser(int Id);
        UserEntity GetUserPresenly( );
    }
}
