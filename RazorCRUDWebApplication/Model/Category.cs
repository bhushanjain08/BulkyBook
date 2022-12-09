using System.ComponentModel.DataAnnotations;

namespace RazorCRUDWebApplication.Model
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required ]
        public string Name { get; set; }

        [Display(Name="Display Order")]
        [Range(1,100,ErrorMessage ="Display value must be in range of 1 to 100")]
        [Required]
        public int DisplayOrder { get; set; }
    }
}
