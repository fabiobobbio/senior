namespace Orchard.Domain
{
    public class Tree : Entity<int, Tree>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public int SpecieId { get; set; }
        public Specie Specie { get; set; }
    }
}