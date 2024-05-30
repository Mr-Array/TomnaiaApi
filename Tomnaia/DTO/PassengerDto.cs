namespace Tomnaia.DTO
{
    public class PassengerDto
    {
        public string PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? AccountId { get; set; }
        public bool IsDeleted { get; set; }
       

        public ICollection<RideDto> Rides { get; set; }
    }
}
