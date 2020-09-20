using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IPetTypeService
    {
        public List<PetType> GetPetTypes();
        public PetType CreatePetType(PetType inputPetType);
        public PetType DeletePetType(int id);
        public PetType GetPetType(int id);
        public PetType UpdatePetType(PetType petType);
        public List<PetType> GetPetTypesWithParameters(string prop, string dir);
    }
}
