using ConsoleApp30.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp30.Services;

public static class CustomerService
{
    public static async Task Create(string fullName, string email, string drivingLicenseNumber, DateOnly licenseExpiryDate)
    {
        using (var context = new AppDbContext())
        {
            if (context.Customers.Any(c => c.Email == email))
            {
                throw new Exception("eyni email tekrarlana bilmez");
            }
            if (context.Customers.Any(c => c.DrivingLicenseNumber == drivingLicenseNumber))
            {
                throw new Exception("eyni Driving License Number tekrarlana bilmez");
            }
            if (licenseExpiryDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new Exception("vaxti kecib");
            }
            var customer = new Models.Customer
            {
                FullName = fullName,
                Email = email,
                DrivingLicenseNumber = drivingLicenseNumber,
                LicenseExpiryDate = licenseExpiryDate
            };
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
        }
    }
    public static void Read()
    {
        using (var context = new AppDbContext())
        {
            var customers = context.Customers.ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }
    }
    public static async Task Update(int customerId, string fullName, string email, string drivingLicenseNumber, DateOnly licenseExpiryDate)
    {
        using (var context = new AppDbContext())
        {
            var customer = context.Customers.Find(customerId);
            if (customer != null)
            {
                customer = new Models.Customer
                {
                    FullName = fullName,
                    Email = email,
                    DrivingLicenseNumber = drivingLicenseNumber,
                    LicenseExpiryDate = licenseExpiryDate
                };
                await context.SaveChangesAsync();
            }
        }
    }
    public static async Task Delete(int Id)
    {
        using (var context = new AppDbContext())
        {
            var customer = context.Customers.Find(Id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
            }
            await context.SaveChangesAsync();
        }
    }
    public static void ShowRentalsById(int Id)
    {
        using (var context = new AppDbContext())
        {
            var customer = context.Customers.Find(Id);
            if (customer != null)
            {
                var rentals = customer.Rentals;
                foreach (var rental in rentals)
                {
                    Console.WriteLine(rental.ToString());
                }
            }
        }
    }
}
