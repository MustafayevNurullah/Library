using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
      public class BuyEntity
      {
        public int Id { get; set; }
        public UserEntity UserId { get; set; }
        public int No { get; set; }
        public BookEntity BookId { get; set; }
        public CustomerEntity Customer { get; set; }
        public string Price { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }
        public BuyEntity Clone()
        {
            BuyEntity buyEntity = new BuyEntity();
            buyEntity.Date = this.Date;
            buyEntity.Id = this.Id;
            buyEntity.No = this.No;
            buyEntity.BookId = this.BookId;
            buyEntity.Price = this.Price;
            buyEntity.Note = this.Note;
            buyEntity.Customer = this.Customer;
            buyEntity.UserId = this.UserId;
            return buyEntity;
        }
        



      }
}
