namespace ConsoleApp30.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string PlateNumber { get; set; } = null!;
    public int DailyPrice { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
    public bool IsAvailable { get; set; }
    public override string ToString()
    {
        return $"Id : {Id}, Brand : {Brand}, Model : {Model}, PlateNumber: {PlateNumber}, DailyPrice : {DailyPrice}, Year : {Year}, Mileage: {Mileage}, Is Avaliable : {IsAvailable}";
    }
}
