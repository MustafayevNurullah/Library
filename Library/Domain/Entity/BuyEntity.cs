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
        public int UserId { get; set; }
        public int No { get; set; }
        public BookEntity Book { get; set; }
        public CustomerEntity Customer { get; set; }
        public UserEntity User { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public double SalePrice { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public BuyEntity Clone()
        {
            BuyEntity buyEntity = new BuyEntity();
            buyEntity.Date = this.Date;
            buyEntity.Id = this.Id;
            buyEntity.No = this.No;
            buyEntity.BookId = this.BookId;
            buyEntity.SalePrice = this.SalePrice;
            buyEntity.Note = this.Note;
            buyEntity.CustomerId = this.CustomerId;
            buyEntity.UserId = this.UserId;

            buyEntity.Book = this.Book;
            buyEntity.Customer = this.Customer;
            buyEntity.User = this.User;
            return buyEntity;
        }
        



      }
}
