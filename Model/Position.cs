using System.Collections.Generic;

namespace URIS_KP
{
    /// <summary>
    /// Должность
    /// </summary>
    public class Position
    {
        public int Id { get; set; }
        public string Name{ get; set; }

        /// <summary>
        /// Список сотрудников на определенной должности
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }


        public override string ToString()
        {
            return Name; 
        }
    }
}
