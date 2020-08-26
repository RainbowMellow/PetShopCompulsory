using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> Pets;

        public static void InitData()
        {
            List<Pet> petList = new List<Pet> {
            new Pet
            {
                ID = 1,
                Name = "Paul",
                Type = PetType.Dog,
                BirthDate = Convert.ToDateTime("31/1/1999"),
                SoldDate = Convert.ToDateTime("31/1/2002"),
                Color = "Red",
                PreviousOwner = "Lars Larsen",
                Price = 2000
            },
            new Pet
            {
                ID = 2,
                Name = "Rebecca",
                Type = PetType.Cat,
                BirthDate = Convert.ToDateTime("21/3/2000"),
                SoldDate = Convert.ToDateTime("31/12/2000"),
                Color = "Orange",
                PreviousOwner = "Mark Hansen",
                Price = 3500
            }
            };

            Pets = petList;
        }

        public static IEnumerable<Pet> GetPetList()
        {
            return Pets;
        }
    }
}
