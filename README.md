# Education System API

This solution consists of three projects:

1. **StudentApi** - API for managing student data
2. **TeacherApi** - API for managing teacher data
3. **ApiGateway** - YARP-based reverse proxy that routes requests to the appropriate backend API

## Project Structure

```
EducationSystem/
├── StudentApi/         # Student API project
├── TeacherApi/         # Teacher API project
└── ApiGateway/         # YARP reverse proxy project
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later

### Running the Solution

You can run all three projects simultaneously. The recommended approach is to start all three projects in separate terminal windows:

```bash
# Terminal 1 - Start the Student API
cd StudentApi
dotnet run

# Terminal 2 - Start the Teacher API
cd TeacherApi
dotnet run

# Terminal 3 - Start the API Gateway
cd ApiGateway
dotnet run
```

Alternatively, you can configure your IDE to run multiple startup projects.

### API Endpoints

When running, the services will be available at:

- **API Gateway**: http://localhost:5000
- **Student API**: http://localhost:5001
- **Teacher API**: http://localhost:5002

All APIs include Swagger UI which can be accessed at `/swagger` path.

### Using the API Gateway

The API Gateway routes requests based on the path:

- `/api/students/*` routes to the Student API
- `/api/teachers/*` routes to the Teacher API

For example:
- http://localhost:5000/api/students - Lists all students
- http://localhost:5000/api/teachers - Lists all teachers

## API Documentation

### Student API

- `GET /api/students` - Get all students
- `GET /api/students/{id}` - Get a student by ID
- `POST /api/students` - Create a new student
- `PUT /api/students/{id}` - Update a student
- `DELETE /api/students/{id}` - Delete a student

### Teacher API

- `GET /api/teachers` - Get all teachers
- `GET /api/teachers/{id}` - Get a teacher by ID
- `POST /api/teachers` - Create a new teacher
- `PUT /api/teachers/{id}` - Update a teacher
- `DELETE /api/teachers/{id}` - Delete a teacher

### Gateway API

- `GET /api/gateway/status` - Check the gateway status


### Reference articles

- https://mehmetozkaya.medium.com/api-gateways-with-yarp-reverse-proxy-in-net-8-microservices-58c5565697d0