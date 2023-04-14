﻿using _02_EFC_CodeFirst.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
}