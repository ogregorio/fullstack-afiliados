using System.Globalization;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Infra.CrosCutting.Helpers;

namespace FullstackAfiliados.Tests.Commons.Helpers
{
    public class SalesFileTests
    {
        [Theory]
        [InlineData(1, "2022-01-15T19:20:30-03:00", "CURSO DE BEM-ESTAR", 12.75, "JOSE CARLOS")]
        [InlineData(2, "2022-02-01T10:00:00-03:00", "VENDA AFILIADO", 50.00, "MARIA SILVA")]
        public void ParseFilesCorrect(int type, string dateStr, string product, decimal amount, string salesman)
        {
            #region Arrange

            SalesFile salesFile = new SalesFile();
            string content = $"{type}{dateStr}{product.PadRight(30)}{amount * 100:0000000000}{salesman.PadRight(20)}\n";

            #endregion

            #region Act

            List<Transaction> transactions = salesFile.Parse(content);

            #endregion

            #region Assert

            Assert.Equal(1, transactions.Count);
            Assert.Equal(type, transactions[0].RelativeType);
            Assert.Equal(DateTime.ParseExact(dateStr, "yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture).ToUniversalTime(), transactions[0].Date);
            Assert.Equal(product, transactions[0].Product);
            Assert.Equal(amount, transactions[0].Amount);
            Assert.Equal(salesman, transactions[0].Salesman);

            #endregion
        }
    }
}