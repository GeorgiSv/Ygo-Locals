namespace YgoLocals.Models.Tournament
{
    using System.ComponentModel.DataAnnotations;
    using YgoLocals.Data.Entities.Enums;

    public class BaseTournamentInputModel
    {
        [Required]
        public int MaxPeopleCount { get; set; }

        [Required]
        public TournamentTypeEnum TournamentType { get; set; }
    }
}
