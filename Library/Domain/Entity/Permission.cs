using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
   public class Permission
    {

        public bool CanCreateBook { get; set; }
        public bool CanCreateUser { get; set; }
        public bool CanCreateBranch { get; set; }
        public bool CanCreateCustomer { get; set; }
        public bool CanRent { get; set; }
    }
}
