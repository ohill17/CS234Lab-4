using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MMABooksEFClasses.MarisModels
{
    public partial class MMABooksContext : DbContext
    {
        public MMABooksContext()
        {
        }

        public MMABooksContext(DbContextOptions<MMABooksContext> options)
            : base(options)
        {
        }
        public DbSet<Yeast> Yeasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Yeast entity
            modelBuilder.Entity<Yeast>(entity =>
            {
                entity.ToTable("yeast", "bits"); // Specify table and schema
                entity.HasKey(e => e.IngredientId); // Specify primary key
                                                    // Map other properties
                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.MinTemp).HasColumnName("min_temp");
                entity.Property(e => e.MaxTemp).HasColumnName("max_temp");
                entity.Property(e => e.Form).HasColumnName("form");
                entity.Property(e => e.Laboratory).HasColumnName("laboratory");
                entity.Property(e => e.Flocculation).HasColumnName("flocculation");
                entity.Property(e => e.Attenuation).HasColumnName("attenuation");
                entity.Property(e => e.MaxReuse).HasColumnName("max_reuse");
                entity.Property(e => e.AddToSecondary).HasColumnName("add_to_secondary");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.BestFor).HasColumnName("best_for");
            });
        }
    }

    // Yeast entity class
    public class Yeast
    {
        public int IngredientId { get; set; }
        public int ProductId { get; set; }
        public decimal MinTemp { get; set; }
        public decimal MaxTemp { get; set; }
        public string Form { get; set; }
        public string Laboratory { get; set; }
        public string Flocculation { get; set; }
        public decimal Attenuation { get; set; }
        public int MaxReuse { get; set; }
        public bool AddToSecondary { get; set; }
        public string Type { get; set; }
        public string BestFor { get; set; }
    }
}