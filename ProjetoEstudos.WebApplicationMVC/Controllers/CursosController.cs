using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoEstudos.WebApplicationMVC.enumVerbs;
using ProjetoEstudos.WebApplicationMVC.Models;

namespace ProjetoEstudos.WebApplicationMVC.Controllers
{
    public class CursosController : Controller
    {
        readonly string apiUri;
        private readonly IConfiguration _configuration;
        public CursosController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiUri = _configuration.GetValue<string>("Uri");
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListaCursos()
        {
            return View(await GetCursos());
        }

        public async Task<IEnumerable<CursosViewModel>?> GetCursos()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                var cursos = new CursosViewModel();

                HttpResponseMessage response = await httpClient.GetAsync(apiUri + enumActions.ObterCursoPorId);
                if (response.IsSuccessStatusCode)
                {
                    var dados = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<CursosViewModel>>(dados);                   
                }
                return new List<CursosViewModel>();
            }
        }
    }
}
