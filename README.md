# Business School Management System

A comprehensive school management system built using the MVC (Model-View-Controller) architectural pattern. This application provides a robust platform for managing educational institutions, including student enrollment, course management, instructor administration, and academic performance tracking.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Features

### Student Management
- Student registration and profile management
- Enrollment in courses
- Academic history tracking
- Grade viewing and performance reports

### Course Management
- Create and manage courses
- Assign instructors to courses
- Set course schedules and capacity
- Track course enrollment

### Instructor Management
- Instructor profile management
- Course assignment
- Grade submission
- Student performance evaluation

### Administrative Functions
- User authentication and authorization
- Role-based access control (Admin, Instructor, Student)
- Dashboard with key metrics
- Reporting and analytics

### Additional Features
- Responsive design for mobile and desktop
- Search and filter functionality
- Data export capabilities
- Email notifications

## 🛠️ Technologies Used

- **Backend Framework**: ASP.NET MVC / PHP / Java Spring MVC
- **Programming Language**: C# / PHP / Java
- **Database**: SQL Server / MySQL / PostgreSQL
- **ORM**: Entity Framework / Hibernate / Eloquent
- **Frontend**: 
  - HTML5
  - CSS3
  - JavaScript
  - Bootstrap 5
  - jQuery
- **Authentication**: ASP.NET Identity / JWT / Custom Authentication
- **Additional Libraries**:
  - Chart.js (for data visualization)
  - DataTables (for advanced table features)
  - Font Awesome (icons)

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version X.X or higher)
- [SQL Server](https://www.microsoft.com/sql-server) or your preferred database
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Node.js and npm](https://nodejs.org/) (for frontend dependencies)

## Installation

1. **Clone the repository**
```bash
   git clone https://github.com/AlvaroBuiza/Business-School-MVC-PROJECT.git
   cd Business-School-MVC-PROJECT
```

2. **Restore dependencies**
```bash
   dotnet restore
   # or
   npm install
```

3. **Update connection string**
   
   Open `appsettings.json` (or `web.config`) and update the database connection string:
```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=BusinessSchoolDB;Trusted_Connection=True;"
   }
```

## Database Setup

1. **Run migrations to create the database**
```bash
   dotnet ef database update
   # or
   Update-Database
```

2. **Seed initial data** (if available)
```bash
   dotnet run --seed
```

The database will be created with the following tables:
- Users
- Students
- Instructors
- Courses
- Enrollments
- Grades
- Departments

## 💻 Usage

1. **Run the application**
```bash
   dotnet run
   # or press F5 in Visual Studio
```

2. **Access the application**
   
   Open your browser and navigate to:
```
   http://localhost:5000
   # or
   https://localhost:5001
```

3. **Default login credentials**
   
   Administrator:
   - Username: `admin@businessschool.com`
   - Password: `Admin@123`
   
   Instructor:
   - Username: `instructor@businessschool.com`
   - Password: `Instructor@123`
   
   Student:
   - Username: `student@businessschool.com`
   - Password: `Student@123`

   ** Important**: Change these default credentials after first login!

## Project Structure
```
Business-School-MVC-PROJECT/
│
├── Controllers/              # MVC Controllers
│   ├── HomeController.cs
│   ├── StudentController.cs
│   ├── CourseController.cs
│   └── InstructorController.cs
│
├── Models/                   # Data models and ViewModels
│   ├── Student.cs
│   ├── Course.cs
│   ├── Instructor.cs
│   └── ViewModels/
│
├── Views/                    # Razor views
│   ├── Home/
│   ├── Student/
│   ├── Course/
│   ├── Instructor/
│   └── Shared/
│
├── Data/                     # Database context and migrations
│   ├── ApplicationDbContext.cs
│   └── Migrations/
│
├── wwwroot/                  # Static files
│   ├── css/
│   ├── js/
│   ├── images/
│   └── lib/
│
├── Services/                 # Business logic services
│   ├── IStudentService.cs
│   ├── StudentService.cs
│   └── ...
│
├── Repositories/             # Data access layer
│   ├── IRepository.cs
│   └── Repository.cs
│
├── appsettings.json          # Configuration file
├── Program.cs                # Application entry point
└── Startup.cs                # Application startup configuration
```

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Coding Standards

- Follow the existing code style
- Write meaningful commit messages
- Add comments for complex logic
- Update documentation as needed
- Write unit tests for new features

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**Alvaro Buiza**

- GitHub: [@AlvaroBuiza](https://github.com/AlvaroBuiza)
- Project Link: [Business School MVC Project](https://github.com/AlvaroBuiza/Business-School-MVC-PROJECT)

