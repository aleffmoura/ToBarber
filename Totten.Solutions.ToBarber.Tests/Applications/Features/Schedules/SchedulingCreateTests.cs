using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Totten.Solutions.ToBarber.Application.Features.Schedules.Handlers;
using Totten.Solutions.ToBarber.Application.Features.Schedules.Handlers.Commands;
using Totten.Solutions.ToBarber.Domain.Features.Employees;
using Totten.Solutions.ToBarber.Domain.Features.ProvidedServices;
using Totten.Solutions.ToBarber.Domain.Features.Schedules;
using Totten.Solutions.ToBarber.Tests.Commons;
using Totten.Solutions.ToBarber.Tests.Commons.ObjectMothers;

namespace Totten.Solutions.ToBarber.Tests.Applications.Features.Schedules
{
    [TestFixture]
    public class SchedulingCreateTests
    {
        private SchedulingCreateHandler _schedulingCreateHandler;

        private Mock<IMapper> _mockMapper;
        private Mock<ISchedulingRepository> _mockSchedulingRepository;
        private Mock<IProvidedServiceRepository> _mockProvidedServiceRepository;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;

        public SchedulingCreateTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockSchedulingRepository = new Mock<ISchedulingRepository>();
            _mockProvidedServiceRepository = new Mock<IProvidedServiceRepository>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();

            _schedulingCreateHandler = new SchedulingCreateHandler(_mockMapper.Object, _mockSchedulingRepository.Object,
                                                                   _mockProvidedServiceRepository.Object, _mockEmployeeRepository.Object);
        }


        [Test]
        public void SchedulingCreateTests_CreateHandlerCommand_ShouldBeOk()
        {
            //arrange
            var createCommand = ObjectMother.ValidSchedulingCreateCommand;
            var validToCreate = ObjectMother.ValidSchedulingToCreate;


            _mockMapper.Setup(map => map.Map<Scheduling>(createCommand))
                       .Returns(validToCreate);

            _mockEmployeeRepository.Setup(emp => emp.GetByIdAsync(createCommand.EmployeeId))
                                    .Returns(CommonValues.ReturnTask(ObjectMother.ValidEmployee));

            _mockProvidedServiceRepository.Setup(serv => serv.GetByIdAsync(CommonValues.ProvidedServicNail))
                                          .Returns(CommonValues.ReturnTask(ObjectMother.ValidProvidedServicNail));

            _mockProvidedServiceRepository.Setup(serv => serv.GetByIdAsync(CommonValues.ProvidedServicHairColoring))
                                          .Returns(CommonValues.ReturnTask(ObjectMother.ValidProvidedServicHairColoring));

            _mockProvidedServiceRepository.Setup(serv => serv.GetByIdAsync(CommonValues.ProvidedServicTanning))
                                          .Returns(CommonValues.ReturnTask(ObjectMother.ValidProvidedServiceTanning));

            _mockSchedulingRepository.Setup(sch => sch.CreateAsync(validToCreate))
                                     .Callback((Scheduling item) => {
                                         item.CreatedAt = DateTime.Now;
                                         item.Id = Guid.NewGuid();
                                      })
                                     .Returns(CommonValues.ReturnTask(validToCreate));

            //action
            var idCreated = _schedulingCreateHandler.Handle(createCommand, CommonValues.CancellationTokenSource.Token).Result;


            //verify
            idCreated.IsSuccess.Should().BeTrue();
            idCreated.Success.Should().NotBe(Guid.Empty);


        }
    }
}
