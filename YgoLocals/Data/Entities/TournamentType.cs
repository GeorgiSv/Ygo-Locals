namespace YgoLocals.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using YgoLocals.Data.Entities.Base;

    public class TournamentType : BaseDeletableEntity<int>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
