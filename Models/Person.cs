using System.ComponentModel.DataAnnotations;

namespace DockerTestApp.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }
    }
}
