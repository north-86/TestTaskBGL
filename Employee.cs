using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestTaskBGL
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public string EmpSurname { get; set; } = null!;
        public string EmpName { get; set; } = null!;
        public string EmpPatronymic { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        [JsonIgnore]
        public virtual Position Position { get; set; } = null!;
    }
}
