using System;
using System.Collections.Generic;
using Totten.Solutions.ToBarber.Domain.Features.Employees;

namespace Totten.Solutions.ToBarber.Tests.Commons.ObjectMothers
{
    public partial class ObjectMother
    {
        public static Employee ValidEmployee => new Employee
        {
            Id = CommonValues.EmployeeID,
            CreatedAt = DateTime.Now.AddDays(-365),
            ProvidedServices = new List<Domain.Features.ProvidedServices.ProvidedService>
            {
                ObjectMother.ValidProvidedServiceTanning,
                ObjectMother.ValidProvidedServicNail,
                ObjectMother.ValidProvidedServicHairColoring
            },
            UpdatedIn = DateTime.Now,
            UserId = CommonValues.UserEmployeeID,
            Version = 1
        };
    }
}
