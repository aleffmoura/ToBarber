using System;
using System.Collections.Generic;
using Totten.Solutions.ToBarber.Domain.Base;
using Totten.Solutions.ToBarber.Domain.Features.Employees;

namespace Totten.Solutions.ToBarber.Domain.Features.ProvidedServices
{
    public class ProvidedService : Entity
    {
        public string Name { get; set; }
        public decimal Value { get; set ; }
        public TimeSpan Duration { get; set ; }
        public List<Employee> Employees { get; set; }
    }
}
