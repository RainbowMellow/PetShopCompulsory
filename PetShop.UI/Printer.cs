using Microsoft.VisualBasic.FileIO;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Impl;
using PetShop.Core.Entities;
using PetShop.Core.Validators;
using PetShop.Core.Validators.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.UI
{
    public class Printer
    {
        private IPetService _petService;
        private IInputValidators _inputValidators;
        private IOwnerService _ownerService;

        public Printer(IPetService petService, IInputValidators inputValidators, IOwnerService ownerService)
        {
            _petService = petService;
            _inputValidators = inputValidators;
            _ownerService = ownerService;

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
            Console.Clear();

            Console.WriteLine("You chose to see a list of the 5 cheapest pets!" +
            "\nList:" +
            "\n------------------------");

            List<Pet> cheapestPets = _petService.GetFiveCheapestPets();
            foreach (var pet in cheapestPets)
            {
                Console.WriteLine($"ID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                    $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                    $"\nPrice: {pet.Price}");
                Console.WriteLine("\n-----------------------------------------------");
            }

            BackToMenu();
        }
        #endregion

        #region Update Pet
        private void UpdatePet()
        {
            Console.Clear();

            Console.WriteLine("You chose to update a pet!" +
                "\nPlease write the id of the pet you want to update:" +
                "\nTo see the list of pets, input L");

            string id = Console.ReadLine().Trim();
            if (id != null && id.Length == 1 && id.ToLower().Equals("l"))
            {
                Console.WriteLine("\nList of pets:\n" +
                "------------------------");

                List<Pet> pets = _petService.GetPets();
                foreach (var pet in pets)
                {
                    Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                        $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                        $"\nPrice: {pet.Price}");
                    Console.WriteLine("\n-----------------------------------------------");
                }

                Console.WriteLine("\nWould you like to go back?" +
                        "\nYes/No"); ;

                switch (Console.ReadLine().ToLower())
                {
                    case "yes":
                        Console.Clear();
                        UpdatePet();
                        break;
                    case "no":
                        ShowMenu();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }


            else if (id == null || _inputValidators.CheckIfNumbers(id) == -1)
            {

                TryAgain(UpdatePet);

            }



            int validatedId = (int)_inputValidators.CheckIfNumbers(id);
            Pet animal = _petService.GetPet(validatedId);

            Console.WriteLine($"\nThe name of the pet was {animal.Name} \nWhat would you like to change it to?");
            string name = Console.ReadLine().Trim();

            if (name == null || !_inputValidators.CheckIfLetters(name, "name"))
            {
                TryAgain(UpdatePet);
            }

            Console.WriteLine($"\nThe type of the pet was {animal.Type} \nWhat would you like to change it to?");
            string type = Console.ReadLine().Trim().ToLower();

            if (type == null || !_inputValidators.CheckIfLetters(type, "type"))
            {
                TryAgain(UpdatePet);
            }
            PetType petType = (PetType)_inputValidators.CheckIfType(type);



            Console.WriteLine($"\nThe birth date of the pet was {animal.BirthDate.ToShortDateString()} \nWhat would you like to change it to?");
            string birthDate = Console.ReadLine().Trim();

            if (birthDate == null || _inputValidators.CheckIfDate(birthDate).Equals(null))
            {
                TryAgain(UpdatePet);
            }
            DateTime bd = (DateTime)_inputValidators.CheckIfDate(birthDate);



            Console.WriteLine($"\nThe sold date of the pet was {animal.SoldDate.ToShortDateString()} \nWhat would you like to change it to?");
            string soldDate = Console.ReadLine().Trim();

            if (soldDate == null || _inputValidators.CheckIfDate(soldDate).Equals(null))
            {
                TryAgain(UpdatePet);
            }
            DateTime sd = (DateTime)_inputValidators.CheckIfDate(soldDate);



            Console.WriteLine($"\nThe color of the pet was {animal.Color} \nWhat would you like to change it to?");
            string color = Console.ReadLine().Trim();
            if (color == null || !_inputValidators.CheckIfLetters(color, "color"))
            {
                TryAgain(UpdatePet);
            }


            Console.WriteLine($"\nThe previous owner of the pet was {animal.PreviousOwner} \nWhat would you like to change it to?");
            string previousOwner = Console.ReadLine().Trim();
            if (previousOwner == null || !_inputValidators.CheckIfLetters(previousOwner, "previous owner"))
            {
                TryAgain(UpdatePet);
            }


            Console.WriteLine($"\nThe price of the pet was {animal.Price} \nWhat would you like to change it to?");
            string price = Console.ReadLine().Trim();
            if (_inputValidators.CheckIfNumbers(price) == -1)
            {
                TryAgain(CreatePet);
            }
            double petPrice = _inputValidators.CheckIfNumbers(price);


            try
            {
                animal.Name = name;
                animal.Type = petType;
                animal.BirthDate = bd;
                animal.SoldDate = sd;
                animal.Color = color;
                animal.PreviousOwner = previousOwner;
                animal.Price = petPrice;

                _petService.UpdatePet(animal);

                Console.WriteLine("\n----------------------------------------" +
                "\nThe pet was updated!");

                Console.WriteLine($"\nID: {animal.ID}" +
                    $"\nName: {animal.Name}" +
                    $"\nType: {animal.Type}" +
                    $"\nColor: {animal.Color}" +
                    $"\nBirth Date: {animal.BirthDate.ToShortDateString()}" +
                    $"\nSold Date: {animal.SoldDate.ToShortDateString()}" +
                    $"\nPrevious Owner: {animal.PreviousOwner}" +
                    $"\nPrice: {animal.Price}");
                
                BackToMenu();
            }
            catch
            {
                Console.WriteLine("The pet could not be updated!");
                
                BackToMenu();
            }
        }
        #endregion

        #region Delete Pet
        private void DeletePet()
        {
            Console.Clear();

            Console.WriteLine("You chose to delete a Pet! " +
                "\nInput the id of the pet you want to delete: " +
                "\nTo see the list of pets, input L");

            string id = Console.ReadLine().Trim();
            
            if(id != null && id.Length == 1 && id.ToLower().Equals("l"))
            {
                Console.WriteLine("\nList of pets:\n" + 
                "------------------------");

                List<Pet> pets = _petService.GetPets();
                foreach (var pet in pets)
                {
                    Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                        $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                        $"\nPrice: {pet.Price}");
                    Console.WriteLine("\n-----------------------------------------------");
                }

                Console.WriteLine("\nWould you like to go back?" +
                        "\nYes/No"); ;

                switch (Console.ReadLine().ToLower())
                {
                    case "yes":
                        Console.Clear();
                        DeletePet();
                        break;
                    case "no":
                        ShowMenu();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
            
            
            else if (id == null || _inputValidators.CheckIfNumbers(id) == -1)
            {
                
                TryAgain(DeletePet);
                
            }

            int validatedId = (int)_inputValidators.CheckIfNumbers(id);

            Pet chosenPet = _petService.GetPet(validatedId);
            Console.WriteLine($"\nAre you sure you want to delete {chosenPet.Name}?" +
                "\nYes/No");

            switch (Console.ReadLine().Trim().ToLower())
            {
                case "yes":
                    try
                    {
                        _petService.DeletePet(validatedId);
                        Console.WriteLine("\nThe pet was deleted!");
                    }
                    catch 
                    {
                        Console.WriteLine("\nThe pet could not be deleted!");
                    }
                    BackToMenu();
                    break;
                case "no":
                    Console.WriteLine("\nThe pet was not deleted!");
                    BackToMenu();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

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
                    $"\nBirth Date: {createdPet.BirthDate.ToShortDateString()}" +
                    $"\nSold Date: {createdPet.SoldDate.ToShortDateString()}" +
                    $"\nPrevious Owner: {createdPet.PreviousOwner}" +
                    $"\nPrice: {createdPet.Price}");

                BackToMenu();
            }

            catch 
            {
                Console.WriteLine("\n----------------------------------------" +
                        "\nPet Creation Failed!");
                TryAgain(CreatePet);

            }

        }
        #endregion

        #region Search By Type
        private void SearchByType()
        {
            Console.Clear();

            Console.WriteLine("You chose to search for pets by type! ");
            Console.WriteLine("Please input the type of pet you would like to see:" +
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

            if (_inputValidators.CheckIfType(type) == null)
            {
                TryAgain(CreatePet);
            }

            PetType petType = (PetType)_inputValidators.CheckIfType(type);

            List<Pet> petTypeList = _petService.GetPetByType(petType);

            if (petTypeList.Count == 0)
            {
                Console.WriteLine("\nSorry! There were no pets of that type.");
                TryAgain(SearchByType);

            }

            Console.WriteLine($"\nList of pets with the type {petType}:" );
            foreach (var pet in petTypeList)
            {
                Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                    $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                    $"\nPrice: {pet.Price}");
                Console.WriteLine("\n-----------------------------------------------");
            }

            BackToMenu();
        }
        #endregion

        #region Get List Of Pets
        private void GetPets()
        {
            Console.Clear();

            Console.WriteLine("You chose to see a list of all pets!" +
            "\nList:" +
            "\n------------------------");

            List<Pet> pets = _petService.GetPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                    $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                    $"\nPrice: {pet.Price}");
                Console.WriteLine("\n-----------------------------------------------");
            }

            Console.WriteLine("\nWould you like to sort the list by price?" +
                "\nYes/No");

            switch (Console.ReadLine().ToLower())
            {
                case "yes":

                    Console.WriteLine("\nSort price from: " +
                        "\n1: Lowest to Highest " +
                        "\n2: Highest to Lowest?");

                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.Clear();

                            List<Pet> lowToHighPets = _petService.GetPetsLToH();
                            Console.WriteLine("You chose to see the list sorted by price from low to high!" +
                            "\nList:" +
                            "\n------------------------");

                            foreach (var pet in lowToHighPets)
                            {
                                Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                                    $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                                    $"\nPrice: {pet.Price}");
                                Console.WriteLine("\n-----------------------------------------------");
                            }

                            BackToMenu();

                            break;

                        case 2:
                            Console.Clear();

                            List<Pet> highToLowPets = _petService.GetPetsHToL();
                            Console.WriteLine("You chose to see the list sorted by price from high to low!" +
                            "\nList:" +
                            "\n------------------------");

                            foreach (var pet in highToLowPets)
                            {
                                Console.WriteLine($"\nID: {pet.ID}, Name: {pet.Name}, Type: {pet.Type}, Color: {pet.Color} " +
                                    $"\nBirth date: {pet.BirthDate.ToShortDateString()}, Sold date: {pet.SoldDate.ToShortDateString()}, Previous Owner: {pet.PreviousOwner}" +
                                    $"\nPrice: {pet.Price}");
                                Console.WriteLine("\n-----------------------------------------------");
                            }

                            BackToMenu();

                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }

                    break;
                case "no":
                    BackToMenu();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region Owner menu
        public void ShowOwnerMenu()
        {
            string[] ownerOptions = _ownerService.GetOwnerMenuItems();
            Console.Clear();
            Console.WriteLine("Hello! Welcome to the owner menu! ");
            Console.WriteLine("Please choose an option: \n");

            //Inputs the numbers in front of the options.
            for (int i = 0; i < ownerOptions.Length; i++)
            {
                Console.WriteLine($"{i}: {ownerOptions.GetValue(i)}");
            }

            Console.WriteLine("\nInput:");

            //Uses the validator to check if the input is an int, and between 0 and the length of the option list.
            int selection = _inputValidators.CheckMenuInput(ownerOptions.Length);

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
