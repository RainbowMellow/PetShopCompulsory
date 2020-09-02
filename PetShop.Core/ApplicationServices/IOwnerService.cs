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
        public void DeleteOwner(int id);
        public Owner GetOwner(int id);
        public List<Owner> GetOwners();
        public void UpdateOwner(Owner inputOwner);

    }
}
