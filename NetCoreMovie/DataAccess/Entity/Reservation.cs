using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Reservation:BaseEntity
    {
        public int MovieId { get; set; }
        public int SaloonId { get; set; }
        public int WeekId { get; set; }
        public int SessionId { get; set; }
        public string AppUserId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Saloon Saloon{ get; set; }
        public virtual Week Week{ get; set; }
        public virtual Session Session{ get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
