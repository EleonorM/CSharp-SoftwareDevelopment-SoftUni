namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using System;

    public class OrderService : IOrderService
    {
        private readonly PetStoreDbContext data;

        public OrderService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void CompleteOrder(int orderId)
        {
            var order = data.Orders.Find(orderId);

            order.OrderStatus = OrderStatus.Done;
            this.data.SaveChanges();
        }
    }
}
