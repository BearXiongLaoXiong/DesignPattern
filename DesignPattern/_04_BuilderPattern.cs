using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesignPattern._04_Builder
{
    [DataContract(Name = "建造者模式")]
    public class _04_BuilderPattern
    {
        public static void Run()
        {
            Console.WriteLine(typeof(_04_BuilderPattern).GetClassName());

            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.ShowItems();
            Console.WriteLine($"Total Cost:{vegMeal.GetCost()}");

            Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            Console.WriteLine("NonVeg Meal");
            nonVegMeal.ShowItems();
            Console.WriteLine($"Total Cost:{nonVegMeal.GetCost()}");

            Console.WriteLine();
        }
    }

    public interface Packing { string Pack(); }

    public class Wrapper : Packing { public string Pack() => "Wrapper"; }

    public class Bottle : Packing { public string Pack() => "Bottle"; }

    public interface IItem
    {
        string Name();
        Packing Packing();
        float Price();
    }

    public abstract class Burger : IItem
    {
        public virtual string Name() => "";
        public Packing Packing() => new Wrapper();
        public abstract float Price();
    }

    public abstract class ColdDrink : IItem
    {
        public string Name() => "";
        public Packing Packing() => new Bottle();
        public abstract float Price();
    }

    public class VegBurger : Burger
    {
        public override float Price() => 25.0f;

        public new string Name() => "Veg Burger";
    }

    public class ChickenBurger : Burger
    {
        public override float Price() => 50.0f;

        public new string Name() => "Chicken Burger";
    }


    public class Coke : ColdDrink
    {
        public override float Price() => 30.0f;

        public new string Name() => "Coke";
    }

    public class Pepsi : ColdDrink
    {
        public override float Price() => 35.0f;

        public new string Name() => "Pepsi";
    }


    public class Meal
    {
        private List<IItem> items = new List<IItem>();

        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        /// <summary>
        /// get费用
        /// </summary>
        /// <returns></returns>
        public float GetCost()
        {
            float cost = 0.0F;
            foreach (var item in items)
                cost += item.Price();
            return cost;
        }

        public void ShowItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Item:{item.Name()},Packing:{item.Packing().Pack()},Price:{item.Price()}");
            }
        }
    }

    public class MealBuilder
    {
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());
            return meal;
        }
        public Meal PrepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());
            return meal;
        }
    }
}
