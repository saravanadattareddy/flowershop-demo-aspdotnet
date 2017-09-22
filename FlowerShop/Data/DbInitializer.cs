using FlowerShop.Models;
using System;
using System.Linq;

namespace FlowerShop.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GeneralContext context)
        {
            context.Database.EnsureCreated();

            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
            new Customer{FirstMidName="Carson",LastName="Alexander",RegistrationDate=DateTime.Parse("2005-09-01")},
            new Customer{FirstMidName="Meredith",LastName="Alonso",RegistrationDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstMidName="Arturo",LastName="Anand",RegistrationDate=DateTime.Parse("2003-09-01")},
            new Customer{FirstMidName="Gytis",LastName="Barzdukas",RegistrationDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstMidName="Yan",LastName="Li",RegistrationDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstMidName="Peggy",LastName="Justice",RegistrationDate=DateTime.Parse("2001-09-01")},
            new Customer{FirstMidName="Laura",LastName="Norman",RegistrationDate=DateTime.Parse("2003-09-01")},
            new Customer{FirstMidName="Nino",LastName="Olivetto",RegistrationDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Customer s in customers)
            {
                context.Customers.Add(s);
            }

            context.SaveChanges();

            var flowers = new Flower[]
            {
            new Flower{FlowerName="Rose"},
            new Flower{FlowerName="Lilly"},
            };
            foreach (Flower s in flowers)
            {
                context.Flowers.Add(s);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
            //new Order{CustomerID=1,FlowerID=1},

            };
            foreach (Order s in orders)
            {
                context.Orders.Add(s);
            }
            context.SaveChanges();

        }
    }
}