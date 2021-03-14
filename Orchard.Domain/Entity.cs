namespace Orchard.Domain
{
    public abstract class Entity<TKeyType, TEntity>
    {
        protected Entity(TKeyType ID = default)
        {
            Id = ID;
        }

        public virtual TKeyType Id { get; set; }
    }
}