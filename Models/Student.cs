using System.ComponentModel.DataAnnotations;
namespace StudentApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";
        [Range(18,50)]
        public int Age { get; set; }
        [Required]
        [MinLength(20)]
        public string Address { get; set; } = "";
        [Required]
        [Phone]
        public string phoneNo { get; set; } = "";
    }
}
