using DCOtoPDF.Models;
using Spire.Doc;

namespace DCOtoPDF.Services
{
    public class WordToPdfService
    {
        private readonly IWebHostEnvironment _env;

        public WordToPdfService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<byte[]> GenerateResumePdf(
            ResumeViewModel model,
            string templateName
        )
        {
            string templatePath = Path.Combine(_env.WebRootPath, "Template", templateName);

            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Template not found", templatePath);

            string tempDocx = Path.GetTempFileName() + ".docx";
            string tempPdf = Path.ChangeExtension(tempDocx, ".pdf");

            File.Copy(templatePath, tempDocx, true);

            using var document = new Document();
            document.LoadFromFile(tempDocx);

            var map = new Dictionary<string, string>
            {
                { "{{FullName}}", model.FullName },
                { "{{Degree}}", model.Degree },
                { "{{Email}}", model.Email },
                { "{{Mobile}}", model.Mobile },
                { "{{Address}}", model.Address },
                { "{{ProfileSummary}}", model.ProfileSummary },
                { "{{Course}}", model.Course },
                { "{{Year}}", model.Year },
                { "{{CGPA}}", model.CGPA },
                { "{{JobTitle}}", model.JobTitle },
                { "{{CompanyName}}", model.CompanyName },
                { "{{JobLocation}}", model.JobLocation },
                { "{{EmploymentDuration}}", model.EmploymentDuration },
                { "{{Skills}}", FormatList(model.Skills) },
                { "{{ExperiencePoints}}", FormatList(model.ExperiencePoints) },
                { "{{ProjectTitle}}", model.ProjectTitle },
                { "{{ProjectDescriptions}}", FormatList(model.ProjectDescriptions) }
            };

            foreach (var item in map)
            {
                document.Replace(item.Key, item.Value ?? "", false, true);
            }

            document.SaveToFile(tempPdf, FileFormat.PDF);
            return await File.ReadAllBytesAsync(tempPdf);
        }

        private static string FormatList(List<string> items)
        {
            return string.Join(
                "\n• ",
                items.Where(x => !string.IsNullOrWhiteSpace(x)).Prepend("")
            );
        }
    }
}
