using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Totten.Solutions.ToBarber.Application.Features.ProvidedServices.Handlers;
using Totten.Solutions.ToBarber.Domain.Features.Employees;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Infra.CrossCutting.Structs;
using Totten.Solutions.ToBarber.Tests.Commons;
using Totten.Solutions.ToBarber.Tests.Commons.ObjectMothers;

namespace Totten.Solutions.ToBarber.Tests.Applications.Features.ProvidedServices
{
    [TestFixture]
    public class ProvidedServiceCreate
    {
        private Mock<IMapper> _mockMapper;
        private Mock<IProvidedServiceRepository> _mockProvidedServiceRepository;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private ProvidedServiceCreateHandler _providedServiceCreateHandler;

        public ProvidedServiceCreate()
        {
            _mockMapper = new Mock<IMapper>();
            _mockProvidedServiceRepository = new Mock<IProvidedServiceRepository>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();


            _providedServiceCreateHandler = new ProvidedServiceCreateHandler(_mockMapper.Object, _mockProvidedServiceRepository.Object, _mockEmployeeRepository.Object);
        }

        private static Task<Result<Exception, T>> ReturnTask<T>(T providedService)
            => Task.Run(() => Result.Run(() => providedService));


        [Test]
        public void ProvidedServiceCreate_CreateCommand_ShouldBeOk()
        {
            //arrange
            var createCommand = ObjectMother.ValidProvidedServiceCommand;
            var providedService = ObjectMother.ValidProvidedService;

            _mockMapper.Setup(map => map.Map<ProvidedService>(createCommand))
                       .Returns(providedService);

            _mockEmployeeRepository.Setup(emp => emp.GetByIdAsync(It.IsAny<Guid>()))
                                    .Returns(ReturnTask(new Employee()));

            _mockProvidedServiceRepository.Setup(rep => rep.CreateAsync(providedService))
                                          .Returns(ReturnTask(providedService))
                                          .Callback((ProvidedService item) =>
                                          {
                                              item.Version++;
                                              item.CreatedAt = DateTime.Now;
                                          });

            //action
            var createdItem = _providedServiceCreateHandler.Handle(createCommand, CommonValues.CancellationTokenSource.Token).Result;

            //verify
            createdItem.IsSuccess.Should().BeTrue();
            createdItem.IsFailure.Should().BeFalse();
            createdItem.Success.Should().NotBe(Guid.Empty);
            providedService.Employees.Should().NotBeNullOrEmpty();
            providedService.Employees.Count.Should().Be(createCommand.EmployeesID.Count);

        }



    }
}
