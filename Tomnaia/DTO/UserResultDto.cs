namespace Tomnaia.DTO
{
    public class UserResultDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? RateCount { get; set; }
        public double? Rate { get; set; }
        public string? ProfilePicture { get; set; }
        public AccountType AccountType { get; set; }
    }
}
