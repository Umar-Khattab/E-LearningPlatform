# E-Learning Platform

This is an E-Learning Platform built with ASP.NET Core and Entity Framework Core. The platform provides functionalities for managing courses, exams, questions, answers, and users.

## Technologies Used

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- C# 12.0

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio 2022

### Setup

1. **Clone the repository:**

   <span> git clone https://github.com/your-repo/e-learning-platform.git
   cd e-learning-platform
   </span>

3. **Configure the database connection:**

    Update the `appsettings.json` file with your SQL Server connection string:

    <span>{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
  }
}</span>

4. **Run database migrations:**

    Open the terminal in the project directory and run:

    <span>dotnet ef database update</span>

5. **Run the application:**
   <span>dotnet run</span>

    The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## Project Structure

- **Controllers**: Contains API controllers for handling HTTP requests.
- **Models**: Contains entity classes representing the database schema.
- **Repositories**: Contains repository classes for data access.
- **Interfaces**: Contains interface definitions for repositories.
- **Data**: Contains the `AppDBContext` class for Entity Framework Core.

## API Endpoints

### Users

- `GET /api/users`: Get all users.
- `GET /api/users/{id}`: Get a user by ID.
- `POST /api/users`: Create a new user.
- `PUT /api/users/{id}`: Update a user.
- `DELETE /api/users/{id}`: Delete a user.

### Courses

- `GET /api/courses`: Get all courses.
- `GET /api/courses/{id}`: Get a course by ID.
- `POST /api/courses`: Create a new course.
- `PUT /api/courses/{id}`: Update a course.
- `DELETE /api/courses/{id}`: Delete a course.

### Exams

- `GET /api/exams`: Get all exams.
- `GET /api/exams/{id}`: Get an exam by ID.
- `POST /api/exams`: Create a new exam.
- `PUT /api/exams/{id}`: Update an exam.
- `DELETE /api/exams/{id}`: Delete an exam.

### Questions

- `GET /api/questions`: Get all questions.
- `GET /api/questions/{id}`: Get a question by ID.
- `POST /api/questions`: Create a new question.
- `PUT /api/questions/{id}`: Update a question.
- `DELETE /api/questions/{id}`: Delete a question.

### Answers

- `GET /api/answers`: Get all answers.
- `GET /api/answers/{id}`: Get an answer by ID.
- `POST /api/answers`: Create a new answer.
- `PUT /api/answers/{id}`: Update an answer.
- `DELETE /api/answers/{id}`: Delete an answer.

### Student Exams

- `GET /api/studentexams`: Get all student exams.
- `GET /api/studentexams/{id}`: Get a student exam by ID.
- `POST /api/studentexams`: Create a new student exam.
- `PUT /api/studentexams/{id}`: Update a student exam.
- `DELETE /api/studentexams/{id}`: Delete a student exam.

## Exception Handling

Global exception handling is implemented to catch and handle exceptions consistently across the application. Custom exceptions include `RepositoryException` and `NotFoundException`.

## Logging

Logging is implemented using the `ILogger` interface to log information, warnings, and errors.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.



    
