using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI
{
    public class Printer
    {
        IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        public void GetPets()
        {
            List<Pet> pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                    $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                    $"\nPrice: {pet.Price}");
                Console.WriteLine("\n-----------------------------------------------");
            }
        }
    }
}
