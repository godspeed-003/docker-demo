using System.ComponentModel.DataAnnotations;

namespace DockerTestApp.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Content { get; set; }
    }
}
