using Newtonsoft.Json;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetTypeRepository : IPetTypeRepository
    {
        public PetType CreatePetType(PetType inputPetType)
        {
            int _id = FakeDB.PetTypes.Count + 1;

            PetType createdType = new PetType
            {
                ID = _id,
                PetTypeName = inputPetType.PetTypeName,
            };

            FakeDB.PetTypes.Add(createdType);
            return createdType;
        }

        public PetType DeletePetType(int id)
        {
            PetType petType = GetPetType(id);
            FakeDB.PetTypes.Remove(petType);
            return petType;
        }

        public PetType GetPetType(int id)
        {
            PetType petType = FakeDB.PetTypes.Find(PetType => PetType.ID == id);
            if (petType == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return petType;
            }
            
        }

        public List<PetType> GetPetTypes()
        {
            return FakeDB.PetTypes;
        }

        public List<PetType> GetPetTypesWithParameters(string prop, string dir)
        {
            switch (prop.Trim().ToLower())
            {
                case "id":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.PetTypes.OrderBy(PetType => PetType.ID).ToList();
                            case "desc":
                                return FakeDB.PetTypes.OrderByDescending(PetType => PetType.ID)
                                                    .ToList();
                            default:
                                return FakeDB.PetTypes.OrderBy(PetTypes => PetTypes.ID).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.PetTypes.OrderBy(PetType => PetType.ID).ToList();
                    }

                case "name":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.PetTypes.OrderBy(PetType => PetType.PetTypeName).ToList();
                            case "desc":
                                return FakeDB.PetTypes.OrderByDescending(PetType => PetType.PetTypeName)
                                                .ToList();
                            default:
                                return FakeDB.PetTypes.OrderBy(PetType => PetType.PetTypeName).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.PetTypes.OrderBy(PetType => PetType.PetTypeName).ToList();
                    }

                case "pettypename":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.PetTypes.OrderBy(PetType => PetType.PetTypeName).ToList();
                            case "desc":
                                return FakeDB.PetTypes.OrderByDescending(PetType => PetType.PetTypeName)
                                                .ToList();
                            default:
                                return FakeDB.PetTypes.OrderBy(PetType => PetType.PetTypeName).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.PetTypes.OrderBy(PetType => PetType.PetTypeName).ToList();
                    }

                default:
                    throw new ArgumentException("The parameters were not valid");
            }
        }

        public PetType UpdatePetType(PetType petType)
        {
            PetType updatedPetType = GetPetType(petType.ID);

            updatedPetType.PetTypeName = petType.PetTypeName;

            return updatedPetType;
        }
    }
}
