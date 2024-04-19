namespace YgoLocals.Controllers
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using YgoLocals.Core.EntityServices.Match;
    using YgoLocals.Data.Entities;
    using YgoLocals.Models.Match;

    public class MatchController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly IMatchService _matchService;

        public MatchController(UserManager<User> userManager, IMatchService matchService)
        {
            _userManager = userManager;
            _matchService = matchService;
        }

        public async Task<IActionResult> Index()
        {
            var baseMatchViewModel = new BaseMatchViewModel()
            {
                AvaiableToJoin = await _matchService.GetAllAvaiable(),
                UserActiveMatches = await _matchService.GetAllByUser(_userManager.GetUserId(User)),
            };

            return View(baseMatchViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var matchId = await _matchService.CreateAsync(_userManager.GetUserId(User));

            return RedirectToAction(nameof(Details), new { id = matchId });
        }

        public async Task<IActionResult> Details(string id)
        {
            var match = await _matchService.GetByIdAsync(id);
            return View(match);
        }

        [HttpPost]
        public async Task<IActionResult> Join(string id)
        {
            await _matchService.JoinAsync(id, _userManager.GetUserId(User));
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> End(EndMatchInputModel input)
        {
            await _matchService.EndAsync(input.MatchId, input.WinnerId);
            return RedirectToAction(nameof(Details), new { id = input.MatchId });
        }
    }
}
