using System.ComponentModel;

namespace Tomnaia.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; } = true;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string VehicleType { get; set; }
        public string Photolicense { get; set; }
        public string PhotoVehicle { get; set; }
        public string licensestatus { get; set; }
        public string DriverId { get; set; } = string.Empty;
        public User Driver { get; set; } = null!;
       
    }
}
