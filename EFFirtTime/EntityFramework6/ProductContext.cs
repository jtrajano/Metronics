using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EntityFramework.Patterns.Extensions;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework6.Repository
{
    public class ProductContext:DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> Categories { get; set; }
        public virtual DbSet<AuditableEntity> AuditableEntities { get; set; }
        public virtual DbSet<ArchiveableEntity> ArchivableEntities { get; set; }
        public ProductContext()
        {
            Database.SetInitializer<ProductContext>(null);
        }
        
        
    }
    class TestDropStategy : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            ProductCategory pcat = new ProductCategory { Name = "Bike" };
            new List<ProductCategory>
            {
                pcat,
                new ProductCategory{Name = "To be deleted"}
            }.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();
            base.Seed(context);
        }
    }

    public partial class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage="*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
    public partial class Product { 
    
    }
    public partial class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Auditable]
    public class AuditableEntity
    {
        public int Id { get; set; }
        public string Color { get; set; }
    }
    [Archivable]
    public class ArchiveableEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }




}
