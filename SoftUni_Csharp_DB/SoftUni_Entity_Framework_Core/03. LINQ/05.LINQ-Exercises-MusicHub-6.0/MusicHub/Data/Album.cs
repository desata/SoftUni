using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [MaxLength(ValidationConstants.AlbumNameMaxLength)]
        public string Name { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        //TODO Price – calculated property (the sum of all song prices in the album)
        public decimal Price { get => this.Songs.Sum(s => s.Price); }

        public int? ProducerId { get; set; }

        public virtual Producer Producer { get; set; } = null!;

        public ICollection<Song> Songs { get; set; }

    }
}
