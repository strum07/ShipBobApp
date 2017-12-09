using System.Linq;
using ShipBobApp.Models;

namespace ShipBobApp.Data
{
    public static class DbSeed
    {
        public static void Initialize(ShipBobAppContext context)
        {
            // Look for any Users.
            if (context.Users.Any())
                return;   // DB has been seeded

            var users = new User[]
            {
                new User { FirstName = "Gytis",    LastName = "Barzdukas"
                   },
                new User { FirstName = "Yan",      LastName = "Li"
                   },
                new User { FirstName = "Peggy",    LastName = "Justice"
                   },
                new User { FirstName = "Laura",    LastName = "Norman"
                   },
                new User { FirstName = "Nino",     LastName = "Olivetto"
                   },
                new User { FirstName = "Carson",     LastName = "Alexander"
                },
                new User { FirstName = "Meredith",     LastName = "Alonso"
                },
                new User { FirstName = "Arturo",     LastName = "Anand"
                }
            };

            foreach (var s in users)
                context.Users.Add(s);

            context.SaveChanges();


        }
    }
}
