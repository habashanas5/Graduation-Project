using GraduationProject.Infrastructures.Docs;
using GraduationProject.Models.Configurations;
using GraduationProject.Models.Entities;
using GraduationProject.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GraduationProject.Infrastructures.Images;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GraduationProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileImage> FileImages { get; set; } = default!;
        public DbSet<FileDocument> FileDocument { get; set; } = default!;
        public DbSet<AdjustmentMinus> AdjustmentMinus { get; set; } = default!;
         public DbSet<AdjustmentPlus> AdjustmentPlus { get; set; } = default!;
         public DbSet<Company> Company { get; set; } = default!;
         public DbSet<CustomerGroup> CustomerGroup { get; set; } = default!;
         public DbSet<CustomerCategory> CustomerCategory { get; set; } = default!;
         public DbSet<CustomerContact> CustomerContact { get; set; } = default!;
         public DbSet<Customer> Customer { get; set; } = default!;
         public DbSet<DeliveryOrder> DeliveryOrder { get; set; } = default!;
         public DbSet<GoodsReceive> GoodsReceive { get; set; } = default!;
         public DbSet<InventoryTransaction> InventoryTransaction { get; set; } = default!;
         public DbSet<LogSession> LogSession { get; set; } = default!;
         public DbSet<LogError> LogError { get; set; } = default!;
         public DbSet<LogAnalytic> LogAnalytic { get; set; } = default!;
         public DbSet<NumberSequence> NumberSequence { get; set; } = default!;
         public DbSet<Product> Product { get; set; } = default!;
         public DbSet<ProductGroup> ProductGroup { get; set; } = default!;
         public DbSet<ManufacturingOrdersTable> PurchaseOrder { get; set; } = default!;
         public DbSet<ManufacturingOrdersItems> PurchaseOrderItem { get; set; } = default!;
         public DbSet<PurchaseReturn> PurchaseReturn { get; set; } = default!;
         public DbSet<SalesOrder> SalesOrder { get; set; } = default!;
         public DbSet<SalesOrderItem> SalesOrderItem { get; set; } = default!;
         public DbSet<SalesReturn> SalesReturn { get; set; } = default!;
         public DbSet<Scrapping> Scrapping { get; set; } = default!;
         public DbSet<StockCount> StockCount { get; set; } = default!;
         public DbSet<TransferIn> TransferIn { get; set; } = default!;
         public DbSet<TransferOut> TransferOut { get; set; } = default!;
         public DbSet<Tax> Tax { get; set; } = default!;
         public DbSet<UnitMeasure> UnitMeasure { get; set; } = default!;
         public DbSet<FactoriesType> FactoryType { get; set; } = default!;
         public DbSet<FactoriesClassification> FactoryClassification { get; set; } = default!;
         public DbSet<Factorys> Factory { get; set; } = default!;
         public DbSet<FactoriesContacts> FactoryContacts { get; set; } = default!;
         public DbSet<Warehouse> Warehouse { get; set; } = default!;
        public DbSet<WarehouseProduct> WarehouseProduct { get; set; } = default!;
        public DbSet<CartItem> CartItem { get; set; } = default!;
        public DbSet<DeliveryCompany> DeliveryCompany { get; set; } = default!;
        public DbSet<SalesReturnProduct> SalesReturnProduct { get; set; } = default!;
        public DbSet<GraduationProject.Models.Entities.GoodsReceiveDetail> GoodsReceiveDetail { get; set; } = default!;
        public DbSet<SalesSummaryByDay> SalesSummaryByDay { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

            builder.Entity<FileImage>().HasKey(f => f.Id);
            builder.Entity<FileImage>().Property(f => f.OriginalFileName).HasMaxLength(100);
            builder.Entity<FileDocument>().HasKey(f => f.Id);
            builder.Entity<FileDocument>().Property(f => f.OriginalFileName).HasMaxLength(100);

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new LogAnalyticConfiguration());
            builder.ApplyConfiguration(new LogErrorConfiguration());
            builder.ApplyConfiguration(new LogSessionConfiguration());
            builder.ApplyConfiguration(new NumberSequenceConfiguration());
            builder.ApplyConfiguration(new CustomerGroupConfiguration());
            builder.ApplyConfiguration(new CustomerCategoryConfiguration());
            builder.ApplyConfiguration(new VendorGroupConfiguration());
            builder.ApplyConfiguration(new VendorCategoryConfiguration());
            builder.ApplyConfiguration(new WarehouseConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new VendorConfiguration());
            builder.ApplyConfiguration(new UnitMeasureConfiguration());
            builder.ApplyConfiguration(new ProductGroupConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CustomerContactConfiguration());
            builder.ApplyConfiguration(new VendorContactConfiguration());
            builder.ApplyConfiguration(new TaxConfiguration());
            builder.ApplyConfiguration(new SalesOrderConfiguration());
            builder.ApplyConfiguration(new SalesOrderItemConfiguration());
            builder.ApplyConfiguration(new PurchaseOrderConfiguration());
            builder.ApplyConfiguration(new PurchaseOrderItemConfiguration());
            builder.ApplyConfiguration(new InventoryTransactionConfiguration());
            builder.ApplyConfiguration(new DeliveryOrderConfiguration());
            builder.ApplyConfiguration(new GoodsReceiveConfiguration());
            builder.ApplyConfiguration(new SalesReturnConfiguration());
            builder.ApplyConfiguration(new PurchaseReturnConfiguration());
            builder.ApplyConfiguration(new TransferInConfiguration());
            builder.ApplyConfiguration(new TransferOutConfiguration());
            builder.ApplyConfiguration(new StockCountConfiguration());
            builder.ApplyConfiguration(new AdjustmentMinusConfiguration());
            builder.ApplyConfiguration(new AdjustmentPlusConfiguration());
            builder.ApplyConfiguration(new ScrappingConfiguration());
            builder.ApplyConfiguration(new DeliveryCompanyConfiguration());

        }
    }
}
