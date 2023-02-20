﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {

        List<Burger> burgerList = new List<Burger>()
        {
            new Burger() {Name = "Cheeseburger", Calories = 461},
            new Burger() {Name = "Fish Burger", Calories = 431},
            new Burger() {Name = "Veggie Burger", Calories = 420},
            new Burger() {Name = "NoBurger", Calories = 0}
        };

        [Route("api/j1/menu/{burger}/{drink}/{side}/{desert}")]
        [HttpGet]
        public int Menu(int burger, int drink, int side, int desert)
        {
            return burgerList[burger].Calories;
        }
    }

    public class Burger
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }
}

// I Googled how to create list of objects with name/value pair.
// I continued to refine my search until I found a pattern that
// I thought I could use to represent the problem I am trying to solve
// even though I dod not really understand it.
// https://csharp.net-tutorials.com/collections/lists/