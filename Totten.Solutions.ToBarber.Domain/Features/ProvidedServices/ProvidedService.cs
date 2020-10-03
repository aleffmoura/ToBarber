using System;
using System.Collections.Generic;
using Totten.Solutions.ToBarber.Domain.Base;
using Totten.Solutions.ToBarber.Domain.Features.Companies;
using Totten.Solutions.ToBarber.Domain.Features.Employees;

namespace Totten.Solutions.ToBarber.Domain.Features.ProvidedServices
{
    public class ProvidedService : Entity
    {

        public ProvidedService()
        {
            Employees = new List<Employee>();
        }

        public Guid UserCreatedId { get; set; }
        public Guid CompanyId { get; set; }

        public string Name { get; set; }
        public decimal Value { get; set; }
        public TimeSpan Duration { get; set ; }
        public List<Employee> Employees { get; set; }
        public virtual Company Company { get; set; }
    }

}
