namespace YgoLocals.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using YgoLocals.Core.EntityServices.Deck;
    using YgoLocals.Core.EntityServices.Tournament;
    using YgoLocals.Data.Entities;
    using YgoLocals.Models.Tournament;

    public class TournamentController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly ITournamentService _tournamentService;
        private readonly IDeckService _deckService;

        public TournamentController(UserManager<User> userManager, ITournamentService tournamentService, IDeckService deckService)
        {
            _userManager = userManager;
            _tournamentService = tournamentService;
            _deckService = deckService;
        }

        public async Task<IActionResult> Index()
        {
            var avaiableToJoinTournaments = await _tournamentService.GetAllAvaiableToJoinAsync();
            return View(avaiableToJoinTournaments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BaseTournamentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var tournamentId = await _tournamentService
                .CreateAsync(_userManager.GetUserId(User),
                input.MaxPeopleCount,
                (int)input.TournamentType);

            return RedirectToAction(nameof(Details), new { id = tournamentId});
        }

        public async Task<IActionResult> Details(int id)
        {
            var tournament = await _tournamentService.GetByIdAsync(id);
            return View(tournament);
        }

        [HttpPost]
        public async Task<IActionResult> Start(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var tournamentId = await _tournamentService.StartAsync(id, _userManager.GetUserId(User));
            return RedirectToAction(nameof(Details), new { id = tournamentId });
        }

        public async Task<IActionResult> Join(int id)
        {
            var tournament = await _tournamentService.GetByIdAsync(id);
            var decks = await _deckService.GetAllByUserAsync(_userManager.GetUserId(User));

            var joinViewModel = new JoinViewModel()
            {
                TournamentId = tournament.Id,
                Tournament = tournament,
                Decks = decks.Select(d => new SelectListItem(d.Name, d.Id)).ToList(),
            };

            return View(joinViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Join(JoinInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await _tournamentService.JoinPlayerAsync(input.TournamentId, _userManager.GetUserId(User), input.SelectedDeckId);

            return RedirectToAction(nameof(Details), new { id = input.TournamentId });
        }
    }
}
