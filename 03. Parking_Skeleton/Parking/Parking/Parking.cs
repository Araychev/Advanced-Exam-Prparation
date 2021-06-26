using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private readonly List<Car> cars;

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => cars.Count;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            cars = new List<Car>();
        }

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model) 
        {
            Car car = cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (car == null)
            {
                return false;
            }

            cars.Remove(car);
            return true;
        }

        public Car GetLatestCar() 
        {
            Car car = cars.OrderByDescending(c=>c.Year).FirstOrDefault();

            return car;
        }

        public Car GetCar(string manufacturer, string model) 
        {
            Car car = cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return car;
        }

        public string GetStatistics() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var item in cars)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }



    }
}
