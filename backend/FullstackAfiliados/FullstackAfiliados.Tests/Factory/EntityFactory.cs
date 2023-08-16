using Bogus;
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
}
public class GenericEntity : Entity
{
    public override void Update(object obj)
    {
        ModifyAt = DateTime.UtcNow;
    }
}