using System.Collections.Generic;
using Totten.Solutions.ToBarber.Domain.Base;
using Totten.Solutions.ToBarber.Domain.Features.Employees;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Domain.Features.UserAggregation;

namespace Totten.Solutions.ToBarber.Domain.Features.Companies
{
    public class Company : Entity
    {
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string Cnpj { get; set; }

        public List<User> Users { get; set; }
        public List<Employee> Employees { get; set; }
        public List<ProvidedService> ProvidedServices { get; set; }
    }
}
