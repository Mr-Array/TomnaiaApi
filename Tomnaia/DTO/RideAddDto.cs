namespace Tomnaia.DTO
{
    public class RideAddDto
    {
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Rider { get; set; }
        public double Fare { get; set; }
        public DateTime RequestTime { get; set; }
        public string VehicleId { get; set; }
        public string PassengerId { get; set; }
    }
}
