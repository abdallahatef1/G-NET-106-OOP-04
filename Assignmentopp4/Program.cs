namespace Assignmentopp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeliveryCenter center = new DeliveryCenter("suez");
            DeliveryAddress address = new DeliveryAddress("suez", "Nile St", 10);

            StandardShipment standard = new StandardShipment("SH001", "Laptop", 3, 80, address);
            ExpressShipment express = new ExpressShipment("SH002", "Mobile Phone", 2, 60, address, 30);
            InternationalShipment international = new InternationalShipment("SH003", "Television", 8, 120, address, "Germany", 100);

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            center.PrintAllShipments();

            Console.WriteLine();
            Console.WriteLine("Tracking Status");
            Console.WriteLine();
            center.PrintTrackingStatuses();
            Console.WriteLine();
            Console.WriteLine("==========================================");

            Console.WriteLine();
            Console.WriteLine("Insurance");
            Console.WriteLine();
            Console.WriteLine($"Standard Shipment Insurance : {standard.CalculateInsurance():0.00} EGP");
            Console.WriteLine($"Express Shipment Insurance : {express.CalculateInsurance():0.00} EGP");
            Console.WriteLine($"International Shipment Insurance : {international.CalculateInsurance():0.00} EGP");
            Console.WriteLine();
            Console.WriteLine("==========================================");

            Console.WriteLine();
            Console.WriteLine("ITrackable[] Demo...");
            Console.WriteLine();
            ITrackable[] trackables = { standard, express, international };
            foreach (ITrackable t in trackables)
            {
                DeliveryReport.PrintShipment(t);
            }

            Console.WriteLine();
            Console.WriteLine("IInsurable[] Demo...");
            Console.WriteLine();
            IInsurable[] insurables = { standard, express, international };
            foreach (IInsurable ins in insurables)
            {
                DeliveryReport.PrintInsurance(ins);
            }

            Console.WriteLine();
            Console.WriteLine("Interface Polymorphism Demonstrated Successfully.");
        }
    }
    
}
