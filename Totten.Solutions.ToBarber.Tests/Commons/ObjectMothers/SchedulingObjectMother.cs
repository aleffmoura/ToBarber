using Totten.Solutions.ToBarber.Application.Features.Schedules.Handlers.Commands;
using Totten.Solutions.ToBarber.Domain.Features.Schedules;

namespace Totten.Solutions.ToBarber.Tests.Commons.ObjectMothers
{
    public partial class ObjectMother
    {
        public static CreateCommand ValidSchedulingCreateCommand => new CreateCommand
        {
            UserCreatedId = CommonValues.UserCreatedId,
            CompanyId  = CommonValues.CompanyId,
            ClientId = CommonValues.ClientId,
            EmployeeId = CommonValues.EmployeeID,
            Schedule = CommonValues.GetValidWeekDay(),
            ProvidedServices = CommonValues.ProvidedServices
        };

        public static Scheduling ValidSchedulingToCreate => new Scheduling
        {
            Schedule = ValidSchedulingCreateCommand.Schedule,
            UserWhoCreatedId = ValidSchedulingCreateCommand.UserCreatedId,
            CompanyId = ValidSchedulingCreateCommand.CompanyId,
            EmployeeId = ValidSchedulingCreateCommand.EmployeeId,
            ClientId = ValidSchedulingCreateCommand.ClientId
        };

    }
}
