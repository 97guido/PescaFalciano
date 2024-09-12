using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace PescaFalciano.Pages
{
    public class PremioDetails{
        public int FromNumber { get; set; }
        public int ToNumber { get; set; }
        public string Description { get; set; } = "";
    }
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<PremioDetails> DettagliPremi;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            DettagliPremi = JsonConvert.DeserializeObject<List<PremioDetails>>(System.IO.File.ReadAllText("PremiPesca2024.json")) ?? new List<PremioDetails>();
        }

        public void OnGet()
        {

        }

        public PremioDetails? GetPremio(int num)
        {
            return DettagliPremi.FirstOrDefault(x => x.FromNumber <= num && x.ToNumber >= num);
        }
    }
}
