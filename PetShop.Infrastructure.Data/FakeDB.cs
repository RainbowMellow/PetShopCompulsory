using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static List<Pet> Pets;


        public static string[] Options = {

                "Exit",
                "Show And Sort List Of All Pets",
                "Search Pets By Type",
                "Create A Pet",
                "Delete A Pet",
                "Update A Pet",
                "Get 5 Cheapest Available Pets"
            };


        public static void InitData()
        {
            Pets = new List<Pet>();

            Pet firstPet = new Pet {
                ID = 1,
                Name = "Paul",
                Type = PetType.Dog,
                BirthDate = Convert.ToDateTime("31/1/1999"),
                SoldDate = Convert.ToDateTime("31/1/2002"),
                Color = "Red",
                PreviousOwner = "Lars Larsen",
                Price = 2000
            };

            Pet secondPet = new Pet {
                ID = 2,
                Name = "Rebecca",
                Type = PetType.Cat,
                BirthDate = Convert.ToDateTime("21/3/2000"),
                SoldDate = Convert.ToDateTime("31/12/2000"),
                Color = "Orange",
                PreviousOwner = "Mark Hansen",
                Price = 3500
            };

            Pets.Add(firstPet);
            Pets.Add(secondPet);
            
        }
    }
}
