using Microsoft.AspNetCore.Mvc;

namespace LoginApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Usuario = TempData["UsuarioLogado"] ?? "Usuário";
            return View();
        }
    }
}
