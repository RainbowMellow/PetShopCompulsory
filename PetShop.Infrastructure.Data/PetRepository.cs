using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {
        }

        public Pet CreatePet(Pet inputPet)
        {
            int _id = FakeDB.Pets.Count + 1;

            Pet createdPet = new Pet
            {

                ID = _id,
                Name = inputPet.Name,
                Type = inputPet.Type,
                BirthDate = inputPet.BirthDate,
                SoldDate = inputPet.SoldDate,
                Color = inputPet.Color,
                PreviousOwner = inputPet.PreviousOwner,
                Price = inputPet.Price

            };

            FakeDB.Pets.Add(createdPet);

            return createdPet;
        }

        public void DeletePet(int id)
        {
            Pet pet = FakeDB.Pets.Find(Pet => Pet.ID == id);
            FakeDB.Pets.Remove(pet);
        }

        public List<Pet> GetFiveCheapestPets()
        {
            List<Pet> cheapestPets = FakeDB.Pets.OrderBy(Pet => Pet.Price).Take(5).ToList();
            return cheapestPets;
        }

        public string[] GetMenuItems()
        {
            return FakeDB.Options;
        }

        public Pet GetPet(int id)
        {
            Pet pet = FakeDB.Pets.Find(Pet => Pet.ID == id);
            return pet;
        }

        public List<Pet> GetPetByType(PetType petType)
        {
            List<Pet> petListByType = FakeDB.Pets.FindAll(Pet => Pet.Type == petType);
            return petListByType;
        }

        public List<Pet> GetPetsHToL()
        {
            List<Pet> petsHToL = FakeDB.Pets.OrderByDescending(Pet => Pet.Price).ToList();
            return petsHToL;
        }

        public List<Pet> GetPetsLToH()
        {
            List<Pet> petsLToH = FakeDB.Pets.OrderBy(Pet => Pet.Price).ToList();
            return petsLToH;
        }

        public List<Pet> ReadPets()
        {
            return FakeDB.Pets.ToList();
        }

        public void UpdatePet(Pet pet)
        {
            Pet chosenPet = FakeDB.Pets.Find(Pet => Pet.ID == pet.ID);
            chosenPet.Name = pet.Name;
            chosenPet.Type = pet.Type;
            chosenPet.BirthDate = pet.BirthDate;
            chosenPet.Color = pet.Color;
            chosenPet.SoldDate = pet.SoldDate;
            chosenPet.PreviousOwner = pet.PreviousOwner;
            chosenPet.Price = pet.Price;
        }
    }
}
