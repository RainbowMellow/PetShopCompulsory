using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IPetRepository
    {
        public List<Pet> ReadPets();
        public string[] GetMenuItems();
        public List<Pet> GetFiveCheapestPets();
        public Pet CreatePet(Pet inputPet);
        public Pet DeletePet(int id);
        public Pet GetPet(int id);
        public Pet UpdatePet(Pet pet);
        public List<Pet> GetPetByType(PetType petType);
        public List<Pet> GetPetsHToL();
        public List<Pet> GetPetsLToH();
    }
}
