﻿using Abby.Models;
using Microsoft.EntityFrameworkCore;

namespace Abby.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<FoodType>? FoodTypes { get; set; }
    }
}
