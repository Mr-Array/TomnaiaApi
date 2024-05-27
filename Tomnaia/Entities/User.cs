using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomnaia.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }

        [InverseProperty("Rater")]
        public virtual ICollection<Rate>? SentRates { get; set; }
        [InverseProperty("Rated")]
        public virtual ICollection<Rate>? ReceivedRates { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual ICollection<Message>? SentMessages { get; set; }
        public virtual ICollection<Message>? ReceivedMessages { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
