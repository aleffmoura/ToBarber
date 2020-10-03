using System;
using System.Collections.Generic;
using Totten.Solutions.ToBarber.Domain.Base;
using Totten.Solutions.ToBarber.Domain.Features.Employees;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;

namespace Totten.Solutions.ToBarber.Domain.Features.Schedules
{
    public class Scheduling : Entity
    {
        public Guid UserWhoCreatedId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ClientId { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime Schedule { get; set; }
        public decimal Total { get; set; }
        public List<ProvidedService> ProvidedServices { get; set; }


        public Scheduling()
        {
            ProvidedServices = new List<ProvidedService>();
        }
    }
}
