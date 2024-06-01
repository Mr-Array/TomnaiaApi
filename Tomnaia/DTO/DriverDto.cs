namespace Tomnaia.DTO
{
    public class DriverDto
    {
        public string DriverId { get; set; }
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ProfilePicture { get; set; }
        public string? NationalPhoto { get; set; }
       
        public string? NationalId { get; set; }
       
        public string? LicensePhoto { get; set; }
      
        public string? DriverLicenseNumber { get; set; }
        //public ICollection<VehicleDto> Vehicles { get; set; }
        //public ICollection<RideDto> Rides { get; set; }
    }
}
