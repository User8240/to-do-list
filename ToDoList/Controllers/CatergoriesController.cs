using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
        private readonly ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    public ActionResult Edit(int id)
    {
        var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
        return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
        _db.Entry(category).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
        return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
        _db.Categories.Remove(thisCategory);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Category thisCategory= _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }
    //-------------------------------------------------------------------------
    // [HttpGet("/categories")]
    // public ActionResult Index()
    // {
    //   List<Category> allCategories = Category.GetAll();
    //   return View(allCategories);
    // }

    // [HttpGet("/categories/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }

    // [HttpPost("/categories")]
    // public ActionResult Create(string categoryName)
    // {
    //   Category newCategory = new Category(categoryName);
    //   return RedirectToAction("Index");
    // }

    // [HttpGet("/categories/{id}")]
    // public ActionResult Show(int id)
    // {

    //   // (pretend this category exists) Category newCategory = new Category("Work");

    //   Dictionary<string, object> model = new Dictionary<string, object>();

    //   // model = { }

    //   Category selectedCategory = Category.Find(id);

    //   // selectedCategory (if id was 1) = 
    //   // newCategory {
    //   //   Name: "Work"
    //   //   Id: 1
    //   //   Items: { newItem }
    //   // } 

    //   List<Item> categoryItems = selectedCategory.Items;

    //   //categoryItems = { newItem }

    //   model.Add("category", selectedCategory);

    //   // model { {"category", newCategory} }

    //   model.Add("items", categoryItems);

    //   // model { {"category", newCategory}, {"items", categoryItems} }

    //   return View(model);
    // }

    // [HttpPost("/categories/{categoryId}/items")]
    // public ActionResult Create(int categoryId, string itemDescription)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category foundCategory = Category.Find(categoryId);
    //   Item newItem = new Item(itemDescription);
    //   newItem.Save();    // New code
    //   foundCategory.AddItem(newItem);
    //   List<Item> categoryItems = foundCategory.Items;
    //   model.Add("items", categoryItems);
    //   model.Add("category", foundCategory);
    //   return View("Show", model);
    // }
  }
} 