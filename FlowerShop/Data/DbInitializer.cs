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



        }
    }
}