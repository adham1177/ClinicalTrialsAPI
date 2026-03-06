# Clinical Trials API

A RESTful API built with ASP.NET Core and Entity Framework Core for managing clinical trial data.
Designed to demonstrate backend development skills including data modeling, validation,
persistent storage, relational database design, and containerized cloud deployment.

## 🚀 Live Demo
**API is live at:** https://clinical-trials-api.azurewebsites.net/scalar/v1

## Tech Stack

- **ASP.NET Core 10** — Web API framework
- **Entity Framework Core** — ORM for database access
- **Azure SQL Database** — Fully managed cloud relational database
- **Scalar** — API documentation and testing UI
- **Docker** — Containerized deployment
- **Microsoft Azure** — Cloud hosting via App Service

## Features

- Full CRUD operations for Patients and Clinical Trials
- One-to-many relationship between Trials and Patients
- Input validation using Data Annotations
- Persistent storage with Azure SQL Database
- Auto-generated API documentation via Scalar
- Containerized with Docker for consistent deployment
- Deployed to Microsoft Azure App Service

## Endpoints

### Patients
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/patients | Get all patients |
| GET | /api/patients/{id} | Get patient by ID |
| POST | /api/patients | Create a new patient |
| PUT | /api/patients/{id} | Update a patient |
| DELETE | /api/patients/{id} | Delete a patient |

### Clinical Trials
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/clinicaltrials | Get all trials with patients |
| GET | /api/clinicaltrials/{id} | Get trial by ID |
| POST | /api/clinicaltrials | Create a new trial |
| DELETE | /api/clinicaltrials/{id} | Delete a trial |

## Getting Started

### Option 1: Live Demo
Visit the live API directly:
```
https://clinical-trials-api.azurewebsites.net/scalar/v1
```

### Option 2: Run with Docker
```bash
git clone https://github.com/adham1177/ClinicalTrialsAPI.git
cd ClinicalTrialsAPI
docker build -t clinical-trials-api .
docker run -p 8080:8080 -e ConnectionStrings__DefaultConnection="your-sql-connection-string" clinical-trials-api
```
Then open: `http://localhost:8080/scalar/v1`

### Option 3: Run Locally
```bash
git clone https://github.com/adham1177/ClinicalTrialsAPI.git
cd ClinicalTrialsAPI
```

Add your connection string to `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-sql-connection-string-here"
  }
}
```

Then run:
```bash
dotnet restore
dotnet ef database update
dotnet run
```
Then open: `http://localhost:5067/scalar/v1`

## Data Models

### Patient
- `Id` — unique identifier
- `FullName` — required, 2-100 characters
- `Age` — required, 1-120
- `Diagnosis` — required, 2-200 characters
- `EnrolledAt` — auto-set to enrollment date
- `ClinicalTrialId` — foreign key to trial

### ClinicalTrial
- `Id` — unique identifier
- `Title` — required, 2-200 characters
- `Description` — required, 10-500 characters
- `StartDate` — trial start date
- `IsActive` — whether trial is currently running
- `Patients` — list of enrolled patients