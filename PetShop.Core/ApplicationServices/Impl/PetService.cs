﻿using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Validators;
using System;
using System.Collections.Generic;

namespace PetShop.Core.ApplicationServices.Impl
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        private INewInputValidators _newInputValidators;
        public PetService(IPetRepository petRepository, INewInputValidators newInputValidators)
        {
            _petRepository = petRepository;

            _newInputValidators = newInputValidators;
        }

        public Pet CreatePet(Pet inputPet)
        {
            if (_newInputValidators.CheckIfLetters(inputPet.Name, "Name")
                    && _newInputValidators.CheckIfType(inputPet.Type)
                    && _newInputValidators.CheckIfValidDate(inputPet.BirthDate, inputPet.SoldDate)
                    && _newInputValidators.CheckIfOwner(inputPet.PreviousOwner)
                    && _newInputValidators.CheckIfLetters(inputPet.Color, "Color")
                    && _newInputValidators.CheckIfNumberIsValid(inputPet.Price))
            {
                return _petRepository.CreatePet(inputPet);
            }
            else
            {
                throw new ArgumentException();
            }
            
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.DeletePet(id);
        }


        public string[] GetMenuItems()
        {
            return _petRepository.GetMenuItems();
        }

        public Pet GetPet(int id)
        {
            return _petRepository.GetPet(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets();
        }

        public List<Pet> GetPetsWithParameters(string prop, string dir)
        {
            return _petRepository.GetPetsWithParameters(prop, dir);
        }

        public Pet UpdatePet(Pet pet)
        {
            if (_newInputValidators.CheckIfLetters(pet.Name, "Name")
                    && _newInputValidators.CheckIfType(pet.Type)
                    && _newInputValidators.CheckIfOwner(pet.PreviousOwner)
                    && _newInputValidators.CheckIfValidDate(pet.BirthDate, pet.SoldDate)
                    && _newInputValidators.CheckIfLetters(pet.Color, "Color")
                    && _newInputValidators.CheckIfNumberIsValid(pet.Price))
            {
                return _petRepository.UpdatePet(pet);
            }
            else
            {
                throw new ArgumentException();
            }
            
        }
    }
}
