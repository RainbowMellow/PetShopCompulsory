using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public enum PetType {Dog, Cat, Goat, Mouse }
    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public Owner PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
