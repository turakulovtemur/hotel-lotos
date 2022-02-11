using hotelApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace hotelApplication.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DataType FirstDate { get; set; }
        public DataType LastDate { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }

    }
}
