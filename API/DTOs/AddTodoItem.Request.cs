using System.ComponentModel.DataAnnotations;
using System;

namespace API.DTOs
{
    public class AddTodoItemRequest
    {
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
