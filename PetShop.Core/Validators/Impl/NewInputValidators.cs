using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PetShop.Core.Validators.Impl
{
    public class NewInputValidators : INewInputValidators
    {
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

            if (Enum.IsDefined(typeof(PetType), input))
            {
                return true;
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
    }
}

