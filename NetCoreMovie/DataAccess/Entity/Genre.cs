using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Genre:BaseEntity
    {
       
        public string GenreName { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }

    }
}
