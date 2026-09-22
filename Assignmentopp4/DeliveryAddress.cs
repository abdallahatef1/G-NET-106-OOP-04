using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmentopp4
{
    internal class DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuildingNumber;

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }
        public string GetFullAddress()
        {
            return $"{BuildingNumber} ,{Street}, {City}";
        }
    }
}
