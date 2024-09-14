using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMT22.Employee
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

    }
}
