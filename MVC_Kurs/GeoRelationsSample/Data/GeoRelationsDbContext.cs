using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoRelationsSample.Models;

namespace GeoRelationsSample.Data
{
    public class GeoRelationsDbContext : DbContext
    {
        public GeoRelationsDbContext (DbContextOptions<GeoRelationsDbContext> options)
            : base(options)
        {
        }

        public DbSet<GeoRelationsSample.Models.Continent> Continents { get; set; }
        public DbSet<GeoRelationsSample.Models.Country> Countries { get; set; }
        public DbSet<GeoRelationsSample.Models.Language> Languages { get; set; }
        public DbSet<GeoRelationsSample.Models.LanguageInCountry> LanguageInCountries { get; set; }
    }
}
