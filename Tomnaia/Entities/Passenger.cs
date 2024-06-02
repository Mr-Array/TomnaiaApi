using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomnaia.Entities
{
    public class Passenger :User
    {
       // public string PassengerId { get; set; }
        public virtual ICollection<Message>? SentMessages { get; set; }
        public virtual ICollection<Message>? ReceivedMessages { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
