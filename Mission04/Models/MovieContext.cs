using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission04.Models
{
    public class MovieContext : DbContext
    {

        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public string Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                    new Category { categoryid = 1, categoryname = "Action/Adventure"},
                    new Category { categoryid = 2, categoryname = "Comedy" },
                    new Category { categoryid = 3, categoryname = "Drama" },
                    new Category { categoryid = 4, categoryname = "Family" },
                    new Category { categoryid = 5, categoryname = "Horror/Suspense" },
                    new Category { categoryid = 6, categoryname = "Miscellaneous" },
                    new Category { categoryid = 7, categoryname = "Television" },
                    new Category { categoryid = 8, categoryname = "VHS" }
                );


            mb.Entity<MovieResponse>().HasData(
                // pre-fill the database with movies
                // P.S. If you haven't seen these, you should really make time for them
                new MovieResponse
                {
                    MovieId = 1,
                    title = "The Count of Monte Cristo",
                    Categoryid = 1,
                    year = 2002,
                    director = "Kevin Reynolds",
                    rating = "PG-13",
                    edited = false,
                    lentto = "",
                    notes = "One of the best movies ever made"
                },
                new MovieResponse
                {
                    MovieId = 2,
                    title = "The Adventure of Robin Hood",
                    Categoryid = 1,
                    year = 1938,
                    director = "Michael Curtis",
                    rating = "PG",
                    edited = false,
                    lentto = "",
                    notes = "One of the best movies ever made"
                },
                new MovieResponse
                {
                    MovieId = 3,
                    title = "Inception",
                    Categoryid = 1,
                    year = 2010,
                    director = "Christopher Nolan",
                    rating = "PG-13",
                    edited = false,
                    lentto = "",
                    notes = "One of the best movies ever made"
                }

            );
        }

        //internal void SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}

        //internal void add(MovieResponse mr)
        //{
        //    throw new NotImplementedException();
        //}
    }
    }
