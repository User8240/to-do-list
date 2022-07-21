using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {

      // (pretend this category exists) Category newCategory = new Category("Work");

      Dictionary<string, object> model = new Dictionary<string, object>();

      // model = { }

      Category selectedCategory = Category.Find(id);

      // selectedCategory (if id was 1) = 
      // newCategory {
      //   Name: "Work"
      //   Id: 1
      //   Items: { newItem }
      // } 

      List<Item> categoryItems = selectedCategory.Items;

      //categoryItems = { newItem }

      model.Add("category", selectedCategory);

      // model { {"category", newCategory} }

      model.Add("items", categoryItems);

      // model { {"category", newCategory}, {"items", categoryItems} }

      return View(model);
    }
  }
} 