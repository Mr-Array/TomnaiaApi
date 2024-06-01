namespace Tomnaia.DTO
{
    public class PassengerDto
    {
        public string PassengerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePicture { get; set; }
      
       

        //public ICollection<RideDto> Rides { get; set; }
    }
}
