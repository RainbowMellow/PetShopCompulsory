using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using PetShop.Core.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationServices.Impl
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;
        private INewInputValidators _newInputValidators;

        public PetTypeService(IPetTypeRepository petTypeRepository, INewInputValidators newInputValidators)
        {
            _petTypeRepository = petTypeRepository;
            _newInputValidators = newInputValidators;
        }

        public PetType CreatePetType(PetType inputPetType)
        {
            if(_newInputValidators.CheckIfLetters(inputPetType.PetTypeName, "PetType Name"))
            {
                return _petTypeRepository.CreatePetType(inputPetType);
            }
            else
            {
                throw new ArgumentException();
            }
            
        }

        public PetType DeletePetType(int id)
        {
            return _petTypeRepository.DeletePetType(id);
        }

        public PetType GetPetType(int id)
        {
            return _petTypeRepository.GetPetType(id);
        }

        public List<PetType> GetPetTypes()
        {
            return _petTypeRepository.GetPetTypes();
        }

        public List<PetType> GetPetTypesWithParameters(string prop, string dir)
        {
            return _petTypeRepository.GetPetTypesWithParameters(prop, dir);
        }

        public PetType UpdatePetType(PetType petType)
        {
            if (_newInputValidators.CheckIfLetters(petType.PetTypeName, "PetType Name"))
            {
                return _petTypeRepository.UpdatePetType(petType);
            }
            else
            {
                throw new ArgumentException();
            }
            
        }
    }
}
