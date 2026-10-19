
using ConsoleApp30.Contexts;
using ConsoleApp30.Exceptions;
using ConsoleApp30.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp30.Services;

public static class MaintenanceService
{
    public static async Task Create(int carId, string description, DateOnly maintenanceDate, int cost, DateOnly nextMaintenanceDate)
    {
        using (var context = new AppDbContext())
        {
            var car = await context.Cars.FirstOrDefaultAsync(c => c.Id == carId);

            if (car == null)
            {
                throw new CarNotFoundException("Avtomobil tapilmadi.");
            }
            var maintenance = new MaintenanceRecord
            {
                CarId = carId,
                Description = description,
                MaintenanceDate = maintenanceDate,
                Cost = cost,
                NextMaintenanceDate = nextMaintenanceDate
            };

            context.MaintenanceRecords.Add(maintenance);

            await context.SaveChangesAsync();
        }
    }
    public static void ReadHistory(int carId)
    {
        using (var context = new AppDbContext())
        {
            var car = context.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null)
            {
                throw new CarNotFoundException("Avtomobil tapilmadi");
            }
            var records = context.MaintenanceRecords.Where(m => m.CarId == carId).OrderByDescending(m => m.MaintenanceDate).ToList();
            foreach (var record in records)
            {
                Console.WriteLine(record.ToString());
            }
        }
    }
    public static void ReadUpcoming(int days)
    {
        using (var context = new AppDbContext())
        {
            if (days < 0)
            {
                throw new Exception("Gun sayi menfi ola bilmez");
            }
            var today = DateOnly.FromDateTime(DateTime.Now);
            var limitDate = today.AddDays(days);
            var records =  context.MaintenanceRecords
                .Include(m => m.Car)
                .Where(m => m.NextMaintenanceDate >= today && m.NextMaintenanceDate <= limitDate)
                .OrderBy(m => m.NextMaintenanceDate)
                .ToList();

            foreach (var record in records)
            {
                Console.WriteLine(record.ToString());
            }
        }
    }
    public static int GetTotalCost(int carId)
    {
        using (var context = new AppDbContext())
        {
            var car = context.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null)
            {
                throw new Exception("Avtomobil tapilmadi");
            }
            int totalCost =  context.MaintenanceRecords
                .Where(m => m.CarId == carId)
                .Sum(m => m.Cost);

            return totalCost;
        }
    }
}
