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

        public Pet DeletePet(int id)
        {
            Pet pet = GetPet(id);

            FakeDB.Pets.Remove(pet);
            return pet;
        }

        public string[] GetMenuItems()
        {
            return FakeDB.Options;
        }

        public Pet GetPet(int id)
        {
            Pet pet = FakeDB.Pets.Find(Pet => Pet.ID == id);
            if (pet == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return pet;
            }
        }

        public List<Pet> GetPetsWithParameters(string prop, string dir)
        {
            switch (prop.Trim().ToLower())
            {
                case "id":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Pets.OrderBy(Pet => Pet.ID).ToList();
                            case "desc":
                                return FakeDB.Pets.OrderByDescending(Pet => Pet.ID)
                                                    .ToList();
                            default:
                                return FakeDB.Pets.OrderBy(Pet => Pet.ID).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Pets.OrderBy(Pet => Pet.ID).ToList();
                    }

                case "name":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Pets.OrderBy(Pet => Pet.Name).ToList();
                            case "desc":
                                return FakeDB.Pets.OrderByDescending(Pet => Pet.Name)
                                                .ToList();
                            default:
                                return FakeDB.Pets.OrderBy(Pet => Pet.Name).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Pets.OrderBy(Pet => Pet.Name).ToList();
                    }

                case "type":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Pets.OrderBy(Pet => Pet.Type.PetTypeName).ToList();
                            case "desc":
                                return FakeDB.Pets.OrderByDescending(Pet => Pet.Type.PetTypeName)
                                                    .ToList();
                            default:
                                return FakeDB.Pets.OrderBy(Pet => Pet.Type.PetTypeName).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Pets.OrderBy(Pet => Pet.Type.PetTypeName).ToList();
                    }

                case "birthdate":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Pets.OrderBy(Pet => Pet.BirthDate).ToList();
                            case "desc":
                                return FakeDB.Pets.OrderByDescending(Pet => Pet.BirthDate)
                                                    .ToList();
                            default:
                                return FakeDB.Pets.OrderBy(Pet => Pet.BirthDate).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Pets.OrderBy(Pet => Pet.BirthDate).ToList();
                    }

                case "solddate":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Pets.OrderBy(Pet => Pet.SoldDate).ToList();
                            case "desc":
                                return FakeDB.Pets.OrderByDescending(Pet => Pet.SoldDate)
                                                    .ToList();
                            default:
                                return FakeDB.Pets.OrderBy(Pet => Pet.SoldDate).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Pets.OrderBy(Pet => Pet.SoldDate).ToList();
                    }

                case "color":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Pets.OrderBy(Pet => Pet.Color).ToList();
                            case "desc":
                                return FakeDB.Pets.OrderByDescending(Pet => Pet.Color)
                                                    .ToList();
                            default:
                                return FakeDB.Pets.OrderBy(Pet => Pet.Color).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Pets.OrderBy(Pet => Pet.Color).ToList();
                    }

                case "previousowner":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Pets.OrderBy(Pet => Pet.PreviousOwner.FirstName).ToList();
                            case "desc":
                                return FakeDB.Pets.OrderByDescending(Pet => Pet.PreviousOwner.FirstName)
                                                    .ToList();
                            default:
                                return FakeDB.Pets.OrderBy(Pet => Pet.PreviousOwner.FirstName).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Pets.OrderBy(Pet => Pet.PreviousOwner).ToList();
                    }

                case "price":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Pets.OrderBy(Pet => Pet.Price).ToList();
                            case "desc":
                                return FakeDB.Pets.OrderByDescending(Pet => Pet.Price)
                                                    .ToList();
                            default:
                                return FakeDB.Pets.OrderBy(Pet => Pet.Price).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Pets.OrderBy(Pet => Pet.Price).ToList();
                    }

                default:
                    throw new ArgumentException("The parameters were not valid");
            }
        }


        public List<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

        public Pet UpdatePet(Pet pet)
        {
            Pet chosenPet = GetPet(pet.ID);

            chosenPet.Name = pet.Name;
            chosenPet.Type = pet.Type;
            chosenPet.BirthDate = pet.BirthDate;
            chosenPet.Color = pet.Color;
            chosenPet.SoldDate = pet.SoldDate;
            chosenPet.PreviousOwner = pet.PreviousOwner;
            chosenPet.Price = pet.Price;

            return chosenPet;

        }
    }
}
