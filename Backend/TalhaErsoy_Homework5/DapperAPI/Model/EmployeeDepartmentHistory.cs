using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Model
{
    public class EmployeeDepartmentHistory
    {
        public int BusinessEntityId { get; set; }
        public int DepartmentId { get; set; }
        public int ShiftId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}