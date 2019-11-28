namespace PetStore.Data.Configuraiton
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Data.Models;

    public class ToyOrderConfiguaration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> toyOrder)
        {
            toyOrder
                .HasKey(fo => new { fo.ToyId, fo.OrderId });

            toyOrder
                .HasOne(to => to.Toy)
                .WithMany(t => t.Orders)
                .HasForeignKey(to => to.ToyId)
                .OnDelete(DeleteBehavior.Restrict);

            toyOrder
                .HasOne(to => to.Order)
                .WithMany(o => o.Toys)
                .HasForeignKey(to => to.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
