using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private readonly List<Ski> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public SkiRental(string name, int capacity )
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }

        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(p => p.Manufacturer == manufacturer && p.Model == model );
            if (ski == null)
            {
                return false;
            }

            data.Remove(ski);
            return true;
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(p => p.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(p => p.Manufacturer == manufacturer && p.Model == model);

            return ski;

        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
