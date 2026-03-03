using Microsoft.AspNetCore.Mvc;
using ClinicalTrialsAPI.Models;
using ClinicalTrialsAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicalTrialsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClinicalTrialsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClinicalTrialsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ClinicalTrial>> GetAll()
    {
        return Ok(_context.ClinicalTrials.Include(ct => ct.Patients).ToList());
    }

    [HttpPost]
    public ActionResult<ClinicalTrial> Create(ClinicalTrial trial)
    {
        _context.ClinicalTrials.Add(trial);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), trial);
    }

    [HttpGet("{id}")]
    public ActionResult<ClinicalTrial> GetById(int id)
    {
        var trial = _context.ClinicalTrials.Include(ct => ct.Patients).FirstOrDefault(ct => ct.Id == id);
        if (trial == null)
        {
            return NotFound($"Clinical trial with ID {id} not found");
        }
        return Ok(trial);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var trial = _context.ClinicalTrials.FirstOrDefault(ct => ct.Id == id);
        if (trial == null)
        {
            return NotFound($"Clinical trial with ID {id} not found");
        }
        _context.ClinicalTrials.Remove(trial);
        _context.SaveChanges();
        return Ok($"Clinical trial with ID {id} deleted");
    }

    [HttpPut("{id}")]
    public ActionResult<ClinicalTrial> Update(int id, ClinicalTrial updatedTrial)
    {
        var trial = _context.ClinicalTrials.FirstOrDefault(ct => ct.Id == id);
        if (trial == null)
        {
            return NotFound($"Clinical trial with ID {id} not found");
        }
        trial.Title = updatedTrial.Title;
        trial.Description = updatedTrial.Description;
        trial.StartDate = updatedTrial.StartDate;
        trial.IsActive = updatedTrial.IsActive;
        
        _context.SaveChanges();
        return Ok(trial);
    }
}