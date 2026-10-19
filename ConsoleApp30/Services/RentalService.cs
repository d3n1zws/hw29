
using ConsoleApp30.Contexts;
using ConsoleApp30.Exceptions;
using ConsoleApp30.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp30.Services;

public static class RentalService
{
    public static async Task Create(int carId, int customerId, DateOnly startDate, DateOnly expectedReturnDate)
    {
        using (var context = new AppDbContext())
        {

            if (startDate < DateOnly.FromDateTime(DateTime.Now) || expectedReturnDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new InvalidRentalDateException("Tarixler kecmise duse bilmez");
            }
            if (startDate >= expectedReturnDate)
            {
                throw new InvalidRentalDateException("Baslangic tarixi qaytarilma tarixinden evvel olmalidir");
            }
            var car = await context.Cars.FirstOrDefaultAsync(c => c.Id == carId);
            if (car == null)
            {
                throw new CarNotFoundException("Avtomobil tapilmadi");
            }
            if (!car.IsAvailable)
            {
                throw new CarNotFoundException("Avtomobil aktiv deyil");
            }
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                throw new CustomerNotFoundException("Musteri tapilmadi");
            }

            if (customer.LicenseExpiryDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new LicenseExpiredException("Suruculuk vesigesinin muddeti bitib");
            }
            bool check = await context.Rentals.AnyAsync(r => r.CarId == carId && r.StartDate < expectedReturnDate && r.ExpectedReturnDate > startDate);
            if (check)
            {
                throw new CarAlreadyReservedException("Avtomobil bu tarixlerde artiq rezerv edilib");
            }
            var rental = new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                StartDate = startDate,
                ExpectedReturnDate = expectedReturnDate,
                DailyPrice = car.DailyPrice
            };
            await context.Rentals.AddAsync(rental);
            await context.SaveChangesAsync();
        }
    }

    public static async Task ReturnCar(int rentalId)
    {
        using (var context = new AppDbContext())
        {
            var rental = await context.Rentals.FirstOrDefaultAsync(r => r.Id == rentalId);
            if (rental == null)
            {
                throw new Exception("Rental tapilmadi");
            }
            if (rental.ActualReturnDate != default)
            {
                throw new RentalAlreadyCompletedException("Avtomobil artiq qaytarilib");
            }
            if (DateOnly.FromDateTime(DateTime.Now) < rental.StartDate)
            {
                throw new InvalidRentalDateException("Rental hele baslamayib");
            }
            await context.SaveChangesAsync();
        }
    }

    public static async Task Cancel(int rentalId)
    {
        using (var context = new AppDbContext())
        {
            var rental = await context.Rentals.FirstOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null)
            {
                throw new Exception("Icare tapilmadi");
            }
            context.Rentals.Remove(rental);
            await context.SaveChangesAsync();
        }
    }
}
