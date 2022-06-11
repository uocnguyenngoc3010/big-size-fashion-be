﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BigSizeFashion.Data.Entities
{
    public partial class BigSizeFashionChainContext : DbContext
    {
        public BigSizeFashionChainContext()
        {
        }

        public BigSizeFashionChainContext(DbContextOptions<BigSizeFashionChainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCart> CustomerCarts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<ImportInvoice> ImportInvoices { get; set; }
        public virtual DbSet<ImportInvoiceDetail> ImportInvoiceDetails { get; set; }
        public virtual DbSet<MainWarehouse> MainWarehouses { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<PromotionDetail> PromotionDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreWarehouse> StoreWarehouses { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Account__DD701264152E319B");

                entity.ToTable("Account");

                entity.HasIndex(e => e.Username, "UQ__Account__F3DBC57213CE48DD")
                    .IsUnique();

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__role_id__267ABA7A");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.RecieveAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("recieve_address");

                entity.Property(e => e.RecieverName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("reciever_name");

                entity.Property(e => e.RecieverPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("reciever_phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__custome__2F10007B");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Category1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("category");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.Color1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("color");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Customer__DD7012640CF62DE1");

                entity.ToTable("Customer");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("uid");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Heigth).HasColumnName("heigth");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PinCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("PIN_code");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Weigth).HasColumnName("weigth");

                entity.HasOne(d => d.UidNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__uid__2C3393D0");
            });

            modelBuilder.Entity<CustomerCart>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProductId, e.StoreId })
                    .HasName("PK__Customer__84B71EF978597847");

                entity.ToTable("CustomerCart");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCarts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerC__custo__3F466844");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CustomerCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerC__produ__403A8C7D");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.CustomerCarts)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerC__store__412EB0B6");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(200)
                    .HasColumnName("content");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__custom__31EC6D26");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__produc__32E0915F");
            });

            modelBuilder.Entity<ImportInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK__ImportIn__F58DFD496F35253B");

                entity.ToTable("ImportInvoice");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("approval_date");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("delivery_date");

                entity.Property(e => e.MainWarehouseId).HasColumnName("main_warehouse_id");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("received_date");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("total_price");

                entity.HasOne(d => d.MainWarehouse)
                    .WithMany(p => p.ImportInvoices)
                    .HasForeignKey(d => d.MainWarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportInv__main___5070F446");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ImportInvoices)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportInv__staff__4F7CD00D");
            });

            modelBuilder.Entity<ImportInvoiceDetail>(entity =>
            {
                entity.HasKey(e => new { e.ImportInvoiceId, e.ProductId })
                    .HasName("PK__ImportIn__6E5DF0234401677C");

                entity.ToTable("ImportInvoiceDetail");

                entity.Property(e => e.ImportInvoiceId).HasColumnName("import_invoice_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.ImportInvoice)
                    .WithMany(p => p.ImportInvoiceDetails)
                    .HasForeignKey(d => d.ImportInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportInv__impor__534D60F1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ImportInvoiceDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImportInv__produ__5441852A");
            });

            modelBuilder.Entity<MainWarehouse>(entity =>
            {
                entity.ToTable("MainWarehouse");

                entity.Property(e => e.MainWarehouseId).HasColumnName("main_warehouse_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.NotificationId).HasColumnName("notification_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("message");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__accou__29572725");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("approval_date");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeliveryAddress).HasColumnName("delivery_address");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("delivery_date");

                entity.Property(e => e.PackagedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("packaged_date");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .HasColumnName("payment_method");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("received_date");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("total_price");

                entity.Property(e => e.TotalPriceAfterDiscount)
                    .HasColumnType("money")
                    .HasColumnName("total_price_after_discount");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__customer___440B1D61");

                entity.HasOne(d => d.DeliveryAddressNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__delivery___44FF419A");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Order__staff_id__46E78A0C");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__store_id__45F365D3");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__OrderDet__022945F63D1FFE6B");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.DiscountPrice)
                    .HasColumnType("money")
                    .HasColumnName("discount_price");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__order__49C3F6B7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__produ__4AB81AF0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("product_name");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("supplier_name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__categor__164452B1");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__color_i__182C9B23");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__size_id__173876EA");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImage");

                entity.Property(e => e.ProductImageId).HasColumnName("product_image_id");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.IsReferenceImage).HasColumnName("is_reference_image");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductIm__produ__20C1E124");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotion");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("apply_date");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expired_date");

                entity.Property(e => e.PromotionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("promotion_name");

                entity.Property(e => e.PromotionValue).HasColumnName("promotion_value");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<PromotionDetail>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.PromotionId })
                    .HasName("PK__Promotio__E5C9E8A355FC2873");

                entity.ToTable("PromotionDetail");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PromotionDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Promotion__produ__1CF15040");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionDetails)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Promotion__promo__1DE57479");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.Size1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("size");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StoreAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("store_address");

                entity.Property(e => e.StorePhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("store_phone");
            });

            modelBuilder.Entity<StoreWarehouse>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("PK__StoreWar__E68284D33E23AFAA");

                entity.ToTable("StoreWarehouse");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreWarehouses)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreWare__produ__38996AB5");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreWarehouses)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreWare__store__37A5467C");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Staff__DD701264F4815873");

                entity.ToTable("Staff");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("uid");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Staff__store_id__3C69FB99");

                entity.HasOne(d => d.UidNavigation)
                    .WithOne(p => p.staff)
                    .HasForeignKey<staff>(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Staff__uid__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}