using System.ComponentModel.DataAnnotations;


namespace ApplicationBLL.Models
{
    public class BaseModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
