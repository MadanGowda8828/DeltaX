namespace DeltaX.Models
{
    /// <summary>
    /// Movie Class
    /// </summary>
    public class Movie
    {
        public string Name { get; set; }
        public string Plot { get; set; }
        public string Date { get; set; }
        public int Producer { get; set; }
        //comma seperated Actors IDs
        public string Actors { get; set; }
        public IFormFile Poster { get; set; }
    }
}
