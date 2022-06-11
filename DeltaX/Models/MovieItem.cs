using NPOI.SS.Formula.Functions;

namespace DeltaX.Models
{
    /// <summary>
    /// Movie Item
    /// </summary>
    public class MovieItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public string Date { get; set; }
        public string Producer { get; set; }
        public List<ActorItem> Actors { get; set; }
        public string PosterName { get; set; }
        public Byte[] PosterData { get; set; }
    }
    public class ActorItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
