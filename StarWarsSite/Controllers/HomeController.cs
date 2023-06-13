using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWarsSite.Models;
using StarWarsSite.Domain;
using StarWarsSite.Models;
using System.Diagnostics;
using Azure;

namespace StarWarsSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext context;
        public HomeController(ILogger<HomeController> logger, AppDbContext AppContext)
        {
            _logger = logger;
            context = AppContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Cards.ToListAsync());
        }

        public IActionResult AddCharacter()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            return View(context.Cards.FirstOrDefault(x => x.Id == id));
        }

        public IActionResult Character(Guid id)
        {
            return View(context.Cards.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Card card)
        {
            context.Cards.Add(card);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Card card)
        {
            if (card.Id == default)
                context.Entry(card).State = EntityState.Added;
            else
                context.Entry(card).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            Card card = context.Cards.FirstOrDefault(card => card.Id == id);
            context.Remove(card);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}