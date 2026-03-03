using System.ComponentModel.DataAnnotations;

namespace ClinicalTrialsAPI.Models;

public class ClinicalTrial
{
    public int Id { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [StringLength(500, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }

    public bool IsActive {get; set;} = true;

    public List<Patient> Patients {get; set;} = new List<Patient>();
}