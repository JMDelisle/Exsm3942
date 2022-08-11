using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClassroomStart.Models;

namespace ClassroomStart.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Accounttype> Accounttypes { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=csharp2_assignment_jeanmarc", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("PRIMARY");

                entity.ToTable("account");

                entity.HasIndex(e => e.AccClientId, "acc_client_id");

                entity.HasIndex(e => e.AccTypeId, "acc_type_id");

                entity.Property(e => e.AccId)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_id");

                entity.Property(e => e.AccBalance)
                    .HasPrecision(5, 2)
                    .HasColumnName("acc_balance");

                entity.Property(e => e.AccClientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_client_id");

                entity.Property(e => e.AccInterestapplieddate)
                    .HasColumnType("datetime")
                    .HasColumnName("acc_interestapplieddate");

                entity.Property(e => e.AccTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_type_id");


                entity.HasOne(d => d.AccClient)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_ibfk_1");

                entity.HasOne(d => d.AccType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_ibfk_2");

                entity.HasData(
                    new Account[]
                    {
                    new Account() { AccId = 1, AccClientId = 1, AccTypeId = 1, AccBalance = 80000.00m, AccInterestapplieddate = new DateTime(2020, 08, 16) },

                  //  new Account() { AccId = 2, AccClientId = 2, AccTypeId = 2, AccBalance = 80000.00m, AccInterestapplieddate = new DateTime(2020, 08, 16) },

                 //  new Account() { AccId = 3, AccClientId = 3, AccTypeId = 3, AccBalance = 80000.00m, AccInterestapplieddate = new DateTime(2020, 08, 16) },

                  //  new Account() { AccId = 4, AccClientId = 4, AccTypeId = 4, AccBalance = 80000.00m, AccInterestapplieddate = new DateTime(2020, 08, 16) },

                   // new Account() { AccId = 5, AccClientId = 5, AccTypeId = 5, AccBalance = 80000.00m, AccInterestapplieddate = new DateTime(2020, 08, 16) },

                 //  new Account() { AccId = 6, AccClientId = 6, AccTypeId = 6, AccBalance = 80000.00m, AccInterestapplieddate = new DateTime(2020, 08, 16) },

                   // new Account() { AccId = 7, AccClientId = 7, AccTypeId = 7, AccBalance = 80000.00m, AccInterestapplieddate = new DateTime(2020, 08, 16) }
                     });
            });

            modelBuilder.Entity<Accounttype>(entity =>
            {
                entity.HasKey(e => e.AtId)
                    .HasName("PRIMARY");

                entity.ToTable("accounttype");

                entity.Property(e => e.AtId)
                    .HasColumnType("int(11)")
                    .HasColumnName("at_id");

                entity.Property(e => e.AtInterestrate)
                    .HasPrecision(5, 2)
                    .HasColumnName("at_interestrate");

                entity.Property(e => e.AtName)
                    .HasMaxLength(50)
                    .HasColumnName("at_name");

                entity.HasData(
                    new Accounttype[]
                    {
                        new Accounttype() { AtId = 1, AtName = "Standard Saving", AtInterestrate = 0.75m}
                    });
            });





            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PRIMARY");

                entity.ToTable("client");

                entity.Property(e => e.CId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("c_id");

                entity.Property(e => e.CBirthdate)
                    .HasColumnName("c_birthdate");

                entity.Property(e => e.CFirstname)
                    .HasMaxLength(50)
                    .HasColumnName("c_firstname");

                entity.Property(e => e.CHomeaddress)
                    .HasMaxLength(255)
                    .HasColumnName("c_homeaddress");

                entity.Property(e => e.CLastname)
                    .HasMaxLength(50)
                    .HasColumnName("c_lastname");

                entity.HasOne(d => d.CIdNavigation)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_ibfk_1");

                entity.HasData(
                   new Client[]
                   {
                        new Client() { CId = 1, CFirstname = "Jorge", CLastname = "Smith", CBirthdate = new DateTime (1968, 12, 31), CHomeaddress = "123 Applewood Way"},
                        new Client() { CId = 2, CFirstname = "Zac", CLastname = "Ingram", CBirthdate = new DateTime (1968, 12, 31), CHomeaddress = "123 Applewood Way"},
                        new Client() { CId = 3, CFirstname = "Charles", CLastname = "Sheen", CBirthdate = new DateTime (1968, 12, 31), CHomeaddress = "123 Applewood Way"},
                        new Client() { CId = 4, CFirstname = "Callie", CLastname = "Whittington", CBirthdate = new DateTime (1968, 12, 31), CHomeaddress = "123 Applewood Way"}

                   });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
