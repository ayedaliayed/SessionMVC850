using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SessionMVC850.ModelView
{
    public class CreateUpadteEmployee
    {
        public int Id { get; set; }


        [DisplayName("Employee Name")]
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }
        [DisplayName("Employee Age")]
        [Required]
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65.")]
        public int age { get; set; }
        [DisplayName("Employee Image")]
        [Required]

        public string Image { get; set; }

        [DisplayName("Emplyee Phone")]
        public string Phone { get; set; }
        public int DeptId { get; set; }
        
    }
}
