using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SQLite.Data
{
    public class PetShopContext: DbContext
    {
        //Configuration til databasen
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt) { }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
    }
}
