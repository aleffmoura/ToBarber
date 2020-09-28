using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Totten.Solutions.ToBarber.Application.Features.ProvidedServices.Handlers.Commands;
using Totten.Solutions.ToBarber.Domain.Features.Employees;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;

namespace Totten.Solutions.ToBarber.Application.Features.ProvidedServices.Handlers
{
    public class ProvidedServiceCreateHandler : IRequestHandler<CreateCommand, Result<Exception, Guid>>
    {
        private IMapper _mapper;
        private IProvidedServiceRepository _repository;
        private IEmployeeRepository _employeeRepository;

        public ProvidedServiceCreateHandler(IMapper mapper,
                                            IProvidedServiceRepository repository,
                                            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _employeeRepository = employeeRepository;
        }


        public async Task<Result<Exception, Guid>> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            ProvidedService providedService = _mapper.Map<ProvidedService>(request);

            Parallel.ForEach(request.EmployeesID,
                             async id =>
                             {
                                 var employee = await _employeeRepository.GetByIdAsync(id);

                                 if (employee.IsSuccess)
                                     providedService.Employees.Add(employee.Success);

                             });


            var entity = await _repository.CreateAsync(providedService);

            if (entity.IsFailure)
                return new Exception();

            return entity.Success.Id;
        }
    }
}