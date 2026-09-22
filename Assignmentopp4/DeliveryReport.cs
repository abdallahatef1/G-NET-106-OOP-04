using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmentopp4
{
    internal static class DeliveryReport 
    {
        public static void PrintShipment(ITrackable shipment)
        {
            if (shipment == null)
                return;

            Console.WriteLine(shipment.GetTrackingStatus());
        }

        public static void PrintInsurance(IInsurable shipment)
        {
            if (shipment == null)
                return;

            Console.WriteLine($"Insurance : {shipment.CalculateInsurance():0.00} EGP");
        }
    }
}
