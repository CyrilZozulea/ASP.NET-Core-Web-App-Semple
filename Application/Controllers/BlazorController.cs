using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class BlazorController : Controller
    {
        private readonly ILogger<BlazorController> logger;
        public BlazorController(ILogger<BlazorController> logger) => this.logger = logger;

        [HttpGet]
        public IActionResult Index()
        {
            logger.LogInformation($"Balzor page start at {DateTime.Now}");
            return View();
        }
    }
}
