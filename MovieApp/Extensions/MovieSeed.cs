using Microsoft.EntityFrameworkCore;
using MovieApp.Enums;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Extensions
{
    public static class MovieSeed
    {
        public static void Seed(this ModelBuilder model)
        {
            model.Entity<MovieModel>().HasData(
                new MovieModel()
                {
                    Id = 1,
                    Title = "Spider man",
                    Duration = "120",
                    Subtitle = (MovieSubtitle)1,
                    Language = (MovieLanguage)3,
                    ReleaseDate = new DateTime(),
                    Type = (MovieType)1
                },
                new MovieModel()
                {
                    Id = 2,
                    Title = "Transformer",
                    Duration = "140",
                    Subtitle = (MovieSubtitle)3,
                    Language = (MovieLanguage)3,
                    ReleaseDate = new DateTime(),
                    Type = (MovieType)2
                }
            );
        }
    }
}
