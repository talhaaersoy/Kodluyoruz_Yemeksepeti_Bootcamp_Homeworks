using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Model
{
    public class FullDepartment
    {
        public string DepartmentName { get; set; }
        public string DepartmentGroupName { get; set; }
        public int BusinessEntityId { get; set; }
        public int ShiftId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
 
    }
}
