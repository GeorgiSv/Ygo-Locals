namespace YgoLocals.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using YgoLocals.Core.EntityServices.Deck;
    using YgoLocals.Data.Entities;
    using YgoLocals.Models.Deck;

    public class DeckController : BaseController
    {
        private readonly IDeckService _deckService;
        private readonly UserManager<User> _userManager;

        public DeckController(IDeckService deckService, UserManager<User> userManager)
        {
            _deckService = deckService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userDecks = await _deckService.GetAllByUserAsync(_userManager.GetUserId(User));

            return View(userDecks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeckInputModel input)
        {
            var deckId = await _deckService.CreateAsync(_userManager.GetUserId(User), input.Name);

            return RedirectToAction(nameof(Index));
        }
    }
}
