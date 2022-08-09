﻿using System.Diagnostics;
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

    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
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

    public IActionResult AgregarJugador(int IdEquipo, string Nombre, DateTime FechaNacimiento, IFormFile Foto, int EquipoActual )
    {
        ViewBag.Lista = IdEquipo;

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
    public IActionResult GuardarJugador(Jugador Jug, int idEquipo, string nombre, DateTime fechaNacimiento, IFormFile foto, string equipoActual)
     {
        /*
        if(foto.Length>0)
        {
            string wwwRootLocal= this.Environment.ContentRootPath + @"\wwwroot\" + foto.FileName;
        }
        */

        BD.AgregarJugador(Jug);
         
        ViewBag.MiEquipo= BD.VerDetalleEquipo(Jug.IdEquipo);
        ViewBag.ListaJugadores = BD.ListarJugadores(Jug.IdEquipo);

        return Redirect(Url.Action("VerDetalleEquipo", "Home", new {IdEquipo = Jug.IdEquipo}));

     }

}
