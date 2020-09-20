using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetService
    {
        public List<Pet> GetPets();
        public string[] GetMenuItems();
        public Pet CreatePet(Pet inputPet);
        public Pet DeletePet(int id);
        public Pet GetPet(int validatedId);
        public Pet UpdatePet(Pet pet);
        public List<Pet> GetPetsWithParameters(string prop, string dir);
    }
}
