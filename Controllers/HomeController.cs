using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TP6.Controllers;

public class HomeController : Controller
{
    //form
    private IWebHostEnvironment Environment;

    private readonly ILogger<HomeController> _logger;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment=environment;
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

    public IActionResult AgregarJugador(int IdEquipo )
    {
        ViewBag.IdEquipo = IdEquipo;

        return View("AgregarJugador");
    }

   [HttpPost] 

   //public IActionResult GuardarJugador(Jugador Jug)
     //{
        
    // }

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

    //form
    [HttpPost]
    public IActionResult GuardarJugador(int IdEquipo, string Nombre, DateTime FechaNacimiento, IFormFile Foto, string EquipoActual)
     {
        
        if(Foto.Length>0)
        {
            string wwwRootLocal= this.Environment.ContentRootPath + @"\wwwroot\" + Foto.FileName;
            using(var stream=System.IO.File.Create(wwwRootLocal))
            {
                Foto.CopyToAsync(stream);
            }
        }

        //crea un nuevo jugador con los datos pasados por parametros
        Jugador Jug= new Jugador(IdEquipo, Nombre, FechaNacimiento,(""+ Foto.FileName), EquipoActual);
        //manda al jugador Jug a la base de datos
        BD.GuardarJugador(Jug);
         //Redirecciona a VerDetalleEquipo para ver al jugador en la tabla y pasa el IdEquipo
        return RedirectToAction(Url.Action("VerDetalleEquipo", "Home", new {IdEquipo = IdEquipo}));

     }

}
