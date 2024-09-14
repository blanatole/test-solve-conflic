using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMT22.Lib
{
    public class WorkLog
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        internal void CopyTo(DataSet.HRM.WorkLog row)
        {
            row.Id = Id;
            row.EmployeeId = EmployeeId;
            row.Checkin = Checkin;
            row.Checkout = Checkout;
        }

        internal void CopyFrom(DataSet.HRM.WorkLog row)
        {
            this.Id = row.Id;
            this.EmployeeId = row.EmployeeId;
            this.Checkin = row.Checkin;
            this.Checkout = row.Checkout;
        }

        public bool Add()
        {
            bool status = false;
            var row = new DataSet.HRM.WorkLog();
            this.CopyTo(row);
            using (var context = new DataSet.HRM.HRMContext())
            {
                context.WorkLogs.Add(row);
                status = context.SaveChanges() > 0;
            }
            if (status)
            {
                this.Id = row.Id;
            }
            return status;
        }

        public bool Load(int id)
        {
            bool status = false;
            DataSet.HRM.WorkLog row;

            using (var context = new DataSet.HRM.HRMContext())
            {
                row = context.WorkLogs.FirstOrDefault(x => x.Id == id);
                status = row != null;
            }
            if (status)
            {
                this.CopyFrom(row);
            }
            return status;
        }
    }
}
