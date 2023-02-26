namespace BlazorVinyls.Server.Data
{
    public class Vinyl
    {
        public int UniqueId { get; set; }
        public string? AlbumName { get; set; }
        public string? ArtistFName { get; set; }
        public string? ArtistLName { get; set; }
        public string? ComingSoon { get; set; }
        public string? ImageUrl { get; set; }
        public string? Review { get; set; }
        public DateTime InsertedDate { get; set; }

    }
}
