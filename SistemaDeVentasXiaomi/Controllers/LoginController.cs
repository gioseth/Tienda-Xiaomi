using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using SistemaDeVentasXiaomi.Contexto;

namespace SistemaDeVentasXiaomi.Controllers
{
    public class LoginController : Controller
    {
        MyContext _context;
        public LoginController(MyContext context)
        {
            //Inyeccion de dependencias
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email , string password)
        {
            var vendedor = _context.Vendedores
                .Where(x => x.Email == email)
                .Where(x => x.Contraseña == password)
                .FirstOrDefault();
            if (vendedor != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Mandando mensajes a la vista
                TempData["LoginError"] = "Cuenta o contraseña incorrecta";
                return RedirectToAction("Index", "Login");
            }

        }

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
