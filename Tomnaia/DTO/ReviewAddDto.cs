namespace Tomnaia.DTO
{
    public class ReviewAddDto
    {
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string RideRequestId { get; set; }
        public string ReviewerId { get; set; }
        public string RevieweeId { get; set; }
    }
}
