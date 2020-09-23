using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetShop.Infrastructure.DBInitialization
{
    public class DBInitializer
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetTypeRepository _petTypeRepository;

        public DBInitializer(
                 IPetRepository petRepository,
                 IOwnerRepository ownerRepository,
                 IPetTypeRepository petTypeRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
            _petTypeRepository = petTypeRepository;
        }

        public void InitData()
        {
            PetType firstType = _petTypeRepository.CreatePetType(new PetType()
            {
                ID = 1,
                PetTypeName = "Dog",
            });
            PetType secondType = _petTypeRepository.CreatePetType(new PetType()
            {
                ID = 2,
                PetTypeName = "Cat",
            });

            PetType thirdType = _petTypeRepository.CreatePetType(new PetType()
            {
                ID = 3,
                PetTypeName = "Mouse",
            });



            Owner firstOwner = _ownerRepository.CreateOwner(new Owner()   
            {
                ID = 1,
                FirstName = "Lars",
                LastName = "Larsen",
                Address = "Januarvej 24, 6700 Esbjerg",
                PhoneNumber = "21234253",
                Email = "lars.larsen@hotmail.com"
            });

            Owner secondOwner = _ownerRepository.CreateOwner(new Owner()
            {
                ID = 2,
                FirstName = "Mark",
                LastName = "Hansen",
                Address = "Septembervej 24, 6700 Esbjerg",
                PhoneNumber = "26728259",
                Email = "mark.hansen@hotmail.com"
            });


            Pet firstPet = _petRepository.CreatePet(new Pet()
            {
                ID = 1,
                Name = "Paul",
                Type = firstType,
                BirthDate = Convert.ToDateTime("31/1/1999", new CultureInfo("da-DK")),
                SoldDate = Convert.ToDateTime("31/1/2002", new CultureInfo("da-DK")),
                Color = "Red",
                PreviousOwner = firstOwner,
                Price = 2000
            });

            firstOwner.Pets.Add(firstPet);

            Pet secondPet = _petRepository.CreatePet(new Pet()
            {
                ID = 2,
                Name = "Rebecca",
                Type = secondType,
                BirthDate = Convert.ToDateTime("21/3/2000", new CultureInfo("da-DK")),
                SoldDate = Convert.ToDateTime("31/12/2000", new CultureInfo("da-DK")),
                Color = "Orange",
                PreviousOwner = secondOwner,
                Price = 3500
            });

            secondOwner.Pets.Add(secondPet);
        }
    }
}
