namespace Football.Models.Footballs
{
    using Data;
    using System.ComponentModel.DataAnnotations;
    using Validations;

    public class CreateTactics
    {
        [Required]
        [MaxLength(50)]
        public string TacticName { get; set; }

        [Required]
        public string Formation { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public PlayerPosition PlayerPosition { get; set; }

        [Required]
        //[ScaffoldColumn(false)]
        public string Description { get; set; }

        [Url]
        [ImageValidations]
        public string Image { get; set; }

        public string Id { get; set; }
    }
}