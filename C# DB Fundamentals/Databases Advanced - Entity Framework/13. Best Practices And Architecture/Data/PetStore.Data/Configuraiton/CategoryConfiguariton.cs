namespace PetStore.Data.Configuraiton
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Data.Models;

    class CategoryConfiguariton : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.HasMany(c => c.Food)
                .WithOne(f => f.Category)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            category.HasMany(c => c.Toys)
               .WithOne(t => t.Category)
               .HasForeignKey(t => t.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

            category.HasMany(c => c.Pets)
               .WithOne(p => p.Category)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
