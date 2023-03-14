using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Song
    {

        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }
        [MaxLength(ValidationConstants.SongNameMaxLength)]
        public string Name { get; set; } = null!;

        public TimeSpan Duration { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; } = null!;

        public int WriterId { get; set; }

        public Writer Writer { get; set; } = null!;

        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
