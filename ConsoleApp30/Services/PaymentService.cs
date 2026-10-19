
using ConsoleApp30.Contexts;
using ConsoleApp30.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp30.Services;

public static class PaymentService
{
    public static void Create(int rentalId, int amount)
    {
        using (var context = new AppDbContext())
        {
            if (amount <= 0)
            {
                throw new Exception("Odenis sifirdan boyuk olmalidi");
            }
            var rental = context.Rentals.FirstOrDefault(r => r.Id == rentalId);
            if (rental == null)
            {
                throw new Exception("Rental tapilmadi");
            }
            int totalPaid = context.Payments
                .Where(p => p.RentalId == rentalId)
                .Sum(p => p.Amount);

            if (amount > rental.TotalPrice - totalPaid)
            {
                throw new Exception("Odenis qalan borcdan cox ola bilmez");
            }
            var payment = new Payment
            {
                RentalId = rentalId,
                Amount = amount,
                PaymentDate = DateOnly.FromDateTime(DateTime.Now)
            };
            context.Payments.Add(payment);
            context.SaveChanges();
        }
    }
    public static void ReadByRentalId(int rentalId)
    {
        using (var context = new AppDbContext())
        {
            var payments = context.Payments
                .Where(p => p.RentalId == rentalId)
                .ToList();

            foreach (var payment in payments)
            {
                Console.WriteLine(payment.ToString());
            }
        }
    }
}
