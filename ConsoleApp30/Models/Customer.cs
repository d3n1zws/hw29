namespace ConsoleApp30.Models;

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string DrivingLicenseNumber { get; set; } = null!;
    public DateOnly LicenseExpiryDate { get; set; }
    public override string ToString()
    {
        return $"Id : {Id}, FullName : {FullName}, Email : {Email}, DrivingLicenseNumber : {DrivingLicenseNumber}, LicenseExpiryDate : {LicenseExpiryDate}";
    }
}
