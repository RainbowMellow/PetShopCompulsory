﻿using PetShop.Core.Entities;
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
        public Boolean CheckIfEmail(string input);
        public Boolean CheckIfAddress(string input);
        public Boolean CheckIfPhoneNumber(string input);
        public Boolean CheckIfValidDate(DateTime birthDate, DateTime soldDate);
        public Boolean CheckIfOwner(Owner owner);
    }
}


