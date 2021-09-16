
using System.Collections.Generic;

namespace URIS_KP
{

    /// <summary>
    /// Локация охраняемого объекта (так сказать адрес объекта, но не адрес)
    /// </summary>
   public class Location
    {
        public int Id{ get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Район, в котором находится объект
        /// </summary>
        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        /// <summary>
        /// Список датчиков, установленных на текущей локации
        /// </summary>
        public virtual ICollection<Place> Places { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
