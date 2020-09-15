using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class FakeDB
    {
        public static List<Pet> Pets;
        public static List<Owner> Owners;


        public static string[] Options = {

                "Exit",
                "Show And Sort List Of All Pets",
                "Search Pets By Type",
                "Create A Pet",
                "Delete A Pet",
                "Update A Pet",
                "Get 5 Cheapest Available Pets",
                "Access Owner Menu"
            };

        public static string[] OwnerMenuOptions = {

                "Exit",
                "Back To Menu",
                "Create Owner",
                "List Of Owners",
                "Update Owner",
                "Delete Owner"
            };



        public static void InitData()
        {
            Pets = new List<Pet>();
            Owners = new List<Owner>();

            Owner firstOwner = new Owner
            {
                ID = 1,
                FirstName = "Lars",
                LastName = "Larsen",
                Address = "Januarvej 24, 6700 Esbjerg",
                PhoneNumber = "21234253",
                Email = "lars.larsen@hotmail.com"
            };

            Owner secondOwner = new Owner
            {
                ID = 2,
                FirstName = "Mark",
                LastName = "Hansen",
                Address = "Septembervej 24, 6700 Esbjerg",
                PhoneNumber = "26728259",
                Email = "mark.hansen@hotmail.com"
            };



            Pet firstPet = new Pet
            {
                ID = 1,
                Name = "Paul",
                Type = PetType.Dog,
                BirthDate = Convert.ToDateTime("31/1/1999", new CultureInfo("da-DK")),
                SoldDate = Convert.ToDateTime("31/1/2002", new CultureInfo("da-DK")),
                Color = "Red",
                PreviousOwner = firstOwner,
                Price = 2000
            };

            Pet secondPet = new Pet
            {
                ID = 2,
                Name = "Rebecca",
                Type = PetType.Cat,
                BirthDate = Convert.ToDateTime("21/3/2000", new CultureInfo("da-DK")),
                SoldDate = Convert.ToDateTime("31/12/2000", new CultureInfo("da-DK")),
                Color = "Orange",
                PreviousOwner = secondOwner,
                Price = 3500
            };

            Owners.Add(firstOwner);
            Owners.Add(secondOwner);
            Pets.Add(firstPet);
            Pets.Add(secondPet);
            
        }
    }
}
