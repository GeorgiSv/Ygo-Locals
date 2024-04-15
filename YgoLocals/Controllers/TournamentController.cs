namespace YgoLocals.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using YgoLocals.Core.EntityServices.Tournament;
    using YgoLocals.Data.Entities;
    using YgoLocals.Models.Tournament;

    public class TournamentController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly ITournamentService _tournamentService;

        public TournamentController(UserManager<User> userManager, ITournamentService tournamentService)
        {
            _userManager = userManager;
            _tournamentService = tournamentService;
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
            var tournamentId = await _tournamentService.StartAsync(id, _userManager.GetUserId(User));
            return RedirectToAction(nameof(Details), new { id = tournamentId });
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(int tournamentId)
        {
            await _tournamentService.AddPlayerAsync(tournamentId, _userManager.GetUserId(User));

            return RedirectToAction(nameof(Details), new { id = tournamentId });
        }
    }
}
