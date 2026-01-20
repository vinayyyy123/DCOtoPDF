using Spire.Doc;
using Spire.Doc.Documents;
using System.Drawing;
using System.Drawing.Imaging;

namespace DCOtoPDF.Services
{
    public class TemplatePreviewService
    {
        private readonly IWebHostEnvironment _env;

        public TemplatePreviewService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void GenerateTemplatePreviews()
        {
            string templateDir = Path.Combine(_env.WebRootPath, "Template");
            string previewDir = Path.Combine(_env.WebRootPath, "TemplatePreviews");

            Directory.CreateDirectory(previewDir);

            foreach (var docx in Directory.GetFiles(templateDir, "*.docx"))
            {
                string name = Path.GetFileNameWithoutExtension(docx);
                string png = Path.Combine(previewDir, name + ".png");

                if (File.Exists(png)) continue;

                using var doc = new Document();
                doc.LoadFromFile(docx);

                using Image img = doc.SaveToImages(0, ImageType.Bitmap);
                using Bitmap resized = new Bitmap(img, new Size(800, 1100));
                resized.Save(png, ImageFormat.Png);
            }
        }
    }
}
