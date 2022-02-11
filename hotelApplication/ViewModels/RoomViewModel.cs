using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelApplication.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int NumberOfRoom { get; set; } //Номер комнаты
        public int NumberOfBeds { get; set; } //Кол-во  кроватей
        public string BedLocation { get; set; } //Расположение кроватей
        public string Description { get; set; } // Описание комнаты
    }
}
