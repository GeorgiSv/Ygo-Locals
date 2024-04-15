namespace YgoLocals.Models.Deck
{
    using System.ComponentModel.DataAnnotations;

    public class DeckInputModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
