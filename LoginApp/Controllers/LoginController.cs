using Microsoft.AspNetCore.Mvc;
using LoginApp.Models;

namespace LoginApp.Controllers
{
    public class LoginController : Controller
    {
        // Simulação de banco de dados (pode ser substituído por dados reais depois)
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { NomeUsuario = "admin", Senha = "1234" },
            new Usuario { NomeUsuario = "rodrigo", Senha = "senha123" }
        };

        // Tela de Login (GET)
        public IActionResult Index()
        {
            return View();
        }

        // Autenticação do usuário (POST)
        [HttpPost]
        public IActionResult Index(Usuario model)
        {
            // Verifica se usuário e senha são válidos
            var usuarioValido = usuarios.Any(u =>
                u.NomeUsuario == model.NomeUsuario && u.Senha == model.Senha);

            if (usuarioValido)
            {
                // Armazena o nome do usuário temporariamente
                TempData["UsuarioLogado"] = model.NomeUsuario;

                // Redireciona para o painel principal (Dashboard)
                return RedirectToAction("Index", "Dashboard");
            }

            // Se não for válido, mostra erro na mesma tela
            ViewBag.Erro = "Usuário ou senha inválidos.";
            return View();
        }
    }
}
