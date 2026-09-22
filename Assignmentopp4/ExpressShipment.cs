using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmentopp4
{
    internal class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        private decimal extraFee;

        public decimal ExtraFee
        {
            get { return extraFee; }
            set
            {
                if (value >= 0)
                    extraFee = value;
            }
        }

        
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + ExtraFee; }
        }

        public ExpressShipment(string trackingCode, string description, decimal weight,
                               decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine();
            PrintCommonDetails();
            PrintLine("Extra Fee", $"{ExtraFee} EGP");
            PrintLine("Estimated Cost", $"{EstimatedCost} EGP");
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Out for Delivery.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }
    }
}
