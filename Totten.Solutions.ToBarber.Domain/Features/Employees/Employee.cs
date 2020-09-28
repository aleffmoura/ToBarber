using System;
using System.Collections.Generic;
using Totten.Solutions.ToBarber.Domain.Base;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Domain.Features.UserAggregation;

namespace Totten.Solutions.ToBarber.Domain.Features.Employees
{
    public class Employee : Entity
    {

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public List<ProvidedService> ProvidedServices { get; set; }

    }
}
