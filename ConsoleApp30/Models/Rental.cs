namespace ConsoleApp30.Models;

public class Rental
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly ExpectedReturnDate { get; set; }
    public DateOnly ActualReturnDate { get; set; }
    public int TotalPrice { get; set; }
    public int DailyPrice { get; set; }
    public Car Car { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public override string ToString()
    {
        return $"Id : {Id}, CarId : {CarId}, CustomerId : {CustomerId}, StartDate : {StartDate}, ExpectedReturnDate : {ExpectedReturnDate}, ActualReturnDate : {ActualReturnDate}, Total Price : {TotalPrice}, DailyPrice : {DailyPrice}";
    }
}
