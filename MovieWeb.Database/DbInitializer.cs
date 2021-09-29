using MovieWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWeb.Database
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.Actors.Any())
            {
                return;
            }

            var actors = new Actor[]
            {
                new Actor(){FirstName = "Tom", LastName = "Cruise", BirthDate = DateTime.Now.AddYears(-5), KevinBaconNumber = 1},
                new Actor(){FirstName = "Johnny", LastName = "Depp", BirthDate = DateTime.Now.AddYears(-6), KevinBaconNumber = 2},
            };

            foreach(var actor in actors)
            {
                context.Actors.Add(actor);
            }

            context.SaveChanges();
        }
    }
}
