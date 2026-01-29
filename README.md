# DCOtoPDF – Resume Builder (ASP.NET Core MVC)

📄 DCOtoPDF – Resume Builder Application

DCOtoPDF is a web-based Resume Builder application developed using ASP.NET Core MVC.
The application allows users to enter their personal and professional details, select a resume template, and generate a downloadable PDF resume instantly.
This project demonstrates real-world implementation of form handling, template rendering, and server-side PDF generation using .NET.

🎯 Key Features
User-friendly resume form (personal, education, experience, skills)
Multiple resume template selection
Live preview of resume layout
One-click PDF generation
Clean MVC architecture
Separation of concerns using Services
Ready for real-world usage and deployment

🛠 Tech Stack
ASP.NET Core MVC
C#
HTML5
CSS3
JavaScript
Bootstrap
PDF Generation Library (server-side)

🧠 How the Application Works (Flow)
User opens the Resume Builder page
User fills in resume details (name, summary, skills, etc.)
User selects a resume template
On clicking Download PDF:
Data is sent to the controller
Resume HTML is rendered using the selected template
Server converts the HTML into a PDF
PDF is generated and downloaded automatically

📂 Project Structure
DCOtoPDF
│
├── Controllers     → Handle form submission & PDF generation
├── Models          → Resume data models
├── Services        → PDF generation logic
├── Views           → Razor UI & resume templates
├── wwwroot         → Static files (CSS, JS)
├── Program.cs      → Application entry point
└── DCOtoPDF.csproj → Project configuration

▶️ How to Run the Project Locally
✅ Prerequisites
.NET SDK (6.0 or above)
Visual Studio / VS Code
Git

🚀 Steps to Run
1.Clone the repository
git clone https://github.com/your-username/DCOtoPDF.git

2.Navigate to the project folder
cd DCOtoPDF

3.Restore dependencies
dotnet restore

4.Run the application
dotnet run

5.Open in browser
http://localhost:5000
or
http://localhost:5001

📌 Use Case
Resume Builder for students & professionals
Demonstration project for ASP.NET Core MVC
Portfolio project for internships & job applications

🧪 Project Status
✔ Completed
✔ Functional PDF generation
✔ Resume-ready project

📜 License
This project is licensed under the MIT License.

📜 License

This project is licensed under the MIT License.
