using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class CustomerEntity
    {
        public int No { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Data { get; set; }

        public CustomerEntity Clone()
        {
            CustomerEntity customerEntity = new CustomerEntity();
            customerEntity.No = this.No;
            customerEntity.Id = this.Id;
            customerEntity.Name = this.Name;
            customerEntity.Surname = this.Surname;
            customerEntity.Phone = this.Phone;
            customerEntity.Data = this.Data;
            return customerEntity;
        }


    }
}
