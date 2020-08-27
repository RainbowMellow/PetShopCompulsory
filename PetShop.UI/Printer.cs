using Microsoft.VisualBasic.FileIO;
using PetShop.Core.ApplicationServices;
using PetShop.Core.Entities;
using PetShop.Core.Validators;
using PetShop.Core.Validators.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI
{
    public class Printer
    {
        private IPetService _petService;
        private IInputValidators _inputValidators;

        public Printer(IPetService petService)
        {
            _petService = petService;
            _inputValidators = new InputValidators();

        }

        #region Show Menu
        /// <summary>
        /// This method gets the menu options from a list in the database,
        /// and shows them in the console.
        /// </summary>
        public void ShowMenu()
        {
            string[] options = _petService.GetMenuItems();
            Console.Clear();
            Console.WriteLine("Hello! Welcome to the pet shop menu! ");
            Console.WriteLine("Please choose an option: \n");

            //Inputs the numbers in front of the options.
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i}: {options.GetValue(i)}");
            }

            Console.WriteLine("\nInput:");

            //Uses the validator to check if the input is an int, and between 0 and the length of the option list.
            int selection = _inputValidators.CheckMenuInput(options.Length);

            switch (selection)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    GetPets();
                    break;
                case 2:
                    SearchByType();
                    break;
                case 3:
                    CreatePet();
                    break;
                case 4:
                    DeletePet();
                    break;
                case 5:
                    UpdatePet();
                    break;
                case 6:
                    GetCheapestPets();
                    break;

            }


        }
        #endregion

        #region 5 Cheapest Pets
        private void GetCheapestPets()
        {
            List<Pet> cheapestPets = _petService.GetFiveCheapestPets();
            foreach (var pet in cheapestPets)
            {
                Console.WriteLine("\nList Of The 5 Cheapest Pets:");
                Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                    $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                    $"\nPrice: {pet.Price}");
                Console.WriteLine("\n-----------------------------------------------");
            }
        }
        #endregion

        private void UpdatePet()
        {
            throw new NotImplementedException();
        }

        private void DeletePet()
        {
            throw new NotImplementedException();
        }

        #region Create Pet
        private void CreatePet()
        {
            Console.Clear();
            Console.WriteLine("You chose to create a pet! " +
                "\nPlease input the name of the pet: ");

            string name = Console.ReadLine().Trim();

            if (name == null || !_inputValidators.CheckIfLetters(name, "name"))
            {
                TryAgain(CreatePet);
            }



            Console.WriteLine("\nInput pet type: " +
                "\nList:" +
                "\n------------------------");

            foreach (var animal in Enum.GetValues(typeof(PetType)))
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("------------------------");
            string type = Console.ReadLine().Trim().ToLower();

            if (!_inputValidators.CheckIfLetters(type, "type"))
            {
                TryAgain(CreatePet);
            }

            if(_inputValidators.CheckIfType(type) == null)
            {
                TryAgain(CreatePet);
            }
                
            PetType petType = (PetType)_inputValidators.CheckIfType(type);



            Console.WriteLine("\nInput Color:");
            string color = Console.ReadLine();
            if (!_inputValidators.CheckIfLetters(color, "color"))
            {
                TryAgain(CreatePet);
            }



            Console.WriteLine("\nInput Birth Date: (dd/MM/yyyy)");
            string birthDate = Console.ReadLine().Trim();
            if(birthDate == null || _inputValidators.CheckIfDate(birthDate).Equals(null))
            {
                TryAgain(CreatePet);
            }
            DateTime bd = (DateTime)_inputValidators.CheckIfDate(birthDate);



            Console.WriteLine("\nInput Sold Date: (dd/MM/yyyy)");
            string soldDate = Console.ReadLine().Trim();
            if (soldDate == null || _inputValidators.CheckIfDate(soldDate).Equals(null))
            {
                TryAgain(CreatePet);
            }
            DateTime sd = (DateTime)_inputValidators.CheckIfDate(soldDate);



            Console.WriteLine("\nInput Previous Owner:");
            string previousOwner = Console.ReadLine();
            if (!_inputValidators.CheckIfLetters(previousOwner, "previous owner"))
            {
                TryAgain(CreatePet);
            }



            Console.WriteLine("\nInput Price:");
            string price = Console.ReadLine().Trim();
            if (_inputValidators.CheckIfNumbers(price) == -1)
            {
                TryAgain(CreatePet);
            }
            double petPrice = _inputValidators.CheckIfNumbers(price);


            try
            {
                Pet inputPet = new Pet();
                inputPet.Name = name;
                inputPet.Type = petType;
                inputPet.BirthDate = bd;
                inputPet.SoldDate = sd;
                inputPet.Color = color;
                inputPet.PreviousOwner = previousOwner;
                inputPet.Price = petPrice;

                Pet createdPet = _petService.CreatePet(inputPet);

                Console.WriteLine("\n----------------------------------------" +
                "\nPet Created!");

                Console.WriteLine($"\nID: {createdPet.ID}" +
                    $"\nName: {createdPet.Name}" +
                    $"\nType: {createdPet.Type}" +
                    $"\nColor: {createdPet.Color}" +
                    $"\nBirth Date: {createdPet.BirthDate}" +
                    $"\nSold Date: {createdPet.SoldDate}" +
                    $"\nPrevious Owner: {createdPet.PreviousOwner}" +
                    $"\nPrice: {createdPet.Price}");

                BackToMenu();
            }

            catch (Exception ex)
            {
                Console.WriteLine("\n----------------------------------------" +
                        "\nPet Creation Failed!");
                TryAgain(CreatePet);

            }

        }
        #endregion

        private void SearchByType()
        {
            throw new NotImplementedException();
        }

        private void GetPets()
        {
            List<Pet> pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                    $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                    $"\nPrice: {pet.Price}");
                Console.WriteLine("\n-----------------------------------------------");
            }
        }


        private void BackToMenu()
        {
            Console.WriteLine("\nWould you like to go back to the menu or exit? \nMenu/Exit");

            switch (Console.ReadLine().ToLower())
            {
                case "menu":
                    ShowMenu();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private void TryAgain(System.Action action)
        {
            Console.WriteLine("\nWould you like to try again?" +
                    "\nYes/No");

            switch (Console.ReadLine().ToLower())
            {
                case "yes":
                    Console.Clear();
                    action();
                    break;
                case "no":
                    ShowMenu();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
