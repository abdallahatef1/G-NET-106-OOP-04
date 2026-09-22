using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmentopp4
{
    internal class PriorityInternationalShipment :InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string description, decimal weight,
                                           decimal deliveryFee, DeliveryAddress destination,
                                           string destinationCountry, decimal customsFee)
          : base(trackingCode, description, weight, deliveryFee, destination, destinationCountry, customsFee)
        {
        }

        public override void PrintShipment()
        {
            Console.WriteLine("*** PRIORITY ***");
            base.PrintShipment();
        }

       
        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine("--- Priority Customs Report (fast-track clearance) ---");
            PrintLine("Tracking Code", TrackingCode);
            PrintLine("Destination Country", DestinationCountry);
            PrintLine("Customs Fee", $"{CustomsFee} EGP");
        }
    }
}
