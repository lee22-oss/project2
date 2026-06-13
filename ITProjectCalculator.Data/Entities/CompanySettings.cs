namespace ITProjectCalculator.Data.Entities;

public class CompanySettings
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string DirectorFirstName { get; set; } = string.Empty;
    public string DirectorLastName { get; set; } = string.Empty;
    public string DirectorPosition { get; set; } = string.Empty;
    public byte[]? Logo { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; }
}
