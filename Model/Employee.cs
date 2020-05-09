using System.Collections.Generic;

namespace URIS_KP
{
    public class Employee
    {
        public int Id{ get; set; }
        public string SecondName{ get; set; }
        public string  Name{ get; set; }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public virtual int PositionId { get; set; }
        public virtual Position Position { get; set; }

        /// <summary>
        /// Список заявок сотрудника
        /// </summary>
        public virtual ICollection<Request> Requests { get; set; }

        /// <summary>
        /// Список обслуживаний
        /// </summary>
        public virtual ICollection<Service> Services { get; set; }
        
    }
}
