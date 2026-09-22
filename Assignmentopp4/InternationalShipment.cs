using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmentopp4
{
    internal class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        private string destinationCountry = "Unknown";
        private decimal customsFee;

        public string DestinationCountry
        {
            get { return destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    destinationCountry = value;
            }
        }

        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value >= 0)
                    customsFee = value;
            }
        }

        
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + CustomsFee; }
        }

        public InternationalShipment(string trackingCode, string description, decimal weight,
                                     decimal deliveryFee, DeliveryAddress destination,
                                     string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine();
            PrintCommonDetails();
            PrintLine("Destination Country", DestinationCountry);
            PrintLine("Customs Fee", $"{CustomsFee} EGP");
            PrintLine("Estimated Cost", $"{EstimatedCost} EGP");
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been Delivered.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("--- Customs Report ---");
            PrintLine("Tracking Code", TrackingCode);
            PrintLine("Destination Country", DestinationCountry);
            PrintLine("Customs Fee", $"{CustomsFee} EGP");
        }
    }
}
