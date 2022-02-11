using hotelApplication.Models;
using hotelApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelApplication.Controllers
{
    public class RoomController : Controller
    {
       public readonly ApplicationContext context ;

        public RoomController(ApplicationContext db)
        {
            context = db;
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                Room room = new Room { 
                    Id = model.Id,
                    NumberOfRoom = model.NumberOfRoom,
                    NumberOfBeds = model.NumberOfBeds,
                    BedLocation = model.BedLocation,
                    Description = model.Description
                };
                context.Rooms.Add(room);
                await context.SaveChangesAsync();                
                return RedirectToAction("Index", "Room");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Room room = await context.Rooms.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
                
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoomViewModel model)
        {
            Room room = context.Rooms.Find(model.Id);
            if (ModelState.IsValid)
            {
                room.BedLocation = model.BedLocation;
                room.Description = model.Description;
                room.NumberOfBeds = model.NumberOfBeds;
                room.NumberOfRoom = model.NumberOfRoom;
                context.Rooms.Update(room);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Room");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundResult();
            }
            var room = context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                return new NotFoundResult();
            }
            return View(room);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var room = await context.Rooms.FindAsync(id);
            context.Rooms.Remove(room);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Room");
        }

        public IActionResult Index()
        {
            return View(context.Rooms);
        }
    }
}
