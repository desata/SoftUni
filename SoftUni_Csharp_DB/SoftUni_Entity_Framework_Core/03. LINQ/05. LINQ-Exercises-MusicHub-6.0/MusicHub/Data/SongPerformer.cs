using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data
{
    public class SongPerformer
    {
        public int SongId { get; set; }

        public virtual Song Song { get; set; } = null!;
        public int PerformerId { get; set; }
        public virtual Performer Performer { get; set; } = null!;
    }
}
