namespace Tomnaia.DTO
{
    public class RideDto
    {
        public string RideId { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Rider { get; set; }
        public double Fare { get; set; }
        public DateTime RequestTime { get; set; }
        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public int VehicleId { get; set; }
        public string VehicleModel { get; set; }
    }
}
