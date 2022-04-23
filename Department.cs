using System;
using System.Collections.Generic;

namespace TestTaskBGL
{
    public partial class Department
    {
        public Department()
        {
            Positions = new HashSet<Position>();
        }

        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }
        public string DepartmentName { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Position> Positions { get; set; }
    }
}
