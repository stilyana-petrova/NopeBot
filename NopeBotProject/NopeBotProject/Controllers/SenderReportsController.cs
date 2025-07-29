using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NopeBotProject.Core.Abstraction;
using NopeBotProject.Infrastructure.Data.Entities;

namespace NopeBotProject.Controllers
{
    public class SenderReportsController : Controller
    {
        private readonly ISenderReportService _reportService;
        private readonly IBlacklistService _blacklistService;
        private readonly UserManager<ApplicationUser> _userManager;

        public SenderReportsController(
            ISenderReportService reportService,
            IBlacklistService blacklistService,
            UserManager<ApplicationUser> userManager)
        {
            _reportService = reportService;
            _blacklistService = blacklistService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User)!;
            var reports = await _reportService.GetAllAsync(userId);
            return View(reports);
        }

        public async Task<IActionResult> Create(int blacklistEntryId)
        {
            var entry = await _blacklistService.GetByIdAsync(blacklistEntryId);
            if (entry == null) return NotFound();

            ViewBag.BlacklistEntry = entry;
            return View(new SenderReport { BlacklistEntryId = blacklistEntryId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SenderReport report)
        {
            if (ModelState.IsValid)
            {
                report.UserId = _userManager.GetUserId(User)!;
                await _reportService.CreateAsync(report);
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }
    }
}
