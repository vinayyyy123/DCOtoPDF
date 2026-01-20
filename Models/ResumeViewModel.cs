using System.ComponentModel.DataAnnotations;

namespace DCOtoPDF.Models
{
    public class ResumeViewModel
    {
        // ===== BASIC INFO =====
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Degree { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string ProfileSummary { get; set; } = string.Empty;

        // ===== EDUCATION =====
        public string Course { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string CGPA { get; set; } = string.Empty;

        // ===== EXPERIENCE =====
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string JobLocation { get; set; } = string.Empty;
        public string EmploymentDuration { get; set; } = string.Empty;

        public List<string> ExperiencePoints { get; set; } = new();

        // ===== SKILLS (DYNAMIC) =====
        public List<string> Skills { get; set; } = new();

        // ===== PROJECTS =====
        public string ProjectTitle { get; set; } = string.Empty;
        public List<string> ProjectDescriptions { get; set; } = new();

        // ===== TEMPLATE =====
        [Required(ErrorMessage = "Please select a resume template")]
        public string SelectedTemplate { get; set; } = string.Empty;

        public List<string> AvailableTemplates { get; set; } = new();
    }
}
