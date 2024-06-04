using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class Driver :User
    {
       // public string DriverId { get; set; }

        [Required]
        public string NationalPhoto { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        public string LicensePhoto { get; set; }
        [Required]
        public string DriverLicenseNumber { get; set; }


        public DateTime expirDate { get; set; }
     
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public virtual ICollection<Message>? SentMessages { get; set; }
        public virtual ICollection<Message>? ReceivedMessages { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<Review>? Reviewee{ get; set; }
    }
}
