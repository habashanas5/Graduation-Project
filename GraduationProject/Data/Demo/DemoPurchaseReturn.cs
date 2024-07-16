using GraduationProject.Applications.GoodsReceives;
using GraduationProject.Applications.InventoryTransactions;
using GraduationProject.Applications.NumberSequences;
using GraduationProject.Applications.PurchaseReturns;
using GraduationProject.Applications.Warehouses;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Enums;

namespace GraduationProject.Data.Demo
{
    public static class DemoPurchaseReturn
    {
        public static async Task GenerateAsync(IServiceProvider services)
        {
            var purchaseReturnService = services.GetRequiredService<PurchaseReturnService>();
            var goodsReceiveService = services.GetRequiredService<GoodsReceiveService>();
            var warehouseService = services.GetRequiredService<WarehouseService>();
            var numberSequenceService = services.GetRequiredService<NumberSequenceService>();
            var inventoryTransactionService = services.GetRequiredService<InventoryTransactionService>();
            Random random = new Random();
            int purchaseReturnStatusLength = Enum.GetNames(typeof(ManufacturingReturnStatus)).Length;

            var goodsReceives = goodsReceiveService
                .GetAll()
                .Where(x => x.Status >= GoodsReceiveStatus.Completed)
                .ToList();

            var warehouses = warehouseService
                .GetAll()
                .Where(x => x.IsDefault == false)
                .Select(x => x.Id)
                .ToArray();

            foreach (var goodsReceive in goodsReceives)
            {
                bool process = random.Next(2) == 0;

                if (process)
                {
                    continue;
                }

                var purchaseReturn = new PurchaseReturn
                {
                    Number = numberSequenceService.GenerateNumber(nameof(PurchaseReturn), "", "PRN"),
                    ReturnDate = goodsReceive.ReceiveDate?.AddDays(random.Next(1, 5)),
                    Status = (ManufacturingReturnStatus)random.Next(0, purchaseReturnStatusLength),
                    GoodsReceiveId = goodsReceive.Id,
                };
                await purchaseReturnService.AddAsync(purchaseReturn);

                var items = inventoryTransactionService
                    .GetAll()
                    .Where(x => x.ModuleId == goodsReceive.Id && x.ModuleName == nameof(GoodsReceive))
                    .ToList();

                foreach (var item in items)
                {
                    var inventoryTransaction = new InventoryTransaction
                    {
                        ModuleId = purchaseReturn.Id,
                        ModuleName = nameof(PurchaseReturn),
                        ModuleCode = "PRN",
                        ModuleNumber = purchaseReturn.Number,
                        MovementDate = purchaseReturn.ReturnDate!.Value,
                        Status = (InventoryTransactionStatus)purchaseReturn.Status,
                        Number = numberSequenceService.GenerateNumber(nameof(InventoryTransaction), "", "IVT"),
                        WarehouseId = DbInitializer.GetRandomValue(warehouses, random),
                        ProductId = item.ProductId,
                        Movement = item.Movement
                    };

                    inventoryTransactionService.CalculateInvenTrans(inventoryTransaction);
                    await inventoryTransactionService.AddAsync(inventoryTransaction);
                }


            }

        }
    }
}
