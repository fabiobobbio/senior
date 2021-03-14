using System.Collections.Generic;

namespace Orchard.Domain
{
    public class TreeGroup : Entity<int, TreeGroup>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TreeId { get; set; }
        public List<Tree> Trees { get; set; }
    }
}