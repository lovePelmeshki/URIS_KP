using System;

namespace URIS_KP
{
    /// <summary>
    /// Плановое обслуживание датчиков
    /// </summary>
    public class Service
    {
        public int Id { get; set; }
        /// <summary>
        /// Тип обслуживания (Тех.процесс, Замена)
        /// </summary>
        public string Type { get; set; } // устанавливается только через ComboBox

        /// <summary>
        /// Дата и время обслуживания
        /// </summary>
        public DateTime ServiceDate { get; set; }
        public DateTime NextServiceDate { get; set; }

        /// <summary>
        /// Датчик, который обслуживался
        /// </summary>
        public int DetectorId { get; set; } 
        public virtual Detector Detector { get; set; } 

        /// <summary>
        /// Сотрудник, производивший обслуживание
        /// </summary>
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


        public string GetServiceDate()
        {
            return ServiceDate.ToString();
        }

        public string GetNextServiceDate()
        {
            return NextServiceDate.ToShortDateString();
        }

        public void ChangeDetectors(Detector oldDetector, Detector newDetector)
        {
            int place = oldDetector.PlaceId;

            oldDetector.PlaceId = 9999; // go to Sklad
            oldDetector.Status = "Ожидает отправки в ремонт";

            newDetector.PlaceId = place; // go to place
            newDetector.Status = "В работе";
        }




    }
}
