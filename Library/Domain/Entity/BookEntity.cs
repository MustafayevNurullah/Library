using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
   public class BookEntity
    {
        public int No { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }
        public int Count { get; set; }
        public string BranchName { get; set; }
        public BookEntity Clone()
        {
            BookEntity bookEntity = new BookEntity(); 
            bookEntity.No = this.No;
            bookEntity.Id = this.No;
            bookEntity.Name = this.Name;
            bookEntity.Author = this.Author;
            bookEntity.SalePrice = this.SalePrice;
            bookEntity.BuyPrice = this.BuyPrice;
            bookEntity.Count = this.Count;
            bookEntity.BranchName = this.BranchName;
            return bookEntity;
        }



    }
}
