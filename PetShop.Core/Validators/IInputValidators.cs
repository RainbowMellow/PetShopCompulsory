using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Validators
{
    public interface IInputValidators
    {
        public int CheckMenuInput(int length);
        public Boolean CheckIfLetters(string input, string type);
        public DateTime? CheckIfDate(string input);
        public PetType? CheckIfType(string input);
        public double CheckIfNumbers(string input);
    }
}
