using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreIstanbulReservationApp.Models;

namespace CoreIstanbulReservationApp.Data
{
    public class CoreIstanbulReservationAppContext : DbContext
    {
        public CoreIstanbulReservationAppContext (DbContextOptions<CoreIstanbulReservationAppContext> options)
            : base(options)
        {
        }

        public DbSet<CoreIstanbulReservationApp.Models.Instruments> Inecternace { get; set; } = default!;

        public DbSet<CoreIstanbulReservationApp.Models.Room> Room { get; set; } = default!;
    }
}
