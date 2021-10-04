using DataAccess.Context;
using DataAccess.Entity;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        public readonly MovieContext movieContext;
        public ReservationRepository(MovieContext _movieContext)
        {
            movieContext = _movieContext;
        }
        public bool Any(Expression<Func<Reservation, bool>> exp)
        {
            return movieContext.Reservations.Any(exp);

        }

        public string DeleteReservation(int ReservationId)
        {
            try
            {
                movieContext.Reservations.Remove(Find(ReservationId));
                movieContext.SaveChanges();
                return $"Rezervasyon Silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Reservation Find(int ReservationId)
        {
            return movieContext.Reservations.Find(ReservationId);
        }

        public List<Reservation> GetReservations()
        {
            return movieContext.Reservations.ToList();
        }

        public string PostReservation(Reservation reservation)
        {
            try
            {
                reservation.IsActive = true;
                movieContext.Reservations.Add(reservation);
                movieContext.SaveChanges();
                return $"Rezervasyon Eklendi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateReservation(Reservation reservation)
        {
            try
            {
                Reservation updated = Find(reservation.Id);
                movieContext.Entry(updated).CurrentValues.SetValues(reservation);
                if (reservation.IsActive)
                {
                    movieContext.Entry(updated).Entity.IsActive = true;
                }
                else
                {
                    movieContext.Entry(updated).Entity.IsActive = false;
                }
                movieContext.SaveChanges();
                return $"Rezervasyon Güncellendi!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<Reservation> Where(Expression<Func<Reservation, bool>> exp)
        {
            return movieContext.Reservations.Where(exp).ToList();
        }
    }
}
