using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthApp.Models;

namespace SimpleAuthApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        HomeIndexViewModel model = new HomeIndexViewModel();

        if (User.Identity is { IsAuthenticated: true })
        {
            string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IdentityUser? user = id != null ? await _userManager.FindByIdAsync(id) : null;
            model.IsAuthenticated = true;
            model.UserId = id;
            model.UserName = user?.UserName;
            model.Email = user?.Email;
        }

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
