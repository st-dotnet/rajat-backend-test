﻿using Angular_CRUD_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRUD_Test.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
