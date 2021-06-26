using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private readonly List<Car> cars;
        private readonly int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }
        public int Count 
        
             => cars.Count;
           
        

        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber) 
        {
            Car car = this.cars.FirstOrDefault(c=>c.RegistrationNumber == registrationNumber);
            if (car== null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            return car;

        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers) 
        {
            cars = cars
                  .Where(c => !registrationNumbers.Contains(c.RegistrationNumber))
                  .ToList();
        }
    }

}
