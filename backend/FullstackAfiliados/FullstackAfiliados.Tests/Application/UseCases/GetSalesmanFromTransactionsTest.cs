using AutoMapper;
using FullstackAfiliados.Application.UseCases.Transactions.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Domain.Dto;
using FullstackAfiliados.Domain.Services.Interfaces;
using FullstackAfiliados.Tests.Factory;
using Moq;

namespace FullstackAfiliados.Tests.Application.UseCases;

public class GetSalesmanFromTransactionsTest
{
    private readonly Mock<ITransactionService> _mockTransactionService;
    private readonly IMapper _mapper;
    private readonly GetSalesmanFromTransactionsHandler _handler;

    public GetSalesmanFromTransactionsTest()
    {
        _mockTransactionService = new Mock<ITransactionService>();
        _mapper = MapperFactory.GetMapperFactory();
        _handler = new GetSalesmanFromTransactionsHandler(_mockTransactionService.Object, _mapper);
    }

    [Fact]
    public async Task ReturnsMappedSalesmanList()
    {
        #region Arrange

        var cancellationToken = CancellationToken.None;

        var serviceResult = new List<Salesman>() { EntityFactory.GetFakeSalesman() };

        _mockTransactionService.Setup(service => service.GetSalesman())
            .ReturnsAsync(serviceResult);

        var request = new GetSalesmanFromTransactionsRequest();

        #endregion

        #region Act

        var result = await _handler.Handle(request, cancellationToken);

        #endregion

        #region Assert

        Assert.NotNull(result);
        Assert.Single(result);

        #endregion
    }

}