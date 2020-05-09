using System;
using System.Collections.Generic;

namespace URIS_KP
{
    public class Detector
    {
        public int Id { get; set; }

        /// <summary>
        /// Дата проверки датчика в ремонтных мастерских
        /// </summary>
        public DateTime CheckDate { get; set; }
        public DateTime NextCheckDate { get => CheckDate.AddMonths(6); }

        /// <summary>
        /// Дата установки датчика
        /// </summary>
        public DateTime InstallationDate { get; set; }

        /// <summary>
        /// Дата демонтажа датчика
        /// </summary>
        public DateTime? DismantlingDate { get => InstallationDate.AddYears(5); }

        /// <summary>
        /// Статус датчика
        /// </summary>
        public string Status { get; set; } // устанавливается только через ComboBox (В работе, в ремонте, на складе, ожидает отправки в ремонт)

        /// <summary>
        /// Где установлен датчик
        /// </summary>
        public  int PlaceId { get; set; }
        public Place Place { get; set; }

        /// <summary>
        /// когда обслуживался датчик
        /// </summary>
        public virtual ICollection<Service> Services { get; set; }

        /// <summary>
        /// Заявки по датчику
        /// </summary>
        public virtual ICollection<Request> Requests { set; get; }

        public string GetCheckDate()
        {
            return CheckDate.ToShortDateString();
        }
        public string GetNextCheckDate()
        {
            return NextCheckDate.ToShortDateString();
        }
        /// <summary>
        /// Отправить в мастерские
        /// </summary>
        /// <param name="detector"></param>
        public void SendToRepair()
        {
            PlaceId = 9998;  // go to masterskie
            Status = "В мастерских";
        }
        

    }
}
