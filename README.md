# Clinical Trials API

A RESTful API built with ASP.NET Core and Entity Framework Core for managing clinical trial data. 
Designed to demonstrate backend development skills including data modeling, validation, 
persistent storage, and relational database design.

## Tech Stack

- **ASP.NET Core 10** — Web API framework
- **Entity Framework Core** — ORM for database access
- **SQLite** — Lightweight persistent database
- **Scalar** — API documentation and testing UI

## Features

- Full CRUD operations for Patients and Clinical Trials
- One-to-many relationship between Trials and Patients
- Input validation using Data Annotations
- Persistent storage with SQLite
- Auto-generated API documentation via Scalar

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

### Prerequisites
- .NET 10 SDK

### Run Locally
```bash
git clone https://github.com/adham1177/ClinicalTrialsAPI.git
cd ClinicalTrialsAPI
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
- `EntrolledAt` — auto-set to enrollment date
- `ClinicalTrialId` — foreign key to trial

### ClinicalTrial
- `Id` — unique identifier
- `Title` — required, 2-200 characters
- `Description` — required, 10-500 characters
- `StartDate` — trial start date
- `IsActive` — whether trial is currently running
- `Patients` — list of enrolled patients