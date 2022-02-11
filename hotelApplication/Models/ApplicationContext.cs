using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelApplication.Models
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        //public IdentityDbContext<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Room> Brons { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Room> Rooms { get; set; }

    }
}
