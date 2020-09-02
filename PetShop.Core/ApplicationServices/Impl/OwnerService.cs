using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices.Impl
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public string[] GetOwnerMenuItems()
        {
            return _ownerRepository.GetOwnerMenuItems();
        }

        public Owner CreateOwner(Owner inputOwner)
        {
            return _ownerRepository.CreateOwner(inputOwner);
        }

        public void DeleteOwner(int id)
        {
            _ownerRepository.DeleteOwner(id);
        }

        public Owner GetOwner(int id)
        {
            return _ownerRepository.GetOwner(id);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwners();
        }

        public void UpdateOwner(Owner inputOwner)
        {
            _ownerRepository.UpdateOwner(inputOwner);
        }


    }
}
