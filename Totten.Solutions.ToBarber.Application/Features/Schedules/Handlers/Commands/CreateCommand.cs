using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;

namespace Totten.Solutions.ToBarber.Application.Features.Schedules.Handlers.Commands
{
    public class CreateCommand : IRequest<Result<Exception, Guid>>
    {
        public Guid UserCreatedId { get; set; }

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
