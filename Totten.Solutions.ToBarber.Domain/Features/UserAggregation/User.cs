using System;
using System.Collections.Generic;
using Totten.Solutions.ToBarber.Domain.Base;
using Totten.Solutions.ToBarber.Domain.Features.Companies;
using Totten.Solutions.ToBarber.Domain.Features.Employees;

namespace Totten.Solutions.ToBarber.Domain.Features.UserAggregation
{
    public class User : Entity
    {
        public Guid CompanyId { get; set; }
        public Guid RoleId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual Role Role { get; set; }
        public virtual Company Company { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
