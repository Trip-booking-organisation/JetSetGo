namespace HouseFinder360.Domain.Common.BuildingBlocks;

public class AggregateRoot<TId> : Entity<TId> 
    where TId : notnull
{
    protected AggregateRoot(TId id) : base(id)
    {
    }

    protected AggregateRoot()
    {
    }
}