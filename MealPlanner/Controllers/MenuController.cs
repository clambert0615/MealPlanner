﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MealPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Controllers
{
    public class MenuController : Controller
    {
        private readonly MealPlannerDbContext _context;
        public MenuController(MealPlannerDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult AddMeals(List<Menu> itemList)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                foreach (Menu i in itemList)
                {
                    _context.Menu.Add(new Menu { UserId = userid, MealDate = i.MealDate, Item = i.Item, Meal = i.Meal, Calories =  i.Calories, Quantity = i.Quantity });
                }
                _context.SaveChanges();  
            }
            return RedirectToAction("ListMeals");
        }
        [Authorize]
        public IActionResult ListMeals()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Menu user = _context.Menu.FirstOrDefault(x => x.UserId == userid);
            if (user != null)
            {
                var userMeals = _context.Menu.Where(x => x.UserId == userid).ToList();
                return View(userMeals);
            }
            else
            {
                return RedirectToAction("ErrorPage");
            }
        }
        [Authorize]
        public IActionResult UpdateQuantity(int itemId, int quantity)
        {
            Menu item = _context.Menu.Find(itemId);
            if(quantity == 0)
            {
                _context.Menu.Remove(item);
                _context.SaveChanges();
            }
            if(item != null && quantity > 0)
            {
                item.Quantity = quantity;
                _context.Entry(item).State = EntityState.Modified;
                _context.Update(item);
                _context.SaveChanges();
            }
            return RedirectToAction("ListMeals");
        }
    }
}
