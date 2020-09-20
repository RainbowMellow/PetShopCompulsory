using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices
{
    public interface IOwnerService
    {
        public string[] GetOwnerMenuItems();
        public Owner CreateOwner(Owner inputOwner);
        public Owner DeleteOwner(int id);
        public Owner GetOwner(int id);
        public List<Owner> GetOwners();
        public Owner UpdateOwner(Owner inputOwner);
        public List<Owner> GetOwnersWithParameters(string prop, string dir);
    }
}
