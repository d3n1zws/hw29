using ConsoleApp30.Contexts;
using ConsoleApp30.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ConsoleApp30.Services;

public static class CarService
{
    public static async Task Create(string brand, string model, string plateNumber, int dailyPrice, int year, int mileage, bool isAvailable)
    {
        using (var context = new AppDbContext())
        {
            var car = new Models.Car
            {
                Brand = brand,
                Model = model,
                PlateNumber = plateNumber,
                DailyPrice = dailyPrice,
                Year = year,
                Mileage = mileage,
                IsAvailable = isAvailable
            };
            context.Cars.Add(car);
            await context.SaveChangesAsync();
        }
    }
    public static void Read()
    {
        using (var context = new AppDbContext())
        {
            var cars = context.Cars.ToList();
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
    public static async Task Update(int carId, string brand, string model, string plateNumber, int dailyPrice, int year, int mileage, bool isAvailable)
    {
        using (var context = new AppDbContext())
        {
            var car = context.Cars.Find(carId);
            if (car != null)
            {
                car.Brand = brand;
                car.Model = model;
                car.PlateNumber = plateNumber;
                car.DailyPrice = dailyPrice;
                car.Year = year;
                car.Mileage = mileage;
                car.IsAvailable = isAvailable;
                await context.SaveChangesAsync();
            }
        }
    }
    public static async Task Delete(int carId)
    {
        using (var context = new AppDbContext())
        {
            var car = context.Cars.Find(carId);
            if (car != null)
            {
                context.Cars.Remove(car);
            }
            await context.SaveChangesAsync();
        }
    }
    public static void FindCarByModel(string model)
    {
        using (var context = new AppDbContext())
        {
            var cars = context.Cars
                .Where(c => c.Model == model)
                .ToList();
            foreach(var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
    public static void FindCarByPrice(int min, int max)
    {
        using (var context = new AppDbContext())
        {
            var cars = context.Cars
                .Where(c => c.DailyPrice >= min)
                .ToList();
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
