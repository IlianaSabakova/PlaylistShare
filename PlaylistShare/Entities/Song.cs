using System.ComponentModel.DataAnnotations;

namespace PlaylistShare.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int? PlaylistId { get; set; }

        public Playlist Playlist { get; set; }
    }
}
