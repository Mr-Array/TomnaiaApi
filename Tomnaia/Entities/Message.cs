using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomnaia.Entities
{
    public class Message
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
       
        public string? SenderPassengerId { get; set; }
        [ForeignKey("SenderPassengerId")]
        public virtual Passenger? SenderPassenger { get; set; }

        public string? SenderDriverId { get; set; }
        [ForeignKey("SenderDriverId")]
        public virtual Driver? SenderDriver { get; set; }

        // Receiver information
        public string? ReceiverPassengerId { get; set; }
        [ForeignKey("ReceiverPassengerId")]
        public virtual Passenger? ReceiverPassenger { get; set; }

        public string? ReceiverDriverId { get; set; }
        [ForeignKey("ReceiverDriverId")]
        public virtual Driver? ReceiverDriver { get; set; }

    }
}
