using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestTaskBGL
{
    public partial class Company
    {
        public Company()
        {
            Departments = new HashSet<Department>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
