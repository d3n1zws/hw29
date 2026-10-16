using ConsoleApp30.Enums;

namespace ConsoleApp30.Models;

public class Payment
{
    public int Id { get; set; }
    public int RentalId { get; set; }
    public Rental Rental { get; set; }
    public int Amount { get; set; }
    public DateOnly PaymentDate { get; set; }
    public PaymentType PaymentType { get; set; }
    public override string ToString()
    {
        return $"Id : {Id}, RentalId : {RentalId}, Amount : {Amount}, Payment Date : {PaymentDate}, Payment Type : {PaymentType}";
    }
}

