using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IOwnerRepository
    {
        public string[] GetOwnerMenuItems();
        public Owner CreateOwner(Owner inputOwner);
        public void DeleteOwner(int id);
        public Owner GetOwner(int id);
        public List<Owner> ReadOwners();
        public void UpdateOwner(Owner inputOwner);

    }
}
