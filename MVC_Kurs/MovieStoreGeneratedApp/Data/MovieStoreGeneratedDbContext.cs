using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieStoreGeneratedApp.Models;

namespace MovieStoreGeneratedApp.Data
{
    public class MovieStoreGeneratedDbContext : DbContext
    {
        public MovieStoreGeneratedDbContext (DbContextOptions<MovieStoreGeneratedDbContext> options)
            : base(options)
        {
        }

        public DbSet<MovieStoreGeneratedApp.Models.Movie>? Movie { get; set; }
        public DbSet<MovieStoreGeneratedApp.Models.Actor>? Actors { get; set; }

        public DbSet<MovieStoreGeneratedApp.Models.Regisseur>? Regisseurs { get; set; }
    }
}
