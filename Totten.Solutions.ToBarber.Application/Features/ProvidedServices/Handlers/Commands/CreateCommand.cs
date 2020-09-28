using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;

namespace Totten.Solutions.ToBarber.Application.Features.ProvidedServices.Handlers.Commands
{
    public class CreateCommand : IRequest<Result<Exception, Guid>>
    {
        public Guid UserCreatedId { get; set; }
        public Guid CompanyId { get; set; }

        public string Name { get; set; }
        public decimal Value { get; set; }
        public TimeSpan Duration { get; set; }
        public List<Guid> EmployeesID { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<CreateCommand>
        {
            public Validator()
            {

            }
        }

    }
}
