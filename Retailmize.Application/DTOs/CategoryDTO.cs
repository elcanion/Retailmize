using System.ComponentModel.DataAnnotations;

namespace Retailmize.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
