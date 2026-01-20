using Microsoft.AspNetCore.Mvc;
using DCOtoPDF.Models;
using DCOtoPDF.Services;

namespace DCOtoPDF.Controllers
{
    public class ResumeController : Controller
    {
        private readonly WordToPdfService _pdfService;
        private readonly IWebHostEnvironment _env;

        public ResumeController(WordToPdfService pdfService, IWebHostEnvironment env)
        {
            _pdfService = pdfService;
            _env = env;
        }

        public IActionResult Index()
        {
            var model = new ResumeViewModel
            {
                AvailableTemplates = LoadTemplates()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(ResumeViewModel model)
        {
            model.AvailableTemplates = LoadTemplates();

            if (!ModelState.IsValid)
                return View("Index", model);

            var pdfBytes = await _pdfService.GenerateResumePdf(
                model,
                model.SelectedTemplate
            );

            var safeName = string.Join("_",
                model.FullName.Split(Path.GetInvalidFileNameChars())
            );

            return File(pdfBytes, "application/pdf", $"{safeName}_Resume.pdf");
        }

        private List<string> LoadTemplates()
        {
            string path = Path.Combine(_env.WebRootPath, "Template");

            return Directory.Exists(path)
                ? Directory.GetFiles(path, "*.docx")
                    .Select(Path.GetFileName)
                    .ToList()!
                : new List<string>();
        }
    }
}
