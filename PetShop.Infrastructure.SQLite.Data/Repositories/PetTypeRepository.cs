using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQLite.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly PetShopContext _ctx;
        public PetTypeRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public PetType CreatePetType(PetType inputPetType)
        {
            var petType = _ctx.Add(inputPetType);
            _ctx.SaveChanges();

            return petType.Entity;
        }

        public PetType DeletePetType(int id)
        {
            var petType = _ctx.Remove(GetPetType(id));
            _ctx.SaveChanges();

            return petType.Entity;
        }

        public PetType GetPetType(int id)
        {
            return _ctx.PetTypes.FirstOrDefault(p => p.ID == id);
        }

        public List<PetType> GetPetTypes()
        {
            return _ctx.PetTypes.ToList();
        }

        public List<PetType> GetPetTypesWithParameters(string prop, string dir)
        {
            throw new NotImplementedException();
        }

        public PetType UpdatePetType(PetType petType)
        {
            throw new NotImplementedException();
        }
    }
}
