using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private readonly List<Ingredient> ingrdiends;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel
        {
            get
            {
                int currAlcoholLevel = 0;
                foreach (var item in ingrdiends)
                {
                    currAlcoholLevel += item.Alcohol;
                }
                return currAlcoholLevel;
            }

        }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingrdiends = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (!ingrdiends.Contains(ingredient)
                && Capacity > ingrdiends.Count 
                && (CurrentAlcoholLevel + ingredient.Alcohol) <= MaxAlcoholLevel)
            {
                ingrdiends.Add(ingredient);
                
            }

        }

        public bool Remove(string name)
        {
            Ingredient ingredients = ingrdiends.FirstOrDefault(i => i.Name == name);

            if (ingredients == null)
            {
                return false;
            }

            ingrdiends.Remove(ingredients);
            return true;
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredients = ingrdiends.FirstOrDefault(i => i.Name == name);


            return ingredients;

        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingrdiends.OrderByDescending(i => i.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in ingrdiends)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
