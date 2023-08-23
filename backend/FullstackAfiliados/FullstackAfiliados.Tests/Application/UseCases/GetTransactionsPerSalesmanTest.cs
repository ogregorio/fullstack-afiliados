using AutoMapper;
using FullstackAfiliados.Application.UseCases.Transactions.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using FullstackAfiliados.Infra.CrosCutting.Exceptions;
using FullstackAfiliados.Tests.Factory;
using Moq;

namespace FullstackAfiliados.Tests.Application.UseCases;

public class GetTransactionsPerSalesmanTest
{
        private readonly Mock<ITransactionService> _mockTransactionService;
        private readonly IMapper _mapper;
        private readonly GetTransactionsPerSalesmanHandler _handler;

        public GetTransactionsPerSalesmanTest()
        {
            _mockTransactionService = new Mock<ITransactionService>();
            _mapper = MapperFactory.GetMapperFactory();
            _handler = new GetTransactionsPerSalesmanHandler(_mockTransactionService.Object, _mapper);
        }

       [Fact]
        public async Task ReturnsListOfTransactions()
        {
            #region Arrange

            var existentTransaction = EntityFactory.GetFakeTransaction();
            var request = new GetTransactionsPerSalesmanRequest { Salesman = existentTransaction.Salesman };
            var cancellationToken = CancellationToken.None;
            var transactions = new List<Transaction> { existentTransaction };

            _mockTransactionService
                .Setup(service => service.GetTransactionsBySalesman(existentTransaction.Salesman))
                .ReturnsAsync(transactions);

            #endregion

            #region Act
            var result = await _handler.Handle(request, cancellationToken);

            #endregion

            #region Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            #endregion
        }

        [Fact]
        public async Task NoTransactionsThrowsNotFoundException()
        {
            #region Arrange

            var request = new GetTransactionsPerSalesmanRequest { Salesman = "Nonexistent Salesman" };
            var cancellationToken = CancellationToken.None;

            #endregion

            _mockTransactionService.Setup(service => service.GetTransactionsBySalesman(request.Salesman))
                .ReturnsAsync(new List<Transaction>());

            #region Act & Assert

            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, cancellationToken));

            #endregion
        }
}