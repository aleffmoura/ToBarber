using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Totten.Solutions.ToBarber.Application.Features.Schedules.Handlers.Commands;
using Totten.Solutions.ToBarber.Domain.Features.Employees;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Domain.Features.Schedules;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;

namespace Totten.Solutions.ToBarber.Application.Features.Schedules.Handlers
{
    public class SchedulingCreateHandler : IRequestHandler<CreateCommand, Result<Exception, Guid>>
    {
        private IMapper _mapper;
        private ISchedulingRepository _repository;
        private IProvidedServiceRepository _providedServiceRepository;
        private IEmployeeRepository _employeeRepository;

        public SchedulingCreateHandler(IMapper mapper, ISchedulingRepository repository, IProvidedServiceRepository providedServiceRepository, IEmployeeRepository employeeRepository )
        {
            _mapper = mapper;
            _repository = repository;
            _providedServiceRepository = providedServiceRepository;
            _employeeRepository = employeeRepository;
        }


        public async Task<Result<Exception, Guid>> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Scheduling>(request);

            foreach (var serviceProvidedId in request.ProvidedServices)
            {
                var providedServiceCallback = await _providedServiceRepository.GetByIdAsync(serviceProvidedId);

                if (providedServiceCallback.IsSuccess)
                    entity.ProvidedServices.Add(providedServiceCallback.Success);
            }

            var employeeCallback = await _employeeRepository.GetByIdAsync(request.EmployeeId);

            if (employeeCallback.IsFailure)
                return new Exception();

            var entityCreated = await _repository.CreateAsync(entity);

            if (entityCreated.IsFailure)
                return entityCreated.Failure;

            return entityCreated.Success.Id;
        }
    }
}