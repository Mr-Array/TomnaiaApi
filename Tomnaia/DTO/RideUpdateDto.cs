namespace Tomnaia.DTO
{
    public class RideUpdateDto
    {
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Rider { get; set; }
        public double Fare { get; set; }
        public DateTime RequestTime { get; set; }
       
    }
}
