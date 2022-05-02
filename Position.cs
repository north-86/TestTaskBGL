using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestTaskBGL
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public string PositionName { get; set; } = null!;
        [JsonIgnore]
        public virtual Department Department { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
