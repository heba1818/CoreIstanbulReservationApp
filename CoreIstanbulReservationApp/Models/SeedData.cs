using CoreIstanbulReservationApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreIstanbulReservationApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CoreIstanbulReservationAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CoreIstanbulReservationAppContext>>()))
            {
                if (context.Inecternace.Any())
                {
                    return;   // DB has been seeded
                }
           

            }


        }
    }
}
