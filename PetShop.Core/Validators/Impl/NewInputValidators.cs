using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PetShop.Core.Validators.Impl
{
    public class NewInputValidators : INewInputValidators
    {
        private IPetTypeRepository _petTypesRepository;
        private IOwnerRepository _ownerRepository;

        public NewInputValidators(IPetTypeRepository petTypesRepository, IOwnerRepository ownerRepository)
        {
            _petTypesRepository = petTypesRepository;
            _ownerRepository = ownerRepository;
        }

        public Boolean CheckIfLetters(string input, string type)
        {
            if(input == null)
            {
                throw new ArgumentException($"{type} is not allowed to be null");
            }
            else if (Regex.IsMatch(input, @"^[A-Za-z\s]*$"))
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"The {type} was not valid.");
            }

        }


        public Boolean CheckIfType(PetType input)
        {
            if(input == null)
            {
                return true;
            }

            foreach (PetType petType in _petTypesRepository.GetPetTypes())
            {
                if(petType.ID == input.ID && petType.PetTypeName.ToLower() == input.PetTypeName.ToLower())
                {
                    return true;
                }
            }

            throw new ArgumentException("Type was not valid.");
        }


        public Boolean CheckIfNumberIsValid(double input)
        {
            if(input < 0)
            {
                throw new ArgumentException("The price was not a valid number.");
            }
            else
            {
                return true;
            }
        }

        public bool CheckIfEmail(string input)
        {
            if (Regex.IsMatch(input, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                return true;
            }
            else
            {
                throw new FormatException("The E-mail was not valid.");
            }

        }

        public bool CheckIfAddress(string input)
        {
            if (input == null)
            {
                throw new ArgumentException("Address is not allowed to be null");
            }
            if (Regex.IsMatch(input, "^[a-zA-Z0-9, ]*$"))
            {
                return true;
            }
            else
            {
                throw new FormatException("The Address was not valid.");
            }
        }

        public bool CheckIfPhoneNumber(string input)
        {
            if (input == null)
            {
                throw new ArgumentException("Phone Number is not allowed to be null");
            }
            if (Regex.IsMatch(input, @"^\d{8}$"))
            {
                return true;
            }
            else
            {
                throw new FormatException("The PhoneNumber was not valid.");
            }

        }

        public bool CheckIfValidDate(DateTime birthDate, DateTime soldDate)
        {
            if(birthDate !< DateTime.Now && soldDate !< DateTime.Now)
            {
                if(birthDate > soldDate)
                {
                    throw new ArgumentException("Birth Date cannot be after Sold Date");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("Birth Date and or Sold Date cannot be in the future.");
            }
            
        }

        public bool CheckIfOwner(Owner owner)
        {
            if (owner == null)
            {
                return true;
            }

            foreach (Owner prevOwner in _ownerRepository.ReadOwners())
            {
                if (owner.ID == prevOwner.ID && owner.FirstName.ToLower() == prevOwner.FirstName.ToLower() 
                    && owner.LastName == prevOwner.LastName && owner.Address.ToLower() == prevOwner.Address.ToLower()
                    && owner.PhoneNumber == prevOwner.PhoneNumber && owner.Email.ToLower() == prevOwner.Email.ToLower())
                {
                    return true;
                }
            }

            throw new ArgumentException("Owner was not valid.");
        }
    }
}

