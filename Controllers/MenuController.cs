using Microsoft.AspNetCore.Mvc;
using Akile.Models;
using Akile.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Akile.Controllers;

public class MenuController : Controller
{
    private readonly ILogger<MenuController> _logger;
    private readonly IInventory<Item, long> _inventory;

    public MenuController(ILogger<MenuController> logger, IInventory<Item, long> inventory)
    {
        _logger = logger;
        _inventory = inventory;
    }

    public IActionResult Index()
    {
        return View(_inventory.List());
    }

    public IActionResult Details(int Id)
    {
        var item = _inventory.Find(i => i.Id == Id).FirstOrDefault();
        return View(item);
    }

    [Authorize]
    [HttpGet]
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
}
