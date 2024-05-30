namespace Tomnaia.DTO
{
    public class DriverDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }

        public ICollection<VehicleDto> Vehicles { get; set; }
        public ICollection<RideDto> Rides { get; set; }
    }
}
