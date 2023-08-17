using Bogus;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Entities.Base;

namespace FullstackAfiliados.Tests.Factory;

public static class EntityFactory
{
    public static GenericEntity GetGenericMockedEntity =>
        new Faker<GenericEntity>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.CreateAt, f => f.Date.Past())
            .RuleFor(x => x.ModifyAt, f => f.Date.Past())
            .RuleFor(x => x.IsDeleted, f => f.Random.Bool());

    public static Transaction GetFakeTransaction() =>
        new Faker<Transaction>()
            .RuleFor(x => x.Type, f => f.PickRandom<TransactionType>())  // Assuming TransactionType is an enum
            .RuleFor(x => x.RelativeType, f => f.Random.Int())
            .RuleFor(x => x.TypeId, f => f.Random.Guid())
            .RuleFor(x => x.Date, f => f.Date.Past())
            .RuleFor(x => x.Product, f => f.Commerce.Product())
            .RuleFor(x => x.Amount, f => f.Finance.Amount())
            .RuleFor(x => x.Salesman, f => f.Name.FullName());

    public static TransactionType GetFakeTransactionType() =>
        new Faker<TransactionType>()
            .RuleFor(x => x.Type, f => f.Random.Int())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .RuleFor(x => x.Origin, f => f.Lorem.Word())
            .RuleFor(x => x.Signal, f => f.Random.Bool());

}
public class GenericEntity : Entity
{
    public override void Update(object obj)
    {
        ModifyAt = DateTime.UtcNow;
    }
}