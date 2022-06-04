using MovieApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required field")]
        public string Title { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MovieSubtitle Subtitle { get; set; }
        public MovieLanguage Language { get; set; }
        public MovieType Type { get; set; }

    }
}
