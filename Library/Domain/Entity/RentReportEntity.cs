using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
  public  class RentReportEntity
    {

        public int Id { get; set; }
        public int No { get; set; }
        public RentEntity RentEntity { get; set; }

        public RentReportEntity Clone()
        {

            RentReportEntity rentReportEntity = new RentReportEntity();
            rentReportEntity.Id = this.Id;
            rentReportEntity.No = this.No;
            rentReportEntity.RentEntity = this.RentEntity;

            return rentReportEntity;
        }



    }
}
