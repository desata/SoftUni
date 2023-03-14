using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data
{
    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        [MaxLength(ValidationConstants.ProducerNameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Album> Albums { get; set; }


    }
}
