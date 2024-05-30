using System.ComponentModel.DataAnnotations.Schema;

namespace Tomnaia.Entities
{
    public class Adminstrator 
    {
        public string AdminstratorId { get; set; } = Guid.NewGuid().ToString();
        //  public string FullName { get; set; }
        //   public bool IsDeleted { get; set; } = false;

        //[ForeignKey("Account")]
        //public string? AccountId { get; set; }
        //public User? Account { get; set; }
    }
}
