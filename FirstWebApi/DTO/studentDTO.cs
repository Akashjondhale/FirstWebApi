using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.DTO
{
    public class studentDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Range(5, 100)]
        public int Age { get; set; }
    }
}
