using Microsoft.AspNetCore.Mvc;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository reservationRepository;
        public ReservationController(IReservationRepository _reservationRepository)
        {
            reservationRepository = _reservationRepository;
        }
        public IActionResult Index()
        {
            return View(reservationRepository.GetReservations());
        }
    }
}
