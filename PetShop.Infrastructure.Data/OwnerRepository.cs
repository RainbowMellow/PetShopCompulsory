using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        public string[] GetOwnerMenuItems()
        {
            return FakeDB.OwnerMenuOptions;
        }

        public Owner CreateOwner(Owner inputOwner)
        {
            int _id = FakeDB.Owners.Count + 1;

            Owner createdOwner = new Owner
            {

                ID = _id,
                FirstName = inputOwner.FirstName,
                LastName = inputOwner.LastName,
                Address = inputOwner.Address,
                PhoneNumber = inputOwner.PhoneNumber,
                Email = inputOwner.Email

            };

            FakeDB.Owners.Add(createdOwner);

            return createdOwner;
        }

        public Owner DeleteOwner(int id)
        {
            Owner owner = FakeDB.Owners.Find(Owner => Owner.ID == id);
            if (owner == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                FakeDB.Owners.Remove(owner);
                return owner;

            }
        }

        public Owner GetOwner(int id)
        {
            Owner owner = FakeDB.Owners.Find(Owner => Owner.ID == id);
            if (owner == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return owner;
            }
        }

        public List<Owner> ReadOwners()
        {
            return FakeDB.Owners;
        }

        public Owner UpdateOwner(Owner inputOwner)
        {
            Owner chosenOwner = FakeDB.Owners.Find(Owner => Owner.ID == inputOwner.ID);
           
            if (chosenOwner == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                chosenOwner.FirstName = inputOwner.FirstName;
                chosenOwner.LastName = inputOwner.LastName;
                chosenOwner.Address = inputOwner.Address;
                chosenOwner.PhoneNumber = inputOwner.PhoneNumber;
                chosenOwner.Email = inputOwner.Email;

                return chosenOwner;

            }
            
        }
    }
}
