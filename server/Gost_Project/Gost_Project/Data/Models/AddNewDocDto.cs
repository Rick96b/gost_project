using Gost_Project.Data.Entities;

namespace Gost_Project.Data.Models;

public class AddNewDocDto
{
    public string? Designation { get; set; }

    public string? FullName { get; set; }

    public string? CodeOKS { get; set; }

    public string? ActivityField { get; set; }

    public DateTime AcceptanceDate { get; set; }

    public DateTime CommissionDate { get; set; }

    public string? Author { get; set; }

    public string? AcceptedFirstTimeOrReplaced { get; set; }

    public string? Content { get; set; }

    public string? KeyWords { get; set; }

    public string? KeyPhrases { get; set; }
    
    public string? ApplicationArea { get; set; }

    public AdoptionLevel AdoptionLevel { get; set; }

    public string? DocumentText { get; set; }

    public string? Changes { get; set; }

    public string? Amendments { get; set; }

    public Status Status { get; set; }
    
    public HarmonizationLevel Harmonization { get; set; }
    
    public bool IsPrimary { get; set; }
}