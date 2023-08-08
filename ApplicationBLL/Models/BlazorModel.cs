using System.ComponentModel.DataAnnotations;

namespace ApplicationBLL.Models
{
    public class BlazorModel : BaseModel 
    {
        [Range(1, 3)]
        public int Type { get; set; }
    }
}
