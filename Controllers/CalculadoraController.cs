using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExemploAspNetMvc.Models;

namespace ExemploAspNetMvc.Controllers;

public class CalculadoraController : Controller 
{
    public class UserForm
    {
        public double N1 { get; set; }
        public double N2 { get; set; }
    }
    private readonly ILogger<CalculadoraController> _logger;

    public CalculadoraController(ILogger<CalculadoraController> logger)
    {
        _logger = logger;
    }

   public IActionResult Operacao ()
   {
        return View();
   }
    public IActionResult ResultadoOperacao ([FromForm] double n1, [FromForm] double n2, [FromForm] string operacao)
    {
        
        ViewBag.N1 = n1;
        ViewBag.N2 = n2;
        ViewBag.Operacao = operacao;

        switch(operacao)
        {
            case "Soma":
                ViewBag.operador = '+';
                ViewBag.resultado = n1 + n2;
                break;

            case "Subtração":
                ViewBag.operador = '-';
                ViewBag.resultado = n1 - n2;
                break;

            case "Multiplicação":
                ViewBag.operador = '*';
                ViewBag.resultado = n1 * n2;
                break;

            case "Divisão":
                ViewBag.operador = '/';
                ViewBag.resultado = n1 / n2;
                break;
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}