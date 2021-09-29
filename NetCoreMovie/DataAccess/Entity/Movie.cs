using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Movie:BaseEntity
    {
        
        public string MovieName { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        public short Rank { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }
    }
}
