namespace YgoLocals.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using YgoLocals.Data.Entities.Base;

    public class Match : BaseDeletableEntity<string>
    {
        public Match()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string PlayerOneId { get; set; }

        public User PlayerOne { get; set; }

        public string? PlayerTwoId { get; set; }

        public User PlayerTwo { get; set; }

        public string? WinnerId { get; set; }

        public User Winner { get; set; }

        public int? TournamentId { get; set; }

        public virtual Tournament? Tournament { get; set; }
    }
}
