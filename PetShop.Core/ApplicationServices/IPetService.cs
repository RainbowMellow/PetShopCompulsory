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
        public List<Pet> GetFiveCheapestPets();
        public Pet CreatePet(Pet inputPet);
        public void DeletePet(int id);
        public Pet GetPet(int validatedId);
        public void UpdatePet(Pet pet);
        public List<Pet> GetPetByType(PetType petType);
        public List<Pet> GetPetsLToH();
        public List<Pet> GetPetsHToL();
    }
}
