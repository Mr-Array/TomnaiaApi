using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Entities
{
    public class Review
    {
        [Key]
        public string ReviewId { get; set; }


     
        [Required]
        public string RideRequestId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public int Rating { get; set; } // Assuming a rating out of 5

        [Required]
        public DateTime Date { get; set; }

      

        [ForeignKey(nameof(RideRequestId))]
        public Ride Rides { get; set; }

        //[Required]
        //public string UserId { get; set; }
        [Required]
        public string ReviewerId { get; set; }
        [ForeignKey(nameof(ReviewerId))]
        public virtual Passenger Reviewer { get; set; }
        [Required]
        public string RevieweeId { get; set; }
        [ForeignKey(nameof(RevieweeId))]
        public virtual Driver Reviewee { get; set; }
    }
}
