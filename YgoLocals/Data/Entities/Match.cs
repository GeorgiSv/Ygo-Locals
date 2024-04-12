namespace YgoLocals.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using YgoLocals.Data.Entities.Base;

    public class Match : BaseDeletableEntity<string>
    {
        [Required]
        public string PlayerrOneId { get; set; }

        public User PlayerOne { get; set; }

        [Required]
        public string PlayerrTwoId { get; set; }

        public User PlayerTwo { get; set; }

        public string WinnerId { get; set; }

        public User Winner { get; set; }

        public int TournamnetId { get; set; }

        public Tournament TournamentId { get; set; }
    }
}
