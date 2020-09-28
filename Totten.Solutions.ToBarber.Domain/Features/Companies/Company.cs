using System;
using System.Collections.Generic;
using System.Text;
using Totten.Solutions.ToBarber.Domain.Base;
using Totten.Solutions.ToBarber.Domain.Features.Employees;

namespace Totten.Solutions.ToBarber.Domain.Features.Companies
{
    public class Company : Entity
    {
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string Cnpj { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
