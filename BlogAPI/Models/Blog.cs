using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Blog
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Image { get; set; }
        public string? Position { get; set; }
        public bool Public { get; set; }
        public string? Category { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicDate { get; set; }
        public string? Secret { get; set; }
    }
}
