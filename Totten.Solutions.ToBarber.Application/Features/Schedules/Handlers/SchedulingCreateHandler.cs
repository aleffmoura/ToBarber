using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Totten.Solutions.ToBarber.Application.Features.Schedules.Handlers.Commands;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;

namespace Totten.Solutions.ToBarber.Application.Features.Schedules.Handlers
{
    public class SchedulingCreateHandler : IRequestHandler<CreateCommand, Result<Exception, Guid>>
    {
        public async Task<Result<Exception, Guid>> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}