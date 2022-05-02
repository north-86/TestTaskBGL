using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Company Company { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Position> Positions { get; set; }
    }
}
