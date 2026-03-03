using System.ComponentModel.DataAnnotations;
namespace ClinicalTrialsAPI.Models;
public class Patient
{
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FullName { get; set; } = string.Empty;
    [Range(1, 120)]
    public int Age { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Diagnosis { get; set; } = string.Empty;
    
    public DateTime EntrolledAt { get; set; } = DateTime.UtcNow;

    //Patient belongs to one trial 
    public int ClinicalTrialId { get; set; }
    public ClinicalTrial? ClinicalTrial { get; set; }

}