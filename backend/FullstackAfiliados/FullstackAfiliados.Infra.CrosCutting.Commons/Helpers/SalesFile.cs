using System.Globalization;
using FullstackAfiliados.Domain.Entities;

namespace FullstackAfiliados.Infra.CrosCutting.Helpers;

public class SalesFile
{
    public List<Transaction> Parse(string content)
    {
        List<Transaction> transactions = new List<Transaction>();
        string[] lines = content.Split('\n');

        foreach (string line in lines)
        {
            if (line.Length >= 86)
            {
                transactions.Add(new Transaction
                {
                    RelativeType = int.Parse(line.Substring(0, 1)),
                    Date = DateTime.ParseExact(line.Substring(1, 25), "yyyy-MM-ddTHH:mm:ssK", CultureInfo.InvariantCulture),
                    Product = line.Substring(26, 30).Trim(),
                    Amount = decimal.Parse(line.Substring(56, 10)) / 100,
                    Salesman = line.Substring(66, 20).Trim()
                });
            }
        }

        return transactions;
    }
}