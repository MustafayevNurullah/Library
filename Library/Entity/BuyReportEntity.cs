using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class BuyReportEntity
    {
        public int Id { get; set; }
        public int No { get; set; }
        public BuyEntity BuyBookId { get; set; }

        public BuyReportEntity Clone()
        {

            BuyReportEntity buyReportEntity = new BuyReportEntity();
            buyReportEntity.Id = this.Id;
            buyReportEntity.No = this.No;
            buyReportEntity.BuyBookId = this.BuyBookId;
            return buyReportEntity;

        }


    }
}
