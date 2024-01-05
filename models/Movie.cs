using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


namespace models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; } = "Movie";
        
        public DateTime ? ReleaseDate { get; set; }
        
        public string? Genre { get; set; } = "Action";
        public string? Cast { get; set; }
        public string? Lang { get; set; }
        public float? Rating { get; set; } = 9;
        public string? TreailerURL { get; set; } = "youtube.com";
    }
}