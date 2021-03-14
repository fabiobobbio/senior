namespace Orchard.Domain
{
    public class Specie : Entity<int, Specie>
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}