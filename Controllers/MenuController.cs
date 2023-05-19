using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Akile.Models;
using Akile.Identity.Data;
using Akile.Services;

namespace Akile.Controllers;

public class MenuController : Controller
{
    private readonly ILogger<MenuController> _logger;
    private readonly IService<Item, long> _service;

    public MenuController(ILogger<MenuController> logger, IService<Item, long> service)
    {
        _logger = logger;
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.List());
    }

    public IActionResult Details(int Id)
    {
        var item = _service.Find(i => i.Id == Id).FirstOrDefault();
        return View(item);
    }

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
            _service.Create(item);
            return RedirectToAction("Index");
        }
        return View();
    }
}
