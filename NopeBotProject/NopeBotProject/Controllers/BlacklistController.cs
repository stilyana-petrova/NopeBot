using Microsoft.AspNetCore.Mvc;
using NopeBotProject.Core.Abstraction;
using NopeBotProject.Infrastructure.Data.Entities;

namespace NopeBotProject.Controllers
{
    public class BlacklistController : Controller
    {
        private readonly IBlacklistService _service;

        public BlacklistController(IBlacklistService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(BlacklistEntry entry)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(entry);
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entry = await _service.GetByIdAsync(id);
            return entry == null ? NotFound() : View(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlacklistEntry entry)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(entry);
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _service.GetByIdAsync(id);
            return entry == null ? NotFound() : View(entry);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
