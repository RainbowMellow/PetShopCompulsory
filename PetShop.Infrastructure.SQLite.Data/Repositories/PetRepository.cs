using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQLite.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _ctx;

        public PetRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet inputPet)
        {
            var pet = _ctx.Add(inputPet);
            pet.Entity.PreviousOwner.Pets.Add(pet.Entity);
            _ctx.SaveChanges();


            return pet.Entity;
        }

        public Pet DeletePet(int id)
        {
            var pet = _ctx.Remove(GetPet(id));
            _ctx.SaveChanges();

            return pet.Entity;
        }

        public string[] GetMenuItems()
        {
            throw new NotImplementedException();
        }

        public Pet GetPet(int id)
        {
            return _ctx.Pets
                .Include(p => p.PreviousOwner)
                .Include(p => p.Type)
                .FirstOrDefault(p => p.ID == id);
        }

        public List<Pet> GetPetsWithParameters(string prop, string dir)
        {
            throw new NotImplementedException();
        }

        public List<Pet> ReadPets()
        {
            return _ctx.Pets
                .Include(p => p.PreviousOwner)
                .Include(p => p.Type)
                .ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
