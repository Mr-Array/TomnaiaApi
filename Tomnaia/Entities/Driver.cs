using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tomnaia.Consts;

namespace Tomnaia.Entities
{
    public class Driver :User
    {


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
    }
}
