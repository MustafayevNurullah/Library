using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
   public class FilialEntity
    {
        public int No { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public FilialEntity FilialClone ()
        {
            FilialEntity filialEntityClone = new FilialEntity();
            filialEntityClone.Id = this.Id;
            filialEntityClone.Name = this.Name;
            filialEntityClone.No = this.No;
            return filialEntityClone;
        }
    }
}
