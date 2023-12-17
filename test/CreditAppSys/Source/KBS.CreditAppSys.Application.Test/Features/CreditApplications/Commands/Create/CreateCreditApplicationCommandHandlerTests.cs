using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create;
using KBS.CreditAppSys.Application.Features.CreditApplications.Profiles;
using KBS.CreditAppSys.Application.Features.CreditApplications.Rules;
using KBS.CreditAppSys.Application.Features.CustomerCriterias.Commands.Create;
using KBS.CreditAppSys.Application.Features.Customers.Queries.GetById;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using KBS.CreditAppSys.Domain.Types;
using KBS.Integration.Abstracts;
using KBS.Integration.Responses;
using MediatR;
using Moq;
using static KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create.CreateCreditApplicationCommand;

namespace KBS.CreditAppSys.Application.Test.Features.CreditApplications.Commands.Create;

[TestFixture]
public class CreateCreditApplicationCommandHandlerTests
{
    //DI
    private IMapper _mapper;
    private ICreditApplicationRepository _creditApplicationRepository;
    private IMediator _mediator;
    private ICreditReportService _creditReportService;
    private CreditApplicationBusinessRules _creditApplicationBusinessRules;

    //Data
    private CreditApplication _creditApplication;
    private Customer _customer;



    [SetUp]
    public void Setup()
    {
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CreditApplicationMappingProfiles>()));
        _creditApplicationRepository = Mock.Of<ICreditApplicationRepository>();
        _mediator = Mock.Of<IMediator>();
        _creditReportService = Mock.Of<ICreditReportService>();
        _creditApplicationBusinessRules =  new CreditApplicationBusinessRules(_creditApplicationRepository);

        _customer = new()
        {
            Email = "test@email.com",
            IdentityNumber = "12345678901",
            Id = Guid.NewGuid(),
            CreatedById = Guid.NewGuid(),
            Name = "Ufuk",
            Surname = "Elibol",
            EntityStatusType = EntityStatusType.Active,
            CreatedAt = DateTime.Now
        };

        _creditApplication = new()
        {
            Amount = 10000,
            ApplicationDate = DateTime.UtcNow,
            CustomerId = Guid.NewGuid(),
            Id = Guid.NewGuid(),
            LoanTerm = 60,
            InterestRate = 1.9m,
            ApplicationResultType = ApplicationResultType.Accepted,
            CreatedAt = DateTime.UtcNow,
            CreatedById = Guid.NewGuid(),
            Customer = _customer,
            EntityStatusType = EntityStatusType.Active
        };
    }

    [Test]
    //Başarılı sonuç dönmeli. Herşey yolunda olmalı
    public async Task Handle_ShouldReturnSuccessResponse_WhenEverythingIsCorrect()
    {
        // Arrange
        var handler = new CreateCreditApplicationCommandHandler(_mapper, _creditApplicationRepository, _mediator, _creditReportService, _creditApplicationBusinessRules);
        Mock.Get(_mediator)
            .Setup(x => x.Send(It.IsAny<GetByIdCustomerQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ResponseResult<GetByIdCustomerQueryResponse>
            {
                Succeeded = true,
                Data = new(),
                ResponseResultType = ResponseResultType.Succeeded
            });


        Mock.Get(_creditReportService)
            .Setup(x => x.CreditInformationByIdentityNumber(It.IsAny<string>()))
            .Returns(new ResponseResult<CreditInformationResponse>
            {
                Succeeded = true,
                Data = new(),
                ResponseResultType = ResponseResultType.Succeeded
            });

        Mock.Get(_creditApplicationRepository)
            .Setup(x => x.AddAsync(It.IsAny<CreditApplication>()))
            .ReturnsAsync(_creditApplication);

        Mock.Get(_mediator)
            .Setup(x => x.Send(It.IsAny<CreateCustomerCriteriaCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ResponseResult<CreateCustomerCriteriaCommandResponse>
            {
                Succeeded = true,
                Data = new(),
                ResponseResultType = ResponseResultType.Succeeded
            });


        // Act
        var result = await handler.Handle(new CreateCreditApplicationCommand(), CancellationToken.None);
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(result.Succeeded, Is.True, @"_________________________
- Succeeded true olmalı,
- Sonuç : {0}, 
- Mesaj : {1}
_________________________", result.Succeeded, result.ResponseMessage);


            Assert.That(result.Data, Is.Not.Null, @"
- Data null olmamalı,
- Sonuç : {0}, 
- Mesaj : {1}
", result.Data, result.ResponseMessage);
        });
    }

    [Test]
    //Müşteri bilgileri alınmadığında başarısız olmalı. [Succeeded false, data null olmalı]
    public async Task Handle_ShouldReturnFailedResponse_WhenCustomerInformationNotReceived()
    {
        // Arrange
        var handler = new CreateCreditApplicationCommandHandler(_mapper, _creditApplicationRepository, _mediator, _creditReportService, _creditApplicationBusinessRules);
        Mock.Get(_mediator)
            .Setup(x => x.Send(It.IsAny<GetByIdCustomerQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ResponseResult<GetByIdCustomerQueryResponse>
            {
                Succeeded = false,
                Data = null,
                ResponseResultType = ResponseResultType.DatabaseError
            });

        // Act
        var result = await handler.Handle(new CreateCreditApplicationCommand(), CancellationToken.None);
        Assert.Multiple(() =>
        {

            // Assert
            Assert.That(result.Succeeded, Is.False, @"
- Succeeded false olmalı,
- Sonuç : {0}, 
- Mesaj : {1}
", result.Succeeded, result.ResponseMessage);


            Assert.That(result.Data, Is.Null, @"
- Data null olmalı,
- Sonuç : {0}, 
- Mesaj : {1}
", result.Data, result.ResponseMessage);
        });
    }

    [Test]
    //Müşteri kredi rapor bilgileri alınmadığında başarısız olmalı. [Succeeded false, data null olmalı]
    public async Task Handle_ShouldReturnFailedResponse_WhenCustomerCreditReportNotReceived()
    {
        // Arrange
        var handler = new CreateCreditApplicationCommandHandler(_mapper, _creditApplicationRepository, _mediator, _creditReportService, _creditApplicationBusinessRules);
        Mock.Get(_mediator)
        .Setup(x => x.Send(It.IsAny<GetByIdCustomerQuery>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(new ResponseResult<GetByIdCustomerQueryResponse>
        {
            Succeeded = true,
            Data = new(),
            ResponseResultType = ResponseResultType.Succeeded
        });

        Mock.Get(_creditReportService)
        .Setup(x => x.CreditInformationByIdentityNumber(It.IsAny<string>()))
        .Returns(new ResponseResult<CreditInformationResponse>
        {
            Succeeded = false,
            Data = null,
            ResponseResultType = ResponseResultType.IntegrationError
        });

        // Act
        var result = await handler.Handle(new CreateCreditApplicationCommand(), CancellationToken.None);
        Assert.Multiple(() =>
        {

            // Assert
            Assert.That(result.Succeeded, Is.False, @"
- Succeeded false olmalı,
- Sonuç : {0}, 
- Mesaj : {1}
", result.Succeeded, result.ResponseMessage);


            Assert.That(result.Data, Is.Null, @"
- Data null olmalı,
- Sonuç : {0}, 
- Mesaj : {1}
", result.Data, result.ResponseMessage);
        });
    }

    [Test]
    //Müşteri CustomerCriteria bilgilerini oluşturamadığında başarısız olmalı. [Succeeded false, data null olmalı]
    public async Task Handle_ShouldReturnFailedResponse_WhenCustomerCriteriaNotAdded()
    {
        // Arrange
        var handler = new CreateCreditApplicationCommandHandler(_mapper, _creditApplicationRepository, _mediator, _creditReportService, _creditApplicationBusinessRules);
        Mock.Get(_mediator)
            .Setup(x => x.Send(It.IsAny<GetByIdCustomerQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ResponseResult<GetByIdCustomerQueryResponse>
            {
                Succeeded = true,
                Data = new(),
                ResponseResultType = ResponseResultType.Succeeded
            });

        Mock.Get(_creditReportService)
            .Setup(x => x.CreditInformationByIdentityNumber(It.IsAny<string>()))
            .Returns(new ResponseResult<CreditInformationResponse>
            {
                Succeeded = true,
                Data = new(),
                ResponseResultType = ResponseResultType.Succeeded
            });

        Mock.Get(_creditApplicationRepository)
            .Setup(x => x.AddAsync(It.IsAny<CreditApplication>()))
            .ReturnsAsync(_creditApplication);

        Mock.Get(_mediator)
            .Setup(x => x.Send(It.IsAny<CreateCustomerCriteriaCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ResponseResult<CreateCustomerCriteriaCommandResponse>
            {
                Succeeded = false,
                Data = null,
                ResponseResultType = ResponseResultType.DatabaseError
            });


        // Act
        var result = await handler.Handle(new CreateCreditApplicationCommand(), CancellationToken.None);
        Assert.Multiple(() =>
        {

            // Assert
            Assert.That(result.Succeeded, Is.False, @"_________________________
- Succeeded false olmalı,
- Sonuç : {0}, 
- Mesaj : {1}
_________________________", result.Succeeded, result.ResponseMessage);


            Assert.That(result.Data, Is.Null, @"
- Data null olmalı,
- Sonuç : {0}, 
- Mesaj : {1}
", result.Data, result.ResponseMessage);
        });
    }
}
