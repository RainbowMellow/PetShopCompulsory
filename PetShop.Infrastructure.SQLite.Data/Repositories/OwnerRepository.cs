using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQLite.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public Owner CreateOwner(Owner inputOwner)
        {
            var owner = _ctx.Add(inputOwner);
            _ctx.SaveChanges();

            return owner.Entity;
        }

        public Owner DeleteOwner(int id)
        {
            var owner = _ctx.Remove(GetOwner(id));
            _ctx.SaveChanges();

            return owner.Entity;
        }

        public Owner GetOwner(int id)
        {
            return _ctx.Owners
                .Include(p => p.Pets)
                .FirstOrDefault(o => o.ID == id);
        }

        public string[] GetOwnerMenuItems()
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetOwnersWithParameters(string prop, string dir)
        {
            throw new NotImplementedException();
        }

        public List<Owner> ReadOwners()
        {
            return _ctx.Owners
                .Include(p => p.Pets)
                .ToList();
        }

        public Owner UpdateOwner(Owner inputOwner)
        {
            throw new NotImplementedException();
        }
    }
}
