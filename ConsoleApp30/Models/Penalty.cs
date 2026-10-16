namespace ConsoleApp30.Models;

public class Penalty
{
    public int Id { get; set; }
    public int RentalId { get; set; }
    public string Reason { get; set; } = null!;
    public bool IsPaid { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}, Reason : {Reason}, Is Paid : {IsPaid}";
    }
}
