using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HamroDailySales.Data;
using Daily_Sales.Models;

namespace HamroDailySales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataBaseObject _db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _db = new DataBaseObject();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sales()
        {
            return View("DailySales", new Sale());
        }

        [HttpPost]
        public async Task<IActionResult> Sales(Daily_Sales.Models.Sale sale)
        {
            if (sale == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid sale data. Please check your input.");
                return View("DailySales", sale ?? new Sale());
            }

            bool check = await _db.SaveItem(sale);
            if (check)
            {
                TempData["SuccessMessage"] = "Sale saved successfully!";
                return RedirectToAction("AllSales");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to save the sale. Please try again.";
                return View("DailySales", sale);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AllSales()
        {
            try
            {
                var sales = await _db.TotallSales();
                return View("TotallSales", sales ?? new List<Daily_Sales.Models.Sale>());
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("error.log", $"{DateTime.Now}: AllSales error: {ex.Message}\n");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
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

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}