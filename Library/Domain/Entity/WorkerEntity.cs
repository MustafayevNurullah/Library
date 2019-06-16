using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
  public  class WorkerEntity
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public FilialEntity Filial { get; set; }
        public int BranchId  { get; set; }

        public WorkerEntity Clone()
        {
            WorkerEntity workerEntity = new WorkerEntity();
            workerEntity.Id = this.Id;
            workerEntity.No = this.No;
            workerEntity.Name = this.Name;
            workerEntity.Surname = this.Surname;
            workerEntity.Phone = this.Phone;
            workerEntity.Salary = this.Salary;
            workerEntity.Filial = this.Filial;
            workerEntity.BranchId = this.BranchId;
            return workerEntity;

        }
    }
}
