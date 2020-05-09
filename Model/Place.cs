using System.Collections.Generic;

namespace URIS_KP
{
    /// <summary>
    /// Место (точка), где установлен датчик на локации
    /// </summary>
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// На какой локации
        /// </summary>
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        /// <summary>
        /// Список датчиков на точке
        /// </summary>
        public ICollection<Detector> Detectors { get; set; }
    }
}
