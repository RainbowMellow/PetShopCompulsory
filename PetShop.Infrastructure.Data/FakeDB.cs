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
        public static IEnumerable<Pet> Pets;
        

        private static string[] Options = {

                "Exit",    
                "Show And Sort List Of All Pets",
                "Search Pets By Type",
                "Create A Pet",
                "Delete A Pet",
                "Update A Pet",
                "Get 5 Cheapest Available Pets"
            };

        internal static Pet CreatePet(Pet inputPet)
        {
            List<Pet> petList = Pets.ToList(); 
            
            int _id = petList.Count + 1;

            Pet createdPet = new Pet { 

                ID = _id++,
                Name = inputPet.Name,
                Type = inputPet.Type,
                BirthDate = inputPet.BirthDate,
                SoldDate = inputPet.SoldDate,
                Color = inputPet.Color,
                PreviousOwner = inputPet.PreviousOwner,
                Price = inputPet.Price

                };

            petList.Add(createdPet);
            Pets = petList;

            return createdPet;
        }

        internal static List<Pet> GetFiveCheapestPets()
        {
            List<Pet> cheapestPets = Pets.OrderBy(Pet => Pet.Price).Take(5).ToList();
            return cheapestPets;
        }

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

        internal static string[] GetMenuItems()
        {
            return Options;
        }

        public static IEnumerable<Pet> GetPetList()
        {
            return Pets;
        }
    }
}
