using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;

namespace PetShop.Core.Validators.Impl
{
    public class InputValidators : IInputValidators
    {
        public int CheckMenuInput(int length)
        {
            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 0
                || selection > length)
            {
                Console.WriteLine($"\nYou need to select a number between 0 and {length - 1}.");
            }

            return selection;
        }

        public Boolean CheckIfLetters(string input, string type)
        {
            if (Regex.IsMatch(input, @"^[A-Za-z\s]*$"))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"\nPlease input a {type} without special characters or numbers.");
                return false;
            }

        }

        public DateTime? CheckIfDate(string input)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(input);
                return dt;
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nPlease input a valid date!");
                return null;
            }
        }

        public PetType? CheckIfType(string input)
        {
            input = char.ToUpper(input[0]) + input.Substring(1);

            bool v = Enum.IsDefined(typeof(PetType), input);
            if(!v)
            {
                Console.WriteLine("\nPlease input a valid option!");
                return null;
            }
            return (PetType?)Enum.Parse(typeof(PetType), input);
        }

        public double CheckIfNumbers(string input)
        {
            try
            {
                double price;
                double.TryParse(input, out price);
                return price;
            }
            catch
            {
                Console.WriteLine("\nPlease input a number!");
                return -1;
            }
        }
    }
}
