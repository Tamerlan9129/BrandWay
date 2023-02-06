﻿using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }








    }
}
