namespace Football.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Football
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength (50)]
        public string TacticName { get; set; }

        [Required]
        public string Formation { get; set; }

        [Required]
        public PlayerPosition PlayerPosition { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
        public string FullName { get; internal set; }
    }
}