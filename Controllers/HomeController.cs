using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6.Models;

namespace TP6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Lista = BD.ListarEquipos();
        return View();
    }

    public IActionResult VerDetalleEquipo(int IdEquipo)
    {
          ViewBag.DetalleEquipo = BD.VerDetalleEquipo(IdEquipo);
        ViewBag.ListaJugadores = BD.ListarJugadores(IdEquipo);
      

        return View("VerDetalleEquipo");
    }

    public IActionResult VerDetalleJugador(int IdJugador)
    {
        ViewBag.DatosJugador = BD.VerInfoJugador(IdJugador);

        return View("VerDetalleJugador");
    }

    public IActionResult AgregarJugador(int IdEquipo)
    {
        ViewBag.Lista = IdEquipo;

        return View("AgregarJugador");
    }

   [HttpPost] 

   public IActionResult GuardarJugador(Jugador Jug)
     {
        BD.AgregarJugador(Jug);
         
        ViewBag.MiEquipo= BD.VerDetalleEquipo(Jug.IdEquipo);
        return View("VerDetalleEquipo");
     }

     public IActionResult EliminarJugador(int IdJugador, int IdEquipo)
     {
        BD.EliminarJugador(IdJugador);
        ViewBag.MiEquipo=BD.VerDetalleEquipo(IdEquipo);
        return View("VerDetalleEquipo");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

     



    
}
