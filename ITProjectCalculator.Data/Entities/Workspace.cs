namespace ITProjectCalculator.Data.Entities;

public class Workspace
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Subdomain { get; set; } = string.Empty;
    public int AdminId { get; set; }
    public Dictionary<int, string> UsersWithPermissions { get; set; } = new(); // UserId -> Permission (View/Edit)
    public List<int> ProjectIds { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
