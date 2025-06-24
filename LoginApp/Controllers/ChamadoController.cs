using Microsoft.AspNetCore.Mvc;
using LoginApp.Models;
using System.Text.Json;
using System.Text;

namespace LoginApp.Controllers
{
    public class ChamadoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string firebaseUrl = "https://SEU-PROJETO.firebaseio.com/Chamados.json"; // Substitua pela sua URL Firebase

        public ChamadoController()
        {
            _httpClient = new HttpClient();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Chamado chamado)
        {
            chamado.DataHoraCriacao = DateTime.Now;
            chamado.Usuario = TempData["UsuarioLogado"]?.ToString() ?? "Desconhecido";

            var json = JsonSerializer.Serialize(chamado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(firebaseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Msg"] = "Chamado criado com sucesso!";
                return RedirectToAction("Criar");
            }

            ViewBag.Erro = "Erro ao salvar no Firebase.";
            return View(chamado);
        }
    }
}
