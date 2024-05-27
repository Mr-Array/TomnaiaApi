using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tomnaia.Entities
{
    public class Comment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
       
        
    }
}
