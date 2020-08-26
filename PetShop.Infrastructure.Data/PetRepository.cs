using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {
        }
        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.GetPetList();
        }
    }
}
