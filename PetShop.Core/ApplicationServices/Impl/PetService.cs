using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices.Impl
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet CreatePet(Pet inputPet)
        {
            return _petRepository.CreatePet(inputPet);
        }

        public List<Pet> GetFiveCheapestPets()
        {
            return _petRepository.GetFiveCheapestPets();
        }

        public string[] GetMenuItems()
        {
            return _petRepository.GetMenuItems();
        }

        public List<Pet> GetPets()
        {
            return (List<Pet>)_petRepository.ReadPets();
        }
    }
}
