using System;

namespace Orchard.Domain
{
    public class Harvest : Entity<int, Harvest>
    {
        public int Id { get; set; }
        public string Information { get; set; }
        public DateTime Date { get; set; }
        public decimal GrossWeight { get; set; }
        public int TreeId { get; set; }
        public Tree Tree { get; set; }
    }
}