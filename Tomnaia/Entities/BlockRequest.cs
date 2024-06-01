using System.ComponentModel.DataAnnotations;

namespace Tomnaia.Entities
{
    public class BlockRequest
    {
        public string Id { get; set; }

        [Required]
        public string RequesterId { get; set; }

        [Required]
        public string TargetUserId { get; set; }

        public string Reason { get; set; }
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ReviewedAt { get; set; }

        public Adminstrator Requester { get; set; }
    }
}
