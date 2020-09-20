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
        public Pet CreatePet(Pet inputPet);
        public Pet DeletePet(int id);
        public Pet GetPet(int id);
        public Pet UpdatePet(Pet pet);
        public List<Pet> GetPetsWithParameters(string prop, string dir);
    }
}
