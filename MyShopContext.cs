using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopDbLibNew
{
    public partial class MyShopContext : DbContext
    {
        IConfiguration _config;
        public MyShopContext()
        {
        }

        public MyShopContext(DbContextOptions<MyShopContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
            Database.SetCommandTimeout(300);
            // Database.EnsureDeleted();  //03.13.20
            Database.EnsureCreated();
        }

        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Katalog> Katalog { get; set; }
        public virtual DbSet<Nomenclature> Nomenclature { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductNomenclature> ProductNomenclature { get; set; }
        public virtual DbSet<TypeProduct> TypeProduct { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_config["ConnectStringLocal"]);
            //  var connectString=Configuration["ConnectStringDocker"];  
            //Startup.GetConnetionStringDB());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Path)
                    .HasName("path_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId)
                    .HasName("fk_Image_Product1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned zerofill")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ImageNavigation)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Image_Product1");
            });

            modelBuilder.Entity<Katalog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Nomenclature>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Markup)
                    .HasColumnName("markup")
                    .HasComment("торговая наценка");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.KatalogId)
                    .HasName("fk_Nomenclature_Katalog1_idx");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TypeProductId)
                    .HasName("fk_Product_TypeProduct1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.KatalogId).HasColumnName("Katalog_id");

                entity.Property(e => e.Markup)
                    .HasColumnName("markup")
                    .HasComment("торговая наценка");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeProductId).HasColumnName("TypeProduct_id");

                entity.HasOne(d => d.Katalog)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.KatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Nomenclature_Katalog1");

                entity.HasOne(d => d.TypeProduct)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.TypeProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Product_TypeProduct1");
            });

            modelBuilder.Entity<ProductNomenclature>(entity =>
            {
                entity.HasIndex(e => e.NomenclatureId)
                    .HasName("fk_ProductNomenclature_Nomenclature1_idx");

                entity.HasIndex(e => e.ProductId)
                    .HasName("fk_ProductNomenclature_Product1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NomenclatureId).HasColumnName("Nomenclature_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.Nomenclature)
                    .WithMany(p => p.ProductNomenclature)
                    .HasForeignKey(d => d.NomenclatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProductNomenclature_Nomenclature1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductNomenclature)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProductNomenclature_Product1");
            });

            modelBuilder.Entity<TypeProduct>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        //  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        //Здесь инициалицируем  БД (субд)  начальными данными  
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            OnModelKatalogCreating(modelBuilder);
            OnModelAuthCreating(modelBuilder);
            OnModelTypeProductCreating(modelBuilder);
        }

        private void OnModelKatalogCreating(ModelBuilder modelBuilder)
        {



            var kagalog = new Katalog[]{
        new Katalog {Id=1,Name="Камод"},
         new Katalog{Id=2,Name="Кровать"},
          new Katalog{Id=3,Name="Шкаф"},
          new Katalog{Id=4,Name="Кухонный Уголок"},
          new Katalog{Id=5,Name="Стол Обеденный"} ,
          new Katalog{Id=6,Name="Стол Писменный"},
          new Katalog{Id=7,Name="Стол Журнальный"},
          new Katalog{Id=8,Name="Стол Маникюрный"},
          new Katalog{Id=9,Name="Стол Тумба"},
          new Katalog{Id=10,Name="Гномик"},
          new Katalog{Id=11,Name="Комплектующие"}

            };

            //  Console.WriteLine("Create -----------      ProductType()---------- Start->");

            modelBuilder.Entity<Katalog>().HasData(kagalog);
            base.OnModelCreating(modelBuilder);
        }

         private void OnModelTypeProductCreating(ModelBuilder modelBuilder){


             var typeProduct=new TypeProduct[]{
                 new TypeProduct{Id=1,Name="All",Description=""},
                 new TypeProduct{Id=2,Name="ЛДСП",Description=""},
                 new TypeProduct{Id=3,Name="МДФ",Description=""}
             };
             modelBuilder.Entity<TypeProduct>().HasData(typeProduct);
             base.OnModelCreating(modelBuilder);

         }

        //  при создании бд  создается admin 
        private void OnModelAuthCreating(ModelBuilder modelBuilder)
        {

            var initObject = _config.GetSection("Users");
            var admin = initObject.GetSection("Admin");
            var user = initObject.GetSection("User");
            string adminEmail = admin["Email"];// ";
            string adminPassword = admin["Password"];
            string userEmail = user["Email"]; //  "user@mail.ru";
            string userPassword = user["Password"];// "";
            string userPhone = user["Phone"];// "+79181111111";
            string userName = "user";

            // добавляем роли

            User adminUser = new User
            {
                Id = 1,
                Email = adminEmail,
                Password = adminPassword,
                Role = Role.Admin,
                Name = admin["Name"]
            ,
                Address = "",
                Phone = admin["Phone"]
            };
            User user1 = new User
            {
                Id = 2,
                Email = userEmail,
                Password = userPassword,
                Name = userName,
                Role = Role.User,
                Address = "",
                Phone = userPhone
            };
            // modelBuilder.Entity<User>().Property(u=>u.Role).HasDefaultValue(Role.User);

            modelBuilder.Entity<User>().HasData(new User[] { adminUser, user1 });
            base.OnModelCreating(modelBuilder);


        }
    }
}
