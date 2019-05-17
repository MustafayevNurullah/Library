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

        public decimal SalePrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Count { get; set; }
        FilialEntity Filial;
    }
}
