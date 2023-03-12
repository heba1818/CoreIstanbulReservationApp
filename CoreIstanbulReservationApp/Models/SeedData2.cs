using CoreIstanbulReservationApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CoreIstanbulReservationApp.Models;

public static class SeedData2
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CoreIstanbulReservationAppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CoreIstanbulReservationAppContext>>()))
        {
            if (context.Room.Any())
            {
                return;   // DB has been seeded
            }
            context.Room.AddRange(
                new Room
                {
                    Id = 1,
                    Name = "room",
                    Capacity = "5",
                    Description = "Meeting Room"
                }
            );

        }


    }
}