using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NopeBotProject.Core.Abstraction;
using NopeBotProject.Infrastructure.Data.Entities;

namespace NopeBotProject.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessagesController(IMessageService messageService, UserManager<ApplicationUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User)!;
            var messages = await _messageService.GetAllAsync(userId);
            return View(messages);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserId = _userManager.GetUserId(User)!;
                message.ReceivedAt = DateTime.UtcNow;
                await _messageService.CreateAsync(message);
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }
    }
}
