namespace Tomnaia.DTO
{
    public class ReviewDto
    {
        public string ReviewId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string RideId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
