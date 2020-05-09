using System;
namespace URIS_KP
{
    /// <summary>
    /// Заявка
    /// </summary>
    public class Request
    {
        public int Id { get; set; }

        /// <summary>
        /// Кто открыл заявку
        /// </summary>
        public int EmployeeIdWhosOpen { get; set; }
        public virtual Employee EmployeeWhosOpen { get; set; } // навигационное свойсвтво? https://metanit.com/sharp/helpdeskmvc/2.1.php

        /// <summary>
        /// Кто закрыл заявку
        /// </summary>
        public int? EmployeeIdWhosClosed { get; set; }
        public virtual Employee EmployeeWhosClosed { get; set; }

        /// <summary>
        /// Дата открытия заявки
        /// </summary>
        public DateTime CreatedDate { get; set; } 

        /// <summary>
        /// Дата закрытия заявкт
        /// </summary>
        public DateTime? CloseDate { get; set; }

        public string Status { get; set; }
        public string Discription { get; set; }
        /// <summary>
        /// Неисправный датчик
        /// </summary>
        public int? DetectorId { get; set; }
        public virtual Detector Detector { get; set; } // навигационное свойство?



    }
}
