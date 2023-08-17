using System.Text;
using FullstackAfiliados.Application.UseCases.Transactions.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;

namespace FullstackAfiliados.Tests.Application.UseCases;

public class TransactionsFromFileTest
{
    [Theory]
    [InlineData(2, "2022-02-01T10:00:00-03:00", "VENDA AFILIADO", 50.00, "MARIA SILVA")]
    public async Task ValidFileSuccess(int type, string dateStr, string product, decimal amount, string salesman)
    {
        // Arrange
        var mockService = new Mock<ITransactionService>();
        var handler = new TransactionsFromFileHandler(mockService.Object);

        var mockFormFile = new Mock<IFormFile>();

        string content = $"{type}{dateStr}{product.PadRight(30)}{amount * 100:0000000000}{salesman.PadRight(20)}\n";
        var fileName = "arquivo.txt";
        var length = content.Length;
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
        mockFormFile.Setup(f => f.FileName).Returns(fileName);
        mockFormFile.Setup(f => f.Length).Returns(length);
        mockFormFile.Setup(f => f.OpenReadStream()).Returns(stream);

        var request = new TransactionsFromFileRequest
        {
            File = mockFormFile.Object
        };

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(response.Success);
        mockService.Verify(s => s.CreateAsync(It.IsAny<Transaction>()), Times.AtLeastOnce);
    }

    [Fact]
    public async Task NullFileThrowsException()
    {
        // Arrange
        var mockService = new Mock<ITransactionService>();
        var handler = new TransactionsFromFileHandler(mockService.Object);

        var request = new TransactionsFromFileRequest
        {
            File = null
        };

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(request, CancellationToken.None));
    }

}