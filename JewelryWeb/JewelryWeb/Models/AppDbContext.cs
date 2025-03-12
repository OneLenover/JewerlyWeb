using Microsoft.EntityFrameworkCore;

namespace JewelryWeb.Models
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр
        /// </summary>
        /// <param name="options">Параметры конфигурации для контекста базы данных</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>Модель товаров</summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>Модель категорий</summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>Модель материалов</summary>
        public DbSet<Material> Materials { get; set; }
        /// <summary>Модель закупок</summary>
        public DbSet<Purchase> Purchases { get; set; }
        /// <summary>Модель поставщиков</summary>
        public DbSet<Supplier> Suppliers { get; set; }
        /// <summary>Модель отзывов</summary>
        public DbSet<Review> Reviews { get; set; }
        /// <summary>Модель клиентов</summary>
        public DbSet<Client> Clients { get; set; }
        /// <summary>Модель заказов</summary>
        public DbSet<Order> Orders { get; set; }
        /// <summary>Модель платежей</summary>
        public DbSet<Payment> Payments { get; set; }
        /// <summary>Модель типа платежей</summary>
        public DbSet<TypePayment> TypesPayment { get; set; }
        /// <summary>Можель элементов зазаза</summary>
        public DbSet<OrderElements> OrdersElements { get; set; }
        /// <summary>Модель пользователей</summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Настройка моделей и связей в бд
        /// </summary>
        /// <param name="modelBuilder">Построитель моделей</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(o => o.TotalCost).HasColumnType("numeric(18,2)");
            modelBuilder.Entity<OrderElements>().Property(o => o.Price).HasColumnType("numeric(18,2)");
            modelBuilder.Entity<Payment>().Property(p => p.TotalPayment).HasColumnType("numeric(18,2)");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("numeric(18,2)");
            modelBuilder.Entity<Purchase>().Property(p => p.Price).HasColumnType("numeric(18,2)");
            // Category
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnType("varchar(100)");
            modelBuilder.Entity<Category>().Property(c => c.Description).HasColumnType("text");
            // Client
            modelBuilder.Entity<Client>().Property(c => c.FirstName).HasColumnType("varchar(100)");
            modelBuilder.Entity<Client>().Property(c => c.LastName).HasColumnType("varchar(100)");
            modelBuilder.Entity<Client>().Property(c => c.PhoneNumber).HasColumnType("varchar(20)");
            // Material
            modelBuilder.Entity<Material>().Property(m => m.Name).HasColumnType("varchar(200)");
            modelBuilder.Entity<Material>().Property(m => m.Description).HasColumnType("text");
            // Order
            modelBuilder.Entity<Order>().Property(o => o.Address).HasColumnType("text");
            // Product
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar(255)");
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("text");
            // Review
            modelBuilder.Entity<Review>().Property(r => r.Comment).HasColumnType("text");
            // Supplier
            modelBuilder.Entity<Supplier>().Property(s => s.Name).HasColumnType("varchar(255)");
            modelBuilder.Entity<Supplier>().Property(s => s.PhoneNumber).HasColumnType("varchar(20)");
            modelBuilder.Entity<Supplier>().Property(s => s.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<Supplier>().Property(s => s.Address).HasColumnType("text");
            // User
            modelBuilder.Entity<User>().Property(c => c.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<User>().Property(c => c.PasswordHash).HasColumnType("text");

            modelBuilder.Entity<Order>().Property(o => o.Status).HasConversion<string>();
            modelBuilder.Entity<TypePayment>().Property(t => t.Type).HasConversion<string>();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Material)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payments)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.TypePayment)
                .WithMany(t => t.Payments)
                .HasForeignKey(p => p.TypePaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderElements>()
                .HasOne(e => e.Order)
                .WithMany(o => o.OrdersElements)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderElements>()
                .HasOne(e => e.Product)
                .WithMany(p => p.OrdersElements)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Purchases)
                .HasForeignKey(p => p.SupplierId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Product)
                .WithMany(pr => pr.Purchases)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.User)
                .WithOne(u => u.Client)
                .HasForeignKey<Client>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
