using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomnaia.Entities
{
    public class Passenger 
    {
        [Key]
        public string PassengerId { get; set; } = Guid.NewGuid().ToString();
        //[Required]
        //public string FirstName { get; set; }
        //[Required]
        //public string LastName { get; set; }
        //public bool IsDeleted { get; set; } = false;

        //[ForeignKey("Account")]
        //public string? AccountId { get; set; }
        //public User? Account { get; set; }

        //    public ICollection<RidePassenger> RidePassengers { get; set; } = new List<RidePassenger>();

    }
}
