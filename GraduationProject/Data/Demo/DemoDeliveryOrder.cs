using GraduationProject.Applications.DeliveryOrders;
using GraduationProject.Applications.InventoryTransactions;
using GraduationProject.Applications.NumberSequences;
using GraduationProject.Applications.SalesOrderItems;
using GraduationProject.Applications.SalesOrders;
using GraduationProject.Applications.Warehouses;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Data.Demo
{
    public static class DemoDeliveryOrder
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var deliveryOrderService = services.GetRequiredService<DeliveryOrderService>();
            var salesOrderService = services.GetRequiredService<SalesOrderService>();
            var salesOrderItemService = services.GetRequiredService<SalesOrderItemService>();
            var warehouseService = services.GetRequiredService<WarehouseService>();
            var numberSequenceService = services.GetRequiredService<NumberSequenceService>();
            var inventoryTransactionService = services.GetRequiredService<InventoryTransactionService>();
            Random random = new Random();
            int deliveryOrderStatusLength = Enum.GetNames(typeof(DeliveryOrderStatus)).Length;

            var salesOrders = salesOrderService
                .GetAll()
                .Where(x => x.OrderStatus >= SalesOrderStatus.Confirmed)
                .ToList();

            var warehouses = warehouseService
                .GetAll()
                .Where(x => x.IsDefault == false)
                .Select(x => x.Id)
                .ToArray();

            var deliveryCompanies = services.GetRequiredService<DbContext>()
               .Set<DeliveryCompany>()
               .ToList();

            foreach (var salesOrder in salesOrders)
            {
                int deliveryCompanyId = deliveryCompanies[random.Next(deliveryCompanies.Count)].Id;

                var deliveryOrder = new DeliveryOrder
                {
                    Number = numberSequenceService.GenerateNumber(nameof(DeliveryOrder), "", "DO"),
                    DeliveryDate = salesOrder.OrderDate?.AddDays(random.Next(1, 5)),
                    Status = (DeliveryOrderStatus)random.Next(0, deliveryOrderStatusLength),
                    SalesOrderId = salesOrder.Id,
                    DeliveryCompanyId = deliveryCompanyId
                };
                await deliveryOrderService.AddAsync(deliveryOrder);

                var items = salesOrderItemService
                    .GetAll()
                    .Include(x => x.Product)
                    .Where(x => x.SalesOrderId == salesOrder.Id && x.Product!.Physical == true).ToList();

                foreach (var item in items)
                {
                    var inventoryTransaction = new InventoryTransaction
                    {
                        ModuleId = deliveryOrder.Id,
                        ModuleName = nameof(DeliveryOrder),
                        ModuleCode = "DO",
                        ModuleNumber = deliveryOrder.Number,
                        MovementDate = deliveryOrder.DeliveryDate!.Value,
                        Status = (InventoryTransactionStatus)deliveryOrder.Status,
                        Number = numberSequenceService.GenerateNumber(nameof(InventoryTransaction), "", "IVT"),
                        WarehouseId = DbInitializer.GetRandomValue(warehouses, random),
                        ProductId = item.ProductId,
                        Movement = item.Quantity!.Value
                    };

                    inventoryTransactionService.CalculateInvenTrans(inventoryTransaction);
                    await inventoryTransactionService.AddAsync(inventoryTransaction);
                }


            }

        }
    }
}
