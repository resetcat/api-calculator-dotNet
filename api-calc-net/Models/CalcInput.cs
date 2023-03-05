using System.ComponentModel.DataAnnotations;

namespace api_calc_net.Models
{
    public class CalcInput
    {
        [Required]
        [Range(0, 9)]
        public int X { get; set; }
        [Required]
        [Range(0, 9)]
        public int Y { get; set; }
        [Required]
        [RegularExpression("[*/\\-+]")]
        public string? Operation { get; set; }
    }
}
