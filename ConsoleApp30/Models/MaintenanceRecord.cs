namespace ConsoleApp30.Models;

public class MaintenanceRecord
{
    public int Id { get; set; }
    public int CardId { get; set; }
    public string Description { get; set; } = null!;
    public DateOnly MaintenanceDate { get; set; }
    public int Cost { get; set; }
    public DateOnly NextMaintenanceDate { get; set; }
    public override string ToString()
    {
        return $"Id : {Id}, CardId : {CardId}, Description : {Description}, MaintenanceDate : {MaintenanceDate}, Cost : {Cost}";
    }
}
