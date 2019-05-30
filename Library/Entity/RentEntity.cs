﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
   public class RentEntity
    {

        public int Id { get; set; }
        public UserEntity UserId { get; set; }
        public int No { get; set; }
        public BookEntity BookId { get; set; }
        public CustomerEntity Customer { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime RealDate { get; set; }
        public string DailyRentPrice { get; set; }
        public RentEntity Clone()
        {
            RentEntity rentEntity = new RentEntity();
            rentEntity.Id = this.Id;
            rentEntity.UserId = this.UserId;
            rentEntity.No = this.No;
            rentEntity.BookId = this.BookId;
            rentEntity.Customer = this.Customer;
            rentEntity.RentDate = this.RentDate;
            rentEntity.Deadline = this.Deadline;
            rentEntity.RentDate = this.RentDate;
            rentEntity.RealDate = this.RealDate;
            rentEntity.DailyRentPrice = this.DailyRentPrice;
            return rentEntity;


        }

    }
}
