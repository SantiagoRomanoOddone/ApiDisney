using ApiDisney.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDisney.Data
{
    public class DisneyDbContext : DbContext
    {
        public DisneyDbContext(DbContextOptions<DisneyDbContext> options) : base(options) { }
        public DbSet<Character> Characters  { get; set; }
        public DbSet <User> Users { get; set; }
    }
}
