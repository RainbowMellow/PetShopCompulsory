using PetShop.Core.DomainServices;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Owner> GetOwnersWithParameters(string prop, string dir)
        {
            switch (prop.Trim().ToLower())
            {
                case "id":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Owners.OrderBy(Owner => Owner.ID).ToList();
                            case "desc":
                                return FakeDB.Owners.OrderByDescending(Owner => Owner.ID)
                                                    .ToList();
                            default:
                                return FakeDB.Owners.OrderBy(Owner => Owner.ID).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Owners.OrderBy(Owner => Owner.ID).ToList();
                    }

                case "firstname":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Owners.OrderBy(Owner => Owner.FirstName).ToList();
                            case "desc":
                                return FakeDB.Owners.OrderByDescending(Owner => Owner.FirstName)
                                                    .ToList();
                            default:
                                return FakeDB.Owners.OrderBy(Owner => Owner.FirstName).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Owners.OrderBy(Owner => Owner.FirstName).ToList();
                    }

                case "lastname":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Owners.OrderBy(Owner => Owner.LastName).ToList();
                            case "desc":
                                return FakeDB.Owners.OrderByDescending(Owner => Owner.LastName)
                                                    .ToList();
                            default:
                                return FakeDB.Owners.OrderBy(Owner => Owner.LastName).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Owners.OrderBy(Owner => Owner.LastName).ToList();
                    }

                case "address":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Owners.OrderBy(Owner => Owner.Address).ToList();
                            case "desc":
                                return FakeDB.Owners.OrderByDescending(Owner => Owner.Address)
                                                    .ToList();
                            default:
                                return FakeDB.Owners.OrderBy(Owner => Owner.Address).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Owners.OrderBy(Owner => Owner.Address).ToList();
                    }

                case "phonenumber":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Owners.OrderBy(Owner => Owner.PhoneNumber).ToList();
                            case "desc":
                                return FakeDB.Owners.OrderByDescending(Owner => Owner.PhoneNumber)
                                                    .ToList();
                            default:
                                return FakeDB.Owners.OrderBy(Owner => Owner.PhoneNumber).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Owners.OrderBy(Owner => Owner.PhoneNumber).ToList();
                    }

                case "email":
                    if (!string.IsNullOrEmpty(dir))
                    {
                        switch (dir.Trim().ToLower())
                        {
                            case "asc":
                                return FakeDB.Owners.OrderBy(Owner => Owner.Email).ToList();
                            case "desc":
                                return FakeDB.Owners.OrderByDescending(Owner => Owner.Email)
                                                    .ToList();
                            default:
                                return FakeDB.Owners.OrderBy(Owner => Owner.Email).ToList();
                        }
                    }
                    else
                    {
                        return FakeDB.Owners.OrderBy(Owner => Owner.Email).ToList();
                    }

                default:
                    throw new ArgumentException("The parameters were not valid");
            }
        }
    }
}
