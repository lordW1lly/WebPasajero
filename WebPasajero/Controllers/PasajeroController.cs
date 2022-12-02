using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebPasajero.Data;
using WebPasajero.Models;

namespace WebPasajero.Controllers
{
    public class PasajeroController : Controller
    {
        private readonly PasajeroContext _context;

        public PasajeroController(PasajeroContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View("Index",_context.pasajeros.ToList());
        }

        public IActionResult Create()
        {
            Pasajero pasajero = new Pasajero();
            return View("Create", pasajero);
        }

        [HttpPost]
        public IActionResult Create(Pasajero pasajero)
        {
            _context.Add(pasajero);
            _context.SaveChanges();
            return RedirectToAction("Index")
;
        }

        [HttpGet("pasajero/fecha/{nacimiento}")]
        public IActionResult FiltrarPorFechaNacimiento(DateTime nacimiento)
        {
            List<Pasajero> listAll = _context.pasajeros.ToList();
            List<Pasajero> list = new List<Pasajero>();

            foreach (Pasajero pasajero in listAll)
            {
                if (pasajero.FechaDeNacimiento == nacimiento)
                {
                    list.Add(pasajero);
                }
            }
            return View("Index", list);

        }
        [HttpGet("/pasajero/ciudad/{ciudad}")]
        public IActionResult FiltrarPorCiudad(string ciudad)
        {
            List<Pasajero> pasajeros = (from p in _context.pasajeros where p.Ciudad == ciudad select p).ToList();
            return View("Index", pasajeros);
        }
    }
}
