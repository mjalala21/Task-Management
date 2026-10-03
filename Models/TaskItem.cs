using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = "";
        [Required]
        [MinLength(10)]
        public string Description { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";

    }
}
