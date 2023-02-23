using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        // create list of burger objects
        public class Burger
        {
            public string Name { get; set; }
            public int Calories { get; set; }
        }

        List<Burger> burgerList = new List<Burger>()
        {
            new Burger() {Name = "Cheeseburger", Calories = 461},
            new Burger() {Name = "Fish Burger", Calories = 431},
            new Burger() {Name = "Veggie Burger", Calories = 420},
            new Burger() {Name = "NoBurger", Calories = 0}
        };

        // create list of drink objects
        public class Drink
        {
            public string Name { get; set; }
            public int Calories { get; set; }
        }

        List<Drink> drinkList = new List<Drink>()
        {
            new Drink() {Name = "Soft Drink", Calories = 130},
            new Drink() {Name = "Orange Juice", Calories = 160},
            new Drink() {Name = "Milk", Calories = 118},
            new Drink() {Name = "No Drink", Calories = 0}
        };

        // create list of side order objects
        public class SideOrder
        {
            public string Name { get; set; }
            public int Calories { get; set; }
        }

        List<SideOrder> sideOrderList = new List<SideOrder>()
        {
            new SideOrder() {Name = "Fries", Calories = 100},
            new SideOrder() {Name = "Baked Potato", Calories = 57},
            new SideOrder() {Name = "Chef Salad", Calories = 70},
            new SideOrder() {Name = "No Side Order", Calories = 0}
        };

        // create list of dessert objects
        public class Dessert
        {
            public string Name { get; set; }
            public int Calories { get; set; }
        }

        List<Dessert> dessertList = new List<Dessert>()
        {
            new Dessert() {Name = "Apple Pie", Calories = 167},
            new Dessert() {Name = "Apple Pie", Calories = 266},
            new Dessert() {Name = "Apple Pie", Calories = 75},
            new Dessert() {Name = "Apple Pie", Calories = 0}

        };

        /// <summary>
        /// computes the total Calories of a meal.
        /// <example>/api/J1/Menu/4/4/4/4 -> Your total calorie count is 0</example>
        /// </summary>
        /// <param name="burger">Integer representing the index burger choice</param>
        /// <param name="drink">Integer representing the index drink choice</param>
        /// <param name="side">Integer representing the index side choice</param>
        /// <param name="dessert">Integer representing the index dessert choice</param>
        /// <returns>A string message of calorie count</returns>
        [Route("api/j1/menu/{burger}/{drink}/{side}/{dessert}")]
        [HttpGet]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            int totalCalories = burgerList[burger - 1].Calories + drinkList[drink - 1].Calories + sideOrderList[side - 1].Calories + dessertList[dessert - 1].Calories;
            return "Your total calorie count is " + totalCalories;
        }
    }
}

// I Googled how to create list of objects with name/value pair.
// I continued to refine my search until I found a pattern that
// I thought I could use to represent the problem I am trying to solve
// even though I dod not really understand it.
// https://csharp.net-tutorials.com/collections/lists/

