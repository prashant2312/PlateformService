﻿using Microsoft.EntityFrameworkCore;
using PlateformService.Models;

namespace PlateformService.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<Plateform> Plateforms { get; set; }
    }
}
