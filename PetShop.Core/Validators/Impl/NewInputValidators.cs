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

        public NewInputValidators(IPetTypeRepository petTypesRepository)
        {
            _petTypesRepository = petTypesRepository;
        }

        public Boolean CheckIfLetters(string input, string type)
        {
            if (Regex.IsMatch(input, @"^[A-Za-z\s]*$"))
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
            if (Regex.IsMatch(input, @"^\d{8}$"))
            {
                return true;
            }
            else
            {
                throw new FormatException("The PhoneNumber was not valid.");
            }

        }
    }
}

