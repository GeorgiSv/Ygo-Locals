using YgoLocals.Data.Entities.Base;

namespace YgoLocals.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Deck : BaseDeletableEntity<string>
    {
        public Deck()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
