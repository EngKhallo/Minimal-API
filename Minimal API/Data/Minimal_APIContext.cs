using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minimal_API;
using Minimal_API.Models;

namespace Minimal_API.Data
{
    public class Minimal_APIContext : DbContext
    {
        public Minimal_APIContext (DbContextOptions<Minimal_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Minimal_API.SuperHero>? SuperHero { get; set; }

        public DbSet<Minimal_API.Models.Author>? Author { get; set; }

        public DbSet<Minimal_API.Models.Book>? Book { get; set; }

        public DbSet<Minimal_API.Models.Book_Author>? Book_Author { get; set; }
    }
}
