using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UpdateTodoItemRequest
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string IsComplete { get; set; }

        [Required]
        [StringLength(50)]
        public string Secret { get; set; }
    }
}
