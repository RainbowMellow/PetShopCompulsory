using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Validators
{
    public interface INewInputValidators
    {
        public Boolean CheckIfLetters(string input, string type);

        public Boolean CheckIfType(PetType input);

        //public Boolean CheckIfNumbers(double input);

        public Boolean CheckIfNumberIsValid(double input);
    }
}


