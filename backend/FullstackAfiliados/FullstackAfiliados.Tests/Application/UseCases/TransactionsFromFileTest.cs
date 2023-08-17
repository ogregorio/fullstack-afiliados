using System.Text;
using FullstackAfiliados.Application.UseCases.Transactions.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;

namespace FullstackAfiliados.Tests.Application.UseCases
{
    public class TransactionsFromFileHandlerTests
    {
        private readonly Mock<ITransactionService> _mockService;
        private readonly TransactionsFromFileHandler _handler;

        public TransactionsFromFileHandlerTests()
        {
            _mockService = new Mock<ITransactionService>();
            _handler = new TransactionsFromFileHandler(_mockService.Object);
        }

        private Mock<IFormFile> CreateMockFormFile(string content)
        {
            var mockFormFile = new Mock<IFormFile>();
            var fileName = "arquivo.txt";
            var length = content.Length;
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            mockFormFile.Setup(f => f.FileName).Returns(fileName);
            mockFormFile.Setup(f => f.Length).Returns(length);
            mockFormFile.Setup(f => f.OpenReadStream()).Returns(stream);

            return mockFormFile;
        }

        [Theory]
        [InlineData(2, "2022-02-01T10:00:00-03:00", "VENDA AFILIADO", 50.00, "MARIA SILVA")]
        public async Task ValidFileSuccessfully(int type, string dateStr, string product, decimal amount, string salesman)
        {
            #region Arrange

            var content = $"{type}{dateStr}{product.PadRight(30)}{amount * 100:0000000000}{salesman.PadRight(20)}\n";
            var mockFormFile = CreateMockFormFile(content);
            var request = new TransactionsFromFileRequest { File = mockFormFile.Object };

            #endregion

            #region Act

            var response = await _handler.Handle(request, CancellationToken.None);

            #endregion

            #region Assert

            Assert.True(response.Success);
            _mockService.Verify(s => s.CreateAsync(It.IsAny<Transaction>()), Times.AtLeastOnce);

            #endregion
        }

        [Fact]
        public async Task NullFileThrowsException()
        {
            #region Arrange

            var request = new TransactionsFromFileRequest { File = null };

            #endregion

            #region Act & Assert

            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));

            #endregion
        }
    }
}