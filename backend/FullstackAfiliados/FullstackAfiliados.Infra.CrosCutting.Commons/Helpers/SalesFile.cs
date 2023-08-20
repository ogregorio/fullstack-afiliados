using System.Globalization;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Infra.CrosCutting.Exceptions;

namespace FullstackAfiliados.Infra.CrosCutting.Helpers;

public class SalesFile
{
    const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ssK";

    public List<Transaction> Parse(string content)
    {
        List<Transaction> transactions = new List<Transaction>();
        string[] lines = content.Split('\n');

        try
        {
            foreach (string line in lines)
            {
                if (!String.IsNullOrWhiteSpace(line))
                {
                    transactions.Add(new Transaction
                    {
                        RelativeType = int.Parse(line.Substring(0, 1)),
                        Date = DateTime.ParseExact(line.Substring(1, 25), DATE_FORMAT, CultureInfo.InvariantCulture),
                        Product = line.Substring(26, 30).Trim(),
                        Amount = decimal.Parse(line.Substring(56, 10)) / 100,
                        Salesman = line.Substring(66).Trim()
                    });
                }
            }
        }
        catch (Exception e)
        {
            throw new BadRequestException("Invalid line in transactions file");
        }

        return transactions;
    }
}