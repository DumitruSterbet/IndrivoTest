using System.ComponentModel.DataAnnotations;

namespace IndrivoTest.Models
{
    public class Type
    {
        [Required]
        public Guid Guid { get; set; }
        public string Title { get; set; }
    }
}
