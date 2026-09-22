using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmentopp4
{
    internal class StandardShipment : Shipment, ITrackable, IInsurable
    {
        public StandardShipment(string trackingCode, string description, decimal weight,
                               decimal deliveryFee, DeliveryAddress destination)
           : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }


        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }


        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine();
            PrintCommonDetails();
            PrintLine("Estimated Cost", $"{EstimatedCost} EGP");
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Ready.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }
    }
}
    

