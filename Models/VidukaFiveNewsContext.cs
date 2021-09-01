using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VidukaFiveNews.Models;

namespace VidukaFiveNews.Repositories
{
    public class VidukaFiveNewsContext : DbContext
    {


        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        }

    }
}
