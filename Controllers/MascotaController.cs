using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GO2PET.Data;
using GO2PET.Models;

namespace GO2PET.Controllers
{
    [Route("[controller]")]
    public class MascotaController : Controller
    {
        private readonly ILogger<MascotaController> _logger;

        private readonly ApplicationDbContext _context;

        public MascotaController(ILogger<MascotaController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistroMascota()
        {
             return View(); 
        }


        [HttpPost]
         public IActionResult Enviar(Mascota objmascota)
        {
            _logger.LogDebug("Ingreso a enviar mensaje");

            objmascota.FechaNacimiento = DateTime.SpecifyKind(objmascota.FechaNacimiento, DateTimeKind.Utc);

            _context.DataMascota.Add(objmascota);
            _context.SaveChanges();

            ViewData["Message"] = "Se registró la mascota";


            return View("RegistroMascota");
        }

        [HttpGet("Lista")]
        public IActionResult Lista()
        {
            var mascotas = _context.DataMascota.ToList();
    
            return View(mascotas);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}