using System.ComponentModel.DataAnnotations;

namespace Tomnaia.DTO
{
    public class RateDto
    {
        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5.")]
        public double RateValue { get; set; }
    }
}
