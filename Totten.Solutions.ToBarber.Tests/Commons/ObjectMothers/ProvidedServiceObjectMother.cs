using System;
using Totten.Solutions.ToBarber.Application.Features.ProvidedServices.Handlers.Commands;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;

namespace Totten.Solutions.ToBarber.Tests.Commons.ObjectMothers
{
    public partial class ObjectMother
    {

        public static CreateCommand ValidProvidedServiceCommand => new CreateCommand
        {
            EmployeesID = CommonValues.EmployeesID,
            UserCreatedId = CommonValues.UserCreatedId,
            CompanyId = CommonValues.CompanyId,
            Duration = TimeSpan.FromMinutes(30),
            Name = "Bronzeamento",
            Value = Decimal.Parse("25.50")
        };

        public static ProvidedService ValidProvidedServiceTanning => new ProvidedService
        {
            CompanyId = ValidProvidedServiceCommand.CompanyId,
            Duration = ValidProvidedServiceCommand.Duration,
            Name = ValidProvidedServiceCommand.Name,
            Value = ValidProvidedServiceCommand.Value,
            UserCreatedId = ValidProvidedServiceCommand.UserCreatedId
        };

        public static ProvidedService ValidProvidedServicNail => new ProvidedService
        {
            CompanyId = ValidProvidedServiceCommand.CompanyId,
            Duration = ValidProvidedServiceCommand.Duration,
            Name = "Unha",
            Value = ValidProvidedServiceCommand.Value,
            UserCreatedId = ValidProvidedServiceCommand.UserCreatedId
        };

        public static ProvidedService ValidProvidedServicHairColoring => new ProvidedService
        {
            CompanyId = ValidProvidedServiceCommand.CompanyId,
            Duration = ValidProvidedServiceCommand.Duration,
            Name = "Pintura de Cabelo",
            Value = ValidProvidedServiceCommand.Value,
            UserCreatedId = ValidProvidedServiceCommand.UserCreatedId
        };

    }
}
