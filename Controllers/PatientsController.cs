using Microsoft.AspNetCore.Mvc;
using ClinicalTrialsAPI.Models;
using ClinicalTrialsAPI.Data;

namespace ClinicalTrialsAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PatientsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Patient>> GetAll()
    {
        return Ok(_context.Patients.ToList());
    }

    [HttpPost]
    public ActionResult<Patient> Create(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), patient);
    }

    [HttpGet("{id}")]
    public ActionResult<Patient> GetById(int id)
    {
        var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
        if (patient == null)
        {
            return NotFound($"Patient with ID {id} not found");
        }
        return Ok(patient);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
        if (patient == null)
        {
            return NotFound($"Patient with ID {id} not found");
        }
        _context.Patients.Remove(patient);
        _context.SaveChanges();
        return Ok($"Patient with ID {id} deleted");
    }

    [HttpPut("{id}")]
    public ActionResult<Patient> Update(int id, Patient updatedPatient)
    {
        var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
        if (patient == null)
        {
            return NotFound($"Patient with ID {id} not found");
        }
        patient.FullName = updatedPatient.FullName;
        patient.Age = updatedPatient.Age;
        patient.Diagnosis = updatedPatient.Diagnosis;
        _context.SaveChanges();
        return Ok(patient);
    }
}