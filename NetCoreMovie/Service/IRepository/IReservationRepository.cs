using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Service.IRepository
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservations();

        string PostReservation(Reservation reservation);

        Reservation Find(int ReservationId);

        string UpdateReservation(Reservation reservation);

        string DeleteReservation(int ReservationId);

        List<Reservation> Where(Expression<Func<Reservation, bool>> exp);

        bool Any(Expression<Func<Reservation, bool>> exp);
    }
}
