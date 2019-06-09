using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
   public  class UserEntity
    {
        public bool Presently { get; set; }
        public int Id { get; set; }
        public int No { get; set; }
        public string Username { get; set; }
        public string Password  { get; set; }
        public bool CanCreateBook { get; set; }
        public bool CanCreateUser { get; set; }
        public bool CanCreateBranch { get; set; }
        public bool CanCreateCustomer { get; set; }
        public bool CanRent { get; set; }
        public string CanBook { get; set; } 

        public UserEntity Clone()
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Id = this.Id;
            userEntity.No = this.No;
            userEntity.Username = this.Username;
            userEntity.Password = this.Password;
            userEntity.CanCreateBook = this.CanCreateBook;
            userEntity.CanCreateBranch = this.CanCreateBranch;
            userEntity.CanCreateCustomer = this.CanCreateCustomer;
            userEntity.CanCreateUser = this.CanCreateUser;
            userEntity.CanRent = this.CanRent;
            return userEntity;
        }
    }
}
