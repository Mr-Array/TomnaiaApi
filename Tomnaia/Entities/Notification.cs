using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomnaia.Entities
{
    public class Notification
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string? PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public virtual  Passenger? ReceiverPassenger { get; set; }

        // Foreign key for Driver
        public string? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver? ReceiverDriver { get; set; }

    }
}
