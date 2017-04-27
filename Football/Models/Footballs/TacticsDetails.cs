namespace Football.Models.Footballs
{

    using Football.Data;


    public class TacticsDetails
    {
       
        public string TacticName { get; set; }

        public string Formation { get; set; }

        public PlayerPosition PlayerPosition { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Id { get; set; }

        public string FullName { get; set; }
    }
}