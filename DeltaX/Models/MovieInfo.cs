namespace DeltaX.Models
{
    //Details of Movie
    public class MovieInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public string Date { get; set; }
        public int Producer { get; set; }
        //comma seperated Actors IDs
        public string Actors { get; set; }
        public string PosterName { get; set; }
        public Byte[] PosterData { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
