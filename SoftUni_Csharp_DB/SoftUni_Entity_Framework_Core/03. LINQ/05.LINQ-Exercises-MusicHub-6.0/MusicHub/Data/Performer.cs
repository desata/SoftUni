﻿using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data
{
    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }

        [MaxLength(ValidationConstants.PerformerFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [MaxLength(ValidationConstants.PerformerLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
