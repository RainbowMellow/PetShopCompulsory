using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System.Collections.Generic;

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

        public void DeletePet(int id)
        {
            _petRepository.DeletePet(id);
        }

        public List<Pet> GetFiveCheapestPets()
        {
            return _petRepository.GetFiveCheapestPets();
        }

        public string[] GetMenuItems()
        {
            return _petRepository.GetMenuItems();
        }

        public Pet GetPet(int id)
        {
            return _petRepository.GetPet(id);
        }

        public List<Pet> GetPetByType(PetType petType)
        {
            return _petRepository.GetPetByType(petType);
        }

        public List<Pet> GetPets()
        {
            return (List<Pet>)_petRepository.ReadPets();
        }

        public List<Pet> GetPetsHToL()
        {
            return _petRepository.GetPetsHToL();
        }

        public List<Pet> GetPetsLToH()
        {
            return _petRepository.GetPetsLToH();
        }

        public void UpdatePet(Pet pet)
        {
            _petRepository.UpdatePet(pet);
        }
    }
}
