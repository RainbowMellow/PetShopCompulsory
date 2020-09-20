using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Validators;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace PetShop.Core.ApplicationServices.Impl
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;
        private INewInputValidators _newInputValidators;

        public OwnerService(IOwnerRepository ownerRepository, INewInputValidators newInputValidators)
        {
            _ownerRepository = ownerRepository;
            _newInputValidators = newInputValidators;
        }
        

        public string[] GetOwnerMenuItems()
        {
            return _ownerRepository.GetOwnerMenuItems();
        }

        public Owner CreateOwner(Owner inputOwner)
        {
            if(_newInputValidators.CheckIfLetters(inputOwner.FirstName, "First Name") 
                && _newInputValidators.CheckIfLetters(inputOwner.LastName, "Last Name") 
                && _newInputValidators.CheckIfAddress(inputOwner.Address) 
                && _newInputValidators.CheckIfEmail(inputOwner.Email) 
                && _newInputValidators.CheckIfPhoneNumber(inputOwner.PhoneNumber))
            {
                return _ownerRepository.CreateOwner(inputOwner);
            }
            else
            {
                throw new ArgumentException();
            }
            
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }

        public Owner GetOwner(int id)
        {
            return _ownerRepository.GetOwner(id);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwners();
        }

        public Owner UpdateOwner(Owner inputOwner)
        {
            return _ownerRepository.UpdateOwner(inputOwner);
        }


    }
}
