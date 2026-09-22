using System;
using System.Collections.Generic;
using System.Text;

namespace Assignmentopp4
{
    internal class DeliveryCenter
    {
        private Shipment[] _shipments = new Shipment[20];

        private string centerName;

        public Driver Driver { get; set; }

        public string CenterName
        {
            get { return centerName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    centerName = value;
            }
        }

        private Shipment[] Shipments
        {
            get { return _shipments; }
        }

        public DeliveryCenter(string centerName)
        {
            this.centerName = !string.IsNullOrWhiteSpace(centerName) ? centerName : "Unknown Center";
        }

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < Shipments.Length)
                    return Shipments[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < Shipments.Length)
                    Shipments[index] = value;
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                foreach (var s in Shipments)
                {
                    if (s != null && s.TrackingCode == trackingCode)
                        return s;
                }
                return null;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            if (shipment == null)
                return false;

            for (int i = 0; i < Shipments.Length; i++)
            {
                if (Shipments[i] == null)
                {
                    Shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < Shipments.Length; i++)
            {
                if (Shipments[i] != null && Shipments[i].TrackingCode == trackingCode)
                {
                    Shipments[i] = null;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine($"Delivery Center : {CenterName}");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            bool any = false;
            for (int i = 0; i < Shipments.Length; i++)
            {
                if (Shipments[i] != null)
                {
                    any = true;
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine();
                    Shipments[i].PrintShipment();
                    Console.WriteLine();
                }
            }

            if (!any)
                Console.WriteLine("No shipments stored.");

            Console.WriteLine("==========================================");
        }

       
        public void PrintTrackingStatuses()
        {
            for (int i = 0; i < Shipments.Length; i++)
            {
                if (Shipments[i] is ITrackable trackable)
                {
                    Console.WriteLine(trackable.GetTrackingStatus());
                }
            }
        }
    }
}

