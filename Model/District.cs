
using System.Collections.Generic;

namespace URIS_KP
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
