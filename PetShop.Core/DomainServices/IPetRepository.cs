using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IPetRepository
    {
        public IEnumerable<Pet> ReadPets();
        public string[] GetMenuItems();
        public List<Pet> GetFiveCheapestPets();
        public Pet CreatePet(Pet inputPet);
    }
}
