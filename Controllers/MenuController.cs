using Microsoft.AspNetCore.Mvc;
using Akile.Models;
using Akile.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Akile.Controllers;

public class MenuController : Controller
{
    private readonly ILogger<MenuController> _logger;
    private readonly IInventory<Item, int> _inventory;

    public MenuController(ILogger<MenuController> logger, IInventory<Item, int> inventory)
    {
        _logger = logger;
        _inventory = inventory;
    }

    public IActionResult Index()
    {
        return View(_inventory.List());
    }

    [Authorize]
    public IActionResult Details(int Id)
    {
        var item = _inventory.Find(i => i.Id == Id).FirstOrDefault();
        return View(item);
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Item item)
    {
        if (ModelState.IsValid)
        {
            _inventory.Create(item);
            return RedirectToAction("Index");
        }
        return View();
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
        return View(_inventory.GetById(id));
    }

    // POST: MenuController/Edit/5
    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Item item)
    {
        try
        {
            _inventory.Update(item);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    [Authorize]
    public ActionResult Delete(int id)
    {
        var item = _inventory.GetById(id);
        return View(item);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Delete(Item item)
    {
        try
        {
            _inventory.Delete(item);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
}
