using hotelApplication.Models;
using hotelApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelApplication.Controllers
{
    public class ReservationController : Controller
    {
        ApplicationContext context;

        public ReservationController(ApplicationContext _db)
        {
            context=_db;
        }
        public IActionResult Index()
        {
            return View(context.Reservations.ToList());
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }
            ViewBag.RoomId = id;
            var model = context.Rooms.FirstOrDefault(m => m.Id == id);
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Create(ReservationViewModel model)
        {            

            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    RoomId = model.RoomId,
                    FirstName = model.FirstName,
                    Name = model.Name,
                    LastName = model.LastName,
                    FirstDate = model.FirstDate,
                    LastDate = model.LastDate
                };
                context.Reservations.Add(reservation);
                await context.SaveChangesAsync();
                return RedirectToAction("Example","Main");
            }

            return View(model);
        }
    }
}
